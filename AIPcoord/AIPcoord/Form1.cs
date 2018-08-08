using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIPcoord
{
    public partial class frmMain : Form
    {

        enum OutputType
        {
            IvAc1,
            IVAC2,
            WebEye
        }

        public frmMain()
        {
            InitializeComponent();
        }

        CoordinateList clist = new CoordinateList();

        private void rad_0_Click(object sender, EventArgs e)
        {
            if (rad_0.Checked)
                txt_color.Enabled = true;
            else
                txt_color.Enabled = false;
        }

        int numberOfChar(char haystack, string needle)
        {
            int a = 0;
            foreach (char c in needle)
                if (c == haystack)
                    a++;
            return a;
        }

        void coordinateProcess(OutputType typ)
        {
            clist.Clear();

            switch (typ)
            {
                case OutputType.IvAc1:
                    txt_ivac1.Clear();
                    break;
                case OutputType.IVAC2:
                    txt_ivac2.Clear();
                    break;
                case OutputType.WebEye:
                    txt_webeye.Clear();
                    break;
            }

            int lineId = 0;
            try
            {
                string text = txt_aip.Text;
                text = text.Replace("\r", "");
                text = text.Replace(" - ", "\n");
                text = text.Replace(".", "");
                text = text.Replace("\t", "");

                List<string> list = text.Split('\n').ToList();

                // removing empty lines
                while (list.Contains(string.Empty))
                    list.Remove(string.Empty);

                for (lineId = 0; lineId < list.Count; lineId++)
                {
                    // removing duplicate spaces
                    while (list[lineId].Contains("  "))
                        list[lineId] = list[lineId].Replace("  ", " ");

                    // removing trailing and leading spaces
                    list[lineId] = list[lineId].Trim();
                }

                // integrity-check - whether contains N/S and E/W or not, and whether contains exactly 1 space
                for (lineId = 0; lineId < list.Count; lineId++)
                {
                    // if not a comment
                    if (!list[lineId].StartsWith(";"))
                    {
                        // if contains more than 1 spaces
                        if (numberOfChar(' ', list[lineId]) > 1)
                        {
                            // 3 spaces = ordinary line, 4 spaces = GEO or ARTCC line without its name/color being removed
                            if (numberOfChar(' ', list[lineId]) == 3 || numberOfChar(' ', list[lineId]) == 4)
                            {
                                // IvAc 1 format
                                var array = list[lineId].Split(' ').ToList();

                                // if the first "word" is not coordinate block, remove it
                                // most likely it's a line from the ARTCC segment then
                                if (!array[0].Contains('N') && !array[0].Contains('S'))
                                    array.RemoveAt(0);

                                string lat1 = array[0];
                                string lon1 = array[1];
                                string lat2 = array[2];
                                string lon2 = array[3];

                                // using the first blocks only
                                list[lineId] = string.Format("{0} {1}", lat1, lon1);

                                // if it's the last line, adding the second block to the end of the list
                                if (list.Count == lineId + 1)
                                    list.Add(string.Format("{0} {1}", lat2, lon2));
                            }
                            else
                            {
                                // again something which needs to be commented out
                                var array = list[lineId].Split(' ');
                                list[lineId] = string.Format("{0} {1}", array[0], array[1]);

                                string newline = "";
                                for (int j = 2; j < array.Length; j++)
                                    newline += (newline.Length > 0 ? ' ' + array[j] : "; " + array[j]);
                                list.Insert(lineId + 1, newline);
                            }
                        }

                        if (numberOfChar(' ', list[lineId]) == 0 && list[lineId].Length > 0)
                            list[lineId] = string.Format("; {0}", list[lineId]);

                        if (numberOfChar(' ', list[lineId]) == 1)
                        {
                            var array = list[lineId].Split(' ');
                            if ((array[0].Contains('N') || array[0].Contains('S')) && (array[1].Contains('E') || array[1].Contains('W')))
                            {
                                // so far so good - looks like it's a valid coordinate-pair
                                string lat = array[0];
                                string lon = array[1];
                                bool north = lat.Contains("N");
                                bool east = lon.Contains("E");

                                double latD = 0, latM = 0, latS = 0;
                                double lonD = 0, lonM = 0, lonS = 0;

                                lat = lat.Replace("N", "").Replace("S", "");
                                lon = lon.Replace("E", "").Replace("W", "");

                                // LATITUDE
                                if (lat.Length <= 6)
                                {
                                    // 2 digit decimal
                                    latD = Convert.ToDouble(lat.Substring(0, 2));
                                    lat = lat.Substring(2, lat.Length - 2);
                                }
                                else
                                {
                                    // 3 digits decimal
                                    latD = Convert.ToDouble(lat.Substring(0, 3));
                                    lat = lat.Substring(3, lat.Length - 3);
                                }

                                latM = Convert.ToDouble(lat.Substring(0, 2));
                                lat = lat.Substring(2, lat.Length - 2);

                                latS = Convert.ToDouble(lat.Substring(0, 2));
                                lat = lat.Substring(2, lat.Length - 2);

                                if (lat.Length > 0)
                                    latS = latS + Convert.ToDouble(lat) / 1000;

                                // LONGITUDE
                                lonD = Convert.ToDouble(lon.Substring(0, 3));
                                lon = lon.Substring(3, lon.Length - 3);

                                lonM = Convert.ToDouble(lon.Substring(0, 2));
                                lon = lon.Substring(2, lon.Length - 2);

                                lonS = Convert.ToDouble(lon.Substring(0, 2));
                                lon = lon.Substring(2, lon.Length - 2);

                                if (lon.Length > 0)
                                    lonS = lonS + Convert.ToDouble(lon) / 1000;

                                Coordinate c = new Coordinate();
                                c.SetDMS(latD, latM, latS, north, lonD, lonM, lonS, east);

                                clist.Add(c);
                            }
                            else
                            {
                                // not valid coordinate pair, let's comment it out
                                list[lineId] = string.Format("; {0}", list[lineId]);
                            }
                        }
                    }

                    if (list[lineId].StartsWith(";"))
                    {
                        if (typ == OutputType.IVAC2)
                        {
                            string s = "";
                            for (int j = 0; j < num_tabs.Value; j++)
                                s = s + '\t';

                            s = s + string.Format("<!-- {0} -->", list[lineId].Replace("; ", ""));
                            txt_ivac2.AppendText(s + Environment.NewLine);
                        }
                        else if (typ == OutputType.IvAc1)
                        {
                            string s = "";
                            int spaces = 0;
                            if (rad_11.Checked)
                                spaces = 11;
                            if (rad_26.Checked)
                                spaces = 26;

                            for (int j = 0; j < spaces; j++)
                                s = s + ' ';

                            s = s + list[lineId];

                            txt_ivac1.AppendText(s + Environment.NewLine);
                        }
                    }
                }

                for (int i = 0; i < clist.Count; i++)
                {
                    if (typ == OutputType.IVAC2)
                    {
                        string s = "";
                        for (int j = 0; j < num_tabs.Value; j++)
                            s = s + '\t';

                        s = s + string.Format("<point lat=\"{0}\" lon=\"{1}\" />", clist[i].ToString("IVAC2_lat"), clist[i].ToString("IVAC2_lon"));
                        txt_ivac2.AppendText(s + Environment.NewLine);
                    }
                    else if (typ == OutputType.IvAc1)
                    {
                        string s = "";
                        int spaces = 0;
                        if (rad_11.Checked)
                            spaces = 11;
                        if (rad_26.Checked)
                            spaces = 26;

                        s = s.PadRight(spaces, ' ');

                        if (clist.Count == 1)
                            s = s + clist[i].ToString("IVAC1");
                        else if (clist.Count > i + 1)
                            s = s + string.Format("{0} {1}", clist[i].ToString("IVAC1"), clist[i + 1].ToString("IVAC1"));

                        if (txt_color.Enabled && txt_color.Text.Length > 0)
                            s = s + " " + txt_color.Text;
                        txt_ivac1.AppendText(s + Environment.NewLine);
                    }
                    else if (typ == OutputType.WebEye)
                    {
                        txt_webeye.AppendText(clist[i].ToString("WEBEYE") + Environment.NewLine);
                    }
                }

                txt_aip.Text = "";
                foreach (string s in list)
                    txt_aip.Text += s + "\r\n";

                switch (typ)
                {
                    case OutputType.IvAc1:
                        Clipboard.SetText(txt_ivac1.Text);
                        break;
                    case OutputType.IVAC2:
                        Clipboard.SetText(txt_ivac2.Text);
                        break;
                    case OutputType.WebEye:
                        Clipboard.SetText(txt_webeye.Text);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occured during the conversion." + Environment.NewLine + ex.Message + Environment.NewLine + "Line: " + (lineId + 1).ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ivac2_Click(object sender, EventArgs e)
        {
            coordinateProcess(OutputType.IVAC2);
        }

        private void btn_ivac1_Click(object sender, EventArgs e)
        {
            coordinateProcess(OutputType.IvAc1);
        }

        private void btn_webeye_Click(object sender, EventArgs e)
        {
            coordinateProcess(OutputType.WebEye);
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/donatmarko/ivao-aipcoord");
        }
    }
}
