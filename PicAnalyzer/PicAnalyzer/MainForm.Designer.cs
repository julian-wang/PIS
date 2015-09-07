namespace PicAnalyzer
{
    partial class PicAnalyzer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PicAnalyzer));
            this.labelOpenFile = new System.Windows.Forms.Label();
            this.textBoxOrigFile = new System.Windows.Forms.TextBox();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.openFileDialogOrig = new System.Windows.Forms.OpenFileDialog();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.buttonTexture = new System.Windows.Forms.Button();
            this.tabControlStitcher = new System.Windows.Forms.TabControl();
            this.tabSelect = new System.Windows.Forms.TabPage();
            this.buttonDelTc = new System.Windows.Forms.Button();
            this.buttonAddTc = new System.Windows.Forms.Button();
            this.buttonSelectTc = new System.Windows.Forms.Button();
            this.flowLayoutPanelSelect = new System.Windows.Forms.FlowLayoutPanel();
            this.tabEditor = new System.Windows.Forms.TabPage();
            this.dataGridViewEditor = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dynasty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kilneye = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonPicAnalyse = new System.Windows.Forms.Button();
            this.buttonUpPic = new System.Windows.Forms.Button();
            this.tabUpload = new System.Windows.Forms.TabPage();
            this.progressBarUpload = new System.Windows.Forms.ProgressBar();
            this.textBoxPicPath = new System.Windows.Forms.TextBox();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.buttonPicChooser = new System.Windows.Forms.Button();
            this.flowLayoutPanelPic = new System.Windows.Forms.FlowLayoutPanel();
            this.tabTexAnalyer = new System.Windows.Forms.TabPage();
            this.tabStitcher = new System.Windows.Forms.TabPage();
            this.buttonStitcher = new System.Windows.Forms.Button();
            this.openFileDialogPicChooser = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorkerUpload = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTexturePath = new System.Windows.Forms.TextBox();
            this.buttonOpenPath = new System.Windows.Forms.Button();
            this.tabLogin = new System.Windows.Forms.TabPage();
            this.checkBoxPassword = new System.Windows.Forms.CheckBox();
            this.checkBoxUser = new System.Windows.Forms.CheckBox();
            this.buttonForget = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.pictureBoxOrig = new System.Windows.Forms.PictureBox();
            this.pictureBoxTexture = new System.Windows.Forms.PictureBox();
            this.pictureBoxAll = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControlStitcher.SuspendLayout();
            this.tabSelect.SuspendLayout();
            this.tabEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEditor)).BeginInit();
            this.tabUpload.SuspendLayout();
            this.tabTexAnalyer.SuspendLayout();
            this.tabStitcher.SuspendLayout();
            this.tabLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTexture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelOpenFile
            // 
            this.labelOpenFile.AutoSize = true;
            this.labelOpenFile.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelOpenFile.Location = new System.Drawing.Point(34, 535);
            this.labelOpenFile.Name = "labelOpenFile";
            this.labelOpenFile.Size = new System.Drawing.Size(129, 20);
            this.labelOpenFile.TabIndex = 2;
            this.labelOpenFile.Text = "选择打开图片";
            this.labelOpenFile.Click += new System.EventHandler(this.labelOpenFile_Click);
            // 
            // textBoxOrigFile
            // 
            this.textBoxOrigFile.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxOrigFile.Location = new System.Drawing.Point(196, 535);
            this.textBoxOrigFile.Name = "textBoxOrigFile";
            this.textBoxOrigFile.Size = new System.Drawing.Size(250, 26);
            this.textBoxOrigFile.TabIndex = 3;
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonOpenFile.Location = new System.Drawing.Point(474, 535);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(91, 26);
            this.buttonOpenFile.TabIndex = 4;
            this.buttonOpenFile.Text = "选择图片";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // openFileDialogOrig
            // 
            this.openFileDialogOrig.FileName = "openFileDialogOrig";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape2,
            this.rectangleShape1,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(980, 682);
            this.shapeContainer1.TabIndex = 5;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.Location = new System.Drawing.Point(153, 225);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(239, 124);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Location = new System.Drawing.Point(152, 246);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(32, 15);
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 110;
            this.lineShape1.X2 = 337;
            this.lineShape1.Y1 = 197;
            this.lineShape1.Y2 = 336;
            // 
            // buttonTexture
            // 
            this.buttonTexture.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonTexture.Location = new System.Drawing.Point(740, 533);
            this.buttonTexture.Name = "buttonTexture";
            this.buttonTexture.Size = new System.Drawing.Size(91, 26);
            this.buttonTexture.TabIndex = 6;
            this.buttonTexture.Text = "纹理分析";
            this.buttonTexture.UseVisualStyleBackColor = true;
            this.buttonTexture.Click += new System.EventHandler(this.buttonTexure_Click);
            // 
            // tabControlStitcher
            // 
            this.tabControlStitcher.Controls.Add(this.tabLogin);
            this.tabControlStitcher.Controls.Add(this.tabSelect);
            this.tabControlStitcher.Controls.Add(this.tabEditor);
            this.tabControlStitcher.Controls.Add(this.tabUpload);
            this.tabControlStitcher.Controls.Add(this.tabTexAnalyer);
            this.tabControlStitcher.Controls.Add(this.tabStitcher);
            this.tabControlStitcher.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlStitcher.Location = new System.Drawing.Point(1, 4);
            this.tabControlStitcher.Name = "tabControlStitcher";
            this.tabControlStitcher.SelectedIndex = 0;
            this.tabControlStitcher.Size = new System.Drawing.Size(979, 678);
            this.tabControlStitcher.TabIndex = 7;
            // 
            // tabSelect
            // 
            this.tabSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(248)))));
            this.tabSelect.Controls.Add(this.buttonDelTc);
            this.tabSelect.Controls.Add(this.buttonAddTc);
            this.tabSelect.Controls.Add(this.buttonSelectTc);
            this.tabSelect.Controls.Add(this.flowLayoutPanelSelect);
            this.tabSelect.Location = new System.Drawing.Point(4, 26);
            this.tabSelect.Name = "tabSelect";
            this.tabSelect.Size = new System.Drawing.Size(971, 648);
            this.tabSelect.TabIndex = 4;
            this.tabSelect.Text = "选择";
            // 
            // buttonDelTc
            // 
            this.buttonDelTc.Location = new System.Drawing.Point(419, 572);
            this.buttonDelTc.Name = "buttonDelTc";
            this.buttonDelTc.Size = new System.Drawing.Size(88, 32);
            this.buttonDelTc.TabIndex = 4;
            this.buttonDelTc.Text = "删除陶瓷";
            this.buttonDelTc.UseVisualStyleBackColor = true;
            this.buttonDelTc.Click += new System.EventHandler(this.buttonDelTc_Click);
            // 
            // buttonAddTc
            // 
            this.buttonAddTc.Location = new System.Drawing.Point(92, 572);
            this.buttonAddTc.Name = "buttonAddTc";
            this.buttonAddTc.Size = new System.Drawing.Size(88, 32);
            this.buttonAddTc.TabIndex = 3;
            this.buttonAddTc.Text = "新增陶瓷";
            this.buttonAddTc.UseVisualStyleBackColor = true;
            this.buttonAddTc.Click += new System.EventHandler(this.buttonAddTc_Click);
            // 
            // buttonSelectTc
            // 
            this.buttonSelectTc.Location = new System.Drawing.Point(776, 572);
            this.buttonSelectTc.Name = "buttonSelectTc";
            this.buttonSelectTc.Size = new System.Drawing.Size(88, 32);
            this.buttonSelectTc.TabIndex = 2;
            this.buttonSelectTc.Text = "编辑陶瓷";
            this.buttonSelectTc.UseVisualStyleBackColor = true;
            this.buttonSelectTc.Click += new System.EventHandler(this.buttonSelectTc_Click);
            // 
            // flowLayoutPanelSelect
            // 
            this.flowLayoutPanelSelect.AutoScroll = true;
            this.flowLayoutPanelSelect.Location = new System.Drawing.Point(55, 56);
            this.flowLayoutPanelSelect.Name = "flowLayoutPanelSelect";
            this.flowLayoutPanelSelect.Size = new System.Drawing.Size(850, 480);
            this.flowLayoutPanelSelect.TabIndex = 1;
            this.flowLayoutPanelSelect.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelSelect_Paint);
            // 
            // tabEditor
            // 
            this.tabEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(248)))));
            this.tabEditor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabEditor.Controls.Add(this.dataGridViewEditor);
            this.tabEditor.Controls.Add(this.buttonPicAnalyse);
            this.tabEditor.Controls.Add(this.buttonUpPic);
            this.tabEditor.Location = new System.Drawing.Point(4, 26);
            this.tabEditor.Name = "tabEditor";
            this.tabEditor.Size = new System.Drawing.Size(971, 648);
            this.tabEditor.TabIndex = 5;
            this.tabEditor.Text = "编辑";
            // 
            // dataGridViewEditor
            // 
            this.dataGridViewEditor.AllowUserToDeleteRows = false;
            this.dataGridViewEditor.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(248)))));
            this.dataGridViewEditor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewEditor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridViewEditor.ColumnHeadersHeight = 36;
            this.dataGridViewEditor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.uid,
            this.dynasty,
            this.kilneye,
            this.category,
            this.descrip});
            this.dataGridViewEditor.Location = new System.Drawing.Point(82, 102);
            this.dataGridViewEditor.Name = "dataGridViewEditor";
            this.dataGridViewEditor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridViewEditor.RowTemplate.Height = 23;
            this.dataGridViewEditor.Size = new System.Drawing.Size(807, 244);
            this.dataGridViewEditor.TabIndex = 0;
            this.dataGridViewEditor.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewEditor_UserAddedRow);
            // 
            // name
            // 
            this.name.FillWeight = 117.801F;
            this.name.HeaderText = "名称";
            this.name.Name = "name";
            this.name.Width = 150;
            // 
            // uid
            // 
            this.uid.FillWeight = 111.5214F;
            this.uid.HeaderText = "送检人";
            this.uid.Name = "uid";
            this.uid.Width = 142;
            // 
            // dynasty
            // 
            this.dynasty.FillWeight = 70.98314F;
            this.dynasty.HeaderText = "朝代";
            this.dynasty.Name = "dynasty";
            this.dynasty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dynasty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dynasty.Width = 90;
            // 
            // kilneye
            // 
            this.kilneye.FillWeight = 72.92472F;
            this.kilneye.HeaderText = "出土地";
            this.kilneye.Name = "kilneye";
            this.kilneye.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.kilneye.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.kilneye.Width = 93;
            // 
            // category
            // 
            this.category.FillWeight = 74.61217F;
            this.category.HeaderText = "陶瓷类别";
            this.category.Name = "category";
            this.category.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.category.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.category.Width = 95;
            // 
            // descrip
            // 
            this.descrip.FillWeight = 152.1575F;
            this.descrip.HeaderText = "陶瓷履历描述";
            this.descrip.Name = "descrip";
            this.descrip.Width = 194;
            // 
            // buttonPicAnalyse
            // 
            this.buttonPicAnalyse.Location = new System.Drawing.Point(591, 547);
            this.buttonPicAnalyse.Name = "buttonPicAnalyse";
            this.buttonPicAnalyse.Size = new System.Drawing.Size(88, 32);
            this.buttonPicAnalyse.TabIndex = 6;
            this.buttonPicAnalyse.Text = "纹理分析";
            this.buttonPicAnalyse.UseVisualStyleBackColor = true;
            this.buttonPicAnalyse.Click += new System.EventHandler(this.buttonPicAnalyse_Click);
            // 
            // buttonUpPic
            // 
            this.buttonUpPic.Location = new System.Drawing.Point(261, 547);
            this.buttonUpPic.Name = "buttonUpPic";
            this.buttonUpPic.Size = new System.Drawing.Size(88, 32);
            this.buttonUpPic.TabIndex = 5;
            this.buttonUpPic.Text = "上传图片";
            this.buttonUpPic.UseVisualStyleBackColor = true;
            this.buttonUpPic.Click += new System.EventHandler(this.buttonUpPic_Click);
            // 
            // tabUpload
            // 
            this.tabUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(248)))));
            this.tabUpload.Controls.Add(this.progressBarUpload);
            this.tabUpload.Controls.Add(this.textBoxPicPath);
            this.tabUpload.Controls.Add(this.buttonUpload);
            this.tabUpload.Controls.Add(this.buttonPicChooser);
            this.tabUpload.Controls.Add(this.flowLayoutPanelPic);
            this.tabUpload.Location = new System.Drawing.Point(4, 26);
            this.tabUpload.Name = "tabUpload";
            this.tabUpload.Size = new System.Drawing.Size(971, 648);
            this.tabUpload.TabIndex = 3;
            this.tabUpload.Text = "图片上传";
            // 
            // progressBarUpload
            // 
            this.progressBarUpload.Location = new System.Drawing.Point(559, 544);
            this.progressBarUpload.Name = "progressBarUpload";
            this.progressBarUpload.Size = new System.Drawing.Size(198, 23);
            this.progressBarUpload.TabIndex = 5;
            // 
            // textBoxPicPath
            // 
            this.textBoxPicPath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPicPath.Location = new System.Drawing.Point(71, 544);
            this.textBoxPicPath.Name = "textBoxPicPath";
            this.textBoxPicPath.Size = new System.Drawing.Size(262, 26);
            this.textBoxPicPath.TabIndex = 4;
            // 
            // buttonUpload
            // 
            this.buttonUpload.Location = new System.Drawing.Point(791, 540);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(90, 31);
            this.buttonUpload.TabIndex = 2;
            this.buttonUpload.Text = "开始上传";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // buttonPicChooser
            // 
            this.buttonPicChooser.Location = new System.Drawing.Point(377, 540);
            this.buttonPicChooser.Name = "buttonPicChooser";
            this.buttonPicChooser.Size = new System.Drawing.Size(90, 31);
            this.buttonPicChooser.TabIndex = 1;
            this.buttonPicChooser.Text = "选择图片";
            this.buttonPicChooser.UseVisualStyleBackColor = true;
            this.buttonPicChooser.Click += new System.EventHandler(this.buttonPicChooser_Click);
            // 
            // flowLayoutPanelPic
            // 
            this.flowLayoutPanelPic.AutoScroll = true;
            this.flowLayoutPanelPic.Location = new System.Drawing.Point(42, 48);
            this.flowLayoutPanelPic.Name = "flowLayoutPanelPic";
            this.flowLayoutPanelPic.Size = new System.Drawing.Size(850, 438);
            this.flowLayoutPanelPic.TabIndex = 0;
            // 
            // tabTexAnalyer
            // 
            this.tabTexAnalyer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(248)))));
            this.tabTexAnalyer.Controls.Add(this.buttonOpenPath);
            this.tabTexAnalyer.Controls.Add(this.textBoxTexturePath);
            this.tabTexAnalyer.Controls.Add(this.label1);
            this.tabTexAnalyer.Controls.Add(this.pictureBoxOrig);
            this.tabTexAnalyer.Controls.Add(this.buttonTexture);
            this.tabTexAnalyer.Controls.Add(this.textBoxOrigFile);
            this.tabTexAnalyer.Controls.Add(this.pictureBoxTexture);
            this.tabTexAnalyer.Controls.Add(this.buttonOpenFile);
            this.tabTexAnalyer.Controls.Add(this.labelOpenFile);
            this.tabTexAnalyer.Location = new System.Drawing.Point(4, 26);
            this.tabTexAnalyer.Name = "tabTexAnalyer";
            this.tabTexAnalyer.Padding = new System.Windows.Forms.Padding(3);
            this.tabTexAnalyer.Size = new System.Drawing.Size(971, 648);
            this.tabTexAnalyer.TabIndex = 0;
            this.tabTexAnalyer.Text = "纹理分析";
            // 
            // tabStitcher
            // 
            this.tabStitcher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(248)))));
            this.tabStitcher.Controls.Add(this.pictureBoxAll);
            this.tabStitcher.Controls.Add(this.pictureBox6);
            this.tabStitcher.Controls.Add(this.pictureBox5);
            this.tabStitcher.Controls.Add(this.pictureBox4);
            this.tabStitcher.Controls.Add(this.pictureBox3);
            this.tabStitcher.Controls.Add(this.pictureBox2);
            this.tabStitcher.Controls.Add(this.pictureBox1);
            this.tabStitcher.Controls.Add(this.buttonStitcher);
            this.tabStitcher.Location = new System.Drawing.Point(4, 26);
            this.tabStitcher.Name = "tabStitcher";
            this.tabStitcher.Padding = new System.Windows.Forms.Padding(3);
            this.tabStitcher.Size = new System.Drawing.Size(971, 648);
            this.tabStitcher.TabIndex = 1;
            this.tabStitcher.Text = "图片拼接";
            // 
            // buttonStitcher
            // 
            this.buttonStitcher.Location = new System.Drawing.Point(410, 540);
            this.buttonStitcher.Name = "buttonStitcher";
            this.buttonStitcher.Size = new System.Drawing.Size(88, 32);
            this.buttonStitcher.TabIndex = 3;
            this.buttonStitcher.Text = "拼接";
            this.buttonStitcher.UseVisualStyleBackColor = true;
            this.buttonStitcher.Click += new System.EventHandler(this.buttonStitcher_Click);
            // 
            // openFileDialogPicChooser
            // 
            this.openFileDialogPicChooser.FileName = "openFileDialogPicChooser";
            // 
            // backgroundWorkerUpload
            // 
            this.backgroundWorkerUpload.WorkerReportsProgress = true;
            this.backgroundWorkerUpload.WorkerSupportsCancellation = true;
            this.backgroundWorkerUpload.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUpload_DoWork);
            this.backgroundWorkerUpload.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerUpload_ProgressChanged);
            this.backgroundWorkerUpload.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUpload_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(34, 589);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "纹理保存路径";
            // 
            // textBoxTexturePath
            // 
            this.textBoxTexturePath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxTexturePath.Location = new System.Drawing.Point(196, 589);
            this.textBoxTexturePath.Name = "textBoxTexturePath";
            this.textBoxTexturePath.Size = new System.Drawing.Size(250, 26);
            this.textBoxTexturePath.TabIndex = 8;
            // 
            // buttonOpenPath
            // 
            this.buttonOpenPath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonOpenPath.Location = new System.Drawing.Point(474, 587);
            this.buttonOpenPath.Name = "buttonOpenPath";
            this.buttonOpenPath.Size = new System.Drawing.Size(91, 26);
            this.buttonOpenPath.TabIndex = 9;
            this.buttonOpenPath.Text = "选择路径";
            this.buttonOpenPath.UseVisualStyleBackColor = true;
            this.buttonOpenPath.Click += new System.EventHandler(this.buttonOpenPath_Click);
            // 
            // tabLogin
            // 
            this.tabLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabLogin.BackgroundImage")));
            this.tabLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabLogin.Controls.Add(this.checkBoxPassword);
            this.tabLogin.Controls.Add(this.checkBoxUser);
            this.tabLogin.Controls.Add(this.buttonForget);
            this.tabLogin.Controls.Add(this.buttonLogin);
            this.tabLogin.Controls.Add(this.textBoxPassword);
            this.tabLogin.Controls.Add(this.comboBoxUser);
            this.tabLogin.Controls.Add(this.labelPassword);
            this.tabLogin.Controls.Add(this.labelUser);
            this.tabLogin.Location = new System.Drawing.Point(4, 26);
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.Size = new System.Drawing.Size(971, 648);
            this.tabLogin.TabIndex = 2;
            this.tabLogin.Text = "登陆";
            this.tabLogin.UseVisualStyleBackColor = true;
            // 
            // checkBoxPassword
            // 
            this.checkBoxPassword.AutoSize = true;
            this.checkBoxPassword.Location = new System.Drawing.Point(525, 411);
            this.checkBoxPassword.Name = "checkBoxPassword";
            this.checkBoxPassword.Size = new System.Drawing.Size(91, 20);
            this.checkBoxPassword.TabIndex = 7;
            this.checkBoxPassword.Text = "记住密码";
            this.checkBoxPassword.UseVisualStyleBackColor = true;
            this.checkBoxPassword.CheckStateChanged += new System.EventHandler(this.checkBoxPassword_CheckStateChanged);
            // 
            // checkBoxUser
            // 
            this.checkBoxUser.AutoSize = true;
            this.checkBoxUser.Location = new System.Drawing.Point(297, 411);
            this.checkBoxUser.Name = "checkBoxUser";
            this.checkBoxUser.Size = new System.Drawing.Size(91, 20);
            this.checkBoxUser.TabIndex = 6;
            this.checkBoxUser.Text = "记住账号";
            this.checkBoxUser.UseVisualStyleBackColor = true;
            this.checkBoxUser.CheckStateChanged += new System.EventHandler(this.checkBoxUser_CheckStateChanged);
            // 
            // buttonForget
            // 
            this.buttonForget.Location = new System.Drawing.Point(509, 454);
            this.buttonForget.Name = "buttonForget";
            this.buttonForget.Size = new System.Drawing.Size(107, 34);
            this.buttonForget.TabIndex = 5;
            this.buttonForget.Text = "忘记密码";
            this.buttonForget.UseVisualStyleBackColor = true;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(281, 454);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(107, 34);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "登陆";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("宋体", 14F);
            this.textBoxPassword.Location = new System.Drawing.Point(334, 326);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(242, 29);
            this.textBoxPassword.TabIndex = 3;
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.Font = new System.Drawing.Font("宋体", 14F);
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(334, 241);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(242, 27);
            this.comboBoxUser.TabIndex = 2;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("宋体", 16F);
            this.labelPassword.Location = new System.Drawing.Point(240, 333);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(76, 22);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "密码：";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("宋体", 16F);
            this.labelUser.Location = new System.Drawing.Point(240, 242);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(76, 22);
            this.labelUser.TabIndex = 0;
            this.labelUser.Text = "用户：";
            // 
            // pictureBoxOrig
            // 
            this.pictureBoxOrig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxOrig.Image = global::PicAnalyzer.Properties.Resources.noimage;
            this.pictureBoxOrig.InitialImage = global::PicAnalyzer.Properties.Resources.noimage;
            this.pictureBoxOrig.Location = new System.Drawing.Point(23, 53);
            this.pictureBoxOrig.Name = "pictureBoxOrig";
            this.pictureBoxOrig.Size = new System.Drawing.Size(600, 450);
            this.pictureBoxOrig.TabIndex = 0;
            this.pictureBoxOrig.TabStop = false;
            this.pictureBoxOrig.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxOrig_Paint);
            this.pictureBoxOrig.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxOrig_MouseDown);
            this.pictureBoxOrig.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxOrig_MouseMove);
            this.pictureBoxOrig.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxOrig_MouseUp);
            // 
            // pictureBoxTexture
            // 
            this.pictureBoxTexture.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxTexture.ErrorImage")));
            this.pictureBoxTexture.Location = new System.Drawing.Point(662, 280);
            this.pictureBoxTexture.Name = "pictureBoxTexture";
            this.pictureBoxTexture.Size = new System.Drawing.Size(251, 223);
            this.pictureBoxTexture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTexture.TabIndex = 1;
            this.pictureBoxTexture.TabStop = false;
            this.pictureBoxTexture.Tag = "预览";
            // 
            // pictureBoxAll
            // 
            this.pictureBoxAll.Location = new System.Drawing.Point(66, 208);
            this.pictureBoxAll.Name = "pictureBoxAll";
            this.pictureBoxAll.Size = new System.Drawing.Size(772, 314);
            this.pictureBoxAll.TabIndex = 10;
            this.pictureBoxAll.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(725, 63);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(114, 84);
            this.pictureBox6.TabIndex = 9;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(596, 63);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(114, 84);
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(460, 63);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(114, 84);
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(329, 63);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(114, 84);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(199, 63);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(114, 84);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(66, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 84);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // PicAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 682);
            this.Controls.Add(this.tabControlStitcher);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "PicAnalyzer";
            this.Text = "古陶瓷鉴定客户端";
            this.Load += new System.EventHandler(this.PicAnalyzer_Load);
            this.tabControlStitcher.ResumeLayout(false);
            this.tabSelect.ResumeLayout(false);
            this.tabEditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEditor)).EndInit();
            this.tabUpload.ResumeLayout(false);
            this.tabUpload.PerformLayout();
            this.tabTexAnalyer.ResumeLayout(false);
            this.tabTexAnalyer.PerformLayout();
            this.tabStitcher.ResumeLayout(false);
            this.tabLogin.ResumeLayout(false);
            this.tabLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTexture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxOrig;
        private System.Windows.Forms.PictureBox pictureBoxTexture;
        private System.Windows.Forms.Label labelOpenFile;
        private System.Windows.Forms.TextBox textBoxOrigFile;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.OpenFileDialog openFileDialogOrig;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Button buttonTexture;
        private System.Windows.Forms.TabControl tabControlStitcher;
        private System.Windows.Forms.TabPage tabTexAnalyer;
        private System.Windows.Forms.TabPage tabStitcher;
        private System.Windows.Forms.Button buttonStitcher;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxAll;
        private System.Windows.Forms.TabPage tabLogin;
        private System.Windows.Forms.Button buttonForget;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.ComboBox comboBoxUser;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TabPage tabUpload;
        private System.Windows.Forms.CheckBox checkBoxPassword;
        private System.Windows.Forms.CheckBox checkBoxUser;
        private System.Windows.Forms.TextBox textBoxPicPath;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.Button buttonPicChooser;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPic;
        private System.Windows.Forms.OpenFileDialog openFileDialogPicChooser;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUpload;
        private System.Windows.Forms.ProgressBar progressBarUpload;
        private System.Windows.Forms.TabPage tabSelect;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSelect;
        private System.Windows.Forms.Button buttonSelectTc;
        private System.Windows.Forms.Button buttonDelTc;
        private System.Windows.Forms.Button buttonAddTc;
        private System.Windows.Forms.TabPage tabEditor;
        private System.Windows.Forms.DataGridView dataGridViewEditor;
        private System.Windows.Forms.Button buttonPicAnalyse;
        private System.Windows.Forms.Button buttonUpPic;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn uid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dynasty;
        private System.Windows.Forms.DataGridViewTextBoxColumn kilneye;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn descrip;
        private System.Windows.Forms.TextBox textBoxTexturePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOpenPath;
    }
}

