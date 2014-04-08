using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ManyToManySearch
{
	public partial class ManyToManySearchForm : Form
	{
		public ManyToManySearchForm()
		{
			InitializeComponent();

			var uiConfig = new FormUIconfigSupport(this);
			uiConfig.AddCustomParamProvider(inFolderTextBox);
			uiConfig.AddCustomParamProvider(includeFilesTextBox);
			uiConfig.AddCustomParamProvider(includeFoldersTextBox);
			uiConfig.AddCustomParamProvider(excludeFilesTextBox);
			uiConfig.AddCustomParamProvider(excludeFoldersTextBox);
			uiConfig.AddCustomParamProvider(stringsToSearchTextBox);
			uiConfig.AddCustomParamProvider(invertSearchResultsCheckBox);
			uiConfig.AddCustomParamProvider(regularExpressionsCheckBox);
			uiConfig.AddCustomParamProvider(doubleClickEditorPathTextBox);
			uiConfig.AddCustomParamProvider(splitContainer1);
		}

		private void pickFolderButton_Click(object sender, EventArgs e)
		{
			var result = folderBrowserDialog1.ShowDialog(this);
			if(result == DialogResult.Cancel) return;
			inFolderTextBox.Text = folderBrowserDialog1.SelectedPath;
		}

		private void startSearchButton_Click(object sender, EventArgs e)
		{
			if(string.IsNullOrWhiteSpace(inFolderTextBox.Text) || !Directory.Exists(inFolderTextBox.Text))
			{
				MessageBox.Show(this, "Please specify correct folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if(string.IsNullOrWhiteSpace(stringsToSearchTextBox.Text))
			{
				MessageBox.Show(this, "Please specify string(s) to search", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var results = new Dictionary<string, List<string>>();
			foreach(var key in stringsToSearchTextBox.Text.Split(new[] {'\r', '\n'}))
			{
				if(string.IsNullOrWhiteSpace(key)) continue;
				results.Add(key, new List<string>());
			}
			SearchFolder(results, inFolderTextBox.Text);
			searchResultsListBox.Items.Clear();

			foreach(var pair in results)
			{
				pair.Value.Sort();
				searchResultsListBox.Items.Add(string.Format("{0} found in {1} files", pair.Key, pair.Value.Count));
				pair.Value.ForEach(file => searchResultsListBox.Items.Add(file));
				searchResultsListBox.Items.Add(string.Empty);
			}
		}

		private void SearchFolder(Dictionary<string, List<string>> results, string path)
		{
			foreach(var file in Directory.GetFiles(path))
			{
				if(!string.IsNullOrWhiteSpace(includeFilesTextBox.Text) && !Regex.IsMatch(file, includeFilesTextBox.Text)) continue;
				if(!string.IsNullOrWhiteSpace(excludeFilesTextBox.Text) && Regex.IsMatch(file, excludeFilesTextBox.Text)) continue;
				var readAllText = File.ReadAllText(file);

				foreach(var pair in results)
				{
					var contains = regularExpressionsCheckBox.Checked ? Regex.IsMatch(readAllText, pair.Key) : readAllText.Contains(pair.Key);
					if(contains ^ invertSearchResultsCheckBox.Checked)
						pair.Value.Add("   " + file);
				}
			}

			foreach(var directory in Directory.GetDirectories(path))
			{
				if(!string.IsNullOrWhiteSpace(includeFoldersTextBox.Text) && !Regex.IsMatch(directory, includeFoldersTextBox.Text)) continue;
				if(!string.IsNullOrWhiteSpace(excludeFoldersTextBox.Text) && Regex.IsMatch(directory, excludeFoldersTextBox.Text)) continue;
				SearchFolder(results, directory);
			}
		}

		private void searchResultsListBox_DoubleClick(object sender, EventArgs e)
		{
			foreach(var selectedItem in searchResultsListBox.SelectedItems)
			{
				if(!( selectedItem is string )) continue;
				var selectedFile = ( (string)selectedItem ).Trim();
				if(File.Exists(selectedFile) && File.Exists(doubleClickEditorPathTextBox.Text))
				{
					if(selectedFile.Contains(" ")) selectedFile = string.Format("\"{0}\"", selectedFile);
					Process.Start(doubleClickEditorPathTextBox.Text, selectedFile);
				}
			}
		}

		private void pickEditorButton_Click(object sender, EventArgs e)
		{
			if(openFileDialog1.ShowDialog(this) == DialogResult.Cancel) return;
			doubleClickEditorPathTextBox.Text = openFileDialog1.FileName;
		}

		private void copyResultsToClipboardButton_Click(object sender, EventArgs e)
		{
			var sb = new StringBuilder();
			foreach(var selectedItem in searchResultsListBox.SelectedItems.Count > 0 ? (IList)searchResultsListBox.SelectedItems : (IList)searchResultsListBox.Items)
			{
				if(!( selectedItem is string )) continue;
				sb.AppendLine((string)selectedItem);
			}
			if(sb.Length > 0)
				Clipboard.SetText(sb.ToString());
		}
	}
}