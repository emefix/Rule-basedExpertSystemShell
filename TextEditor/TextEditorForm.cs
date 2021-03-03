using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class TextEditorForm : Form
    {
        #region "Constructor"

        public TextEditorForm()
        {
            InitializeComponent();
        } 
        #endregion

        #region "Load File"

        public void LoadContent(string fileName)
        {
            StreamReader sr = new StreamReader(fileName, Encoding.UTF8);
            _richTextBox.Text = sr.ReadToEnd();
            sr.Close();
        }

        private void _richTextBox_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            const int margin = 5;
            RichTextBox rch = sender as RichTextBox;
            rch.ClientSize = new Size(e.NewRectangle.Width + margin, e.NewRectangle.Height + margin);
        } 
        #endregion
    }
}
