namespace ExpertSystem
{
    partial class ExpertSystemForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpertSystemForm));
            this._propertyKnowledge = new System.Windows.Forms.PropertyGrid();
            this._lbRuleBase = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._loadKnowledgeBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._saveAsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._newKnowledgeBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._cutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._selectAlltoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._runForwardChainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._openLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._cleanNewFactsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._lbFactBase = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this._addRuleToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._removeRuleToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this._addConditionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._removeConditionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this._addFactToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._removeFactToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this._runForwardToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._cleanFactsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this._filePathToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _propertyKnowledge
            // 
            this._propertyKnowledge.BackColor = System.Drawing.Color.Lavender;
            this._propertyKnowledge.CommandsBackColor = System.Drawing.Color.Lavender;
            resources.ApplyResources(this._propertyKnowledge, "_propertyKnowledge");
            this._propertyKnowledge.LineColor = System.Drawing.SystemColors.ControlDark;
            this._propertyKnowledge.Name = "_propertyKnowledge";
            this._propertyKnowledge.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this._propertyKnowledge.Tag = "";
            this._propertyKnowledge.ViewBackColor = System.Drawing.Color.GhostWhite;
            this._propertyKnowledge.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this._propertyKnowledge_PropertyValueChanged);
            // 
            // _lbRuleBase
            // 
            this._lbRuleBase.BackColor = System.Drawing.Color.Cornsilk;
            resources.ApplyResources(this._lbRuleBase, "_lbRuleBase");
            this._lbRuleBase.FormattingEnabled = true;
            this._lbRuleBase.Name = "_lbRuleBase";
            this._lbRuleBase.SelectedIndexChanged += new System.EventHandler(this._lbRuleBase_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.HighlightText;
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem1,
            this._editToolStripMenuItem,
            this._runToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // _fileToolStripMenuItem1
            // 
            this._fileToolStripMenuItem1.BackColor = System.Drawing.Color.Lavender;
            this._fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._loadKnowledgeBaseToolStripMenuItem,
            this.toolStripSeparator1,
            this._saveFileToolStripMenuItem,
            this._saveAsFileToolStripMenuItem,
            this.toolStripSeparator2,
            this._newKnowledgeBaseToolStripMenuItem,
            this.toolStripSeparator3,
            this._exitToolStripMenuItem});
            this._fileToolStripMenuItem1.Name = "_fileToolStripMenuItem1";
            resources.ApplyResources(this._fileToolStripMenuItem1, "_fileToolStripMenuItem1");
            // 
            // _loadKnowledgeBaseToolStripMenuItem
            // 
            this._loadKnowledgeBaseToolStripMenuItem.Image = global::ExpertSystem.Properties.Resources.open;
            this._loadKnowledgeBaseToolStripMenuItem.Name = "_loadKnowledgeBaseToolStripMenuItem";
            resources.ApplyResources(this._loadKnowledgeBaseToolStripMenuItem, "_loadKnowledgeBaseToolStripMenuItem");
            this._loadKnowledgeBaseToolStripMenuItem.Click += new System.EventHandler(this._loadKnowledgeBaseToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // _saveFileToolStripMenuItem
            // 
            this._saveFileToolStripMenuItem.Image = global::ExpertSystem.Properties.Resources.save;
            this._saveFileToolStripMenuItem.Name = "_saveFileToolStripMenuItem";
            resources.ApplyResources(this._saveFileToolStripMenuItem, "_saveFileToolStripMenuItem");
            this._saveFileToolStripMenuItem.Click += new System.EventHandler(this._saveFileToolStripMenuItem_Click);
            // 
            // _saveAsFileToolStripMenuItem
            // 
            this._saveAsFileToolStripMenuItem.Name = "_saveAsFileToolStripMenuItem";
            resources.ApplyResources(this._saveAsFileToolStripMenuItem, "_saveAsFileToolStripMenuItem");
            this._saveAsFileToolStripMenuItem.Click += new System.EventHandler(this._saveAsFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // _newKnowledgeBaseToolStripMenuItem
            // 
            resources.ApplyResources(this._newKnowledgeBaseToolStripMenuItem, "_newKnowledgeBaseToolStripMenuItem");
            this._newKnowledgeBaseToolStripMenuItem.Name = "_newKnowledgeBaseToolStripMenuItem";
            this._newKnowledgeBaseToolStripMenuItem.Click += new System.EventHandler(this._newKnowledgeBaseToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // _exitToolStripMenuItem
            // 
            this._exitToolStripMenuItem.Image = global::ExpertSystem.Properties.Resources.exit;
            this._exitToolStripMenuItem.Name = "_exitToolStripMenuItem";
            resources.ApplyResources(this._exitToolStripMenuItem, "_exitToolStripMenuItem");
            this._exitToolStripMenuItem.Click += new System.EventHandler(this._exitToolStripMenuItem_Click);
            // 
            // _editToolStripMenuItem
            // 
            this._editToolStripMenuItem.BackColor = System.Drawing.Color.Lavender;
            this._editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._copyToolStripMenuItem1,
            this._pasteToolStripMenuItem1,
            this._cutToolStripMenuItem1,
            this._selectAlltoolStripMenuItem1});
            this._editToolStripMenuItem.Name = "_editToolStripMenuItem";
            resources.ApplyResources(this._editToolStripMenuItem, "_editToolStripMenuItem");
            // 
            // _copyToolStripMenuItem1
            // 
            this._copyToolStripMenuItem1.Image = global::ExpertSystem.Properties.Resources.copy;
            this._copyToolStripMenuItem1.Name = "_copyToolStripMenuItem1";
            resources.ApplyResources(this._copyToolStripMenuItem1, "_copyToolStripMenuItem1");
            this._copyToolStripMenuItem1.Click += new System.EventHandler(this._copyToolStripMenuItem1_Click);
            // 
            // _pasteToolStripMenuItem1
            // 
            this._pasteToolStripMenuItem1.Image = global::ExpertSystem.Properties.Resources.paste;
            this._pasteToolStripMenuItem1.Name = "_pasteToolStripMenuItem1";
            resources.ApplyResources(this._pasteToolStripMenuItem1, "_pasteToolStripMenuItem1");
            this._pasteToolStripMenuItem1.Click += new System.EventHandler(this._pasteToolStripMenuItem1_Click);
            // 
            // _cutToolStripMenuItem1
            // 
            this._cutToolStripMenuItem1.Image = global::ExpertSystem.Properties.Resources.cut;
            this._cutToolStripMenuItem1.Name = "_cutToolStripMenuItem1";
            resources.ApplyResources(this._cutToolStripMenuItem1, "_cutToolStripMenuItem1");
            this._cutToolStripMenuItem1.Click += new System.EventHandler(this._cutToolStripMenuItem1_Click);
            // 
            // _selectAlltoolStripMenuItem1
            // 
            this._selectAlltoolStripMenuItem1.Name = "_selectAlltoolStripMenuItem1";
            resources.ApplyResources(this._selectAlltoolStripMenuItem1, "_selectAlltoolStripMenuItem1");
            this._selectAlltoolStripMenuItem1.Click += new System.EventHandler(this._selectAlltoolStripMenuItem1_Click);
            // 
            // _runToolStripMenuItem
            // 
            this._runToolStripMenuItem.BackColor = System.Drawing.Color.Lavender;
            this._runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._runForwardChainingToolStripMenuItem,
            this.toolStripSeparator8,
            this.toolStripMenuItem1,
            this._cleanNewFactsToolStripMenuItem});
            this._runToolStripMenuItem.Name = "_runToolStripMenuItem";
            resources.ApplyResources(this._runToolStripMenuItem, "_runToolStripMenuItem");
            // 
            // _runForwardChainingToolStripMenuItem
            // 
            this._runForwardChainingToolStripMenuItem.Image = global::ExpertSystem.Properties.Resources.run;
            this._runForwardChainingToolStripMenuItem.Name = "_runForwardChainingToolStripMenuItem";
            resources.ApplyResources(this._runForwardChainingToolStripMenuItem, "_runForwardChainingToolStripMenuItem");
            this._runForwardChainingToolStripMenuItem.Click += new System.EventHandler(this._runForwardChainingToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openLogFileToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // _openLogFileToolStripMenuItem
            // 
            this._openLogFileToolStripMenuItem.Image = global::ExpertSystem.Properties.Resources.open;
            this._openLogFileToolStripMenuItem.Name = "_openLogFileToolStripMenuItem";
            resources.ApplyResources(this._openLogFileToolStripMenuItem, "_openLogFileToolStripMenuItem");
            this._openLogFileToolStripMenuItem.Click += new System.EventHandler(this._openLogFileToolStripMenuItem_Click);
            // 
            // _cleanNewFactsToolStripMenuItem
            // 
            this._cleanNewFactsToolStripMenuItem.Image = global::ExpertSystem.Properties.Resources.cleanfacts;
            this._cleanNewFactsToolStripMenuItem.Name = "_cleanNewFactsToolStripMenuItem";
            resources.ApplyResources(this._cleanNewFactsToolStripMenuItem, "_cleanNewFactsToolStripMenuItem");
            this._cleanNewFactsToolStripMenuItem.Click += new System.EventHandler(this._cleanNewFactsToolStripMenuItem_Click);
            // 
            // _lbFactBase
            // 
            this._lbFactBase.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this._lbFactBase, "_lbFactBase");
            this._lbFactBase.FormattingEnabled = true;
            this._lbFactBase.Name = "_lbFactBase";
            this._lbFactBase.SelectedIndexChanged += new System.EventHandler(this._listFactBase_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.SandyBrown;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.MediumAquamarine;
            this.label2.Name = "label2";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblName.Name = "lblName";
            // 
            // _txtName
            // 
            this._txtName.BackColor = System.Drawing.SystemColors.Menu;
            resources.ApplyResources(this._txtName, "_txtName");
            this._txtName.Name = "_txtName";
            this._txtName.TextChanged += new System.EventHandler(this._txtName_TextChanged);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._lbRuleBase);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._lbFactBase);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this._propertyKnowledge);
            this.groupBox2.Controls.Add(this._txtName);
            this.groupBox2.Controls.Add(this.lblName);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.groupBox2.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Name = "label3";
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this._addRuleToolStripButton,
            this._removeRuleToolStripButton,
            this.toolStripSeparator5,
            this.toolStripLabel3,
            this._addConditionToolStripButton,
            this._removeConditionToolStripButton,
            this.toolStripSeparator4,
            this.toolStripLabel1,
            this._addFactToolStripButton,
            this._removeFactToolStripButton,
            this.toolStripSeparator7,
            this.toolStripLabel5,
            this._runForwardToolStripButton,
            this._cleanFactsToolStripButton,
            this.toolStripSeparator9,
            this.toolStripLabel4,
            this._filePathToolStripTextBox});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            resources.ApplyResources(this.toolStripLabel2, "toolStripLabel2");
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.toolStripLabel2.Name = "toolStripLabel2";
            // 
            // _addRuleToolStripButton
            // 
            resources.ApplyResources(this._addRuleToolStripButton, "_addRuleToolStripButton");
            this._addRuleToolStripButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._addRuleToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._addRuleToolStripButton.Name = "_addRuleToolStripButton";
            this._addRuleToolStripButton.Click += new System.EventHandler(this._addRuleToolStripButton_Click);
            // 
            // _removeRuleToolStripButton
            // 
            resources.ApplyResources(this._removeRuleToolStripButton, "_removeRuleToolStripButton");
            this._removeRuleToolStripButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._removeRuleToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._removeRuleToolStripButton.Name = "_removeRuleToolStripButton";
            this._removeRuleToolStripButton.Click += new System.EventHandler(this._removeRuleToolStripButton_Click);
            // 
            // toolStripSeparator5
            // 
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            // 
            // toolStripLabel3
            // 
            resources.ApplyResources(this.toolStripLabel3, "toolStripLabel3");
            this.toolStripLabel3.Name = "toolStripLabel3";
            // 
            // _addConditionToolStripButton
            // 
            resources.ApplyResources(this._addConditionToolStripButton, "_addConditionToolStripButton");
            this._addConditionToolStripButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._addConditionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._addConditionToolStripButton.Name = "_addConditionToolStripButton";
            this._addConditionToolStripButton.Click += new System.EventHandler(this._addConditionToolStripButton_Click);
            // 
            // _removeConditionToolStripButton
            // 
            resources.ApplyResources(this._removeConditionToolStripButton, "_removeConditionToolStripButton");
            this._removeConditionToolStripButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._removeConditionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._removeConditionToolStripButton.Name = "_removeConditionToolStripButton";
            this._removeConditionToolStripButton.Click += new System.EventHandler(this._removeConditionToolStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // toolStripLabel1
            // 
            resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
            this.toolStripLabel1.Name = "toolStripLabel1";
            // 
            // _addFactToolStripButton
            // 
            resources.ApplyResources(this._addFactToolStripButton, "_addFactToolStripButton");
            this._addFactToolStripButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._addFactToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._addFactToolStripButton.Name = "_addFactToolStripButton";
            this._addFactToolStripButton.Click += new System.EventHandler(this._addFactToolStripButton_Click);
            // 
            // _removeFactToolStripButton
            // 
            resources.ApplyResources(this._removeFactToolStripButton, "_removeFactToolStripButton");
            this._removeFactToolStripButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._removeFactToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._removeFactToolStripButton.Name = "_removeFactToolStripButton";
            this._removeFactToolStripButton.Click += new System.EventHandler(this._removeFactToolStripButton_Click);
            // 
            // toolStripSeparator7
            // 
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            // 
            // toolStripLabel5
            // 
            resources.ApplyResources(this.toolStripLabel5, "toolStripLabel5");
            this.toolStripLabel5.Name = "toolStripLabel5";
            // 
            // _runForwardToolStripButton
            // 
            resources.ApplyResources(this._runForwardToolStripButton, "_runForwardToolStripButton");
            this._runForwardToolStripButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._runForwardToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._runForwardToolStripButton.Name = "_runForwardToolStripButton";
            this._runForwardToolStripButton.Click += new System.EventHandler(this._runForwardToolStripButton_Click);
            // 
            // _cleanFactsToolStripButton
            // 
            resources.ApplyResources(this._cleanFactsToolStripButton, "_cleanFactsToolStripButton");
            this._cleanFactsToolStripButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._cleanFactsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._cleanFactsToolStripButton.Name = "_cleanFactsToolStripButton";
            this._cleanFactsToolStripButton.Click += new System.EventHandler(this._cleanFactsToolStripButton_Click);
            // 
            // toolStripSeparator9
            // 
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            // 
            // toolStripLabel4
            // 
            resources.ApplyResources(this.toolStripLabel4, "toolStripLabel4");
            this.toolStripLabel4.Name = "toolStripLabel4";
            // 
            // _filePathToolStripTextBox
            // 
            resources.ApplyResources(this._filePathToolStripTextBox, "_filePathToolStripTextBox");
            this._filePathToolStripTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this._filePathToolStripTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this._filePathToolStripTextBox.Name = "_filePathToolStripTextBox";
            this._filePathToolStripTextBox.ReadOnly = true;
            this._filePathToolStripTextBox.DoubleClick += new System.EventHandler(this._filePathToolStripTextBox_DoubleClick);
            // 
            // ExpertSystemForm
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ExpertSystemForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox _lbRuleBase;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem _newKnowledgeBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _editToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem _copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem _pasteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem _cutToolStripMenuItem1;
        private System.Windows.Forms.ListBox _lbFactBase;
        private System.Windows.Forms.ToolStripMenuItem _loadKnowledgeBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _saveAsFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.ToolStripMenuItem _saveFileToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PropertyGrid _propertyKnowledge;
        private System.Windows.Forms.ToolStripMenuItem _selectAlltoolStripMenuItem1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton _addRuleToolStripButton;
        private System.Windows.Forms.ToolStripButton _removeRuleToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton _addConditionToolStripButton;
        private System.Windows.Forms.ToolStripButton _removeConditionToolStripButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton _addFactToolStripButton;
        private System.Windows.Forms.ToolStripButton _removeFactToolStripButton;
        private System.Windows.Forms.ToolStripButton _runForwardToolStripButton;
        private System.Windows.Forms.ToolStripButton _cleanFactsToolStripButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem _runForwardChainingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem _cleanNewFactsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox _filePathToolStripTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem _openLogFileToolStripMenuItem;
    }
}

