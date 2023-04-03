

namespace SmokeShopVideo
{
    //partial class Form1
    //{
    //    /// <summary>
    //    /// Required designer variable.
    //    /// </summary>
    //    private System.ComponentModel.IContainer components = null;

    //    /// <summary>
    //    /// Clean up any resources being used.
    //    /// </summary>
    //    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && (components != null))
    //        {
    //            components.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }

    //    #region Windows Form Designer generated code

    //    /// <summary>
    //    /// Required method for Designer support - do not modify
    //    /// the contents of this method with the code editor.
    //    /// </summary>
    //    private void InitializeComponent()
    //    {
    //        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
    //        this.webView1 = new Microsoft.Toolkit.Forms.UI.Controls.WebView();
    //        ((System.ComponentModel.ISupportInitialize)(this.webView1)).BeginInit();
    //        this.SuspendLayout();
    //        // 
    //        // webView1
    //        // 
    //        resources.ApplyResources(this.webView1, "webView1");
    //        this.webView1.Name = "webView1";
    //        this.webView1.DOMContentLoaded += new System.EventHandler<Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlDOMContentLoadedEventArgs>(this.webView1_DOMContentLoaded);
    //        this.webView1.ScriptNotify += new System.EventHandler<Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlScriptNotifyEventArgs>(this.webView1_ScriptNotify);
    //        // 
    //        // Form1
    //        // 
    //        resources.ApplyResources(this, "$this");
    //        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    //        this.Controls.Add(this.webView1);
    //        this.Name = "Form1";
    //        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
    //        this.Load += new System.EventHandler(this.Form1_Load);
    //        ((System.ComponentModel.ISupportInitialize)(this.webView1)).EndInit();
    //        this.ResumeLayout(false);

    //    }

    //    #endregion
    //    private Microsoft.Toolkit.Forms.UI.Controls.WebView webView1;
    //}
//    partial class Form2
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
//            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
//            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.LoadFolder = new System.Windows.Forms.ToolStripMenuItem();
//            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
//            this.ListOfVideos = new System.Windows.Forms.ListBox();
//            this.FileName = new System.Windows.Forms.Label();
//            this.duration = new System.Windows.Forms.Label();
//            this.timer1 = new System.Windows.Forms.Timer(this.components);
//            this.MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
//            this.menuStrip1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // menuStrip1
//            // 
//            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.fileToolStripMenuItem,
//            this.versionToolStripMenuItem});
//            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
//            this.menuStrip1.Name = "menuStrip1";
//            this.menuStrip1.Size = new System.Drawing.Size(805, 24);
//            this.menuStrip1.TabIndex = 0;
//            this.menuStrip1.Text = "menuStrip1";
//            // 
//            // fileToolStripMenuItem
//            // 
//            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.LoadFolder,
//            this.aboutToolStripMenuItem,
//            this.exitToolStripMenuItem});
//            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
//            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
//            this.fileToolStripMenuItem.Text = "File";
//            // 
//            // LoadFolder
//            // 
//            this.LoadFolder.Name = "LoadFolder";
//            this.LoadFolder.Size = new System.Drawing.Size(151, 22);
//            this.LoadFolder.Text = "Load Directory";
//            this.LoadFolder.Click += new System.EventHandler(this.LoadDirectory);
//            // 
//            // aboutToolStripMenuItem
//            // 
//            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
//            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
//            this.aboutToolStripMenuItem.Text = "About";
//            // 
//            // exitToolStripMenuItem
//            // 
//            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
//            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
//            this.exitToolStripMenuItem.Text = "Exit";
//            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit);
//            // 
//            // versionToolStripMenuItem
//            // 
//            this.versionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.toolStripMenuItem2});
//            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
//            this.versionToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
//            this.versionToolStripMenuItem.Text = "Version";
//            // 
//            // toolStripMenuItem2
//            // 
//            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
//            this.toolStripMenuItem2.Size = new System.Drawing.Size(89, 22);
//            this.toolStripMenuItem2.Text = "1.0";
//            // 
//            // ListOfVideos
//            // 
//            this.ListOfVideos.FormattingEnabled = true;
//            this.ListOfVideos.Location = new System.Drawing.Point(608, 39);
//            this.ListOfVideos.Name = "ListOfVideos";
//            this.ListOfVideos.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
//            this.ListOfVideos.Size = new System.Drawing.Size(180, 394);
//            this.ListOfVideos.TabIndex = 2;
//            this.ListOfVideos.Visible = false;
//            this.ListOfVideos.SelectedIndexChanged += new System.EventHandler(this.PlayList);
//            // 
//            // FileName
//            // 
//            this.FileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
//            this.FileName.AutoSize = true;
//            this.FileName.Font = new System.Drawing.Font("Sitka Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.FileName.Location = new System.Drawing.Point(13, 448);
//            this.FileName.Name = "FileName";
//            this.FileName.Size = new System.Drawing.Size(59, 16);
//            this.FileName.TabIndex = 3;
//            this.FileName.Text = "File Name";
//            this.FileName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
//            this.FileName.Click += new System.EventHandler(this.label1_Click);
//            // 
//            // duration
//            // 
//            this.duration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
//            this.duration.AutoSize = true;
//            this.duration.Location = new System.Drawing.Point(550, 448);
//            this.duration.Name = "duration";
//            this.duration.Size = new System.Drawing.Size(32, 13);
//            this.duration.TabIndex = 4;
//            this.duration.Text = "State";
//            this.duration.TextAlign = System.Drawing.ContentAlignment.BottomRight;
//            this.duration.Click += new System.EventHandler(this.label1_Click_1);
//            // 
//            // timer1
//            // 
//            this.timer1.Tick += new System.EventHandler(this.TimerEvent);
//            // 
//            // MediaPlayer
//            // 
//            this.MediaPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//            | System.Windows.Forms.AnchorStyles.Left)
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.MediaPlayer.Enabled = true;
//            this.MediaPlayer.Location = new System.Drawing.Point(12, 27);
//            this.MediaPlayer.Name = "MediaPlayer";
//            this.MediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MediaPlayer.OcxState")));
//            this.MediaPlayer.Size = new System.Drawing.Size(781, 413);
//            this.MediaPlayer.TabIndex = 1;
//            this.MediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.StateChangeEvent);
//            this.MediaPlayer.Enter += new System.EventHandler(this.MediaPlayer_Enter);
//            // 
//            // Form1
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(805, 469);
//            this.Controls.Add(this.duration);
//            this.Controls.Add(this.FileName);
////            this.Controls.Add(this.MediaPlayer);
//            this.Controls.Add(this.menuStrip1);
//            this.Controls.Add(this.ListOfVideos);
//            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
//            this.MainMenuStrip = this.menuStrip1;
//            this.Name = "Form1";
//            this.Text = "Media Player";
//            this.Load += new System.EventHandler(this.Form1_Load);
//            this.menuStrip1.ResumeLayout(false);
//            this.menuStrip1.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.MenuStrip menuStrip1;
//        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
//        private System.Windows.Forms.ToolStripMenuItem LoadFolder;
//        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
//        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
//        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
//        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
//        private AxWMPLib.AxWindowsMediaPlayer MediaPlayer;
//        private System.Windows.Forms.ListBox ListOfVideos;
//        private System.Windows.Forms.Label FileName;
//        private System.Windows.Forms.Label duration;
//        private System.Windows.Forms.Timer timer1;
//    }
}

