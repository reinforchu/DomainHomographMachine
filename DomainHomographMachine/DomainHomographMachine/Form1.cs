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
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Domain Homograph Machine v1.1\nCopyright (C) reinforchu", "Domain Homograph Machine", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.TextLength > 0)
            {
                if (!System.IO.File.Exists(@"C:\Program Files\Mozilla Firefox\firefox.exe"))
                {
                    MessageBox.Show("It looks like you don't have Firefox installed.", "Firefox 404 Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Process.Start(@"C:\Program Files\Mozilla Firefox\firefox.exe", textBox3.Text);
                }
            }
            else
            {
                MessageBox.Show("URL not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eULAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This software is intended for cybersecurity research purposes.\nTherefore you are not allowed to exploit and abuse the results of this tool in any way. And the developer does not take any responsibility.", "End User License Agreement", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string inputString = textBox1.Text;
            foreach (char character in inputString) // Cyrillic
            {
                if (Regex.IsMatch(character.ToString(), "a"))
                {
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
                if (Regex.IsMatch(character.ToString(), "[0-9]"))
                {
                    domain.Append(character);
                }
                if (Regex.IsMatch(character.ToString(), "-"))
                {
                    domain.Append(character);
                }
                if (!Regex.IsMatch(character.ToString(), "[aeorpkscxyil3bmqwjftu0-9-]"))
                {
                    MessageBox.Show("There was no substituted letter for '" + character + "'.\nStop searching for the Cyrillic subcategory.", "Exception - Cyrillic", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string inputString = textBox1.Text;
            foreach (char character in inputString) // Greek and Coptic
            {
                if (Regex.IsMatch(character.ToString(), "a"))
                {
                    domain.Append("α");
                }
                if (Regex.IsMatch(character.ToString(), "y"))
                {
                    domain.Append("γ");
                }
                if (Regex.IsMatch(character.ToString(), "l"))
                {
                    domain.Append("ι");
                }
                if (Regex.IsMatch(character.ToString(), "k"))
                {
                    domain.Append("κ");
                }
                if (Regex.IsMatch(character.ToString(), "v"))
                {
                    domain.Append("ν");
                }
                if (Regex.IsMatch(character.ToString(), "i"))
                {
                    domain.Append("ί");
                }
                if (Regex.IsMatch(character.ToString(), "o"))
                {
                    domain.Append("ο");
                }
                if (Regex.IsMatch(character.ToString(), "p"))
                {
                    domain.Append("ρ");
                }
                if (Regex.IsMatch(character.ToString(), "t"))
                {
                    domain.Append("τ");
                }
                if (Regex.IsMatch(character.ToString(), "u"))
                {
                    domain.Append("υ");
                }
                if (Regex.IsMatch(character.ToString(), "x"))
                {
                    domain.Append("χ");
                }
                if (Regex.IsMatch(character.ToString(), "[0-9]"))
                {
                    domain.Append(character);
                }
                if (Regex.IsMatch(character.ToString(), "-"))
                {
                    domain.Append(character);
                }
                if (!Regex.IsMatch(character.ToString(), "[aylkvioptux0-9-]"))
                {
                    MessageBox.Show("There was no substituted letter for '" + character + "'.\nStop searching for the Greek and Coptic subcategory.", "Exception - Greek and Coptic", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    domain.Clear();
                    break;
                }
            }
            textBox4.Text = domain.ToString();

            if (!string.IsNullOrEmpty(domain.ToString()))
            {
                textBox3.Text = "http://" + domain.ToString() + ".com/";
            }
            domain.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string inputString = textBox1.Text;
            foreach (char character in inputString) // Armenian
            {
                if (Regex.IsMatch(character.ToString(), "t"))
                {
                    domain.Append("ե");
                }
                if (Regex.IsMatch(character.ToString(), "q"))
                {
                    domain.Append("զ");
                }
                if (Regex.IsMatch(character.ToString(), "d"))
                {
                    domain.Append("ժ");
                }
                if (Regex.IsMatch(character.ToString(), "l"))
                {
                    domain.Append("լ");
                }
                if (Regex.IsMatch(character.ToString(), "h"))
                {
                    domain.Append("հ");
                }
                if (Regex.IsMatch(character.ToString(), "j"))
                {
                    domain.Append("յ");
                }
                if (Regex.IsMatch(character.ToString(), "n"))
                {
                    domain.Append("ո");
                }
                if (Regex.IsMatch(character.ToString(), "u"))
                {
                    domain.Append("ս");
                }
                if (Regex.IsMatch(character.ToString(), "g"))
                {
                    domain.Append("ց");
                }
                if (Regex.IsMatch(character.ToString(), "o"))
                {
                    domain.Append("օ");
                }
                if (Regex.IsMatch(character.ToString(), "[0-9]"))
                {
                    domain.Append(character);
                }
                if (Regex.IsMatch(character.ToString(), "-"))
                {
                    domain.Append(character);
                }
                if (!Regex.IsMatch(character.ToString(), "[tqdlhjnugo0-9-]"))
                {
                    MessageBox.Show("There was no substituted letter for '" + character + "'.\nStop searching for the Armenian subcategory.", "Exception - Armenian", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    domain.Clear();
                    break;
                }
            }
            textBox5.Text = domain.ToString();

            if (!string.IsNullOrEmpty(domain.ToString()))
            {
                textBox3.Text = "http://" + domain.ToString() + ".com/";
            }
            domain.Clear();
        }
    }
}