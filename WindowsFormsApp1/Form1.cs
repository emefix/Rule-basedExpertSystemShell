using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Editor
{
    public partial class Form1 : Form
    {
        private KnowledgeBase kbase;
        public Form1()
        {
            InitializeComponent();
            kbase = new KnowledgeBase();

            listBoxKnowledge.Items.Add(kbase.name);
            //listBoxKnowledge.Items.Add(kbase.goal);
            int num = 0;
            foreach (string f in kbase.facts)
            {
                num++;
                listBoxKnowledge.Items.Add("fakt " + num + ": " + f);
            }
            foreach (Rule r in kbase.rules)
            {
                listBoxKnowledge.Items.Add(r);
            }
        }

        private void listBoxKnowledge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxKnowledge.SelectedIndex != -1)
            {
                propertyGrid1.SelectedObject = listBoxKnowledge.SelectedItem;
            }
        }
    }
}
