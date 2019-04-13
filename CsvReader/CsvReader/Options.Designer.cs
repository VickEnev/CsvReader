namespace CsvReader
{
    partial class Options
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtn_NoRel = new System.Windows.Forms.RadioButton();
            this.rbtn_AutoRel = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_ColTypes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_colName = new System.Windows.Forms.TextBox();
            this.btn_remove = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_columns_List = new System.Windows.Forms.ListBox();
            this.tb_delimiter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_dirPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_browse = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_trackbarValue = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.cb_Columns = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtn_NoRel);
            this.groupBox1.Controls.Add(this.rbtn_AutoRel);
            this.groupBox1.Location = new System.Drawing.Point(15, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Relationship type";
            // 
            // rbtn_NoRel
            // 
            this.rbtn_NoRel.AutoSize = true;
            this.rbtn_NoRel.Checked = true;
            this.rbtn_NoRel.Location = new System.Drawing.Point(61, 53);
            this.rbtn_NoRel.Name = "rbtn_NoRel";
            this.rbtn_NoRel.Size = new System.Drawing.Size(165, 17);
            this.rbtn_NoRel.TabIndex = 1;
            this.rbtn_NoRel.TabStop = true;
            this.rbtn_NoRel.Text = "No Relationship ( One Table )";
            this.rbtn_NoRel.UseVisualStyleBackColor = true;
            // 
            // rbtn_AutoRel
            // 
            this.rbtn_AutoRel.AutoSize = true;
            this.rbtn_AutoRel.Location = new System.Drawing.Point(61, 30);
            this.rbtn_AutoRel.Name = "rbtn_AutoRel";
            this.rbtn_AutoRel.Size = new System.Drawing.Size(168, 17);
            this.rbtn_AutoRel.TabIndex = 0;
            this.rbtn_AutoRel.Text = "Automatic Relationship( 1 : N )";
            this.rbtn_AutoRel.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_Columns);
            this.groupBox2.Controls.Add(this.cb_ColTypes);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tb_colName);
            this.groupBox2.Controls.Add(this.btn_remove);
            this.groupBox2.Controls.Add(this.btn_add);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lb_columns_List);
            this.groupBox2.Controls.Add(this.tb_delimiter);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(419, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(486, 259);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Advanced configuration";
            // 
            // cb_ColTypes
            // 
            this.cb_ColTypes.FormattingEnabled = true;
            this.cb_ColTypes.Items.AddRange(new object[] {
            "Integer",
            "Real",
            "Text",
            "Numeric"});
            this.cb_ColTypes.Location = new System.Drawing.Point(349, 168);
            this.cb_ColTypes.Name = "cb_ColTypes";
            this.cb_ColTypes.Size = new System.Drawing.Size(93, 21);
            this.cb_ColTypes.TabIndex = 10;
            this.cb_ColTypes.Text = "Select Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(346, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Column Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(346, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Column Name";
            // 
            // tb_colName
            // 
            this.tb_colName.Location = new System.Drawing.Point(349, 81);
            this.tb_colName.Name = "tb_colName";
            this.tb_colName.Size = new System.Drawing.Size(100, 20);
            this.tb_colName.TabIndex = 7;
            // 
            // btn_remove
            // 
            this.btn_remove.Location = new System.Drawing.Point(101, 224);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(105, 23);
            this.btn_remove.TabIndex = 6;
            this.btn_remove.Text = "Remove Selected";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(349, 211);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 5;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Columns";
            // 
            // lb_columns_List
            // 
            this.lb_columns_List.FormattingEnabled = true;
            this.lb_columns_List.Location = new System.Drawing.Point(101, 84);
            this.lb_columns_List.Name = "lb_columns_List";
            this.lb_columns_List.Size = new System.Drawing.Size(213, 134);
            this.lb_columns_List.TabIndex = 3;
            // 
            // tb_delimiter
            // 
            this.tb_delimiter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_delimiter.Location = new System.Drawing.Point(101, 34);
            this.tb_delimiter.MaxLength = 1;
            this.tb_delimiter.Name = "tb_delimiter";
            this.tb_delimiter.Size = new System.Drawing.Size(37, 29);
            this.tb_delimiter.TabIndex = 1;
            this.tb_delimiter.Text = ",";
            this.tb_delimiter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data Delimiter";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_dirPath
            // 
            this.tb_dirPath.BackColor = System.Drawing.Color.White;
            this.tb_dirPath.Location = new System.Drawing.Point(116, 35);
            this.tb_dirPath.Name = "tb_dirPath";
            this.tb_dirPath.ReadOnly = true;
            this.tb_dirPath.Size = new System.Drawing.Size(187, 20);
            this.tb_dirPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Database Directory";
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(318, 33);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(75, 23);
            this.btn_browse.TabIndex = 3;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // btn_save
            // 
            this.btn_save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_save.Location = new System.Drawing.Point(25, 280);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(130, 39);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "Save configuration options";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(53, 208);
            this.trackBar.Maximum = 11;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(270, 45);
            this.trackBar.TabIndex = 5;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Column type accuracy: ";
            // 
            // lbl_trackbarValue
            // 
            this.lbl_trackbarValue.AutoSize = true;
            this.lbl_trackbarValue.Location = new System.Drawing.Point(174, 178);
            this.lbl_trackbarValue.Name = "lbl_trackbarValue";
            this.lbl_trackbarValue.Size = new System.Drawing.Size(138, 13);
            this.lbl_trackbarValue.TabIndex = 7;
            this.lbl_trackbarValue.Text = "Scan only the first data row!";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Title = "Database Save Path";
            // 
            // cb_Columns
            // 
            this.cb_Columns.FormattingEnabled = true;
            this.cb_Columns.Location = new System.Drawing.Point(349, 112);
            this.cb_Columns.Name = "cb_Columns";
            this.cb_Columns.Size = new System.Drawing.Size(100, 21);
            this.cb_Columns.TabIndex = 11;
            this.cb_Columns.Text = "CSV Columns";
            this.cb_Columns.SelectedIndexChanged += new System.EventHandler(this.cb_Columns_SelectedIndexChanged);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 331);
            this.Controls.Add(this.lbl_trackbarValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_dirPath);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_dirPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.RadioButton rbtn_NoRel;
        private System.Windows.Forms.RadioButton rbtn_AutoRel;
        private System.Windows.Forms.ComboBox cb_ColTypes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_colName;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lb_columns_List;
        private System.Windows.Forms.TextBox tb_delimiter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_trackbarValue;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ComboBox cb_Columns;
    }
}