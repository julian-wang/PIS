using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Emgu.CV;
using Emgu.CV.Stitching;
using Emgu.CV.Structure;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Collections.Specialized;


namespace PicAnalyzer
{
    public partial class PicAnalyzer : Form
    {
        private ImageCut textureImgCut;
        Bitmap bitImg;  //定义位图对像
        private int x1;     //鼠标按下时横坐标
        private int y1;     //鼠标按下时纵坐标
        private int width;  //所打开的图像的宽
        private int heigth; //所打开的图像的高
        private bool HeadImageBool = false;    

        private Point p1;   //定义鼠标按下时的坐标点
        private Point p2;   //定义移动鼠标时的坐标点
        private Point p3;   //定义松开鼠标时的坐标点


        private string checkTc;

        private bool isSaveUser = false;
        private bool isSavePassword = false;

        private Queue<string> picsToUpload = new Queue<string>();
        private int currCount = 0;

        //配置默认路径
        private string confPath = "D:\\pictest\\settings.ini";
        //纹理默认路径
        private string textureImg = "D:\\pictest\\texture\\t1.jpg";
        //纹理特征默认
        private string grayText = "D:\\pictest\\in\\g1.txt";

        private string token = "dongdong1130";
        private string baseUrl = "http://lyczjwl.gqsj.cc/";

        public PicAnalyzer()
        {
            InitializeComponent();
            this.tabControlStitcher.Controls.Remove(this.tabSelect);
            this.tabControlStitcher.Controls.Remove(this.tabUpload);
            this.tabControlStitcher.Controls.Remove(this.tabStitcher);
            this.tabControlStitcher.Controls.Remove(this.tabTexAnalyer);
            this.tabControlStitcher.Controls.Remove(this.tabEditor);

            if (File.Exists(this.confPath))
            {
                StreamReader sr = new StreamReader(this.confPath, true);
                while (sr.Peek() > 0)
                {
                    string[] userInfo = sr.ReadLine().Split('#');
                    if( userInfo[0]== ""){
                        return;
                    }
                    this.checkBoxUser.Checked = true;
                    this.comboBoxUser.Items.Add(userInfo[0]);
                    this.comboBoxUser.Text = userInfo[0];

                    if (userInfo.Length >= 2)
                    {
                        this.textBoxPassword.Text = userInfo[1];
                        this.checkBoxPassword.Checked = true;
                    }
                }
                sr.Close();
            }
        }

        private void PicAnalyzer_Load(object sender, EventArgs e)
        {

        }

        private void labelOpenFile_Click(object sender, EventArgs e)
        {

        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "D:\\pictest\\orig";
            openFileDialog.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //PicSelector ps = new PicSelector();
                //ps.bitOrig = new Bitmap(openFileDialog.FileName.ToString());
                //ps.Width = ps.bitOrig.Width;
                //ps.Height = ps.bitOrig.Height;
                //ps.Show();
                textBoxOrigFile.Text = openFileDialog.FileName.ToString();
                //pictureBoxOrig.Image = Image.FromFile(openFileDialog.FileName,true);

                Image tmp = new Bitmap(openFileDialog.FileName.ToString());
                int h, w;
                if (tmp.Width * pictureBoxOrig.Height < tmp.Height * pictureBoxOrig.Width)
                {
                    h = this.pictureBoxOrig.Height;
                    w = (int)(tmp.Width * 1.0 / tmp.Height * this.pictureBoxOrig.Height);  
                }
                else
                {
                    w = this.pictureBoxOrig.Width;
                    h = (int)(tmp.Height * 1.0 / tmp.Width * this.pictureBoxOrig.Width);   
                }
                bitImg = new Bitmap(tmp, w, h);  //使用打开的图片路径创建位图对像
                ImageCut IC = new ImageCut(0,0,this.pictureBoxOrig.Width, this.pictureBoxOrig.Height);      //实例化ImageCut类，四个参数据分别表示为：x、y、width、heigth，（40、112）表示pictureBox1的Lcation的坐标，（120、144）表示pictureBox1控件的宽度和高度
                pictureBoxOrig.Image = IC.KiCut((Bitmap)(this.GetSelectImage(this.pictureBoxOrig.Width, this.pictureBoxOrig.Height)));     //（120、144）表示pictureBox1控件的宽度和高度
                //pictureBoxOrig.Image.Save("D:\\pictest\\orig.jpg", ImageFormat.Jpeg);     
            }
        }

        private void buttonTexure_Click(object sender, EventArgs e)
        {
            Image<Gray, byte> textImg = new Image<Gray, byte>(this.textureImg);
            System.IO.StreamWriter grayWriter = new System.IO.StreamWriter(this.grayText);
            for (int i = 0; i < textImg.Height; i++)
            {
                for (int j = 0; j < textImg.Width; j++)
                {
                    var tmp = textImg.Data[i, j, 0];
                    grayWriter.Write(tmp + "\t");
                }
                grayWriter.WriteLine();
            }
            grayWriter.Close();
        }


        private Bitmap Crop(Bitmap bitmap)
        {
            Rectangle rec = new Rectangle(100, 100, 250, 250);
            return bitmap.Clone(rec,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }


        private void pictureBoxOrig_MouseDown(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Cross;
            this.p1 = new Point(e.X, e.Y);
            x1 = e.X;
            y1 = e.Y;
            if (this.pictureBoxOrig.Image != null)
            {
                HeadImageBool = true;
            }
            else
            {
                HeadImageBool = false;
            }
        }

        private void pictureBoxOrig_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.Cursor == Cursors.Cross)
            {
                this.p2 = new Point(e.X, e.Y);
                if ((p2.X - p1.X) > 0 && (p2.Y - p1.Y) > 0)     //当鼠标从左上角向开始移动时P3坐标
                {
                    this.p3 = new Point(p1.X, p1.Y);
                }
                if ((p2.X - p1.X) < 0 && (p2.Y - p1.Y) > 0)     //当鼠标从右上角向左下方向开始移动时P3坐标
                {
                    this.p3 = new Point(p2.X, p1.Y);
                }
                if ((p2.X - p1.X) > 0 && (p2.Y - p1.Y) < 0)     //当鼠标从左下角向上开始移动时P3坐标
                {
                    this.p3 = new Point(p1.X, p2.Y);
                }
                if ((p2.X - p1.X) < 0 && (p2.Y - p1.Y) < 0)     //当鼠标从右下角向左方向上开始移动时P3坐标
                {
                    this.p3 = new Point(p2.X, p2.Y);
                }
                this.pictureBoxOrig.Invalidate();  //使控件的整个图面无效，并导致重绘控件
            }
        }


        private void pictureBoxOrig_MouseUp(object sender, MouseEventArgs e)
        {
            if (HeadImageBool)
            {
                width = this.pictureBoxOrig.Image.Width;
                heigth = this.pictureBoxOrig.Image.Height;
                if ((e.X - x1) > 0 && (e.Y - y1) > 0)   //当鼠标从左上角向右下方向开始移动时发生
                {
                    textureImgCut = new ImageCut(x1, y1, Math.Abs(e.X - x1), Math.Abs(e.Y - y1));    //实例化ImageCut1类
                }
                if ((e.X - x1) < 0 && (e.Y - y1) > 0)   //当鼠标从右上角向左下方向开始移动时发生
                {
                    textureImgCut = new ImageCut(e.X, y1, Math.Abs(e.X - x1), Math.Abs(e.Y - y1));   //实例化ImageCut1类
                }
                if ((e.X - x1) > 0 && (e.Y - y1) < 0)   //当鼠标从左下角向右上方向开始移动时发生
                {
                    textureImgCut = new ImageCut(x1, e.Y, Math.Abs(e.X - x1), Math.Abs(e.Y - y1));   //实例化ImageCut1类
                }
                if ((e.X - x1) < 0 && (e.Y - y1) < 0)   //当鼠标从右下角向左上方向开始移动时发生
                {
                    textureImgCut = new ImageCut(e.X, e.Y, Math.Abs(e.X - x1), Math.Abs(e.Y - y1));      //实例化ImageCut1类
                }
                this.pictureBoxTexture.Width = (textureImgCut.KiCut((Bitmap)(this.pictureBoxOrig.Image))).Width;
                this.pictureBoxTexture.Height = (textureImgCut.KiCut((Bitmap)(this.pictureBoxOrig.Image))).Height;
                this.pictureBoxTexture.Image = textureImgCut.KiCut((Bitmap)(this.pictureBoxOrig.Image));
                this.pictureBoxTexture.Image.Save(this.textureImg, System.Drawing.Imaging.ImageFormat.Jpeg);    
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void pictureBoxOrig_Paint(object sender, PaintEventArgs e)
        {
            if (HeadImageBool)
            {
                Pen p = new Pen(Color.Black, 2);//画笔
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                //Bitmap bitmap = new Bitmap(strHeadImagePath);
                Bitmap bitmap = bitImg;
                Rectangle rect = new Rectangle(p3, new Size(System.Math.Abs(p2.X - p1.X), System.Math.Abs(p2.Y - p1.Y)));
                e.Graphics.DrawRectangle(p, rect);
            }
           
        }


        public Image GetSelectImage(int Width, int Height)
        {
            //Image initImage = this.pictureBox1.Image;
            Image initImage = bitImg;
            //原图宽高均小于模版，不作处理，直接保存 
            if (initImage.Width <= Width && initImage.Height <= Height)
            {
                //initImage.Save(fileSaveUrl, System.Drawing.Imaging.ImageFormat.Jpeg);
                return initImage;
            }
            else
            {
                //原始图片的宽、高 
                int initWidth = initImage.Width;
                int initHeight = initImage.Height;

                //非正方型先裁剪为正方型 
                if (initWidth != initHeight)
                {
                    //截图对象 
                    System.Drawing.Image pickedImage = null;
                    System.Drawing.Graphics pickedG = null;

                    //宽大于高的横图 
                    if (initWidth > initHeight)
                    {
                        //对象实例化 
                        pickedImage = new System.Drawing.Bitmap(initHeight, initHeight);
                        pickedG = System.Drawing.Graphics.FromImage(pickedImage);
                        //设置质量 
                        pickedG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        pickedG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        //定位 
                        Rectangle fromR = new Rectangle((initWidth - initHeight) / 2, 0, initHeight, initHeight);
                        Rectangle toR = new Rectangle(0, 0, initHeight, initHeight);
                        //画图 
                        pickedG.DrawImage(initImage, toR, fromR, System.Drawing.GraphicsUnit.Pixel);
                        //重置宽 
                        initWidth = initHeight;
                    }
                    //高大于宽的竖图 
                    else
                    {
                        //对象实例化
                        pickedImage = new System.Drawing.Bitmap(initWidth, initWidth);
                        pickedG = System.Drawing.Graphics.FromImage(pickedImage);
                        //设置质量 
                        pickedG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        pickedG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        //定位 
                        Rectangle fromR = new Rectangle(0, (initHeight - initWidth) / 2, initWidth, initWidth);
                        Rectangle toR = new Rectangle(0, 0, initWidth, initWidth);
                        //画图 
                        pickedG.DrawImage(initImage, toR, fromR, System.Drawing.GraphicsUnit.Pixel);
                        //重置高 
                        initHeight = initWidth;
                    }

                    initImage = (System.Drawing.Image)pickedImage.Clone();
                    //释放截图资源 
                    pickedG.Dispose();
                    pickedImage.Dispose();
                }

                return initImage;
            }
        }

        private void buttonStitcher_Click(object sender, EventArgs e)
        {
            Image<Bgr, Byte>[] sources;
            OpenFileDialog open = new OpenFileDialog();
            open.CheckFileExists = true;
            open.Multiselect = true;
            open.Filter = "打开图片|*.jpg";
            open.ShowDialog();
            sources = new Image<Bgr, byte>[open.FileNames.Length];

            for (int i = 0; i < open.FileNames.Length; i++)
            {
                sources[i] = new Image<Bgr, byte>(open.FileNames[i]);
            }

            pictureBox1.Image = new Bitmap(sources[0].Bitmap,100,75);
            pictureBox2.Image = new Bitmap(sources[1].Bitmap, 100, 75);
            pictureBox3.Image = new Bitmap(sources[2].Bitmap, 100, 75);

            Stitcher stitcher = new Stitcher(false);
            Image<Bgr, byte> result = stitcher.Stitch(sources);
            pictureBoxAll.Image = new Bitmap(result.Bitmap, 800, 350);
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            while (true)
            {
                string username = this.comboBoxUser.Text.Trim();
                string password = this.textBoxPassword.Text.Trim();
                string url = this.baseUrl + "jiekou.php?type=user&user=" + username + "&pass=" + password + "&my=" + this.token;
                Console.WriteLine(url);

                int status = 0;
                string result = HttpRequestHelper.httpGET(url, 2000, "gb2312", out status);
                JObject obj = JObject.Parse(result);
                //var res = JsonConvert.DeserializeObject(result);
                if (status<200 || status>299)
                {
                    if (MessageBox.Show("网络错误,请确认网络连接后重试？", "提示", MessageBoxButtons.RetryCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if ((string)obj["UserName"] != null)
                {
                    if (MessageBox.Show("欢迎, " + (string)obj["UserName"] + " 登陆图片鉴定系统！", "提示", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        break;
                    }
                }
                else
                {
                    StringBuilder errTips = new StringBuilder();
                    foreach(var str in obj){
                        errTips.Append(str);
                    }
                    if (MessageBox.Show("账号或者密码错误,详细错误信息如下:\n" + errTips.ToString(), "提示", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        return;
                    }
                }
            }

            this.tabControlStitcher.Controls.Add(this.tabSelect);
            this.tabControlStitcher.Controls.Remove(this.tabLogin); 

  
            string confContent = "";
            if (this.isSaveUser)
            {
                confContent += this.comboBoxUser.Text;
            }
            if (this.isSavePassword)
            {
                confContent += "#" + this.textBoxPassword.Text;
            }
            StreamWriter sw = new StreamWriter(this.confPath);
            sw.WriteLine(confContent);
            sw.Close();

            initLayoutPanel();
        }

       
        private void checkBoxUser_CheckStateChanged(object sender, EventArgs e)
        {
            this.isSaveUser = this.checkBoxUser.Checked;
            if (!this.isSaveUser && this.isSavePassword)
            {
                this.checkBoxPassword.Checked = false;
            }
        }

        private void checkBoxPassword_CheckStateChanged(object sender, EventArgs e)
        {
            this.isSavePassword = this.checkBoxPassword.Checked;
            if (!this.isSaveUser && this.isSavePassword)
            {
                this.checkBoxUser.Checked = true;
            }
        }

        private void buttonPicChooser_Click(object sender, EventArgs e)
        {
            this.progressBarUpload.Value = 0;
            OpenFileDialog openFileDialogPics = new OpenFileDialog();
            openFileDialogPics.InitialDirectory = "D:\\pictest\\orig";
            openFileDialogPics.Multiselect = true;
            openFileDialogPics.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            openFileDialogPics.RestoreDirectory = true;
            openFileDialogPics.FilterIndex = 1;
            if (openFileDialogPics.ShowDialog() == DialogResult.OK)
            {
                
                string safePath = openFileDialogPics.FileName.ToString().Replace(openFileDialogPics.SafeFileName.ToString(), "");
                this.textBoxPicPath.Text = safePath;
                for (int i = 0; i < openFileDialogPics.SafeFileNames.Length; i++)
                {
                    PictureBox picBoxTmp = new PictureBox();
                    picBoxTmp.Width = 200;
                    picBoxTmp.Height = 150;
                    picBoxTmp.Name = "pictureBoxUpload" + i;
                    string realPic = safePath + openFileDialogPics.SafeFileNames[i].ToString();
                    this.picsToUpload.Enqueue(realPic);
                    Image imageTmp = new Bitmap(realPic);
                    //非等比例缩放
                    //picBoxTmp.Image = new Bitmap(imageTmp, 200, 150);
                    //等比例缩放
                    int h, w;
                    if (imageTmp.Width * picBoxTmp.Height < imageTmp.Height * picBoxTmp.Width)
                    {
                        h = picBoxTmp.Height;
                        w = (int)(imageTmp.Width * 1.0 / imageTmp.Height * picBoxTmp.Height);
                    }
                    else
                    {
                        w = picBoxTmp.Width;
                        h = (int)(imageTmp.Height * 1.0 / imageTmp.Width * picBoxTmp.Width);
                    }
                    bitImg = new Bitmap(imageTmp, w, h);
                    ImageCut IC = new ImageCut(0, 0, picBoxTmp.Width, picBoxTmp.Height);
                    picBoxTmp.Image = IC.KiCut((Bitmap)(this.GetSelectImage(picBoxTmp.Width, picBoxTmp.Height)));
                    
                    imageTmp.Dispose();
                    picBoxTmp.Visible = true;
                    this.flowLayoutPanelPic.Controls.Add(picBoxTmp);
                    
                }
               
            }
        }

        private void backgroundWorkerUpload_DoWork(object sender, DoWorkEventArgs e)
        {
            while (this.picsToUpload.Count != 0)
            {
                this.currCount++;
                string fileUploading = this.picsToUpload.Dequeue();
                Console.WriteLine(fileUploading);
                string reqUrl = baseUrl + "admin/Tc/update.php";
                int status = 0;
                NameValueCollection stringDict = new NameValueCollection();
                try
                {
                    string result = HttpRequestHelper.httpPOST(reqUrl, 2000, "gb2312", fileUploading, fileUploading, stringDict, out status);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.StackTrace);
                }
                Console.WriteLine("Uploading file:" + fileUploading);
                Thread.Sleep(1000);
                this.backgroundWorkerUpload.ReportProgress(this.currCount * 100 / (this.picsToUpload.Count + this.currCount));
                //this.progressBarUpload.Value = (int)(this.currCount * 100 / (this.picsToUpload.Count + this.currCount));
                if (this.backgroundWorkerUpload.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                //this.backgroundWorkerUpload.ReportProgress(50);
            }
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            this.backgroundWorkerUpload.RunWorkerAsync();
        }

        private void backgroundWorkerUpload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBarUpload.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerUpload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.progressBarUpload.Value = 100;
        }

        private void flowLayoutPanelSelect_Paint(object sender, PaintEventArgs e)
        {
           

        }


        private void initLayoutPanel()
        {
            while (true)
            {
                string url = this.baseUrl + "jiekou.php?type=tc_result&my=" + this.token;
                int status = 0;
                string result = HttpRequestHelper.httpGET(url, 2000, "gb2312", out status);
                JArray jsonobj = (JArray)JsonConvert.DeserializeObject(result);
                //var res = JsonConvert.DeserializeObject(result);
                if (status < 200 || status > 299)
                {
                    if (MessageBox.Show("网络错误,请确认网络连接后重试？", "提示", MessageBoxButtons.RetryCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    int i = 0;
                    foreach (var db in jsonobj)
                    {
                        foreach (var tc in db)
                        {
                            i++;
                            //MessageBox.Show(tc["PicUrl"].ToString());
                            RadioButton radioBtnTc = new RadioButton();

                            string realPic = tc["PicUrl"].ToString();
                            try
                            {
                                WebRequest webreq = WebRequest.Create(realPic);
                                WebResponse webres = webreq.GetResponse();
                                Stream stream = webres.GetResponseStream();
                                radioBtnTc.BackgroundImage = System.Drawing.Image.FromStream(stream);  
                            }
                            catch
                            {
                                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PicAnalyzer));
                                radioBtnTc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxTexture.ErrorImage")));
                            }

                            radioBtnTc.BackgroundImageLayout = ImageLayout.Zoom;
                            radioBtnTc.Name = tc.ToString();
                            radioBtnTc.Width = 200;
                            radioBtnTc.Height = 150;
                            radioBtnTc.CheckedChanged += new System.EventHandler(this.radioBtn_CheckedChanged);
                            this.flowLayoutPanelSelect.Controls.Add(radioBtnTc);
                        }
                    }

                    break;
                }
            }

        }

        private void buttonSelectTc_Click(object sender, EventArgs e)
        {
            if (this.checkTc!=null && this.checkTc != "")
            {
                //MessageBox.Show("已选择陶瓷：" + this.checkTc);
                if (!this.tabControlStitcher.Controls.Contains(this.tabEditor))
                {
                    this.tabControlStitcher.Controls.Add(this.tabEditor);
                }
                var jsonobj = (JArray)JsonConvert.DeserializeObject("["+this.checkTc+"]");
                this.dataGridViewEditor.Rows[0].Cells[0].Value = jsonobj[0]["Name"];
                this.dataGridViewEditor.Rows[0].Cells[1].Value = jsonobj[0]["Uid"];
                this.dataGridViewEditor.Rows[0].Cells[2].Value = jsonobj[0]["DynastyID"];
                this.dataGridViewEditor.Rows[0].Cells[3].Value = jsonobj[0]["KilneyeID"];
                this.dataGridViewEditor.Rows[0].Cells[4].Value = jsonobj[0]["CategoryID"];
                this.dataGridViewEditor.Rows[0].Cells[5].Value = jsonobj[0]["Descrip"];
                this.dataGridViewEditor.Rows[0].Height = 50;
            }else{
                MessageBox.Show("请先选择一个陶瓷！");
            }
        }

        private void radioBtn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            this.checkTc = radioBtn.Name;
        }

        private void buttonAddTc_Click(object sender, EventArgs e)
        {
            if(!this.tabControlStitcher.Controls.Contains(this.tabUpload))
            {
                this.tabControlStitcher.Controls.Add(this.tabUpload);
            }
        }

        private void buttonDelTc_Click(object sender, EventArgs e)
        {
            if (this.checkTc != null && this.checkTc != "")
            {
                DialogResult dlg = MessageBox.Show("删除陶瓷：" + this.checkTc, "删除陶瓷：" + this.checkTc, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dlg == DialogResult.OK)
                {
                    MessageBox.Show("已删除陶瓷：" + this.checkTc);
                }
            }
            else
            {
                MessageBox.Show("请先选择一个要删除的陶瓷！");
            }

        }

        private void buttonUpPic_Click(object sender, EventArgs e)
        {
            if (!this.tabControlStitcher.Controls.Contains(this.tabUpload))
            {
                this.tabControlStitcher.Controls.Add(this.tabUpload);
            }
        }

        private void buttonPicAnalyse_Click(object sender, EventArgs e)
        {
            if (!this.tabControlStitcher.Controls.Contains(this.tabTexAnalyer))
            {
                this.tabControlStitcher.Controls.Add(this.tabTexAnalyer);
            }
        }

        private void dataGridViewEditor_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (this.dataGridViewEditor.Rows.Count > 0)
                this.dataGridViewEditor.AllowUserToAddRows = false;
        }

        private void buttonOpenPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialogTexturePath = new FolderBrowserDialog();
            if (folderBrowserDialogTexturePath.ShowDialog() == DialogResult.OK)
                this.textBoxTexturePath.Text = folderBrowserDialogTexturePath.SelectedPath;
        }
    }
}
