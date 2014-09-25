namespace MYMusic
{
    partial class frmmain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmmain));
            this.lbllogo = new System.Windows.Forms.Label();
            this.lblchangeskin = new System.Windows.Forms.Label();
            this.lblmin = new System.Windows.Forms.Label();
            this.lblclose = new System.Windows.Forms.Label();
            this.lblrealtime = new System.Windows.Forms.Label();
            this.lbltimeline = new System.Windows.Forms.Label();
            this.lblstarttime = new System.Windows.Forms.Label();
            this.lblendtime = new System.Windows.Forms.Label();
            this.lblvolume = new System.Windows.Forms.Label();
            this.lblvolumeline = new System.Windows.Forms.Label();
            this.picprevious = new System.Windows.Forms.PictureBox();
            this.picplay = new System.Windows.Forms.PictureBox();
            this.picnext = new System.Windows.Forms.PictureBox();
            this.piclike = new System.Windows.Forms.PictureBox();
            this.picadd = new System.Windows.Forms.PictureBox();
            this.chktopform = new System.Windows.Forms.CheckBox();
            this.tmrtimeline = new System.Windows.Forms.Timer(this.components);
            this.helpmsg = new System.Windows.Forms.ToolTip(this.components);
            this.cmsmain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.导入播放列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.导入喜欢列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除喜欢列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.打开皮肤文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblinfo = new System.Windows.Forms.Label();
            this.MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.FileChoose = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picprevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picnext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piclike)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picadd)).BeginInit();
            this.cmsmain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // lbllogo
            // 
            this.lbllogo.BackColor = System.Drawing.Color.Transparent;
            this.lbllogo.ForeColor = System.Drawing.Color.OrangeRed;
            resources.ApplyResources(this.lbllogo, "lbllogo");
            this.lbllogo.Name = "lbllogo";
            this.helpmsg.SetToolTip(this.lbllogo, resources.GetString("lbllogo.ToolTip"));
            this.lbllogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbllogo_MouseDown);
            this.lbllogo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbllogo_MouseMove);
            this.lbllogo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbllogo_MouseUp);
            // 
            // lblchangeskin
            // 
            this.lblchangeskin.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblchangeskin, "lblchangeskin");
            this.lblchangeskin.ForeColor = System.Drawing.Color.White;
            this.lblchangeskin.Name = "lblchangeskin";
            this.helpmsg.SetToolTip(this.lblchangeskin, resources.GetString("lblchangeskin.ToolTip"));
            this.lblchangeskin.Click += new System.EventHandler(this.lblchangeskin_Click);
            this.lblchangeskin.MouseLeave += new System.EventHandler(this.lblchangeskin_MouseLeave);
            this.lblchangeskin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblchangeskin_MouseMove);
            // 
            // lblmin
            // 
            this.lblmin.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblmin, "lblmin");
            this.lblmin.ForeColor = System.Drawing.Color.White;
            this.lblmin.Name = "lblmin";
            this.lblmin.Click += new System.EventHandler(this.lblmin_Click);
            this.lblmin.MouseLeave += new System.EventHandler(this.lblmin_MouseLeave);
            this.lblmin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblmin_MouseMove);
            // 
            // lblclose
            // 
            this.lblclose.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblclose, "lblclose");
            this.lblclose.ForeColor = System.Drawing.Color.White;
            this.lblclose.Name = "lblclose";
            this.lblclose.Click += new System.EventHandler(this.lblclose_Click);
            this.lblclose.MouseLeave += new System.EventHandler(this.lblclose_MouseLeave);
            this.lblclose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblclose_MouseMove);
            // 
            // lblrealtime
            // 
            this.lblrealtime.BackColor = System.Drawing.Color.White;
            this.lblrealtime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblrealtime.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblrealtime, "lblrealtime");
            this.lblrealtime.Name = "lblrealtime";
            this.helpmsg.SetToolTip(this.lblrealtime, resources.GetString("lblrealtime.ToolTip"));
            this.lblrealtime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblrealtime_MouseDown);
            this.lblrealtime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblrealtime_MouseMove);
            // 
            // lbltimeline
            // 
            this.lbltimeline.BackColor = System.Drawing.Color.Black;
            this.lbltimeline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbltimeline.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lbltimeline, "lbltimeline");
            this.lbltimeline.Name = "lbltimeline";
            this.helpmsg.SetToolTip(this.lbltimeline, resources.GetString("lbltimeline.ToolTip"));
            this.lbltimeline.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbltimeline_MouseDown);
            this.lbltimeline.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbltimeline_MouseMove);
            // 
            // lblstarttime
            // 
            this.lblstarttime.BackColor = System.Drawing.Color.Transparent;
            this.lblstarttime.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblstarttime, "lblstarttime");
            this.lblstarttime.Name = "lblstarttime";
            // 
            // lblendtime
            // 
            this.lblendtime.BackColor = System.Drawing.Color.Transparent;
            this.lblendtime.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblendtime, "lblendtime");
            this.lblendtime.Name = "lblendtime";
            // 
            // lblvolume
            // 
            this.lblvolume.BackColor = System.Drawing.Color.White;
            this.lblvolume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblvolume.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblvolume, "lblvolume");
            this.lblvolume.Name = "lblvolume";
            this.helpmsg.SetToolTip(this.lblvolume, resources.GetString("lblvolume.ToolTip"));
            this.lblvolume.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblvolume_MouseDown);
            this.lblvolume.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblvolume_MouseMove);
            // 
            // lblvolumeline
            // 
            this.lblvolumeline.BackColor = System.Drawing.Color.Black;
            this.lblvolumeline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblvolumeline.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblvolumeline, "lblvolumeline");
            this.lblvolumeline.Name = "lblvolumeline";
            this.helpmsg.SetToolTip(this.lblvolumeline, resources.GetString("lblvolumeline.ToolTip"));
            this.lblvolumeline.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblvolumeline_MouseDown);
            this.lblvolumeline.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblvolumeline_MouseMove);
            // 
            // picprevious
            // 
            this.picprevious.BackColor = System.Drawing.Color.Transparent;
            this.picprevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picprevious.Image = global::MYMusic.Properties.Resources.previous;
            resources.ApplyResources(this.picprevious, "picprevious");
            this.picprevious.Name = "picprevious";
            this.picprevious.TabStop = false;
            this.helpmsg.SetToolTip(this.picprevious, resources.GetString("picprevious.ToolTip"));
            this.picprevious.Click += new System.EventHandler(this.picprevious_Click);
            this.picprevious.MouseLeave += new System.EventHandler(this.picprevious_MouseLeave);
            this.picprevious.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picprevious_MouseMove);
            // 
            // picplay
            // 
            this.picplay.BackColor = System.Drawing.Color.Transparent;
            this.picplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picplay.Image = global::MYMusic.Properties.Resources.play;
            resources.ApplyResources(this.picplay, "picplay");
            this.picplay.Name = "picplay";
            this.picplay.TabStop = false;
            this.helpmsg.SetToolTip(this.picplay, resources.GetString("picplay.ToolTip"));
            this.picplay.Click += new System.EventHandler(this.picplay_Click);
            this.picplay.MouseLeave += new System.EventHandler(this.picplay_MouseLeave);
            this.picplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picplay_MouseMove);
            // 
            // picnext
            // 
            this.picnext.BackColor = System.Drawing.Color.Transparent;
            this.picnext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picnext.Image = global::MYMusic.Properties.Resources.next;
            resources.ApplyResources(this.picnext, "picnext");
            this.picnext.Name = "picnext";
            this.picnext.TabStop = false;
            this.helpmsg.SetToolTip(this.picnext, resources.GetString("picnext.ToolTip"));
            this.picnext.Click += new System.EventHandler(this.picnext_Click);
            this.picnext.MouseLeave += new System.EventHandler(this.picnext_MouseLeave);
            this.picnext.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picnext_MouseMove);
            // 
            // piclike
            // 
            this.piclike.BackColor = System.Drawing.Color.Transparent;
            this.piclike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.piclike.Image = global::MYMusic.Properties.Resources.favorite;
            resources.ApplyResources(this.piclike, "piclike");
            this.piclike.Name = "piclike";
            this.piclike.TabStop = false;
            this.helpmsg.SetToolTip(this.piclike, resources.GetString("piclike.ToolTip"));
            this.piclike.Click += new System.EventHandler(this.piclike_Click);
            this.piclike.MouseLeave += new System.EventHandler(this.piclike_MouseLeave);
            this.piclike.MouseMove += new System.Windows.Forms.MouseEventHandler(this.piclike_MouseMove);
            // 
            // picadd
            // 
            this.picadd.BackColor = System.Drawing.Color.Transparent;
            this.picadd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picadd.Image = global::MYMusic.Properties.Resources.add;
            resources.ApplyResources(this.picadd, "picadd");
            this.picadd.Name = "picadd";
            this.picadd.TabStop = false;
            this.helpmsg.SetToolTip(this.picadd, resources.GetString("picadd.ToolTip"));
            this.picadd.Click += new System.EventHandler(this.picadd_Click);
            this.picadd.MouseLeave += new System.EventHandler(this.picadd_MouseLeave);
            this.picadd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picadd_MouseMove);
            // 
            // chktopform
            // 
            resources.ApplyResources(this.chktopform, "chktopform");
            this.chktopform.BackColor = System.Drawing.Color.Transparent;
            this.chktopform.Checked = true;
            this.chktopform.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chktopform.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chktopform.ForeColor = System.Drawing.Color.White;
            this.chktopform.Name = "chktopform";
            this.helpmsg.SetToolTip(this.chktopform, resources.GetString("chktopform.ToolTip"));
            this.chktopform.UseVisualStyleBackColor = false;
            this.chktopform.CheckedChanged += new System.EventHandler(this.chktopform_CheckedChanged);
            // 
            // tmrtimeline
            // 
            this.tmrtimeline.Tick += new System.EventHandler(this.tmrtimeline_Tick);
            // 
            // helpmsg
            // 
            this.helpmsg.ForeColor = System.Drawing.SystemColors.Highlight;
            // 
            // cmsmain
            // 
            resources.ApplyResources(this.cmsmain, "cmsmain");
            this.cmsmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入播放列表ToolStripMenuItem,
            this.清除列表ToolStripMenuItem,
            this.toolStripSeparator2,
            this.导入喜欢列表ToolStripMenuItem,
            this.清除喜欢列表ToolStripMenuItem,
            this.toolStripSeparator1,
            this.打开皮肤文件夹ToolStripMenuItem,
            this.toolStripSeparator3,
            this.关于ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.cmsmain.Name = "cmsmain";
            // 
            // 导入播放列表ToolStripMenuItem
            // 
            this.导入播放列表ToolStripMenuItem.Name = "导入播放列表ToolStripMenuItem";
            resources.ApplyResources(this.导入播放列表ToolStripMenuItem, "导入播放列表ToolStripMenuItem");
            this.导入播放列表ToolStripMenuItem.Click += new System.EventHandler(this.导入播放列表ToolStripMenuItem_Click);
            // 
            // 清除列表ToolStripMenuItem
            // 
            this.清除列表ToolStripMenuItem.Name = "清除列表ToolStripMenuItem";
            resources.ApplyResources(this.清除列表ToolStripMenuItem, "清除列表ToolStripMenuItem");
            this.清除列表ToolStripMenuItem.Click += new System.EventHandler(this.清除列表ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // 导入喜欢列表ToolStripMenuItem
            // 
            this.导入喜欢列表ToolStripMenuItem.Name = "导入喜欢列表ToolStripMenuItem";
            resources.ApplyResources(this.导入喜欢列表ToolStripMenuItem, "导入喜欢列表ToolStripMenuItem");
            this.导入喜欢列表ToolStripMenuItem.Click += new System.EventHandler(this.导入喜欢列表ToolStripMenuItem_Click);
            // 
            // 清除喜欢列表ToolStripMenuItem
            // 
            this.清除喜欢列表ToolStripMenuItem.Name = "清除喜欢列表ToolStripMenuItem";
            resources.ApplyResources(this.清除喜欢列表ToolStripMenuItem, "清除喜欢列表ToolStripMenuItem");
            this.清除喜欢列表ToolStripMenuItem.Click += new System.EventHandler(this.清除喜欢列表ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // 打开皮肤文件夹ToolStripMenuItem
            // 
            this.打开皮肤文件夹ToolStripMenuItem.Name = "打开皮肤文件夹ToolStripMenuItem";
            resources.ApplyResources(this.打开皮肤文件夹ToolStripMenuItem, "打开皮肤文件夹ToolStripMenuItem");
            this.打开皮肤文件夹ToolStripMenuItem.Click += new System.EventHandler(this.打开皮肤文件夹ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            resources.ApplyResources(this.关于ToolStripMenuItem, "关于ToolStripMenuItem");
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            resources.ApplyResources(this.退出ToolStripMenuItem, "退出ToolStripMenuItem");
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // lblinfo
            // 
            this.lblinfo.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblinfo, "lblinfo");
            this.lblinfo.ForeColor = System.Drawing.Color.White;
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblinfo_MouseDown);
            this.lblinfo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblinfo_MouseMove);
            this.lblinfo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblinfo_MouseUp);
            // 
            // MediaPlayer
            // 
            resources.ApplyResources(this.MediaPlayer, "MediaPlayer");
            this.MediaPlayer.Name = "MediaPlayer";
            this.MediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MediaPlayer.OcxState")));
            this.MediaPlayer.TabStop = false;
            // 
            // frmmain
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MYMusic.Properties.Resources.BackImage;
            this.ContextMenuStrip = this.cmsmain;
            this.Controls.Add(this.MediaPlayer);
            this.Controls.Add(this.lblinfo);
            this.Controls.Add(this.chktopform);
            this.Controls.Add(this.picadd);
            this.Controls.Add(this.piclike);
            this.Controls.Add(this.picnext);
            this.Controls.Add(this.picplay);
            this.Controls.Add(this.picprevious);
            this.Controls.Add(this.lblvolume);
            this.Controls.Add(this.lblendtime);
            this.Controls.Add(this.lblstarttime);
            this.Controls.Add(this.lblrealtime);
            this.Controls.Add(this.lblclose);
            this.Controls.Add(this.lblmin);
            this.Controls.Add(this.lblchangeskin);
            this.Controls.Add(this.lbllogo);
            this.Controls.Add(this.lbltimeline);
            this.Controls.Add(this.lblvolumeline);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmmain";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmmain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmmain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmmain_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmmain_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmmain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmmain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmmain_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.picprevious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picnext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piclike)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picadd)).EndInit();
            this.cmsmain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbllogo;
        private System.Windows.Forms.Label lblchangeskin;
        private System.Windows.Forms.Label lblmin;
        private System.Windows.Forms.Label lblclose;
        private System.Windows.Forms.Label lblrealtime;
        private System.Windows.Forms.Label lbltimeline;
        private System.Windows.Forms.Label lblstarttime;
        private System.Windows.Forms.Label lblendtime;
        private System.Windows.Forms.Label lblvolume;
        private System.Windows.Forms.Label lblvolumeline;
        private System.Windows.Forms.PictureBox picprevious;
        private System.Windows.Forms.PictureBox picplay;
        private System.Windows.Forms.PictureBox picnext;
        private System.Windows.Forms.PictureBox piclike;
        private System.Windows.Forms.PictureBox picadd;
        private System.Windows.Forms.CheckBox chktopform;
        private System.Windows.Forms.Timer tmrtimeline;
        private System.Windows.Forms.ToolTip helpmsg;
        private System.Windows.Forms.ContextMenuStrip cmsmain;
        private System.Windows.Forms.Label lblinfo;
        private AxWMPLib.AxWindowsMediaPlayer MediaPlayer;
        private System.Windows.Forms.OpenFileDialog FileChoose;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入喜欢列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 导入播放列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 清除喜欢列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开皮肤文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

