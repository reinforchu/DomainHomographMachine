using System;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CyrillicHomographGen
{
    public partial class Form1 : Form
    {
        StringBuilder domain = new StringBuilder();
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DialogResult eula = MessageBox.Show("This software is intended for cybersecurity research purposes.\nTherefore you are not allowed to exploit and abuse the results of this tool in any way. And the developer does not take any responsibility.\nDo you still agree and continue?", "End User License Agreement", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (eula == DialogResult.No)
            {
                Environment.Exit(0);
            }
            if (!System.IO.File.Exists(@"C:\Program Files\Mozilla Firefox\firefox.exe"))
            {
                MessageBox.Show("It looks like you don't have Firefox installed.", "Firefox 404 Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputString = textBox1.Text;
            foreach (char character in inputString)
            {
                if (Regex.IsMatch(character.ToString(), "a")) {
                    domain.Append("а");
                }
                if (Regex.IsMatch(character.ToString(), "e"))
                {
                    domain.Append("е");
                }
                if (Regex.IsMatch(character.ToString(), "o"))
                {
                    domain.Append("о");
                }
                if (Regex.IsMatch(character.ToString(), "r"))
                {
                    domain.Append("г");
                }
                if (Regex.IsMatch(character.ToString(), "p"))
                {
                    domain.Append("р");
                }
                if (Regex.IsMatch(character.ToString(), "k"))
                {
                    domain.Append("к");
                }
                if (Regex.IsMatch(character.ToString(), "s"))
                {
                    domain.Append("ѕ");
                }
                if (Regex.IsMatch(character.ToString(), "c"))
                {
                    domain.Append("с");
                }
                if (Regex.IsMatch(character.ToString(), "x"))
                {
                    domain.Append("х");
                }
                if (Regex.IsMatch(character.ToString(), "y"))
                {
                    domain.Append("у");
                }
                if (Regex.IsMatch(character.ToString(), "i"))
                {
                    domain.Append("і");
                }
                if (Regex.IsMatch(character.ToString(), "l"))
                {
                    domain.Append("ӏ");
                }
                if (Regex.IsMatch(character.ToString(), "3"))
                {
                    domain.Append("ӡ");
                }
                if (Regex.IsMatch(character.ToString(), "h"))
                {
                    domain.Append("һ");
                }
                if (Regex.IsMatch(character.ToString(), "b"))
                {
                    domain.Append("Ь");
                }
                if (Regex.IsMatch(character.ToString(), "m"))
                {
                    domain.Append("м");
                }
                if (Regex.IsMatch(character.ToString(), "q"))
                {
                    domain.Append("ԛ");
                }
                if (Regex.IsMatch(character.ToString(), "w"))
                {
                    domain.Append("ԝ");
                }
                if (Regex.IsMatch(character.ToString(), "j"))
                {
                    domain.Append("ј");
                }
                if (Regex.IsMatch(character.ToString(), "f"))
                {
                    domain.Append("ғ");
                }
                if (Regex.IsMatch(character.ToString(), "t"))
                {
                    domain.Append("т");
                }
                if (Regex.IsMatch(character.ToString(), "u"))
                {
                    domain.Append("ч");
                }
                if (!Regex.IsMatch(character.ToString(), "[aeorpkscxyil3bmqwjftu]"))
                {
                    MessageBox.Show("There was no alternate letter for '" + character + "'.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    domain.Clear();
                    break;
                }
            }
            textBox2.Text = domain.ToString();

            if (!string.IsNullOrEmpty(domain.ToString()))
            {
                textBox3.Text = "http://" + domain.ToString() + ".com/";
            }
            domain.Clear();
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            button1.Enabled = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cyrillic Homograph Generator\nVersion 1.0.0.0\nCopyright (C) reinforchu", "Cyrillic Homograph Generator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength > 0)
            {
                Process.Start(textBox3.Text);
            } else
            {
                MessageBox.Show("Domain name not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength > 0)
            {
                Process.Start(@"C:\Program Files\Mozilla Firefox\firefox.exe", textBox3.Text);
            }
            else
            {
                MessageBox.Show("URL not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "opera";
            button1.PerformClick();
        }
    }
}