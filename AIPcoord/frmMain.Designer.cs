namespace AIPcoord
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_aip = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_ivac2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_ivac2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.num_tabs = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_ivac1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_color = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rad_26 = new System.Windows.Forms.RadioButton();
            this.rad_11 = new System.Windows.Forms.RadioButton();
            this.rad_0 = new System.Windows.Forms.RadioButton();
            this.btn_ivac1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_webeye = new System.Windows.Forms.TextBox();
            this.btn_webeye = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_help = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_aurora = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rad_decimal = new System.Windows.Forms.RadioButton();
            this.rad_dms_11 = new System.Windows.Forms.RadioButton();
            this.rad_dms_14 = new System.Windows.Forms.RadioButton();
            this.btn_aurora = new System.Windows.Forms.Button();
            this.chk_linesegments = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_tabs)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_aip
            // 
            this.txt_aip.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_aip.Location = new System.Drawing.Point(12, 32);
            this.txt_aip.Multiline = true;
            this.txt_aip.Name = "txt_aip";
            this.txt_aip.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_aip.Size = new System.Drawing.Size(363, 552);
            this.txt_aip.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(8, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "AIP coordinates";
            // 
            // btn_ivac2
            // 
            this.btn_ivac2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_ivac2.Location = new System.Drawing.Point(381, 238);
            this.btn_ivac2.Name = "btn_ivac2";
            this.btn_ivac2.Size = new System.Drawing.Size(49, 42);
            this.btn_ivac2.TabIndex = 7;
            this.btn_ivac2.Text = ">>";
            this.btn_ivac2.UseVisualStyleBackColor = true;
            this.btn_ivac2.Click += new System.EventHandler(this.btn_ivac2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_ivac2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.num_tabs);
            this.groupBox1.Location = new System.Drawing.Point(436, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 157);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IVAC2 point list for <path> element";
            // 
            // txt_ivac2
            // 
            this.txt_ivac2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_ivac2.Location = new System.Drawing.Point(6, 38);
            this.txt_ivac2.Multiline = true;
            this.txt_ivac2.Name = "txt_ivac2";
            this.txt_ivac2.ReadOnly = true;
            this.txt_ivac2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_ivac2.Size = new System.Drawing.Size(431, 108);
            this.txt_ivac2.TabIndex = 8;
            this.txt_ivac2.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Leading tabs:";
            // 
            // num_tabs
            // 
            this.num_tabs.Location = new System.Drawing.Point(381, 12);
            this.num_tabs.Name = "num_tabs";
            this.num_tabs.Size = new System.Drawing.Size(56, 20);
            this.num_tabs.TabIndex = 6;
            this.num_tabs.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_ivac1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_color);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.rad_26);
            this.groupBox2.Controls.Add(this.rad_11);
            this.groupBox2.Controls.Add(this.rad_0);
            this.groupBox2.Location = new System.Drawing.Point(436, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 158);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "IvAc 1 line segments";
            // 
            // txt_ivac1
            // 
            this.txt_ivac1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_ivac1.Location = new System.Drawing.Point(9, 44);
            this.txt_ivac1.Multiline = true;
            this.txt_ivac1.Name = "txt_ivac1";
            this.txt_ivac1.ReadOnly = true;
            this.txt_ivac1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_ivac1.Size = new System.Drawing.Size(428, 108);
            this.txt_ivac1.TabIndex = 23;
            this.txt_ivac1.WordWrap = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(286, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Color attribute:";
            // 
            // txt_color
            // 
            this.txt_color.Enabled = false;
            this.txt_color.Location = new System.Drawing.Point(364, 18);
            this.txt_color.Name = "txt_color";
            this.txt_color.Size = new System.Drawing.Size(73, 20);
            this.txt_color.TabIndex = 21;
            this.txt_color.Text = "restrict";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Leading spaces:";
            // 
            // rad_26
            // 
            this.rad_26.AutoSize = true;
            this.rad_26.Checked = true;
            this.rad_26.Location = new System.Drawing.Point(173, 19);
            this.rad_26.Name = "rad_26";
            this.rad_26.Size = new System.Drawing.Size(37, 17);
            this.rad_26.TabIndex = 19;
            this.rad_26.TabStop = true;
            this.rad_26.Text = "26";
            this.rad_26.UseVisualStyleBackColor = true;
            this.rad_26.Click += new System.EventHandler(this.rad_0_Click);
            // 
            // rad_11
            // 
            this.rad_11.AutoSize = true;
            this.rad_11.Location = new System.Drawing.Point(135, 19);
            this.rad_11.Name = "rad_11";
            this.rad_11.Size = new System.Drawing.Size(37, 17);
            this.rad_11.TabIndex = 18;
            this.rad_11.TabStop = true;
            this.rad_11.Text = "11";
            this.rad_11.UseVisualStyleBackColor = true;
            this.rad_11.Click += new System.EventHandler(this.rad_0_Click);
            // 
            // rad_0
            // 
            this.rad_0.AutoSize = true;
            this.rad_0.Location = new System.Drawing.Point(99, 19);
            this.rad_0.Name = "rad_0";
            this.rad_0.Size = new System.Drawing.Size(31, 17);
            this.rad_0.TabIndex = 17;
            this.rad_0.TabStop = true;
            this.rad_0.Text = "0";
            this.rad_0.UseVisualStyleBackColor = true;
            this.rad_0.Click += new System.EventHandler(this.rad_0_Click);
            // 
            // btn_ivac1
            // 
            this.btn_ivac1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_ivac1.Location = new System.Drawing.Point(381, 78);
            this.btn_ivac1.Name = "btn_ivac1";
            this.btn_ivac1.Size = new System.Drawing.Size(49, 42);
            this.btn_ivac1.TabIndex = 19;
            this.btn_ivac1.Text = ">>";
            this.btn_ivac1.UseVisualStyleBackColor = true;
            this.btn_ivac1.Click += new System.EventHandler(this.btn_ivac1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_webeye);
            this.groupBox3.Location = new System.Drawing.Point(436, 332);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(446, 133);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "WebEye (The Eye, DLMN, etc.) shape";
            // 
            // txt_webeye
            // 
            this.txt_webeye.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_webeye.Location = new System.Drawing.Point(6, 19);
            this.txt_webeye.Multiline = true;
            this.txt_webeye.Name = "txt_webeye";
            this.txt_webeye.ReadOnly = true;
            this.txt_webeye.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_webeye.Size = new System.Drawing.Size(431, 108);
            this.txt_webeye.TabIndex = 23;
            this.txt_webeye.WordWrap = false;
            // 
            // btn_webeye
            // 
            this.btn_webeye.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_webeye.Location = new System.Drawing.Point(381, 379);
            this.btn_webeye.Name = "btn_webeye";
            this.btn_webeye.Size = new System.Drawing.Size(49, 42);
            this.btn_webeye.TabIndex = 25;
            this.btn_webeye.Text = ">>";
            this.btn_webeye.UseVisualStyleBackColor = true;
            this.btn_webeye.Click += new System.EventHandler(this.btn_webeye_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 590);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(319, 33);
            this.textBox1.TabIndex = 26;
            this.textBox1.Text = "Copyright (c) 2020 www.donatus.hu\r\ncreated by Donat Marko | software@donatus.hu\r\n" +
    "";
            // 
            // btn_help
            // 
            this.btn_help.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_help.Location = new System.Drawing.Point(337, 590);
            this.btn_help.Name = "btn_help";
            this.btn_help.Size = new System.Drawing.Size(38, 33);
            this.btn_help.TabIndex = 28;
            this.btn_help.Text = "?";
            this.btn_help.UseVisualStyleBackColor = true;
            this.btn_help.Click += new System.EventHandler(this.btn_help_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chk_linesegments);
            this.groupBox4.Controls.Add(this.txt_aurora);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.rad_decimal);
            this.groupBox4.Controls.Add(this.rad_dms_11);
            this.groupBox4.Controls.Add(this.rad_dms_14);
            this.groupBox4.Location = new System.Drawing.Point(436, 471);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(446, 158);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Aurora ATC Client point list / line segments";
            // 
            // txt_aurora
            // 
            this.txt_aurora.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_aurora.Location = new System.Drawing.Point(9, 44);
            this.txt_aurora.Multiline = true;
            this.txt_aurora.Name = "txt_aurora";
            this.txt_aurora.ReadOnly = true;
            this.txt_aurora.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_aurora.Size = new System.Drawing.Size(428, 108);
            this.txt_aurora.TabIndex = 23;
            this.txt_aurora.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Type:";
            // 
            // rad_decimal
            // 
            this.rad_decimal.AutoSize = true;
            this.rad_decimal.Location = new System.Drawing.Point(188, 19);
            this.rad_decimal.Name = "rad_decimal";
            this.rad_decimal.Size = new System.Drawing.Size(63, 17);
            this.rad_decimal.TabIndex = 19;
            this.rad_decimal.Text = "Decimal";
            this.rad_decimal.UseVisualStyleBackColor = true;
            // 
            // rad_dms_11
            // 
            this.rad_dms_11.AutoSize = true;
            this.rad_dms_11.Location = new System.Drawing.Point(118, 19);
            this.rad_dms_11.Name = "rad_dms_11";
            this.rad_dms_11.Size = new System.Drawing.Size(64, 17);
            this.rad_dms_11.TabIndex = 18;
            this.rad_dms_11.Text = "DMS 11";
            this.rad_dms_11.UseVisualStyleBackColor = true;
            // 
            // rad_dms_14
            // 
            this.rad_dms_14.AutoSize = true;
            this.rad_dms_14.Checked = true;
            this.rad_dms_14.Location = new System.Drawing.Point(48, 19);
            this.rad_dms_14.Name = "rad_dms_14";
            this.rad_dms_14.Size = new System.Drawing.Size(64, 17);
            this.rad_dms_14.TabIndex = 17;
            this.rad_dms_14.TabStop = true;
            this.rad_dms_14.Text = "DMS 14";
            this.rad_dms_14.UseVisualStyleBackColor = true;
            // 
            // btn_aurora
            // 
            this.btn_aurora.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_aurora.Location = new System.Drawing.Point(381, 515);
            this.btn_aurora.Name = "btn_aurora";
            this.btn_aurora.Size = new System.Drawing.Size(49, 42);
            this.btn_aurora.TabIndex = 30;
            this.btn_aurora.Text = ">>";
            this.btn_aurora.UseVisualStyleBackColor = true;
            this.btn_aurora.Click += new System.EventHandler(this.btn_ivac3_Click);
            // 
            // chk_linesegments
            // 
            this.chk_linesegments.AutoSize = true;
            this.chk_linesegments.Location = new System.Drawing.Point(343, 19);
            this.chk_linesegments.Name = "chk_linesegments";
            this.chk_linesegments.Size = new System.Drawing.Size(94, 17);
            this.chk_linesegments.TabIndex = 24;
            this.chk_linesegments.Text = "Line segments";
            this.chk_linesegments.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 635);
            this.Controls.Add(this.btn_aurora);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btn_help);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_webeye);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_ivac1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_ivac2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_aip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "AIPcoord";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_tabs)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_aip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_ivac2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_ivac2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown num_tabs;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_ivac1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_color;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rad_26;
        private System.Windows.Forms.RadioButton rad_11;
        private System.Windows.Forms.RadioButton rad_0;
        private System.Windows.Forms.Button btn_ivac1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_webeye;
        private System.Windows.Forms.Button btn_webeye;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_help;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txt_aurora;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rad_decimal;
        private System.Windows.Forms.RadioButton rad_dms_11;
        private System.Windows.Forms.RadioButton rad_dms_14;
        private System.Windows.Forms.Button btn_aurora;
        private System.Windows.Forms.CheckBox chk_linesegments;
    }
}

