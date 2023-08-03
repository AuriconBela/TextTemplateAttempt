using System.IO;
using System;
using System.Windows.Forms;
using TextTemplateAttempt.Parser;
using TextTemplateAttempt.Version;

namespace TextTemplateAttempt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var major = VersionInfo.MajorVersion;
            var minor = VersionInfo.MinorVersion;

            label1.Text = major.ToString();
            label2.Text = minor.ToString();
        }
    }
}
