using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace MYMusic
{
    public partial class frmmain : Form
    {
        Point p = new Point();
        WMPLib.IWMPPlaylist playlist = null;
        WMPLib.IWMPPlaylist likelist = null;
        static string datapath = Application.StartupPath + "\\MYMusic";
        string playlistxml = datapath + "\\playlist.xml";
        string likelistxml = datapath + "\\likelist.xml";

        string skinpath = datapath + "\\skin";
        int SkinSeq = 0;

        //在没有歌的时候显示的文本
        string lblinfo_notext = "TAO - MYMusic";

        public frmmain()
        {
            InitializeComponent();
            Init();
        }
        //formload
        private void frmmain_Load(object sender, EventArgs e)
        {
            MediaPlayer.currentPlaylist = playlist;
            LoadPlayList();
            //if (File.Exists(datapath + "\\BackImage"))
            //{
            //    this.BackgroundImage = Image.FromFile(datapath + "\\BackImage");               
            //}
        }

        //初始化,在构造函数中调用
        /// <summary>
        /// 初始化,在构造函数中调用
        /// </summary>
        public void Init()
        {
            playlist = MediaPlayer.playlistCollection.newPlaylist("palylist");
            likelist = MediaPlayer.playlistCollection.newPlaylist("likelist");

            //时间轴绘制
            lblrealtime.MaximumSize = lbltimeline.Size;
            lblrealtime.Width = 0;

            //音量设置轴一些设置
            lblvolume.MaximumSize = lblvolumeline.Size;
            lblvolume.Width = (int)(lblvolumeline.Width * 0.5);
            MediaPlayer.settings.volume = 50;

            //滚轮设置音量
            this.MouseWheel += this.SetVolumeByWhell;
        }

        #region 界面点击响应
        private void lblclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblmin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblchangeskin_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(skinpath))
            {
                Directory.CreateDirectory(skinpath);
            }

            string[] skins = Directory.GetFiles(skinpath);

            //可能是刚新建的文件夹,也有可能是没有文件
            if (skins.Length <= 0)
            {
                return;
            }

            if (SkinSeq == skins.Length)
            {
                SkinSeq = 0;
            }
            this.BackgroundImage = Image.FromFile(skins[SkinSeq]);
            System.GC.Collect();
            //将正在使用的背景拷到backimage ,窗体启动时加载
            //Image.FromFile(datapath + "\\BackImage").Dispose();
            //File.Copy(skins[SkinSeq],datapath+"\\BackImage",true);
            SkinSeq++;
        }

        private void picprevious_Click(object sender, EventArgs e)
        {
            MediaPlayer.Ctlcontrols.previous();
            PlayMusic();
        }

        private void picplay_Click(object sender, EventArgs e)
        {
            if (MediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                MediaPlayer.Ctlcontrols.pause();
            }
            else if (MediaPlayer.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                MediaPlayer.Ctlcontrols.play();
            }
        }

        private void picnext_Click(object sender, EventArgs e)
        {
            MediaPlayer.Ctlcontrols.next();
            PlayMusic();
        }

        private void piclike_Click(object sender, EventArgs e)
        {
            if (IsLike())
            {
                likelist.removeItem(MediaPlayer.currentMedia);
            }
            else
                likelist.appendItem(MediaPlayer.newMedia(MediaPlayer.currentMedia.getItemInfo("SourceURL")));
            PlayMusic();
            SaveLikeList();
        }

        private void picadd_Click(object sender, EventArgs e)
        {
            FileChoose.Multiselect = true;
            FileChoose.InitialDirectory = @"D:\kugou";
            FileChoose.Filter = @"音乐文件(*.mp3;*.wma;*.wav)
                |*.mp3;*.wma;*.wav";
            //|所有文件(*.*)|*.*
            if (FileChoose.ShowDialog() == DialogResult.OK)
            {
                string[] files = FileChoose.FileNames;

                //保存原来的列表数量
                int oldCount = playlist.count;
                //添加到列表
                foreach (var file in files)
                {
                    playlist.appendItem(MediaPlayer.newMedia(file));
                }
                SavePlayList();
                MediaPlayer.currentPlaylist = playlist;
                MediaPlayer.Ctlcontrols.currentItem = playlist.Item[oldCount];
                PlayMusic();
            }
        }

        private void chktopform_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = chktopform.Checked;
        }
        #endregion

        #region 鼠标悬停,离开效果
        private void lblchangeskin_MouseMove(object sender, MouseEventArgs e)
        {
            lblchangeskin.ForeColor = Color.Black;
        }

        private void lblchangeskin_MouseLeave(object sender, EventArgs e)
        {
            lblchangeskin.ForeColor = Color.White;
        }

        private void lblmin_MouseMove(object sender, MouseEventArgs e)
        {
            lblmin.ForeColor = Color.Black;
        }

        private void lblmin_MouseLeave(object sender, EventArgs e)
        {
            lblmin.ForeColor = Color.White;
        }

        private void lblclose_MouseMove(object sender, MouseEventArgs e)
        {
            lblclose.ForeColor = Color.Black;
        }

        private void lblclose_MouseLeave(object sender, EventArgs e)
        {
            lblclose.ForeColor = Color.White;
        }

        private void picprevious_MouseMove(object sender, MouseEventArgs e)
        {
            picprevious.Image = Properties.Resources.previous_hover;
        }

        private void picprevious_MouseLeave(object sender, EventArgs e)
        {
            picprevious.Image = Properties.Resources.previous;
        }

        private void picplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (MediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                picplay.Image = Properties.Resources.play_hover;
            }
            else if (MediaPlayer.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                picplay.Image = Properties.Resources.pause_hover;
            }
        }

        private void picplay_MouseLeave(object sender, EventArgs e)
        {
            if (MediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                picplay.Image = Properties.Resources.play;
            }
            else if (MediaPlayer.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                picplay.Image = Properties.Resources.pause;
            }
        }

        private void picnext_MouseMove(object sender, MouseEventArgs e)
        {
            picnext.Image = Properties.Resources.next_hover;
        }

        private void picnext_MouseLeave(object sender, EventArgs e)
        {
            picnext.Image = Properties.Resources.next;
        }

        private void piclike_MouseMove(object sender, MouseEventArgs e)
        {
            piclike.Image = Properties.Resources.favorite_hover;
        }

        private void piclike_MouseLeave(object sender, EventArgs e)
        {
            if (IsLike())
            {
                piclike.Image = Properties.Resources.favorite_hover;
            }
            else
                piclike.Image = Properties.Resources.favorite;
        }

        private void picadd_MouseMove(object sender, MouseEventArgs e)
        {
            picadd.Image = Properties.Resources.add_hover;
        }

        private void picadd_MouseLeave(object sender, EventArgs e)
        {
            picadd.Image = Properties.Resources.add;
        }

        #endregion

        #region 无边框窗体拖动,frmmain,lbllogo,lblinfo
        private void frmmain_MouseDown(object sender, MouseEventArgs e)
        {
            p = new Point(e.X, e.Y);
        }

        private void frmmain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*
                 * 窗体左上角 与 当前鼠标的距离一定,相隔mousedown的坐标
                 */
                Point now = Control.MousePosition;
                now.Offset(-p.X, -p.Y);
                this.Location = now;
            }
        }

        private void frmmain_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.Location.X < 0) this.Location = new Point(
                0, this.Location.Y);
            if (this.Location.Y < 0) this.Location = new Point(
                this.Location.X, 0);
        }

        private void lbllogo_MouseDown(object sender, MouseEventArgs e)
        {
            p = new Point(e.X, e.Y);
            p.Offset(this.lbllogo.Location);
            //p现在是以frm左上角为原点的坐标
        }

        private void lbllogo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*
                 * 窗体左上角 与 当前鼠标的距离一定,相隔mousedown的坐标
                 */
                Point now = Control.MousePosition;
                now.Offset(-p.X, -p.Y);
                this.Location = now;
            }
        }

        private void lbllogo_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.Location.X < 0) this.Location = new Point(
                0, this.Location.Y);
            if (this.Location.Y < 0) this.Location = new Point(
                this.Location.X, 0);
        }

        private void lblinfo_MouseDown(object sender, MouseEventArgs e)
        {
            p = new Point(e.X, e.Y);
            //mouse down的坐标都是相对于控件的
            p.Offset(this.lblinfo.Location);
        }

        private void lblinfo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*
                 * 窗体左上角 与 当前鼠标的距离一定,相隔mousedown的坐标
                 */
                Point now = Control.MousePosition;
                now.Offset(-p.X, -p.Y);
                this.Location = now;
            }
        }

        private void lblinfo_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.Location.X < 0) this.Location = new Point(
                0, this.Location.Y);
            if (this.Location.Y < 0) this.Location = new Point(
                this.Location.X, 0);
        }
        #endregion

        #region 进度条拖动
        //拖动,点击 均可,
        //注意 int/int*double=0;前面两个width相除,结果小于1,转为int为0,再转为double为0
        private void lblrealtime_MouseDown(object sender, MouseEventArgs e)
        {
            if (MediaPlayer.currentMedia != null)
            {
                lblrealtime.Width = e.X;
                MediaPlayer.Ctlcontrols.currentPosition = (double)(lblrealtime.Width
                    * MediaPlayer.currentMedia.duration / lbltimeline.Width);
            }
        }

        private void lblrealtime_MouseMove(object sender, MouseEventArgs e)
        {
            //是左键按着拖动
            if (MediaPlayer.currentMedia != null && e.Button == MouseButtons.Left)
            {
                lblrealtime.Width = e.X;
                MediaPlayer.Ctlcontrols.currentPosition = (double)(lblrealtime.Width
                    * MediaPlayer.currentMedia.duration / lbltimeline.Width);

                //拖动时可以预览时间
                tmrtimeline.Enabled = true;
            }
        }

        private void lbltimeline_MouseDown(object sender, MouseEventArgs e)
        {
            if (MediaPlayer.currentMedia != null)
            {
                lblrealtime.Width = e.X;
                MediaPlayer.Ctlcontrols.currentPosition = (double)(lblrealtime.Width
                    * MediaPlayer.currentMedia.duration / lbltimeline.Width);
            }
        }

        private void lbltimeline_MouseMove(object sender, MouseEventArgs e)
        {
            //是左键按着拖动
            if (MediaPlayer.currentMedia != null && e.Button == MouseButtons.Left)
            {
                lblrealtime.Width = e.X;
                // int/int*double=0;
                MediaPlayer.Ctlcontrols.currentPosition = (double)(lblrealtime.Width
                    * MediaPlayer.currentMedia.duration / lbltimeline.Width);

                //拖动时可以预览时间
                tmrtimeline.Enabled = true;
            }
        }
        #endregion

        #region 声音设置
        private void lblvolume_MouseDown(object sender, MouseEventArgs e)
        {
            lblvolume.Width = e.X;
            MediaPlayer.settings.volume = 100 * lblvolume.Width /
                lblvolumeline.Width;
        }

        private void lblvolume_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblvolume.Width = e.X;
                MediaPlayer.settings.volume = 100 * lblvolume.Width /
                    lblvolumeline.Width;
            }
        }

        private void lblvolumeline_MouseDown(object sender, MouseEventArgs e)
        {
            lblvolume.Width = e.X;
            MediaPlayer.settings.volume = 100 * lblvolume.Width /
                lblvolumeline.Width;
        }

        private void lblvolumeline_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblvolume.Width = e.X;
                MediaPlayer.settings.volume = 100 * lblvolume.Width /
                    lblvolumeline.Width;
            }
        }
        #endregion


        //播放音乐,获取lblinfo,获取是否是喜欢列表里面的
        /// <summary>uury
        /// 播放音乐,获取lblinfo
        /// </summary>
        private void PlayMusic()
        {
            MediaPlayer.Ctlcontrols.play();
            if (MediaPlayer.currentMedia != null)
            {
                lblinfo.Text = Path.GetFileNameWithoutExtension(
                    MediaPlayer.currentMedia.getItemInfo("SourceURL"));
                tmrtimeline.Enabled = true;
                if (IsLike())
                {
                    piclike.Image = Properties.Resources.favorite_hover;
                }
                else
                    piclike.Image = Properties.Resources.favorite;
            }
            else
            {
                tmrtimeline.Enabled = false;
                lblinfo.Text = lblinfo_notext;
                piclike.Image = Properties.Resources.favorite;
            }
            MediaPlayer.Ctlcontrols.currentItem
        }

        private void tmrtimeline_Tick(object sender, EventArgs e)
        {
            //current media 不为null
            if (MediaPlayer.currentMedia != null)
            {
                lblstarttime.Text = MediaPlayer.Ctlcontrols.currentPositionString;
                lblendtime.Text = MediaPlayer.currentMedia.durationString;
                lblrealtime.Width = (int)(MediaPlayer.Ctlcontrols.currentPosition /
                    MediaPlayer.currentMedia.duration * lbltimeline.Width);
            }
            else
            {
                //为null,清空所有文字,进度条,停止timer,直到下一次PlayMusic启用
                lblstarttime.Text = "";
                lblendtime.Text = "";
                lblinfo.Text = lblinfo_notext;
                lblrealtime.Width = 0;
                tmrtimeline.Enabled = false;
            }
        }

        //滚轮事件处理函数,用它来处理声音加减
        /// <summary>
        /// 滚轮事件处理函数,用它来处理声音加减
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetVolumeByWhell(object sender, MouseEventArgs e)
        {
            int add = e.Delta / 20;
            lblvolume.Width += add;
            MediaPlayer.settings.volume += add;
        }

        #region 右键菜单
        private void 导入喜欢列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MediaPlayer.currentPlaylist = likelist;
            LoadLikeList();
            PlayMusic();
        }

        private void 清除列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Delete(playlistxml);
            playlist.clear();
        }

        private void 导入播放列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MediaPlayer.currentPlaylist = playlist;
            LoadPlayList();
            PlayMusic();
        }

        private void 清除喜欢列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Delete(likelistxml);
            likelist.clear();
            //当一首 喜欢 的歌正在放的时候,点清除喜欢,得重新验证它是否还在喜欢列表中
            PlayMusic();

        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Threading.Thread mythread= new System.Threading.Thread(new System.Threading.ThreadStart(
            //    delegate
            //    {
            //        this.lblinfo.Text = "---涛涛制作 *^_^* 盗版必究---";
            //        System.Threading.Thread.Sleep(3000);
            //    }));
            //mythread.Start();
            //this.lblinfo.Text = "---涛涛制作 *^_^* 盗版必究---";
            //System.Threading.Thread.Sleep(3000);
            //this.TopMost = false;
            //MessageBox.Show("---涛涛制作 *^_^* 盗版必究---"
            //    , "就是我啦~", MessageBoxButtons.OK);
            //this.TopMost = true;

            //学习了异步编程这都小菜了
            //我想让lblinfo显示几秒钟关于信息,然后显示原来的信息
            string temp = lblinfo.Text;
            Color tempColor = lblinfo.ForeColor;

            lblinfo.Text = "--- 涛涛制作 *^_^* 盗版必究 ---";
            //lblinfo.ForeColor = Color.Red;
            new System.Threading.Thread(() =>
            {
                //定义委托
                Action<Color> SetColor = color => { lblinfo.ForeColor = color; };
                Invoke(SetColor,Color.Red);
                System.Threading.Thread.Sleep(500);
                Invoke(SetColor,Color.Yellow);
                System.Threading.Thread.Sleep(500);
                Invoke(SetColor,Color.YellowGreen);
                System.Threading.Thread.Sleep(500);
                Invoke(SetColor,Color.SaddleBrown);
                System.Threading.Thread.Sleep(500);

                Invoke(new Action(() => {
                    lblinfo.Text = temp;
                    lblinfo.ForeColor = tempColor;
                }));
            }).Start();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region 列表相关
        public void SavePlayList()
        {
            if (!Directory.Exists(datapath)) Directory.CreateDirectory(datapath);
            //File.Delete(playlistxml);
            FileStream fs = File.Create(playlistxml);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.UTF8;
            settings.NewLineOnAttributes = true;
            XmlWriter xw = XmlWriter.Create(fs, settings);

            xw.WriteStartDocument();
            xw.WriteStartElement("playlist");
            xw.WriteEndElement();
            xw.WriteEndDocument();

            xw.Close();
            fs.Close();


            XmlDocument doc = new XmlDocument();
            //这里说是缺少根节点,只能先用XmlWriter写了
            doc.Load(playlistxml);

            //playlist 节点
            XmlElement root = doc.DocumentElement;

            for (int i = 0; i < this.playlist.count; i++)
            {
                XmlElement song = doc.CreateElement("song");
                XmlElement title = doc.CreateElement("title");
                XmlElement url = doc.CreateElement("url");

                title.InnerText = this.playlist.Item[i].getItemInfo("title");
                url.InnerText = this.playlist.Item[i].getItemInfo("SourceURL");

                song.AppendChild(title);
                song.AppendChild(url);

                root.AppendChild(song);
            }
            doc.Save(playlistxml);
        }

        public void LoadPlayList()
        {
            if (!File.Exists(playlistxml))
            {
                return;
            }
            playlist.clear();

            XmlDocument doc = new XmlDocument();
            doc.Load(playlistxml);

            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("/playlist/song/url");

            //这里添加的时候会触发media change,导致程序启动自动播放
            //MediaPlayer.MediaChange -= this.MediaPlayer_MediaChange;
            foreach (XmlNode node in nodes)
            {
                playlist.appendItem(MediaPlayer.newMedia(node.InnerText));
            }
            //MediaPlayer.MediaChange += this.MediaPlayer_MediaChange;
        }

        public void SaveLikeList()
        {
            if (!Directory.Exists(datapath)) Directory.CreateDirectory(datapath);

            //create可以覆盖原来的文件,所以不用担心原来的文件还存在
            FileStream fs = File.Create(likelistxml);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.UTF8;
            settings.NewLineOnAttributes = true;
            XmlWriter xw = XmlWriter.Create(fs, settings);

            xw.WriteStartDocument();
            xw.WriteStartElement("likelist");
            xw.WriteEndElement();
            xw.WriteEndDocument();

            xw.Close();
            fs.Close();


            XmlDocument doc = new XmlDocument();
            //这里说是缺少根节点,只能先用XmlWriter写了
            doc.Load(likelistxml);

            //playlist 节点
            XmlElement root = doc.DocumentElement;

            for (int i = 0; i < this.likelist.count; i++)
            {
                XmlElement song = doc.CreateElement("song");
                XmlElement title = doc.CreateElement("title");
                XmlElement url = doc.CreateElement("url");

                title.InnerText = this.likelist.Item[i].getItemInfo("title");
                url.InnerText = this.likelist.Item[i].getItemInfo("SourceURL");

                song.AppendChild(title);
                song.AppendChild(url);

                root.AppendChild(song);
            }
            doc.Save(likelistxml);
        }

        public void LoadLikeList()
        {
            if (!File.Exists(likelistxml))
            {
                return;
            }
            likelist.clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(likelistxml);

            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("/likelist/song/url");
            foreach (XmlNode node in nodes)
            {
                likelist.appendItem(MediaPlayer.newMedia(node.InnerText));
            }
        }
        #endregion

        //判断当前文件是否在喜欢列表中
        /// <summary>
        /// 判断当前文件是否在喜欢列表中
        /// </summary>
        /// <returns></returns>
        public bool IsLike()
        {
            if (!File.Exists(likelistxml))
            {
                return false;
            }

            if (MediaPlayer.currentMedia != null)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(likelistxml);

                XmlElement root = doc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("/likelist/song/url");
                foreach (XmlNode node in nodes)
                {
                    if (MediaPlayer.currentMedia.getItemInfo("SourceURL") == node.InnerText)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void frmmain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void frmmain_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            //保存原来的列表数量
            int oldCount = playlist.count;
            //添加到列表
            foreach (var file in files)
            {
                //文件
                if (File.Exists(file))
                {
                    string extension = Path.GetExtension(file);
                    if (extension == ".mp3" | extension == ".wma" | extension == ".wav")
                    {
                        playlist.appendItem(MediaPlayer.newMedia(file));
                    }
                }
                else
                {
                    //文件不存在,说明是目录
                    string[] subfiles = Directory.GetFiles(file);
                    foreach (var subfile in subfiles)
                    {
                        string extension = Path.GetExtension(subfile);
                        if (extension == ".mp3" | extension == ".wma" | extension == ".wav")
                        {
                            playlist.appendItem(MediaPlayer.newMedia(subfile));
                        }
                    }
                }
            }

            //如果没有添加任何歌曲,直接返回
            if (playlist.count == oldCount)
            {
                this.TopMost = false;
                MessageBox.Show("没能添加任何歌曲,拖拽进来的文件格式有误", "I'm Sorry", MessageBoxButtons.OK);
                this.TopMost = true;
                return;
            }
            SavePlayList();
            MediaPlayer.currentPlaylist = playlist;
            MediaPlayer.Ctlcontrols.currentItem = playlist.Item[oldCount];
            PlayMusic();
        }

        private void 打开皮肤文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", skinpath);
        }

        private void frmmain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // ESC 键最小化
                case Keys.Escape:
                    this.WindowState = FormWindowState.Minimized;
                    break;
                case Keys.Up:
                    lblvolume.Width += 10;
                    MediaPlayer.settings.volume = 100 * lblvolume.Width /
                        lblvolumeline.Width;
                    break;
            }
        }
    }//end class
}//end namespace