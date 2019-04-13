using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvToSqlParser.Interfaces;
using CsvToSqlParser;
using SQLLITEDatabaseLib;

namespace CsvReader
{

    public partial class RelationshipBuilder : Form
    {
        private Column[] Columns { get; set; }
        public List<Table> Tables { get; private set; }
        private Table TempTableVariable { get; set; }

        public RelationshipBuilder()
        {
            InitializeComponent();
        }

        public RelationshipBuilder(Column[] columns, List<Table> tables = null)
        {
            InitializeComponent();

            this.Columns = columns;

            if (tables != null)
                this.Tables = tables;
        }

        private void BuildMainTable()
        {
            var table = new Table();
            table.AddName("Main_Table");
            foreach(var c in Columns)
            {
                table.AddColumn(c);
            }
            Tables.Add(table);
        }

        private void tb_addTable_tableName_Click(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            if (tb.Text.Contains("Enter") && tb.Text.Contains("Name"))
                tb.Text = "";
        }

        private void btn_addTable_addColumn_Click(object sender, EventArgs e)
        {
            var col = new Column
            {
                ColumnName = tb_addTable_columnName.Text
            };
            var type = cb_addTable_columnType.SelectedIndex;
            if (type == -1)
            {
                MessageBox.Show("Please select a column type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                col.ColumnType = (ColumnTypeSQLLITE)type;


                if (check_addTable_NULL.Checked)
                    col.Attributes.Add(ColumnAttributes.NotNull);
                if (check_addTable_PK.Checked)
                    col.Attributes.Add(ColumnAttributes.PrimaryKey);
                if (check_addTable_Unique.Checked)
                    col.Attributes.Add(ColumnAttributes.Unique);

                TempTableVariable.AddColumn(col);

                cb_addTable_ViewColumns.Items.Add(col.ShortDisplay());
            }
        }

        private void btn_addTable_addTable_Click(object sender, EventArgs e)
        {
            Tables.Add(TempTableVariable);
            TempTableVariable = null;
            this.groupBox_addTable.Visible = false;
            RefreshComboBoxes();
        }

        private void addTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TempTableVariable = new Table();
            this.groupBox_addTable.Visible = true;
            this.cb_addTable_ViewColumns.Items.Clear();
        }

        private void btn_addTable_cancel_Click(object sender, EventArgs e)
        {
            TempTableVariable = null;
            this.groupBox_addTable.Visible = false;
        }

        private void RelationshipBuilder_Load(object sender, EventArgs e)
        {
            BuildMainTable();
            RefreshComboBoxes();
        }

        private void RefreshComboBoxes()
        {
            cb_Table1.Items.Clear();
            cb_Table2.Items.Clear();
            foreach(var t in Tables)
            {
                cb_Table1.Items.Add(t.ToString());
                cb_Table2.Items.Add(t.ToString());
            }           
        }
    }

  
}
