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
using CsvToSqlParser.Interfaces;

namespace CsvReader
{
    public partial class Form1 : Form, IObserver<INotification>
    {
        private Parser Parser { get; set; }
        private Configuration Config { get; set; } = new Configuration();

        private string FileName { get; set; }
        private int TestSec { get; set; } = 0;

        private Task ParserTask { get; set; }

        public void OnNext(INotification value)
        {
            if (value.GetType() == typeof(Status))
            {
                this.Invoke(new Action(() =>
                {
                    var s = value as Status;
                    toolStripStatusLabel.Text = s.Notification;
                }));
            }

        }

        public void OnError(Exception error)
        {
            MessageBox.Show(error.ToString(), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            this.Invoke(new Action(() =>
            {
                btn_Upload.Enabled = true;
                toolStripStatusLabel.Text = "Done";
            }));
        }

        public void OnCompleted()
        {
            this.Invoke(new Action(() =>
            {
                RunTimer.Stop();
                MessageBox.Show($"Task completed in {Math.Round(TestSec / 60d, 2)}", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_Upload.Enabled = true;
                toolStripStatusLabel.Text = "Done";
            }));

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog.FileName;
                btn_Start.Enabled = btn_options.Enabled = true;
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            Start();
            RunTimer.Start();
        }

        private void Start()
        {
            btn_Start.Enabled = btn_Upload.Enabled = btn_options.Enabled = false;
            Parser = new Parser(FileName, Config);
            Parser.Subscribe(this);
            try
            {
                ParserTask = Task.Factory.StartNew(new Action(() =>
                {
                    Parser.ParseFile();
                }));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        private void RunTimer_Tick(object sender, EventArgs e)
        {
            TestSec++;

        }

        private void btn_options_Click(object sender, EventArgs e)
        {
            var options = new Options(FileName);
            if (options.ShowDialog() == DialogResult.OK)
                Config = options.Configuration;
        }
    }
}
