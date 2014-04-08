namespace ManyToManySearch
{
	partial class ManyToManySearchForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.inFolderTextBox = new System.Windows.Forms.TextBox();
			this.pickFolderButton = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.startSearchButton = new System.Windows.Forms.Button();
			this.invertSearchResultsCheckBox = new System.Windows.Forms.CheckBox();
			this.regularExpressionsCheckBox = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.searchResultsListBox = new System.Windows.Forms.ListBox();
			this.copyResultsToClipboardButton = new System.Windows.Forms.Button();
			this.doubleClickEditotPathTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.pickEditorButton = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.includeFilesTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.excludeFilesTextBox = new System.Windows.Forms.TextBox();
			this.excludeFoldersTextBox = new System.Windows.Forms.TextBox();
			this.includeFoldersTextBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.stringsToSearchTextBox = new System.Windows.Forms.RichTextBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 126);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "S&tring(s) to Search:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "In &Folder:";
			// 
			// inFolderTextBox
			// 
			this.inFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.inFolderTextBox.Location = new System.Drawing.Point(12, 25);
			this.inFolderTextBox.Name = "inFolderTextBox";
			this.inFolderTextBox.Size = new System.Drawing.Size(335, 20);
			this.inFolderTextBox.TabIndex = 1;
			this.inFolderTextBox.Text = "c:\\Projects\\Ameritox\\branchBugFixesJune2014\\src\\WebPortal\\";
			// 
			// pickFolderButton
			// 
			this.pickFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pickFolderButton.Location = new System.Drawing.Point(353, 25);
			this.pickFolderButton.Name = "pickFolderButton";
			this.pickFolderButton.Size = new System.Drawing.Size(26, 20);
			this.pickFolderButton.TabIndex = 2;
			this.pickFolderButton.Text = "&...";
			this.pickFolderButton.UseVisualStyleBackColor = true;
			this.pickFolderButton.Click += new System.EventHandler(this.pickFolderButton_Click);
			// 
			// startSearchButton
			// 
			this.startSearchButton.Location = new System.Drawing.Point(12, 261);
			this.startSearchButton.Name = "startSearchButton";
			this.startSearchButton.Size = new System.Drawing.Size(75, 23);
			this.startSearchButton.TabIndex = 11;
			this.startSearchButton.Text = "&Search";
			this.startSearchButton.UseVisualStyleBackColor = true;
			this.startSearchButton.Click += new System.EventHandler(this.startSearchButton_Click);
			// 
			// invertSearchResultsCheckBox
			// 
			this.invertSearchResultsCheckBox.AutoSize = true;
			this.invertSearchResultsCheckBox.Location = new System.Drawing.Point(12, 215);
			this.invertSearchResultsCheckBox.Name = "invertSearchResultsCheckBox";
			this.invertSearchResultsCheckBox.Size = new System.Drawing.Size(128, 17);
			this.invertSearchResultsCheckBox.TabIndex = 9;
			this.invertSearchResultsCheckBox.Text = "Invert Search Results";
			this.toolTip1.SetToolTip(this.invertSearchResultsCheckBox, "Display files NOT contaning any String(s) to Search");
			this.invertSearchResultsCheckBox.UseVisualStyleBackColor = true;
			// 
			// regularExpressionsCheckBox
			// 
			this.regularExpressionsCheckBox.AutoSize = true;
			this.regularExpressionsCheckBox.Location = new System.Drawing.Point(12, 238);
			this.regularExpressionsCheckBox.Name = "regularExpressionsCheckBox";
			this.regularExpressionsCheckBox.Size = new System.Drawing.Size(122, 17);
			this.regularExpressionsCheckBox.TabIndex = 10;
			this.regularExpressionsCheckBox.Text = "Regular Expressions";
			this.regularExpressionsCheckBox.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 308);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(82, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "Search Results:";
			// 
			// searchResultsListBox
			// 
			this.searchResultsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.searchResultsListBox.Location = new System.Drawing.Point(12, 324);
			this.searchResultsListBox.Name = "searchResultsListBox";
			this.searchResultsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.searchResultsListBox.Size = new System.Drawing.Size(367, 82);
			this.searchResultsListBox.TabIndex = 13;
			this.searchResultsListBox.DoubleClick += new System.EventHandler(this.searchResultsListBox_DoubleClick);
			// 
			// copyResultsToClipboardButton
			// 
			this.copyResultsToClipboardButton.Location = new System.Drawing.Point(0, 0);
			this.copyResultsToClipboardButton.Name = "copyResultsToClipboardButton";
			this.copyResultsToClipboardButton.Size = new System.Drawing.Size(205, 23);
			this.copyResultsToClipboardButton.TabIndex = 0;
			this.copyResultsToClipboardButton.Text = "Copy Selected Results to Clipboard";
			this.copyResultsToClipboardButton.UseVisualStyleBackColor = true;
			this.copyResultsToClipboardButton.Click += new System.EventHandler(this.copyResultsToClipboardButton_Click);
			// 
			// doubleClickEditotPathTextBox
			// 
			this.doubleClickEditotPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.doubleClickEditotPathTextBox.Location = new System.Drawing.Point(0, 42);
			this.doubleClickEditotPathTextBox.Name = "doubleClickEditotPathTextBox";
			this.doubleClickEditotPathTextBox.Size = new System.Drawing.Size(335, 20);
			this.doubleClickEditotPathTextBox.TabIndex = 2;
			this.doubleClickEditotPathTextBox.Text = "C:\\Desktop\\Dropbox\\Utils\\Editors\\Notepad++\\notepad++.exe";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(-3, 26);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(150, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "Editor for Results double click:";
			// 
			// pickEditorButton
			// 
			this.pickEditorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pickEditorButton.Location = new System.Drawing.Point(341, 42);
			this.pickEditorButton.Name = "pickEditorButton";
			this.pickEditorButton.Size = new System.Drawing.Size(26, 20);
			this.pickEditorButton.TabIndex = 3;
			this.pickEditorButton.Text = "&...";
			this.pickEditorButton.UseVisualStyleBackColor = true;
			this.pickEditorButton.Click += new System.EventHandler(this.pickEditorButton_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.copyResultsToClipboardButton);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.doubleClickEditotPathTextBox);
			this.panel1.Controls.Add(this.pickEditorButton);
			this.panel1.Location = new System.Drawing.Point(12, 416);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(367, 69);
			this.panel1.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(107, 13);
			this.label5.TabIndex = 3;
			this.label5.Text = "Include files RegExp:";
			// 
			// includeFilesTextBox
			// 
			this.includeFilesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.includeFilesTextBox.Location = new System.Drawing.Point(12, 64);
			this.includeFilesTextBox.Name = "includeFilesTextBox";
			this.includeFilesTextBox.Size = new System.Drawing.Size(183, 20);
			this.includeFilesTextBox.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(200, 48);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(110, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "Exclude files RegExp:";
			// 
			// excludeFilesTextBox
			// 
			this.excludeFilesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.excludeFilesTextBox.Location = new System.Drawing.Point(203, 64);
			this.excludeFilesTextBox.Name = "excludeFilesTextBox";
			this.excludeFilesTextBox.Size = new System.Drawing.Size(176, 20);
			this.excludeFilesTextBox.TabIndex = 6;
			this.excludeFilesTextBox.Text = "(.*\\.exe)|(.*\\.pdb)|(.*\\.dll)|(.*\\.pdf)";
			// 
			// excludeFoldersTextBox
			// 
			this.excludeFoldersTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.excludeFoldersTextBox.Location = new System.Drawing.Point(203, 103);
			this.excludeFoldersTextBox.Name = "excludeFoldersTextBox";
			this.excludeFoldersTextBox.Size = new System.Drawing.Size(176, 20);
			this.excludeFoldersTextBox.TabIndex = 17;
			this.excludeFoldersTextBox.Text = "(\\\\bin$)|(\\\\obj$)|(\\\\.svn)";
			// 
			// includeFoldersTextBox
			// 
			this.includeFoldersTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.includeFoldersTextBox.Location = new System.Drawing.Point(12, 103);
			this.includeFoldersTextBox.Name = "includeFoldersTextBox";
			this.includeFoldersTextBox.Size = new System.Drawing.Size(183, 20);
			this.includeFoldersTextBox.TabIndex = 15;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(200, 87);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(123, 13);
			this.label7.TabIndex = 16;
			this.label7.Text = "Exclude folders RegExp:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(9, 87);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(120, 13);
			this.label8.TabIndex = 14;
			this.label8.Text = "Include folders RegExp:";
			// 
			// stringsToSearchTextBox
			// 
			this.stringsToSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.stringsToSearchTextBox.Location = new System.Drawing.Point(12, 142);
			this.stringsToSearchTextBox.Name = "stringsToSearchTextBox";
			this.stringsToSearchTextBox.Size = new System.Drawing.Size(367, 67);
			this.stringsToSearchTextBox.TabIndex = 18;
			this.stringsToSearchTextBox.Text = "bootstrap.min.css\nDatePicker.css\ndefault.css\njquery-ui.css\nlayout.css\nLoggedIn.cs" +
    "s\nModalDialog.css\nNotLoggedIn.css\nOLROnePage.css\nReports.css\nSearchPatientCss.cs" +
    "s";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 490);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(392, 22);
			this.statusStrip1.TabIndex = 19;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// ManyToManySearchForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(392, 512);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.stringsToSearchTextBox);
			this.Controls.Add(this.excludeFoldersTextBox);
			this.Controls.Add(this.includeFoldersTextBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.searchResultsListBox);
			this.Controls.Add(this.regularExpressionsCheckBox);
			this.Controls.Add(this.invertSearchResultsCheckBox);
			this.Controls.Add(this.startSearchButton);
			this.Controls.Add(this.pickFolderButton);
			this.Controls.Add(this.excludeFilesTextBox);
			this.Controls.Add(this.includeFilesTextBox);
			this.Controls.Add(this.inFolderTextBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.MinimumSize = new System.Drawing.Size(400, 550);
			this.Name = "ManyToManySearchForm";
			this.Text = "Many to Many Search";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox inFolderTextBox;
		private System.Windows.Forms.Button pickFolderButton;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button startSearchButton;
		private System.Windows.Forms.CheckBox invertSearchResultsCheckBox;
		private System.Windows.Forms.CheckBox regularExpressionsCheckBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox searchResultsListBox;
		private System.Windows.Forms.Button copyResultsToClipboardButton;
		private System.Windows.Forms.TextBox doubleClickEditotPathTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button pickEditorButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox includeFilesTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox excludeFilesTextBox;
		private System.Windows.Forms.TextBox excludeFoldersTextBox;
		private System.Windows.Forms.TextBox includeFoldersTextBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.RichTextBox stringsToSearchTextBox;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
	}
}

