using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text File(*.txt)|*.txt";
            richTextBox1.Dock = DockStyle.Fill;
            //if (richTextBox1.SelectedText.Length == 0)
            //{
            //    копироватьToolStripMenuItem.Enabled = false;
            //    вырезатьToolStripMenuItem.Enabled = false;
            //    отменитьToolStripMenuItem.Enabled = false;
            //}
            
        }

        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (richTextBox1.Modified == false) return;
        //    DialogResult MBox = MessageBox.Show("Текст был изменен.\nСохранить изменения ?","TextEditor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
        //    if (MBox == DialogResult.No) return;
        //    if (MBox == DialogResult.Cancel) e.Cancel = true;
        //    if (MBox == DialogResult.Yes)
        //    {
        //        if (saveFileDialog1.ShowDialog() == DialogResult.OK) 
        //        {
        //            сохранитьКакToolStripMenuItem1_Click(sender, e);
        //            return;
        //        }
        //        else
        //        {
        //            e.Cancel = true;
        //        }
        //    }
        //}

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                сохранитьКакToolStripMenuItem1_Click(this, null); return true;
            }
            if (keyData == (Keys.Control | Keys.O))
            {
                сохранитьToolStripMenuItem_Click(this, null); return true;
            }
            if (keyData == (Keys.Control | Keys.C))
            {
                копироватьToolStripMenuItem_Click(this, null); return true;
            }
            if (keyData == (Keys.Control | Keys.V))
            {
                вставитьToolStripMenuItem_Click(this, null); return true;
            }
            if (keyData == (Keys.Control | Keys.X))
            {
                вырезатьToolStripMenuItem_Click(this, null); return true;
            }
            if (keyData == (Keys.Control | Keys.A))
            {
                выделитьВсеToolStripMenuItem_Click(this, null); return true;
            }
            if (keyData == (Keys.Control | Keys.Z))
            {
                отменитьToolStripMenuItem_Click(this, null); return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }



        //public bool FindMyText(string text)
        //{
        //    // Initialize the return value to false by default.
        //    bool returnValue = false;

        //    // Ensure a search string has been specified.
        //    if (text.Length > 0)
        //    {
        //        // Obtain the location of the search string in richTextBox1.
        //        int indexToText = richTextBox1.Find(text, RichTextBoxFinds.MatchCase);
        //        // Determine if the text was found in richTextBox1.
        //        if (indexToText >= 0)
        //        {
        //            returnValue = true;
        //        }
        //    }

        //    return returnValue;
        //}

        private void сохранитьКакToolStripMenuItem1_Click(object sender, EventArgs e) //Сохранить как
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            string filename = saveFileDialog1.FileName;
            File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e) //Открытие
        {
            if(openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            string filename = openFileDialog1.FileName;
            string fileText = File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            string filename = openFileDialog1.FileName;
            string fileText = File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0) 
            {
                richTextBox1.Copy();
            }
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Paste();
            }
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void фонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.BackColor = colorDialog1.Color;
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.SelectAll();
            }
        }

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                richTextBox1.ContextMenuStrip = contextMenuStrip1;
            }
        }

        private void копироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void вставитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Paste();
            }
        }

        private void вырезатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void выделитьВсеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.SelectAll();
            }
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Undo();
            }
        }

        private void найтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        public void textFinder(string str)
        {
            int index = 0;
            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = Color.White;
            while (index < richTextBox1.Text.LastIndexOf(str))
            {
                richTextBox1.Find(str, index, richTextBox1.TextLength, RichTextBoxFinds.MatchCase);
                richTextBox1.BackColor = Color.Yellow;
                index = richTextBox1.Text.IndexOf(str) + 1;
            }
        }

        private void правкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (richTextBox1.SelectedText.Length == 0)
            //{
            //    копироватьToolStripMenuItem.Enabled = false;
            //    вырезатьToolStripMenuItem.Enabled = false;
            //    отменитьToolStripMenuItem.Enabled = false;
            //}
        }
    }
}
