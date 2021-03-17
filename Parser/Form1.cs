using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parser
{
    public partial class Form1 : Form
    {

        BinaryTree Tree;
        public void AddNode(Node parent)
        {
            if (parent != null)
            {
                
                AddNode(parent.LeftNode);
                listBox1.Items.Add(parent.Data);
                AddNode(parent.RightNode);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {

            Checker expresie = new Checker();
            if (expresie.checkRegex(textBox1.Text) == 1)
            {
                ParsingExpression Parse = new ParsingExpression();
                Parse.Parsing(textBox1.Text);
                Tree = Parse.getTree();
                AddNode(Tree.Root);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            listBox1.Items.Clear();

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
