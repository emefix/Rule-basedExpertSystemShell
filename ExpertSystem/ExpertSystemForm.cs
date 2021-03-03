using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using TextEditor;

namespace ExpertSystem
{
    public partial class ExpertSystemForm : Form
    {
        #region "Fields and Accessors"

        public static string logFileName = "LogFile.txt";

        private KnowledgeBase knowledgeBase;
        private string fileName;
        #endregion

        #region "Constructor"

        public ExpertSystemForm()
        {
            InitializeComponent();
            _propertyKnowledge.PropertySort = PropertySort.NoSort;

            knowledgeBase = new KnowledgeBase();
        }
        #endregion

        #region "Add knowledge base to form"

        private void AddKnowledgeBaseToForm()
        {
            ClearEditor();
            _filePathToolStripTextBox.Text = Path.GetFileName(fileName);
            _txtName.Text = knowledgeBase.Name;

            foreach (Fact f in knowledgeBase.Facts)
                _lbFactBase.Items.Add(f);

            foreach (Rule r in knowledgeBase.Rules)
                _lbRuleBase.Items.Add(r);
        }

        private void ClearEditor()
        {
            _filePathToolStripTextBox.Clear();
            _lbRuleBase.Items.Clear();
            _lbFactBase.Items.Clear();
        }
        #endregion

        #region "Menu item File"

        private void _loadKnowledgeBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Title = "Wybierz plik",
                Filter = "Pliki tekstowe (xml)|*.xml",
                DefaultExt = ".xml",
                RestoreDirectory = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                XmlDocument xmlDoc = new XmlDocument();
                fileName = dialog.FileName;
                if (File.Exists(fileName))
                {
                    xmlDoc.Load(fileName);
                    knowledgeBase.LoadFromXml(xmlDoc);

                    AddKnowledgeBaseToForm();
                }
            }
        }

        private void _saveAsFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Title = "Zapisz plik",
                Filter = "Pliki tekstowe (xml)|*.xml",
                DefaultExt = ".xml",
                RestoreDirectory = true
            };

            if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dialog.FileName))
            {
                fileName = dialog.FileName;

                SerializeToXmlFile serialization = new SerializeToXmlFile(fileName);
                serialization.SerializeKnowledgeBase(knowledgeBase);
                MessageBox.Show("Zapisano bazę wiedzy do pliku:\n" + fileName, "Zapis bazy wiedzy");
            }
            _filePathToolStripTextBox.Text = Path.GetFileName(fileName);
        }

        private void _saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                SerializeToXmlFile serialization = new SerializeToXmlFile(fileName);
                serialization.SerializeKnowledgeBase(knowledgeBase);
            }
            else
                _saveAsFileToolStripMenuItem_Click(sender, e);
        }

        private void _newKnowledgeBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            knowledgeBase = new KnowledgeBase();
            fileName = string.Empty;
            ClearEditor();
        }

        private void _exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region "Menu item Edit"

        private void _copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Control ctrl = this.ActiveControl;
            if (ctrl != null)
            {
                if (ctrl is TextBox tx)
                {
                    tx.Copy();
                }
                if (ctrl is ListBox lb)
                {
                    string s = lb.SelectedItem.ToString();
                    Clipboard.SetData(DataFormats.StringFormat, s);
                }
            }
        }

        private void _pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Control ctrl = this.ActiveControl;
            if (ctrl != null)
            {
                if (ctrl is TextBox tx)
                {
                    tx.Paste();
                }
            }
        }

        private void _cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Control ctrl = this.ActiveControl;
            if (ctrl != null)
            {
                if (ctrl is TextBox tx)
                {
                    tx.Cut();
                }
            }
        }

        private void _selectAlltoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Control ctrl = this.ActiveControl;
            if (ctrl != null)
            {
                if (ctrl is TextBox tx)
                {
                    tx.SelectAll();
                }
            }
        }
        #endregion

        #region "Menu item Run forward chaining"

        private void _runForwardChainingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppendToLogFile();
            _lbFactBase.Items.Clear();

            ForwardChaining forwardChaining = new ForwardChaining(knowledgeBase);
            forwardChaining.ExecuteReasoning();

            int spaces, padLeft, length = 74, a = 1;
            string str;

            foreach (Fact f in forwardChaining.CFacts/*FFacts*/)
            {
                if (f.IdRule != -1 && a == 1)
                {
                    a--;
                    str = " Nowe fakty "; spaces = length - str.Length; padLeft = str.Length + spaces / 2;
                    _lbFactBase.Items.Add(str.PadLeft(padLeft, '_').PadRight(length, '_'));
                }
                _lbFactBase.Items.Add(f);
            }
            if (a == 1)
            {
                str = " Brak nowych faktów "; spaces = length - str.Length; padLeft = str.Length + spaces / 2;
                _lbFactBase.Items.Add(str.PadLeft(padLeft, '_').PadRight(length, '_'));
            }
            str = "[ Fakty po wnioskowaniu ]";
            LogFile.Log("\r\n" + str.PadRight(80, '_') + "\r\n\r\n " + 
                forwardChaining.CFacts.Select("\r\n "), ExpertSystemForm.logFileName);
        }

        private void _cleanNewFactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lbFactBase.Items.Clear();

            foreach (Fact f in knowledgeBase.Facts)
                _lbFactBase.Items.Add(f);
        }

        private void _openLogFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(logFileName))
            {
                TextEditorForm textEditor = new TextEditorForm();
                textEditor.LoadContent(logFileName);
                textEditor.Show(this);
            }
            else MessageBox.Show("Nie znaleziono pliku\n\n {0}", logFileName);
        }

        private void AppendToLogFile()
        {
            StringBuilder message = new StringBuilder();
            if (fileName != null)
                message.Append("Baza wiedzy pochodzi z pliku: " + fileName + "\r\n");
            message.Append(knowledgeBase.ToString());

            LogFile.AppendEntry(message.ToString(), logFileName);
        }
        #endregion

        #region "Tool strip"

        private void _addRuleToolStripButton_Click(object sender, EventArgs e)
        {
            int index = _lbRuleBase.SelectedIndex;
            if (index != -1)
            {
                Rule r = new Rule(index);

                knowledgeBase.Rules.Insert(index, r);
                knowledgeBase.Rules.Rename(index + 1, "reguła");

                _lbRuleBase.Items.Clear();
                foreach (Rule ri in knowledgeBase.Rules)
                    _lbRuleBase.Items.Add(ri);
            }
            else
            {
                Rule r = new Rule(knowledgeBase.Rules.Count);

                knowledgeBase.Rules.Add(r);
                _lbRuleBase.Items.Add(r);
            }
        }

        private void _addFactToolStripButton_Click(object sender, EventArgs e)
        {
            int index = _lbFactBase.SelectedIndex;
            if (index != -1)
            {
                Fact f = new Fact(index);

                knowledgeBase.Facts.Insert(index, f);
                knowledgeBase.Facts.Rename(index + 1, "fakt");

                _lbFactBase.Items.Clear();
                foreach (Fact fi in knowledgeBase.Facts)
                    _lbFactBase.Items.Add(fi);
            }
            else
            {
                Fact f = new Fact(knowledgeBase.Facts.Count);

                knowledgeBase.Facts.Add(f);
                _lbFactBase.Items.Add(f);
            }
        }

        private void _addConditionToolStripButton_Click(object sender, EventArgs e)
        {
            Literal c = new Literal();
            int index = _lbRuleBase.SelectedIndex;
            if (index != -1)
            {
                Rule rule = knowledgeBase.Rules[index] as Rule;
                rule.Conditions.Add(c);
                _propertyKnowledge.Refresh();
            }
        }

        private void _removeRuleToolStripButton_Click(object sender, EventArgs e)
        {
            int index = _lbRuleBase.SelectedIndex;
            if (index != -1)
            {
                knowledgeBase.Rules.RemoveAt(index);
                knowledgeBase.Rules.Rename(index, "reguła");

                _lbRuleBase.Items.Clear();
                foreach (Rule r in knowledgeBase.Rules)
                    _lbRuleBase.Items.Add(r);

                _propertyKnowledge.SelectedObject = _lbRuleBase.SelectedItems;
            }
            else MessageBox.Show("Zaznacz regułę na liści do usunięcia.");
        }

        private void _removeFactToolStripButton_Click(object sender, EventArgs e)
        {
            int index = _lbFactBase.SelectedIndex;
            if (index != -1)
            {
                knowledgeBase.Facts.RemoveAt(index);
                knowledgeBase.Facts.Rename(index, "fakt");

                _lbFactBase.Items.Clear();
                foreach (Fact f in knowledgeBase.Facts)
                    _lbFactBase.Items.Add(f);

                _propertyKnowledge.SelectedObject = _lbFactBase.SelectedItems;
            }
            else MessageBox.Show("Zaznacz fakt na liści do usunięcia.");
        }

        private void _removeConditionToolStripButton_Click(object sender, EventArgs e)
        {
            int index;
            if ((index = _lbRuleBase.SelectedIndex) != -1)
            {
                Rule rule = knowledgeBase.Rules[index] as Rule;
                rule.Conditions.Remove((Literal)_propertyKnowledge.SelectedGridItem.Value);

                _propertyKnowledge.Refresh();
                _lbRuleBase.Items.Clear();

                foreach (Rule r in knowledgeBase.Rules)
                    _lbRuleBase.Items.Add(r);
            }
            else MessageBox.Show("Zaznacz regułę na liści, której warunek jest do usunięcia.");
        }

        private void _runForwardToolStripButton_Click(object sender, EventArgs e)
        {
            _runForwardChainingToolStripMenuItem_Click(sender, e);
        }

        private void _cleanFactsToolStripButton_Click(object sender, EventArgs e)
        {
            _cleanNewFactsToolStripMenuItem_Click(sender, e);
        }

        private void _filePathToolStripTextBox_DoubleClick(object sender, EventArgs e)
        {
            _loadKnowledgeBaseToolStripMenuItem_Click(sender, e);
            _filePathToolStripTextBox.Text = Path.GetFileName(fileName);
        }
        #endregion

        #region "Show properties of object"

        private void _lbRuleBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lbRuleBase.SelectedIndex != -1)
                _propertyKnowledge.SelectedObject = _lbRuleBase.SelectedItem;
        }

        private void _listFactBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lbFactBase.SelectedIndex != -1)
                _propertyKnowledge.SelectedObject = _lbFactBase.SelectedItem;
        }
        #endregion

        #region "Property value or name of knowledge base has been changed"

        private void _propertyKnowledge_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            AddKnowledgeBaseToForm();
        }

        private void _txtName_TextChanged(object sender, EventArgs e)
        {
            knowledgeBase.Name = _txtName.Text;
        }
        #endregion
    }
}
