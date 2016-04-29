namespace MotionDetectorSample
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openVideoFileusingDirectShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localVideoCaptureDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openJPEGURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMJPEGURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.fpsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.objectsCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.MainMap = new MotionDetectorSample.Map();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.labelCurCoordXY = new System.Windows.Forms.Label();
            this.labelCurCoord = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.listBoxRGN = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.imageListView1 = new Manina.Windows.Forms.ImageListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButtonCT3 = new System.Windows.Forms.RadioButton();
            this.textBoxCachePath = new System.Windows.Forms.TextBox();
            this.radioButtonCT1 = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.buttonChangeCacheDir = new System.Windows.Forms.Button();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBoxMapType = new System.Windows.Forms.ComboBox();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxStartImitator = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxSaveNavigationMap = new System.Windows.Forms.CheckBox();
            this.checkBoxSaveOnDblClick = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBoxAccuracy = new System.Windows.Forms.TextBox();
            this.textBoxSpeed = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.buttonLoadTrack = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.alarmTimer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timerImitator = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timerTMP = new System.Windows.Forms.Timer(this.components);
            this.timerReal = new System.Windows.Forms.Timer(this.components);
            this.menuMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxRGN)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMenu
            // 
            this.menuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuMenu.Location = new System.Drawing.Point(0, 0);
            this.menuMenu.Name = "menuMenu";
            this.menuMenu.Size = new System.Drawing.Size(1248, 24);
            this.menuMenu.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openVideoFileusingDirectShowToolStripMenuItem,
            this.localVideoCaptureDeviceToolStripMenuItem,
            this.openJPEGURLToolStripMenuItem,
            this.openMJPEGURLToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openVideoFileusingDirectShowToolStripMenuItem
            // 
            this.openVideoFileusingDirectShowToolStripMenuItem.Name = "openVideoFileusingDirectShowToolStripMenuItem";
            this.openVideoFileusingDirectShowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openVideoFileusingDirectShowToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.openVideoFileusingDirectShowToolStripMenuItem.Text = "&Open";
            this.openVideoFileusingDirectShowToolStripMenuItem.Click += new System.EventHandler(this.openVideoFileusingDirectShowToolStripMenuItem_Click);
            // 
            // localVideoCaptureDeviceToolStripMenuItem
            // 
            this.localVideoCaptureDeviceToolStripMenuItem.Name = "localVideoCaptureDeviceToolStripMenuItem";
            this.localVideoCaptureDeviceToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.localVideoCaptureDeviceToolStripMenuItem.Text = "Local &Video Capture Device";
            this.localVideoCaptureDeviceToolStripMenuItem.Click += new System.EventHandler(this.localVideoCaptureDeviceToolStripMenuItem_Click);
            // 
            // openJPEGURLToolStripMenuItem
            // 
            this.openJPEGURLToolStripMenuItem.Name = "openJPEGURLToolStripMenuItem";
            this.openJPEGURLToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.openJPEGURLToolStripMenuItem.Text = "Open JPEG &URL";
            this.openJPEGURLToolStripMenuItem.Click += new System.EventHandler(this.openJPEGURLToolStripMenuItem_Click);
            // 
            // openMJPEGURLToolStripMenuItem
            // 
            this.openMJPEGURLToolStripMenuItem.Name = "openMJPEGURLToolStripMenuItem";
            this.openMJPEGURLToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.openMJPEGURLToolStripMenuItem.Text = "Open &MJPEG URL";
            this.openMJPEGURLToolStripMenuItem.Click += new System.EventHandler(this.openMJPEGURLToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.openToolStripMenuItem.Text = "Open video file (using VFW interface)";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(267, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "AVI files (*.avi)|*.avi|All files (*.*)|*.*";
            this.openFileDialog.Title = "Opem movie";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fpsLabel,
            this.objectsCountLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 640);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1248, 22);
            this.statusBar.TabIndex = 3;
            // 
            // fpsLabel
            // 
            this.fpsLabel.AutoSize = false;
            this.fpsLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.fpsLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(150, 17);
            this.fpsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // objectsCountLabel
            // 
            this.objectsCountLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.objectsCountLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.objectsCountLabel.Name = "objectsCountLabel";
            this.objectsCountLabel.Size = new System.Drawing.Size(1083, 17);
            this.objectsCountLabel.Spring = true;
            this.objectsCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1248, 616);
            this.panel1.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.checkBox5);
            this.splitContainer1.Size = new System.Drawing.Size(1248, 616);
            this.splitContainer1.SplitterDistance = 469;
            this.splitContainer1.TabIndex = 47;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.videoSourcePlayer);
            this.splitContainer2.Panel1.Resize += new System.EventHandler(this.splitContainer2_Panel1_Resize);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer2.Size = new System.Drawing.Size(1248, 469);
            this.splitContainer2.SplitterDistance = 765;
            this.splitContainer2.TabIndex = 0;
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.BackColor = System.Drawing.SystemColors.Control;
            this.videoSourcePlayer.BorderColor = System.Drawing.SystemColors.Control;
            this.videoSourcePlayer.ForeColor = System.Drawing.Color.White;
            this.videoSourcePlayer.Location = new System.Drawing.Point(3, 3);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(234, 92);
            this.videoSourcePlayer.TabIndex = 0;
            this.videoSourcePlayer.VideoSource = null;
            this.videoSourcePlayer.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer_NewFrame);
            this.videoSourcePlayer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer_MouseClick);
            this.videoSourcePlayer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer_MouseDoubleClick);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(474, 461);
            this.tabControl2.TabIndex = 0;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.MainMap);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.labelCurCoordXY);
            this.tabPage3.Controls.Add(this.labelCurCoord);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(466, 435);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Навігаційна карта";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // MainMap
            // 
            this.MainMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(5, 42);
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 2;
            this.MainMap.MinZoom = 2;
            this.MainMap.MouseWheelZoomEnabled = true;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(456, 366);
            this.MainMap.TabIndex = 51;
            this.MainMap.Zoom = 0D;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.button10);
            this.groupBox6.Controls.Add(this.button9);
            this.groupBox6.Controls.Add(this.button11);
            this.groupBox6.Controls.Add(this.button8);
            this.groupBox6.Location = new System.Drawing.Point(6, -1);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(453, 39);
            this.groupBox6.TabIndex = 50;
            this.groupBox6.TabStop = false;
            // 
            // button10
            // 
            this.button10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button10.Image = global::DronProtectSample.Properties.Resources._3;
            this.button10.Location = new System.Drawing.Point(317, 7);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(130, 30);
            this.button10.TabIndex = 0;
            this.button10.Text = "Видалити мітки";
            this.button10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.Image = global::DronProtectSample.Properties.Resources._1;
            this.button9.Location = new System.Drawing.Point(190, 7);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(124, 30);
            this.button9.TabIndex = 0;
            this.button9.Text = "Зберегти мітки";
            this.button9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button11
            // 
            this.button11.Image = global::DronProtectSample.Properties.Resources.file;
            this.button11.Location = new System.Drawing.Point(54, 7);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(46, 30);
            this.button11.TabIndex = 0;
            this.button11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button8
            // 
            this.button8.Image = global::DronProtectSample.Properties.Resources.koordsmall;
            this.button8.Location = new System.Drawing.Point(5, 7);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(46, 30);
            this.button8.TabIndex = 0;
            this.button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // labelCurCoordXY
            // 
            this.labelCurCoordXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCurCoordXY.BackColor = System.Drawing.Color.PaleGreen;
            this.labelCurCoordXY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelCurCoordXY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCurCoordXY.Location = new System.Drawing.Point(256, 412);
            this.labelCurCoordXY.Name = "labelCurCoordXY";
            this.labelCurCoordXY.Size = new System.Drawing.Size(204, 19);
            this.labelCurCoordXY.TabIndex = 49;
            // 
            // labelCurCoord
            // 
            this.labelCurCoord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCurCoord.BackColor = System.Drawing.Color.LemonChiffon;
            this.labelCurCoord.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelCurCoord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCurCoord.Location = new System.Drawing.Point(6, 412);
            this.labelCurCoord.Name = "labelCurCoord";
            this.labelCurCoord.Size = new System.Drawing.Size(210, 19);
            this.labelCurCoord.TabIndex = 49;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.listBoxRGN);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(466, 435);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Таблиця об\'єктів";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // listBoxRGN
            // 
            this.listBoxRGN.AllowUserToAddRows = false;
            this.listBoxRGN.AllowUserToDeleteRows = false;
            this.listBoxRGN.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxRGN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listBoxRGN.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.listBoxRGN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listBoxRGN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column1,
            this.Column2});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listBoxRGN.DefaultCellStyle = dataGridViewCellStyle4;
            this.listBoxRGN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxRGN.GridColor = System.Drawing.Color.Gainsboro;
            this.listBoxRGN.Location = new System.Drawing.Point(0, 0);
            this.listBoxRGN.Name = "listBoxRGN";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listBoxRGN.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.listBoxRGN.RowHeadersVisible = false;
            this.listBoxRGN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listBoxRGN.Size = new System.Drawing.Size(466, 435);
            this.listBoxRGN.TabIndex = 54;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "№";
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "X";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.HeaderText = "Y";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Lat";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Lng";
            this.Column2.Name = "Column2";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.splitContainer3);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(466, 435);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Перегляд збережених знімків";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.imageListView1);
            this.splitContainer3.Size = new System.Drawing.Size(460, 429);
            this.splitContainer3.SplitterDistance = 39;
            this.splitContainer3.TabIndex = 1;
            // 
            // imageListView1
            // 
            this.imageListView1.DefaultImage = null;
            this.imageListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListView1.ErrorImage = null;
            this.imageListView1.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.imageListView1.Location = new System.Drawing.Point(0, 0);
            this.imageListView1.Name = "imageListView1";
            this.imageListView1.Size = new System.Drawing.Size(460, 386);
            this.imageListView1.TabIndex = 0;
            this.imageListView1.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.checkBox6);
            this.groupBox3.Controls.Add(this.checkBox4);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.comboBoxMapType);
            this.groupBox3.Controls.Add(this.comboBoxMode);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(571, -1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(412, 138);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Налаштування роботи з картою";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButtonCT3);
            this.groupBox5.Controls.Add(this.textBoxCachePath);
            this.groupBox5.Controls.Add(this.radioButtonCT1);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.button7);
            this.groupBox5.Controls.Add(this.buttonChangeCacheDir);
            this.groupBox5.Location = new System.Drawing.Point(201, 11);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(205, 121);
            this.groupBox5.TabIndex = 57;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Cache type";
            // 
            // radioButtonCT3
            // 
            this.radioButtonCT3.AutoSize = true;
            this.radioButtonCT3.Location = new System.Drawing.Point(112, 19);
            this.radioButtonCT3.Name = "radioButtonCT3";
            this.radioButtonCT3.Size = new System.Drawing.Size(75, 17);
            this.radioButtonCT3.TabIndex = 75;
            this.radioButtonCT3.Text = "SASplanet";
            this.radioButtonCT3.UseVisualStyleBackColor = true;
            this.radioButtonCT3.CheckedChanged += new System.EventHandler(this.radioButtonCT1_CheckedChanged);
            // 
            // textBoxCachePath
            // 
            this.textBoxCachePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCachePath.Location = new System.Drawing.Point(5, 67);
            this.textBoxCachePath.Multiline = true;
            this.textBoxCachePath.Name = "textBoxCachePath";
            this.textBoxCachePath.ReadOnly = true;
            this.textBoxCachePath.Size = new System.Drawing.Size(168, 48);
            this.textBoxCachePath.TabIndex = 50;
            // 
            // radioButtonCT1
            // 
            this.radioButtonCT1.AutoSize = true;
            this.radioButtonCT1.Checked = true;
            this.radioButtonCT1.Location = new System.Drawing.Point(10, 19);
            this.radioButtonCT1.Name = "radioButtonCT1";
            this.radioButtonCT1.Size = new System.Drawing.Size(96, 17);
            this.radioButtonCT1.TabIndex = 74;
            this.radioButtonCT1.TabStop = true;
            this.radioButtonCT1.Text = "DB cache type";
            this.radioButtonCT1.UseVisualStyleBackColor = true;
            this.radioButtonCT1.CheckedChanged += new System.EventHandler(this.radioButtonCT1_CheckedChanged);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(6, 39);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(183, 25);
            this.label16.TabIndex = 71;
            this.label16.Text = "Директорія SASplanet cache (поточна - за умовчанням)";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(176, 93);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(25, 22);
            this.button7.TabIndex = 2;
            this.button7.Text = "x";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // buttonChangeCacheDir
            // 
            this.buttonChangeCacheDir.Location = new System.Drawing.Point(176, 67);
            this.buttonChangeCacheDir.Name = "buttonChangeCacheDir";
            this.buttonChangeCacheDir.Size = new System.Drawing.Size(25, 22);
            this.buttonChangeCacheDir.TabIndex = 2;
            this.buttonChangeCacheDir.Text = "...";
            this.buttonChangeCacheDir.UseVisualStyleBackColor = true;
            this.buttonChangeCacheDir.Click += new System.EventHandler(this.buttonChangeCacheDir_Click);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Location = new System.Drawing.Point(6, 69);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(105, 17);
            this.checkBox6.TabIndex = 49;
            this.checkBox6.Text = "Прямокутна СК";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(6, 50);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(117, 17);
            this.checkBox4.TabIndex = 49;
            this.checkBox4.Text = "Відображати сітку";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 32);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(177, 17);
            this.checkBox2.TabIndex = 49;
            this.checkBox2.Text = "Автоповорот відповідно курсу";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(6, 15);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(133, 17);
            this.checkBox1.TabIndex = 49;
            this.checkBox1.Text = "Переміщувати карту ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBoxMapType
            // 
            this.comboBoxMapType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMapType.FormattingEnabled = true;
            this.comboBoxMapType.Location = new System.Drawing.Point(46, 87);
            this.comboBoxMapType.Name = "comboBoxMapType";
            this.comboBoxMapType.Size = new System.Drawing.Size(152, 21);
            this.comboBoxMapType.TabIndex = 43;
            this.comboBoxMapType.DropDownClosed += new System.EventHandler(this.comboBoxMapType_DropDownClosed);
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Location = new System.Drawing.Point(46, 111);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(152, 21);
            this.comboBoxMode.TabIndex = 45;
            this.comboBoxMode.DropDownClosed += new System.EventHandler(this.comboBoxMode_DropDownClosed);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(3, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "Карта";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(3, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "Режим";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxStartImitator);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 135);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            // 
            // checkBoxStartImitator
            // 
            this.checkBoxStartImitator.AutoSize = true;
            this.checkBoxStartImitator.Location = new System.Drawing.Point(6, 112);
            this.checkBoxStartImitator.Name = "checkBoxStartImitator";
            this.checkBoxStartImitator.Size = new System.Drawing.Size(141, 17);
            this.checkBoxStartImitator.TabIndex = 49;
            this.checkBoxStartImitator.Text = "Режим імітації польоту";
            this.checkBoxStartImitator.UseVisualStyleBackColor = true;
            this.checkBoxStartImitator.CheckedChanged += new System.EventHandler(this.checkBoxStartImitator_CheckedChanged);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.MistyRose;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.ForeColor = System.Drawing.Color.Brown;
            this.textBox4.Location = new System.Drawing.Point(212, 71);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(72, 24);
            this.textBox4.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Honeydew;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.ForeColor = System.Drawing.Color.Green;
            this.textBox3.Location = new System.Drawing.Point(78, 72);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(73, 24);
            this.textBox3.TabIndex = 2;
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.Color.Linen;
            this.textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox10.ForeColor = System.Drawing.Color.RoyalBlue;
            this.textBox10.Location = new System.Drawing.Point(212, 14);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(91, 24);
            this.textBox10.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(161, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Курс, °";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Висота, м";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Linen;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.Color.DarkOrange;
            this.textBox1.Location = new System.Drawing.Point(78, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(91, 24);
            this.textBox1.TabIndex = 2;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.Linen;
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox9.ForeColor = System.Drawing.Color.RoyalBlue;
            this.textBox9.Location = new System.Drawing.Point(212, 43);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(91, 24);
            this.textBox9.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(175, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 19);
            this.label15.TabIndex = 3;
            this.label15.Text = "X, м";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Linen;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.ForeColor = System.Drawing.Color.DarkOrange;
            this.textBox2.Location = new System.Drawing.Point(78, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(91, 24);
            this.textBox2.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(174, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 18);
            this.label14.TabIndex = 3;
            this.label14.Text = "Y, м";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Широта, °";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Довгота, °";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxSaveNavigationMap);
            this.groupBox4.Controls.Add(this.checkBoxSaveOnDblClick);
            this.groupBox4.Controls.Add(this.checkBox3);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.button6);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.textBox6);
            this.groupBox4.Controls.Add(this.textBox8);
            this.groupBox4.Controls.Add(this.textBox7);
            this.groupBox4.Location = new System.Drawing.Point(983, 1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(260, 134);
            this.groupBox4.TabIndex = 53;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Налаштування роботи з відео";
            // 
            // checkBoxSaveNavigationMap
            // 
            this.checkBoxSaveNavigationMap.AutoSize = true;
            this.checkBoxSaveNavigationMap.Checked = true;
            this.checkBoxSaveNavigationMap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSaveNavigationMap.Location = new System.Drawing.Point(6, 87);
            this.checkBoxSaveNavigationMap.Name = "checkBoxSaveNavigationMap";
            this.checkBoxSaveNavigationMap.Size = new System.Drawing.Size(169, 17);
            this.checkBoxSaveNavigationMap.TabIndex = 49;
            this.checkBoxSaveNavigationMap.Text = "Зберегати навігаційну карту";
            this.checkBoxSaveNavigationMap.UseVisualStyleBackColor = true;
            // 
            // checkBoxSaveOnDblClick
            // 
            this.checkBoxSaveOnDblClick.AutoSize = true;
            this.checkBoxSaveOnDblClick.Location = new System.Drawing.Point(6, 68);
            this.checkBoxSaveOnDblClick.Name = "checkBoxSaveOnDblClick";
            this.checkBoxSaveOnDblClick.Size = new System.Drawing.Size(201, 17);
            this.checkBoxSaveOnDblClick.TabIndex = 49;
            this.checkBoxSaveOnDblClick.Text = "Зберегати зображення за DblClick";
            this.checkBoxSaveOnDblClick.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(6, 19);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(118, 17);
            this.checkBox3.TabIndex = 49;
            this.checkBox3.Text = "Збереження відео";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(169, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(12, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "x";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(207, 113);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 13);
            this.label13.TabIndex = 49;
            this.label13.Text = "...";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(105, 107);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(95, 23);
            this.button6.TabIndex = 48;
            this.button6.Text = "Копія приорітет";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 107);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(95, 23);
            this.button5.TabIndex = 48;
            this.button5.Text = "Копія екрану";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 39);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(79, 24);
            this.button4.TabIndex = 48;
            this.button4.Text = "Новий файл";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(91, 42);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(163, 20);
            this.textBox6.TabIndex = 51;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(187, 17);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(35, 20);
            this.textBox8.TabIndex = 51;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(130, 17);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(35, 20);
            this.textBox7.TabIndex = 51;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(321, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(244, 119);
            this.tabControl1.TabIndex = 53;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(23, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(217, 111);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Робочий";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(8, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 106);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Сервер координат";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(82, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "...";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(47, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 49;
            this.label10.Text = "мс";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "...";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(70, 81);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 23);
            this.button3.TabIndex = 50;
            this.button3.Text = "Швидкість прийому";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(6, 81);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(35, 20);
            this.textBox5.TabIndex = 51;
            this.textBox5.Text = "50";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Статус:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(106, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 23);
            this.button2.TabIndex = 48;
            this.button2.Text = "Стоп сервер";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 47;
            this.button1.Text = "Старт сервер";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(17, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = "Прийнято:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox12);
            this.tabPage2.Controls.Add(this.textBoxAccuracy);
            this.tabPage2.Controls.Add(this.textBoxSpeed);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.textBox11);
            this.tabPage2.Controls.Add(this.buttonLoadTrack);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Location = new System.Drawing.Point(23, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(217, 111);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Демо";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(176, 60);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(35, 20);
            this.textBox12.TabIndex = 51;
            this.textBox12.Text = "1000";
            // 
            // textBoxAccuracy
            // 
            this.textBoxAccuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAccuracy.Location = new System.Drawing.Point(169, 85);
            this.textBoxAccuracy.Name = "textBoxAccuracy";
            this.textBoxAccuracy.Size = new System.Drawing.Size(42, 20);
            this.textBoxAccuracy.TabIndex = 28;
            this.textBoxAccuracy.Text = "0.0003";
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSpeed.Location = new System.Drawing.Point(73, 85);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.Size = new System.Drawing.Size(42, 20);
            this.textBoxSpeed.TabIndex = 27;
            this.textBoxSpeed.Text = "50";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(114, 88);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 14);
            this.label19.TabIndex = 29;
            this.label19.Text = "Точність";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(8, 82);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 26);
            this.label20.TabIndex = 28;
            this.label20.Text = "Швидкість руху км/ч";
            // 
            // textBox11
            // 
            this.textBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox11.Location = new System.Drawing.Point(6, 34);
            this.textBox11.Multiline = true;
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(180, 22);
            this.textBox11.TabIndex = 50;
            // 
            // buttonLoadTrack
            // 
            this.buttonLoadTrack.Location = new System.Drawing.Point(189, 34);
            this.buttonLoadTrack.Name = "buttonLoadTrack";
            this.buttonLoadTrack.Size = new System.Drawing.Size(25, 22);
            this.buttonLoadTrack.TabIndex = 2;
            this.buttonLoadTrack.Text = "...";
            this.buttonLoadTrack.UseVisualStyleBackColor = true;
            this.buttonLoadTrack.Click += new System.EventHandler(this.buttonLoadTrack_Click);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(8, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(183, 25);
            this.label17.TabIndex = 71;
            this.label17.Text = "Завантажити файл з координатами маршруту руху БПЛА";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(8, 64);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(170, 13);
            this.label18.TabIndex = 44;
            this.label18.Text = "Період оновлення маршруту, мс";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point(344, 120);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(180, 17);
            this.checkBox5.TabIndex = 49;
            this.checkBox5.Text = "Відображати маршрут на карті";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // alarmTimer
            // 
            this.alarmTimer.Interval = 200;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerImitator
            // 
            this.timerImitator.Tick += new System.EventHandler(this.timerImitator_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timerTMP
            // 
            this.timerTMP.Interval = 60000;
            this.timerTMP.Tick += new System.EventHandler(this.timerTMP_Tick);
            // 
            // timerReal
            // 
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 662);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DronProtect ver.1.0.0 - fedor4uk.d@gmail.com";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuMenu.ResumeLayout(false);
            this.menuMenu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxRGN)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel fpsLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem openJPEGURLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMJPEGURLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localVideoCaptureDeviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openVideoFileusingDirectShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel objectsCountLabel;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
        private System.Windows.Forms.Timer alarmTimer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxMapType;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label labelCurCoord;
        private System.Windows.Forms.Label labelCurCoordXY;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButtonCT3;
        private System.Windows.Forms.TextBox textBoxCachePath;
        private System.Windows.Forms.RadioButton radioButtonCT1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button buttonChangeCacheDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Button buttonLoadTrack;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox checkBoxStartImitator;
        private System.Windows.Forms.Timer timerImitator;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBoxAccuracy;
        private System.Windows.Forms.TextBox textBoxSpeed;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Timer timerTMP;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private Manina.Windows.Forms.ImageListView imageListView1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private Map MainMap;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.CheckBox checkBoxSaveOnDblClick;
        private System.Windows.Forms.CheckBox checkBoxSaveNavigationMap;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView listBoxRGN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Timer timerReal;
    }
}

