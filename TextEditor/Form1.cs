using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace TextEditor
{
    enum Mode
    {
        Normal,
        Insert,
        Command
    }
    public partial class Form1 : Form
    {
        private Mode mode;

        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text File(*.txt)|*.txt";
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Font = new Font("Times New Roman", 14);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            /*if (keyData == Keys.I && !Control.ModifierKeys.HasFlag(Keys.Shift) && !Console.CapsLock && mode == Mode.Normal)
            {
                mode = Mode.Insert;
            }
            if (keyData == Keys.J && !Control.ModifierKeys.HasFlag(Keys.Shift) && !Console.CapsLock && mode == Mode.Normal)
            {
                MoveToNextLine(); return true;
            }*/
            if (keyData == (Keys.Control | Keys.S))
            {
                saveAsToolStripMenuItem_Click(this, null); return true;
            }
            if (keyData == (Keys.Control | Keys.O))
            {
                openToolStripMenuItem_Click(this, null); return true;
            }
            if (keyData == (Keys.Control | Keys.C))
            {
                copyToolStripMenuItem_Click(this, null); return true;
            }
            if (keyData == (Keys.Control | Keys.V))
            {
                pasteToolStripMenuItem_Click(this, null); return true;
            }
            if (keyData == (Keys.Control | Keys.X))
            {
                cutToolStripMenuItem_Click(this, null); return true;
            }
            if (keyData == (Keys.Control | Keys.A))
            {
                selectAllToolStripMenuItem_Click(this, null); return true;
            }
            if (keyData == (Keys.Control | Keys.Z))
            {
                undoToolStripMenuItem_Click(this, null); return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MoveToNextLine()
        {
            int currentCaretPosition = richTextBox1.SelectionStart;

            int currentLine = richTextBox1.GetLineFromCharIndex(currentCaretPosition);
            int currentColumn = currentCaretPosition - richTextBox1.GetFirstCharIndexOfCurrentLine();

            int nextLineStartIndex = richTextBox1.GetFirstCharIndexFromLine(currentLine + 1);

            if (nextLineStartIndex >= 0)
            {
                int newCaretPosition = nextLineStartIndex + currentColumn;
                int nextLineLength = richTextBox1.Lines[currentLine + 1].Length;

                if (newCaretPosition > nextLineLength)
                {
                    newCaretPosition = nextLineLength;
                }
                else
                {

                        if (newCaretPosition > nextLineStartIndex + nextLineLength)
                        {
                            newCaretPosition = nextLineStartIndex + nextLineLength;
                        }
                }
            }
            else
            {
                richTextBox1.AppendText(Environment.NewLine);
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
            }
        }



        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            string filename = saveFileDialog1.FileName;
            File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            string filename = openFileDialog1.FileName;
            string fileText = File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
        }


        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.BackColor = colorDialog1.Color;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Paste();
            }
        }



        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Undo();
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        public void textFinder(string str)
        {
            int index = 0;
            int startIndex = 0;

            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = SystemColors.InactiveBorder;

            while ((index = richTextBox1.Text.IndexOf(str,startIndex,StringComparison.CurrentCulture)) != -1)
            {
                richTextBox1.Select(index, str.Length);
                richTextBox1.SelectionBackColor = Color.Yellow;
                startIndex = index + str.Length;
            }
            richTextBox1.Select(startIndex, 0);
            richTextBox1.SelectionBackColor = Color.White;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Полезная информация", "Справка");

        }

        private void foregroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.ForeColor = colorDialog1.Color;
        }
    }
}

