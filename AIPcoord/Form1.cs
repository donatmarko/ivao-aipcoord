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

                // removing duplicate spaces
                for (lineId = 0; lineId < list.Count; lineId++)
                {
                    while (list[lineId].Contains("  "))
                        list[lineId] = list[lineId].Replace("  ", " ");
                }

                // integrity-check - whether contains N/S and E/W or not, and whether contains exactly 1 space
                for (lineId = 0; lineId < list.Count; lineId++)
                {
                    if (!list[lineId].StartsWith(";"))
                    {
                        if (numberOfChar(' ', list[lineId]) > 1)
                        {
                            var array = list[lineId].Split(' ');
                            list[lineId] = string.Format("{0} {1}", array[0], array[1]);

                            string newline = "";
                            for (int j = 2; j < array.Length; j++)
                                newline += (newline.Length > 0 ? ' ' + array[j] : "; " + array[j]);
                            list.Insert(lineId + 1, newline);
                        }

                        if (numberOfChar(' ', list[lineId]) == 0 && list[lineId].Length > 0)
                            list[lineId] = string.Format("; {0}", list[lineId]);

                        if (numberOfChar(' ', list[lineId]) == 1)
                        {
                            // removing dots - dots are exist if it's an IvAc1 coordinate-pair
                            var array = list[lineId].Replace(".", "").Split(' ');
                            if ((array[0].Contains('N') || array[0].Contains('S')) && (array[1].Contains('E') || array[1].Contains('W')))
                            {
                                // so far so good - looks like it's a valid coordinate-pair
                                string lat = array[0];
                                string lon = array[1];
                                bool north = lat.Contains("N");
                                bool east = lon.Contains("E");

                                int latD = 0, latM = 0, latS = 0, latMS = 0;
                                int lonD = 0, lonM = 0, lonS = 0, lonMS = 0;

                                lat = lat.Replace("N", "").Replace("S", "");
                                lon = lon.Replace("E", "").Replace("W", "");

                                // LATITUDE
                                if (lat.Length <= 6)
                                {
                                    // 2 digit decimal
                                    latD = Convert.ToInt32(lat.Substring(0, 2));
                                    lat = lat.Substring(2, lat.Length - 2);
                                }
                                else
                                {
                                    // 3 digits decimal
                                    latD = Convert.ToInt32(lat.Substring(0, 3));
                                    lat = lat.Substring(3, lat.Length - 3);
                                }

                                latM = Convert.ToInt32(lat.Substring(0, 2));
                                lat = lat.Substring(2, lat.Length - 2);

                                latS = Convert.ToInt32(lat.Substring(0, 2));
                                lat = lat.Substring(2, lat.Length - 2);

                                if (lat.Length > 0)
                                    latMS = Convert.ToInt32(lat);

                                // LONGITUDE
                                lonD = Convert.ToInt32(lon.Substring(0, 3));
                                lon = lon.Substring(3, lon.Length - 3);

                                lonM = Convert.ToInt32(lon.Substring(0, 2));
                                lon = lon.Substring(2, lon.Length - 2);

                                lonS = Convert.ToInt32(lon.Substring(0, 2));
                                lon = lon.Substring(2, lon.Length - 2);

                                if (lon.Length > 0)
                                    lonMS = Convert.ToInt32(lon);

                                Coordinate c = new Coordinate();
                                c.SetDMS(latD, latM, latS + latMS / 1000, north, lonD, lonM, lonS + lonMS / 1000, east);

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

                        s = s + string.Format("<point lat=\"{0}\" lon=\"{1}\" />", c.ToString("IVAC2_lat"), c.ToString("IVAC2_lon"));
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

                        s = s + string.Format("{0} {1}", c.ToString("IVAC1_lat"), c.ToString("IVAC1_lon"));

                        if (txt_color.Enabled && txt_color.Text.Length > 0)
                            s = s + " " + txt_color.Text;

                        txt_ivac1.AppendText(s + Environment.NewLine);
                    }
                    else if (typ == OutputType.WebEye)
                    {
                        txt_webeye.AppendText(c.ToString("WEBEYE") + Environment.NewLine);
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

        private void btn_ivac1_Click_1(object sender, EventArgs e)
        {
            coordinateProcess(OutputType.IvAc1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            coordinateProcess(OutputType.WebEye);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(
                "This tool is created in a few hours to make my life easier while converting path/shape coordinates from eAIP to IVAC2. Later on I added the feature to do the same thing resulting WebEye format." + Environment.NewLine + Environment.NewLine +
                "However the source coordinate format has to be eAIP-style WGS84 format, it MIGHT work with IVAC2 coordinates as source too. Latitude and longitude must be separated by ONE space, and the coordinate pairs must be separated either via newline or dash." + Environment.NewLine + Environment.NewLine +
                "USAGE: insert the source data and press one of the three buttons on the top. Leading tabs can be adjusted for IVAC2, leading spaces and color attribute for IvAc1 format. The output will be moved to the clipboard, so you don't have to Ctrl-C the result manually. Basically that's all. :-)" + Environment.NewLine + Environment.NewLine +
                "Example input data which will work:" + Environment.NewLine +
                "474643N 0190652E - 473720N 0185425E - 473500N 0185300E - 473220N 0185858E - 473055N 0190118E - 473054N 0190159E - 473612N 0190412E - 474615N 0191631E - 474643N 0190652E" + Environment.NewLine + Environment.NewLine +
                "I don't take any responsibility if this tool screws up your origin or result point list. As I stated it had been created from scratch in a couple of hours and doesn't contain any error correction part. If there's a mistake in the input data either it shoots an error message, or does the conversion well or not well." + Environment.NewLine +
                "PS: I used this tool for LHCC, LAAA and LHKR FIRs and it worked well." + Environment.NewLine + Environment.NewLine +
                "Should you have any questions or bugreports, contact me via email or Slack.", "Help or whatever", MessageBoxButtons.OK, MessageBoxIcon.Information
                );
        }
    }
}
