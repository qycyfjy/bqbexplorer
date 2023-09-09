namespace BqbExplorer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            noPreviewItemsToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            entriesTreeView = new TreeView();
            openFileDialog1 = new OpenFileDialog();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 25);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, noPreviewItemsToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(39, 21);
            fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "打开";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // noPreviewItemsToolStripMenuItem
            // 
            noPreviewItemsToolStripMenuItem.CheckOnClick = true;
            noPreviewItemsToolStripMenuItem.Name = "noPreviewItemsToolStripMenuItem";
            noPreviewItemsToolStripMenuItem.Size = new Size(180, 22);
            noPreviewItemsToolStripMenuItem.Text = "不显示预览图";
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(9, 25);
            splitContainer1.Margin = new Padding(0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(entriesTreeView);
            splitContainer1.Size = new Size(782, 416);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.SplitterWidth = 6;
            splitContainer1.TabIndex = 1;
            // 
            // entriesTreeView
            // 
            entriesTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            entriesTreeView.BorderStyle = BorderStyle.None;
            entriesTreeView.Location = new Point(-1, 0);
            entriesTreeView.Margin = new Padding(0);
            entriesTreeView.Name = "entriesTreeView";
            entriesTreeView.Size = new Size(265, 414);
            entriesTreeView.TabIndex = 0;
            entriesTreeView.NodeMouseClick += entriesTreeView_NodeMouseClick;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "表情包浏览器";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private SplitContainer splitContainer1;
        private TreeView entriesTreeView;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem noPreviewItemsToolStripMenuItem;
    }
}