using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvToSqlParser;
using SQLLITEDatabaseLib;

namespace CsvReader
{


    public partial class Options : Form
    {
        public Configuration Configuration { get; private set; }
        private string SaveFileName { get; set; } = "";
        private List<string> Columns;
        private List<IColumn> ComputedColumns;

        public Options()
        {
            InitializeComponent();
        }

        public Options(string filename)
        {
            InitializeComponent();
            ComputedColumns = new List<IColumn>();
            Parser parser = new Parser(filename, new Configuration());
            Columns = new List<string>();
            var cols = parser.GetColumnsFromCsv();
            if (cols != null)
                Columns.AddRange(cols);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string colName = "";

            if (cb_Columns.SelectedIndex != -1)
                colName = cb_Columns.Items[cb_Columns.SelectedIndex].ToString();

            if (tb_colName.Text != "")
                colName = tb_colName.Text;

            if (cb_ColTypes.SelectedIndex != -1)
            {
                var col = new Column()
                {
                    ColumnName = colName,
                    ColumnType = (ColumnTypeSQLLITE)cb_ColTypes.SelectedIndex
                };

                ComputedColumns.Add(col);

                lb_columns_List.Items.Add(col.ShortDisplay());
            }
            else
            {
                MessageBox.Show("Please select a column type!");
            }

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Configuration = new Configuration()
            {
                DatabasePath = SaveFileName,
                Delimiter = tb_delimiter.Text[0],
                Type = (rbtn_AutoRel.Checked) ? RelationshipType.AutomaticRelationship : RelationshipType.NoRelationship,
                Columns = (ComputedColumns.Count > 0) ? ComputedColumns : null,
                ColumnTypeAccuracy = (trackBar.Value == 0) ? 0 : ((trackBar.Value == 11) ? 11 : trackBar.Value * 1000)
            };

        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                SaveFileName = saveFileDialog.FileName;
                tb_dirPath.Text = SaveFileName;
            }
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            if (trackBar.Value == 0)
            {
                lbl_trackbarValue.Text = $"Scan only the first data row!";
            }
            else if (trackBar.Value == 11)
            {
                lbl_trackbarValue.Text = $"Scan all rows!\n(May significantly reduce performance!)";
            }
            else
            {
                lbl_trackbarValue.Text = $"Scan {trackBar.Value * 1000} rows";
            }

        }

        private void Options_Load(object sender, EventArgs e)
        {
            cb_Columns.Items.AddRange(Columns.ToArray());
        }

        private void cb_Columns_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_colName.Text = "";
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (lb_columns_List.SelectedIndex != -1)
            {
                ComputedColumns.RemoveAt(lb_columns_List.SelectedIndex);
                lb_columns_List.Items.RemoveAt(lb_columns_List.SelectedIndex);
            }
        }
    }


}
