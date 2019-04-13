namespace CsvReader
{
    partial class RelationshipBuilder
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
            this.cb_Table1 = new System.Windows.Forms.ComboBox();
            this.cb_Relationships = new System.Windows.Forms.ComboBox();
            this.cb_Table2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_addTable = new System.Windows.Forms.GroupBox();
            this.btn_addTable_addColumn = new System.Windows.Forms.Button();
            this.check_addTable_Unique = new System.Windows.Forms.CheckBox();
            this.check_addTable_NULL = new System.Windows.Forms.CheckBox();
            this.check_addTable_PK = new System.Windows.Forms.CheckBox();
            this.cb_addTable_columnType = new System.Windows.Forms.ComboBox();
            this.tb_addTable_columnName = new System.Windows.Forms.TextBox();
            this.tb_addTable_tableName = new System.Windows.Forms.TextBox();
            this.cb_addTable_ViewColumns = new System.Windows.Forms.ComboBox();
            this.btn_addTable_cancel = new System.Windows.Forms.Button();
            this.btn_addTable_addTable = new System.Windows.Forms.Button();
            this.rtb_relationshipViewer = new System.Windows.Forms.RichTextBox();
            this.btn_makeRelationship = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.editTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.groupBox_addTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_Table1
            // 
            this.cb_Table1.FormattingEnabled = true;
            this.cb_Table1.Location = new System.Drawing.Point(48, 60);
            this.cb_Table1.Name = "cb_Table1";
            this.cb_Table1.Size = new System.Drawing.Size(121, 21);
            this.cb_Table1.TabIndex = 0;
            // 
            // cb_Relationships
            // 
            this.cb_Relationships.FormattingEnabled = true;
            this.cb_Relationships.Items.AddRange(new object[] {
            "One To Many 1:N",
            "One To One 1:1"});
            this.cb_Relationships.Location = new System.Drawing.Point(211, 89);
            this.cb_Relationships.Name = "cb_Relationships";
            this.cb_Relationships.Size = new System.Drawing.Size(122, 21);
            this.cb_Relationships.TabIndex = 1;
            // 
            // cb_Table2
            // 
            this.cb_Table2.FormattingEnabled = true;
            this.cb_Table2.Location = new System.Drawing.Point(373, 60);
            this.cb_Table2.Name = "cb_Table2";
            this.cb_Table2.Size = new System.Drawing.Size(121, 21);
            this.cb_Table2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Table";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Relationships";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(370, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Table";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tableToolStripMenuItem,
            this.buildDatabaseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(554, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tableToolStripMenuItem
            // 
            this.tableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTableToolStripMenuItem,
            this.editTableToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteTableToolStripMenuItem});
            this.tableToolStripMenuItem.Name = "tableToolStripMenuItem";
            this.tableToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.tableToolStripMenuItem.Text = "Table";
            // 
            // addTableToolStripMenuItem
            // 
            this.addTableToolStripMenuItem.Name = "addTableToolStripMenuItem";
            this.addTableToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addTableToolStripMenuItem.Text = "Add Table";
            this.addTableToolStripMenuItem.Click += new System.EventHandler(this.addTableToolStripMenuItem_Click);
            // 
            // deleteTableToolStripMenuItem
            // 
            this.deleteTableToolStripMenuItem.Name = "deleteTableToolStripMenuItem";
            this.deleteTableToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.deleteTableToolStripMenuItem.Text = "Delete Selected Table";
            // 
            // buildDatabaseToolStripMenuItem
            // 
            this.buildDatabaseToolStripMenuItem.Name = "buildDatabaseToolStripMenuItem";
            this.buildDatabaseToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.buildDatabaseToolStripMenuItem.Text = "Build Database";
            // 
            // groupBox_addTable
            // 
            this.groupBox_addTable.Controls.Add(this.btn_addTable_addColumn);
            this.groupBox_addTable.Controls.Add(this.check_addTable_Unique);
            this.groupBox_addTable.Controls.Add(this.check_addTable_NULL);
            this.groupBox_addTable.Controls.Add(this.check_addTable_PK);
            this.groupBox_addTable.Controls.Add(this.cb_addTable_columnType);
            this.groupBox_addTable.Controls.Add(this.tb_addTable_columnName);
            this.groupBox_addTable.Controls.Add(this.tb_addTable_tableName);
            this.groupBox_addTable.Controls.Add(this.cb_addTable_ViewColumns);
            this.groupBox_addTable.Controls.Add(this.btn_addTable_cancel);
            this.groupBox_addTable.Controls.Add(this.btn_addTable_addTable);
            this.groupBox_addTable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox_addTable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox_addTable.Location = new System.Drawing.Point(39, 391);
            this.groupBox_addTable.Name = "groupBox_addTable";
            this.groupBox_addTable.Size = new System.Drawing.Size(455, 266);
            this.groupBox_addTable.TabIndex = 7;
            this.groupBox_addTable.TabStop = false;
            this.groupBox_addTable.Text = "Add Table";
            this.groupBox_addTable.Visible = false;
            // 
            // btn_addTable_addColumn
            // 
            this.btn_addTable_addColumn.Location = new System.Drawing.Point(21, 189);
            this.btn_addTable_addColumn.Name = "btn_addTable_addColumn";
            this.btn_addTable_addColumn.Size = new System.Drawing.Size(75, 23);
            this.btn_addTable_addColumn.TabIndex = 10;
            this.btn_addTable_addColumn.Text = "Add Column";
            this.btn_addTable_addColumn.UseVisualStyleBackColor = true;
            this.btn_addTable_addColumn.Click += new System.EventHandler(this.btn_addTable_addColumn_Click);
            // 
            // check_addTable_Unique
            // 
            this.check_addTable_Unique.AutoSize = true;
            this.check_addTable_Unique.Location = new System.Drawing.Point(218, 154);
            this.check_addTable_Unique.Name = "check_addTable_Unique";
            this.check_addTable_Unique.Size = new System.Drawing.Size(60, 17);
            this.check_addTable_Unique.TabIndex = 9;
            this.check_addTable_Unique.Text = "Unique";
            this.check_addTable_Unique.UseVisualStyleBackColor = true;
            // 
            // check_addTable_NULL
            // 
            this.check_addTable_NULL.AutoSize = true;
            this.check_addTable_NULL.Location = new System.Drawing.Point(120, 154);
            this.check_addTable_NULL.Name = "check_addTable_NULL";
            this.check_addTable_NULL.Size = new System.Drawing.Size(79, 17);
            this.check_addTable_NULL.TabIndex = 8;
            this.check_addTable_NULL.Text = "Can be null";
            this.check_addTable_NULL.UseVisualStyleBackColor = true;
            // 
            // check_addTable_PK
            // 
            this.check_addTable_PK.AutoSize = true;
            this.check_addTable_PK.Location = new System.Drawing.Point(21, 154);
            this.check_addTable_PK.Name = "check_addTable_PK";
            this.check_addTable_PK.Size = new System.Drawing.Size(81, 17);
            this.check_addTable_PK.TabIndex = 6;
            this.check_addTable_PK.Text = "Primary Key";
            this.check_addTable_PK.UseVisualStyleBackColor = true;
            // 
            // cb_addTable_columnType
            // 
            this.cb_addTable_columnType.FormattingEnabled = true;
            this.cb_addTable_columnType.Items.AddRange(new object[] {
            "Integer",
            "Real",
            "Text",
            "Numeric"});
            this.cb_addTable_columnType.Location = new System.Drawing.Point(21, 106);
            this.cb_addTable_columnType.Name = "cb_addTable_columnType";
            this.cb_addTable_columnType.Size = new System.Drawing.Size(121, 21);
            this.cb_addTable_columnType.TabIndex = 5;
            this.cb_addTable_columnType.Text = "Column Type";
            // 
            // tb_addTable_columnName
            // 
            this.tb_addTable_columnName.Location = new System.Drawing.Point(21, 65);
            this.tb_addTable_columnName.Name = "tb_addTable_columnName";
            this.tb_addTable_columnName.Size = new System.Drawing.Size(124, 20);
            this.tb_addTable_columnName.TabIndex = 4;
            this.tb_addTable_columnName.Text = "Enter Column Name";
            this.tb_addTable_columnName.Click += new System.EventHandler(this.tb_addTable_tableName_Click);
            // 
            // tb_addTable_tableName
            // 
            this.tb_addTable_tableName.Location = new System.Drawing.Point(21, 30);
            this.tb_addTable_tableName.Name = "tb_addTable_tableName";
            this.tb_addTable_tableName.Size = new System.Drawing.Size(124, 20);
            this.tb_addTable_tableName.TabIndex = 3;
            this.tb_addTable_tableName.Text = "Enter Table Name";
            this.tb_addTable_tableName.Click += new System.EventHandler(this.tb_addTable_tableName_Click);
            // 
            // cb_addTable_ViewColumns
            // 
            this.cb_addTable_ViewColumns.FormattingEnabled = true;
            this.cb_addTable_ViewColumns.Location = new System.Drawing.Point(271, 30);
            this.cb_addTable_ViewColumns.Name = "cb_addTable_ViewColumns";
            this.cb_addTable_ViewColumns.Size = new System.Drawing.Size(144, 21);
            this.cb_addTable_ViewColumns.TabIndex = 2;
            this.cb_addTable_ViewColumns.Text = "View Columns";
            // 
            // btn_addTable_cancel
            // 
            this.btn_addTable_cancel.Location = new System.Drawing.Point(363, 225);
            this.btn_addTable_cancel.Name = "btn_addTable_cancel";
            this.btn_addTable_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_addTable_cancel.TabIndex = 1;
            this.btn_addTable_cancel.Text = "Cancel";
            this.btn_addTable_cancel.UseVisualStyleBackColor = true;
            this.btn_addTable_cancel.Click += new System.EventHandler(this.btn_addTable_cancel_Click);
            // 
            // btn_addTable_addTable
            // 
            this.btn_addTable_addTable.Location = new System.Drawing.Point(282, 225);
            this.btn_addTable_addTable.Name = "btn_addTable_addTable";
            this.btn_addTable_addTable.Size = new System.Drawing.Size(75, 23);
            this.btn_addTable_addTable.TabIndex = 0;
            this.btn_addTable_addTable.Text = "Add Table";
            this.btn_addTable_addTable.UseVisualStyleBackColor = true;
            this.btn_addTable_addTable.Click += new System.EventHandler(this.btn_addTable_addTable_Click);
            // 
            // rtb_relationshipViewer
            // 
            this.rtb_relationshipViewer.Location = new System.Drawing.Point(48, 204);
            this.rtb_relationshipViewer.Name = "rtb_relationshipViewer";
            this.rtb_relationshipViewer.ReadOnly = true;
            this.rtb_relationshipViewer.Size = new System.Drawing.Size(446, 150);
            this.rtb_relationshipViewer.TabIndex = 8;
            this.rtb_relationshipViewer.Text = "";
            // 
            // btn_makeRelationship
            // 
            this.btn_makeRelationship.Location = new System.Drawing.Point(48, 175);
            this.btn_makeRelationship.Name = "btn_makeRelationship";
            this.btn_makeRelationship.Size = new System.Drawing.Size(121, 23);
            this.btn_makeRelationship.TabIndex = 9;
            this.btn_makeRelationship.Text = "Make Relationship";
            this.btn_makeRelationship.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(48, 113);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(373, 113);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Key";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(371, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Key";
            // 
            // editTableToolStripMenuItem
            // 
            this.editTableToolStripMenuItem.Name = "editTableToolStripMenuItem";
            this.editTableToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.editTableToolStripMenuItem.Text = "Edit Selected Table";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // RelationshipBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 757);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox_addTable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_Table2);
            this.Controls.Add(this.cb_Relationships);
            this.Controls.Add(this.cb_Table1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btn_makeRelationship);
            this.Controls.Add(this.rtb_relationshipViewer);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RelationshipBuilder";
            this.Text = "Relationship Builder";
            this.Load += new System.EventHandler(this.RelationshipBuilder_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox_addTable.ResumeLayout(false);
            this.groupBox_addTable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Table1;
        private System.Windows.Forms.ComboBox cb_Relationships;
        private System.Windows.Forms.ComboBox cb_Table2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildDatabaseToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox_addTable;
        private System.Windows.Forms.Button btn_addTable_addColumn;
        private System.Windows.Forms.CheckBox check_addTable_Unique;
        private System.Windows.Forms.CheckBox check_addTable_NULL;
        private System.Windows.Forms.CheckBox check_addTable_PK;
        private System.Windows.Forms.ComboBox cb_addTable_columnType;
        private System.Windows.Forms.TextBox tb_addTable_columnName;
        private System.Windows.Forms.TextBox tb_addTable_tableName;
        private System.Windows.Forms.ComboBox cb_addTable_ViewColumns;
        private System.Windows.Forms.Button btn_addTable_cancel;
        private System.Windows.Forms.Button btn_addTable_addTable;
        private System.Windows.Forms.RichTextBox rtb_relationshipViewer;
        private System.Windows.Forms.Button btn_makeRelationship;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem editTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}