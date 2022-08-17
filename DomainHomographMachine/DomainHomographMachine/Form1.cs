using System;
using System.Collections.Generic;
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

        private void button4_Click(object sender, EventArgs e) // Cyrillic
        {
            var CyrillicTable = new Dictionary<string, string>()
            {
                {"a", "а"}, {"e", "е"}, {"o", "о"}, {"r", "г"}, {"p", "р"}, {"k", "к"}, {"s", "ѕ"}, {"c", "с"}, {"x", "х"}, {"y", "у"}, {"i", "і"}, {"l", "ӏ"}, {"h", "һ"}, {"b", "Ь"}, {"m", "м"}, {"q", "ԛ"}, {"w", "ԝ"}, {"j", "ј"}, {"f", "ғ"}, {"t", "т"}, {"u", "ч"}
            };
            foreach (char character in textBox1.Text)
            {
                if (!Regex.IsMatch(character.ToString(), "[aeorpkscxyilbmqwjftu0-9-]"))
                {
                    MessageBox.Show("There was no substituted letter for '" + character + "'.\nStop searching for the Cyrillic subcategory.", "Exception - Cyrillic", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    domain.Clear();
                    break;
                }
                foreach (KeyValuePair<string, string> cyrillic in CyrillicTable)
                {
                    if (Regex.IsMatch(character.ToString(), cyrillic.Key))
                    {
                        domain.Append(cyrillic.Value);
                        break;
                    }
                }
                if (Regex.IsMatch(character.ToString(), "[0-9-]"))
                {
                    domain.Append(character);
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

        private void button2_Click(object sender, EventArgs e)  // Greek and Coptic
        {
            var GreekAndCopticTable = new Dictionary<string, string>()
            {
                {"a", "α"}, {"y", "γ"}, {"l", "ι"}, {"k", "κ"}, {"v", "ν"}, {"i", "ί"}, {"o", "ο"}, {"p", "ρ"}, {"u", "υ"}, {"x", "χ"}
            };
            foreach (char character in textBox1.Text)
            {
                if (!Regex.IsMatch(character.ToString(), "[aylkvioptux0-9-]"))
                {
                    MessageBox.Show("There was no substituted letter for '" + character + "'.\nStop searching for the Greek and Coptic subcategory.", "Exception - Greek and Coptic", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    domain.Clear();
                    break;
                }
                foreach (KeyValuePair<string, string> greek in GreekAndCopticTable)
                {
                    if (Regex.IsMatch(character.ToString(), greek.Key))
                    {
                        domain.Append(greek.Value);
                        break;
                    }
                }
                if (Regex.IsMatch(character.ToString(), "[0-9-]"))
                {
                    domain.Append(character);
                }
            }
            textBox4.Text = domain.ToString();
            if (!string.IsNullOrEmpty(domain.ToString()))
            {
                textBox3.Text = "http://" + domain.ToString() + ".com/";
            }
            domain.Clear();
        }

        private void button5_Click(object sender, EventArgs e) // Armenian
        {
            var ArmenianTable = new Dictionary<string, string>()
            {
                {"t", "ե"}, {"q", "զ"}, {"d", "ժ"}, {"l", "լ"}, {"h", "հ"}, {"j", "յ"}, {"n", "ո"}, {"u", "ս"}, {"g", "ց"}, {"o", "օ"}
            };
            foreach (char character in textBox1.Text)
            {
                if (!Regex.IsMatch(character.ToString(), "[tqdlhjnugo0-9-]"))
                {
                    MessageBox.Show("There was no substituted letter for '" + character + "'.\nStop searching for the Armenian subcategory.", "Exception - Armenian", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    domain.Clear();
                    break;
                }
                foreach (KeyValuePair<string, string> armenian in ArmenianTable)
                {
                    if (Regex.IsMatch(character.ToString(), armenian.Key))
                    {
                        domain.Append(armenian.Value);
                        break;
                    }
                }
                if (Regex.IsMatch(character.ToString(), "[0-9-]"))
                {
                    domain.Append(character);
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