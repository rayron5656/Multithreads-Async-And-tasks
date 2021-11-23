using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Search_Files
{
    public partial class Form1 : Form
    {
        
        public Threads_HW.Search Mysearch { get; set; }
        public Timer T = new Timer();
        Task Tasker;

        public Form1()
        {
            InitializeComponent();
            T.Tick += RefreshCMB;
            T.Interval = 4000;


        }

        private void Searchbutton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(SearchtextBox.Text) || comboBox1.SelectedIndex == -1)
            {

            }
            else
            {
                Mysearch = new Threads_HW.Search(SearchtextBox.Text, $@"{comboBox1.Text}:\");
                Tasker = (Mysearch.ProccessDirectory(Mysearch.Drive));
                
                
                T.Start();


            }
        }

        private void RefreshCMB(object Sender, System.EventArgs e)
        {
            Foundlabel.Text = (Mysearch.FilesFound.Count + 1).ToString();
            T.Interval = 1000;
            T.Start();
        }

        private void Stopbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Tasker.Dispose();
                
               
                Mysearch.Stop();
                T.Stop();
            }
            catch (Exception)
            {

                
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SearchtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
