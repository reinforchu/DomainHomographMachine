using System;
using System.Collections;
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
        Dictionary<string, string> CyrillicTable = new Dictionary<string, string>() { { "a", "а" }, { "e", "е" }, { "o", "о" }, { "r", "г" }, { "p", "р" }, { "k", "к" }, { "s", "ѕ" }, { "c", "с" }, { "x", "х" }, { "y", "у" }, { "i", "і" }, { "l", "ӏ" }, { "h", "һ" }, { "b", "Ь" }, { "m", "м" }, { "q", "ԛ" }, { "w", "ԝ" }, { "j", "ј" }, { "f", "ғ" }, { "t", "т" }, { "u", "ч" } };
        const string CyrillicRegex = "[aeorpkscxyilbmqwjftu0-9-]";
        Dictionary<string, string> GreekAndCopticTable = new Dictionary<string, string>() { { "a", "α" }, { "y", "γ" }, { "l", "ι" }, { "k", "κ" }, { "v", "ν" }, { "i", "ί" }, { "o", "ο" }, { "p", "ρ" }, { "u", "υ" }, { "x", "χ" } };
        const string GreekAndCopticRegex = "[aylkvioptux0-9-]";
        Dictionary<string, string> ArmenianTable = new Dictionary<string, string>() { { "t", "ե" }, { "q", "զ" }, { "d", "ժ" }, { "l", "լ" }, { "h", "հ" }, { "j", "յ" }, { "n", "ո" }, { "u", "ս" }, { "g", "ց" }, { "o", "օ" } };
        const string ArmenianRegex = "[tqdlhjnugo0-9-]";

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

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = SearchHomograph(CyrillicTable, "Cyrillic", CyrillicRegex);
            domain.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = SearchHomograph(GreekAndCopticTable, "Greek and Coptic", GreekAndCopticRegex);
            domain.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Text = SearchHomograph(ArmenianTable, "Armenian", ArmenianRegex);
            domain.Clear();
        }

        private string SearchHomograph(Dictionary<string, string> SubstitutedTable, string subcategory, string TableRegex)
        {
            foreach (char character in textBox1.Text)
            {
                if (!Regex.IsMatch(character.ToString(), TableRegex))
                {
                    MessageBox.Show("There was no substituted letter for '" + character + "'.\nStop searching for the " + subcategory + " subcategory.", "Exception - " + subcategory, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return String.Empty;
                }
                foreach (KeyValuePair<string, string> SubChar in SubstitutedTable)
                {
                    if (Regex.IsMatch(character.ToString(), SubChar.Key))
                    {
                        domain.Append(SubChar.Value);
                        break;
                    }
                }
                if (Regex.IsMatch(character.ToString(), "[0-9-]"))
                {
                    domain.Append(character);
                }
            }
            if (!string.IsNullOrEmpty(domain.ToString()))
            {
                textBox3.Text = "http://" + domain.ToString() + ".com/";
            }
            return domain.ToString();
        }
    }
}