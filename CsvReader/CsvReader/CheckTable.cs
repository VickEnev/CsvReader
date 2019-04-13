using CsvToSqlParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsvReader
{
    public partial class CheckTable : Form
    {
        private Column[] Columns { get; set; }
       
        public CheckTable()
        {
            InitializeComponent();
        }

        public CheckTable(Column[] columns)
        {
            InitializeComponent();
            Columns = columns;
           
        }

        private void btn_Show_Click(object sender, EventArgs e)
        {
            string info = "";
            for(int i = 0; i < Columns.Length; i++)
            {
                info += $"{Columns[i].ToString()}\n";
            }
            MessageBox.Show(info,"Column Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
