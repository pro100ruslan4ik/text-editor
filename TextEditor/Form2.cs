using System;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        public Form2(Form1 parent)
        {
            form1 = parent;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.textFinder(textBox1.Text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
