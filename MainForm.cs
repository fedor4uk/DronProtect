using System;
using System.Net;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Xml;
using System.Text;

using AForge;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.VFW;
using AForge.Video.DirectShow;
using AForge.Vision.Motion;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;

using System.IO;
using System.Net.Sockets;

using CoordTools;
using Globals;
using Demo.WindowsForms.CustomMarkers;

namespace MotionDetectorSample
{
    public partial class MainForm : Form
    {
        AVIWriter writer;

        internal readonly GMapOverlay routesObj = new GMapOverlay("routesObj");
        internal readonly GMapOverlay objectsS = new GMapOverlay("objectsS");
        internal readonly GMapOverlay polygons = new GMapOverlay("polygons");
        internal readonly GMapOverlay objects = new GMapOverlay("objects");

        GMapPolygon polygon;

        System.Drawing.Image mapImage;

        public class Target
        {
            public double X;
            public double Y;
            public double Vx;
            public double Vy;
            public PointF a;
            public int time;
        }

        AppSettings appSettings;
        string fileName;
        string curDir;
        int dX, dY;
        int cntImg = 0;
        bool StartServer = false;
        bool StartRead = false;
        bool isStartServer = false;
        bool isStopServer = false;
        bool isNewAvi = true;
        bool isNewImg = false;
        bool isNewImgPr = false;
        // opened video source
        private IVideoSource videoSource = null;
        // motion detector
        MotionDetector detector = new MotionDetector(
            new TwoFramesDifferenceDetector( ),
            new MotionAreaHighlighting( ) );
        // motion detection and processing algorithm
        private int motionDetectionType = 1;
        private int motionProcessingType = 1;

        // statistics length
        private const int statLength = 15;
        // current statistics index
        private int statIndex = 0;
        // ready statistics values
        private int statReady = 0;
        // statistics array
        private int[] statCount = new int[statLength];

        // counter used for flashing
        private int flash = 0;
        private float motionAlarmLevel = 0.015f;

        private List<float> motionHistory = new List<float>( );
        private int detectedObjectsCount = -1;
        PointLatLng flyPt;
        double flyAz = 0;
        double flyAlt = 0;
        int cntDcl = 0;
        int pos = 0;
        int plW = 0;
        int plH = 0;

        System.Drawing.Point[] DclPt = new System.Drawing.Point[10];
        Target[] target;
        List<PointF> ltarget;
        double targetL, targetB;
        int currentPos = 0;
        int zn = 1;
        bool LoadTrack = false;
        bool UpdateTrack = false;

        private void LoadConfiguration(string filename = "rs.xml")
        {
            string FileName = "";

            if (filename == "rs.xml")
                FileName = Application.StartupPath + "\\" + filename;
            else FileName = filename;
            PointLatLng pos = new PointLatLng();
            double lon = 0, lat = 0;

            CultureInfo cinf = CultureInfo.CurrentCulture;
            string numbdecsep = cinf.NumberFormat.NumberDecimalSeparator;

            //*******************************************************************************
            // Создаем экземпляр класса
            XmlDocument xmlDoc = new XmlDocument();

            if (!File.Exists(FileName)) return;
            // Загружаем XML-документ из файла
            xmlDoc.Load(FileName);

            foreach (XmlNode table in xmlDoc.DocumentElement.ChildNodes)
            {
                if (numbdecsep == ",")
                {
                    table.Attributes[1].Value = table.Attributes[1].Value.Replace('.', ',');
                    table.Attributes[2].Value = table.Attributes[2].Value.Replace('.', ',');
                }
                else
                {
                    table.Attributes[1].Value = table.Attributes[1].Value.Replace(',', '.');
                    table.Attributes[2].Value = table.Attributes[2].Value.Replace(',', '.');
                }
                // перебираем все атрибуты элемента

                lon = Convert.ToDouble(table.Attributes[1].Value.ToString());
                lat = Convert.ToDouble(table.Attributes[2].Value.ToString());
                pos.Lng = lon; pos.Lat = lat;

                GMarkerGoogle d = new GMarkerGoogle(pos, GMarkerGoogleType.yellow_small);
                d.ToolTip = new GMapRoundedToolTip(d);

                GMapMarkerCircle mBorders = new GMapMarkerCircle(pos);
                {
                    mBorders.InnerMarker = d;
                    mBorders.ToolTipText = (table.Attributes[0].Value).ToString();
                    mBorders.ToolTipMode = MarkerTooltipMode.Always;
                    mBorders.showEffRad = true;
                    mBorders.Radius = 500;
                    mBorders.ToolTipMode = MarkerTooltipMode.Always;
                }

                objects.Markers.Add(d);
                objects.Markers.Add(mBorders);
            }
        }

        public MainForm( )
        {
            InitializeComponent( );
            Application.Idle += new EventHandler( Application_Idle );

            AppSettings.StartupPath = Application.StartupPath;
            appSettings = new AppSettings();
            imageListView1.Items.AddRange(Directory.GetFiles(AppSettings.StartupPath + Path.DirectorySeparatorChar + "Img"));
            imageListView1.View = Manina.Windows.Forms.View.Gallery;

            comboBoxMode.DataSource = Enum.GetValues(typeof(AccessMode));
            comboBoxMode.SelectedItem = MainMap.Manager.Mode;

            if (appSettings.cacheMode == AppSettings.CacheMode.CacheOnly)
                MainMap.Manager.Mode = AccessMode.CacheOnly;
            else if (appSettings.cacheMode == AppSettings.CacheMode.ServerAndCache)
                MainMap.Manager.Mode = AccessMode.ServerAndCache;
            else if (appSettings.cacheMode == AppSettings.CacheMode.ServerOnly)
                MainMap.Manager.Mode = AccessMode.ServerOnly;

            if (appSettings.cacheType == AppSettings.CacheType.DB)
            {
                GMap.NET.CacheProviders.SQLitePureImageCache ch = new GMap.NET.CacheProviders.SQLitePureImageCache();
                ch.CacheLocation = appSettings.DBCachePath;
                MainMap.Manager.PrimaryCache = ch;
            }
            else if (appSettings.cacheType == AppSettings.CacheType.SASPlanet)
            {
                GMap.NET.CacheProviders.SASPureImageCache ch = new GMap.NET.CacheProviders.SASPureImageCache();
                ch.CacheFolder = appSettings.SASCachePath;
                MainMap.Manager.PrimaryCache = ch;
            }

            GMapProvider curprov = null;// = GMapProviders.GoogleMap;
            for (int i = 0; i < GMapProviders.List.Count; i++)
            {
                if (GMapProviders.List[i].Name == appSettings.MapProvider)
                    curprov = GMapProviders.List[i];
            }
            if (curprov != null)
                MainMap.MapProvider = curprov;
            else MainMap.MapProvider = GMapProviders.GoogleMap;

            MainMap.CacheLocation = Application.StartupPath;
            MainMap.DragButton = System.Windows.Forms.MouseButtons.Left;
            MainMap.MinZoom = 0;
            MainMap.MaxZoom = 24;
            MainMap.Zoom = 15;
            MainMap.Position = new PointLatLng(appSettings.BMap, appSettings.LMap);
            MainMap.DisableFocusOnMouseEnter = true;
            MainMap.MouseMove += new MouseEventHandler(MainMap_MouseMove);

            List<GMapProvider> prov = new List<GMapProvider>();
            prov.Add(GMapProviders.GoogleMap); prov.Add(GMapProviders.GoogleSatelliteMap); prov.Add(GMapProviders.GoogleHybridMap);
            prov.Add(GMapProviders.YandexMap); prov.Add(GMapProviders.YandexSatelliteMap); prov.Add(GMapProviders.YandexHybridMap);
            prov.Add(GMapProviders.BingMap); prov.Add(GMapProviders.BingSatelliteMap); prov.Add(GMapProviders.BingHybridMap);
            prov.Add(GMapProviders.OpenStreetMap); prov.Add(GMapProviders.WikiMapiaMap);
            comboBoxMapType.ValueMember = "Name";
            comboBoxMapType.DataSource = prov;// GMapProviders.List;
            comboBoxMapType.SelectedItem = MainMap.MapProvider;

            flyPt = new PointLatLng(50.193000925981, 28.519241809845);
            MainMap.Position = flyPt;

            curDir = Application.StartupPath;

            MainMap.MouseMove += new MouseEventHandler(MainMap_MouseMove);

            MainMap.Overlays.Add(objectsS);
            MainMap.Overlays.Add(routesObj);
            MainMap.Overlays.Add(polygons);
            MainMap.Overlays.Add(objects);
            routesObj.Routes.Add(new GMapRoute("Rule"));
            routesObj.Routes[0].Stroke = new Pen(new SolidBrush(Color.FromArgb(155, 255, 0, 0)), 2);
            List<PointLatLng> polygonPoints = new List<PointLatLng>();

            polygon = new GMapPolygon(polygonPoints, "polygon danger");
            polygon.Points.Add(new PointLatLng(50.2277188739856, 28.5254997925648));
            polygon.Points.Add(new PointLatLng(50.224084735001,  28.5185475067982));
            polygon.Points.Add(new PointLatLng(50.2173663510934, 28.518332930077  ));
            polygon.Points.Add(new PointLatLng(50.2163199597771, 28.5320658402332 ));
            polygon.Points.Add(new PointLatLng(50.2199546936239, 28.5474295334705));
            polygon.Points.Add(new PointLatLng(50.2267828345064, 28.5502619461902));
            polygon.Points.Add(new PointLatLng(50.230031362914,  28.538503141869));
            polygon.Points.Add(new PointLatLng(50.2277188739856, 28.5254997925648 ));

            polygons.Polygons.Add(polygon);
            polygon.Fill = new SolidBrush(Color.FromArgb(50, 0, 255, 0));

            LoadConfiguration();
        }

        void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            PointLatLng? sensorCoord = MainMap.FromLocalToLatLng(e.X, e.Y);
            double X = 0, Y = 0;
            CoordTransform.WGStoPulkovo42(sensorCoord.Value.Lat, sensorCoord.Value.Lng, out X, out Y);
            labelCurCoord.Text = "Lat: " + sensorCoord.Value.Lat.ToString("0.000000") + "   Lon: " + sensorCoord.Value.Lng.ToString("0.000000");
            labelCurCoord.Text = "Lat: " + BigCoord(sensorCoord.Value.Lat) + "   Lon: " + BigCoord(sensorCoord.Value.Lng);
            
            labelCurCoordXY.Text = "X: " + X.ToString("0.000") + "   Y: " + Y.ToString("0.000"); 
        }

        // "Exit" menu item clicked
        private void exitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.Close( );
        }

        // "About" menu item clicked
        private void aboutToolStripMenuItem_Click( object sender, EventArgs e )
        {
            AboutForm form = new AboutForm( );
            form.ShowDialog( );
        }

        // "Open" menu item clieck - open AVI file
        private void openToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( openFileDialog.ShowDialog( ) == DialogResult.OK )
            {
                // create video source
                AVIFileVideoSource fileSource = new AVIFileVideoSource( openFileDialog.FileName );

                OpenVideoSource( fileSource );
            }
        }

        // Open JPEG URL
        private void openJPEGURLToolStripMenuItem_Click( object sender, EventArgs e )
        {
            URLForm form = new URLForm( );

            form.Description = "Enter URL of an updating JPEG from a web camera:";
            form.URLs = new string[]
				{
					"http://195.243.185.195/axis-cgi/jpg/image.cgi?camera=1"
				};

            if ( form.ShowDialog( this ) == DialogResult.OK )
            {
                // create video source
                JPEGStream jpegSource = new JPEGStream( form.URL );

                // open it
                OpenVideoSource( jpegSource );
            }
        }

        // Open MJPEG URL
        private void openMJPEGURLToolStripMenuItem_Click( object sender, EventArgs e )
        {
            URLForm form = new URLForm( );

            form.Description = "Enter URL of an MJPEG video stream:";
            form.URLs = new string[]
				{
					"http://195.243.185.195/axis-cgi/mjpg/video.cgi?camera=3",
					"http://195.243.185.195/axis-cgi/mjpg/video.cgi?camera=4",
				};

            if ( form.ShowDialog( this ) == DialogResult.OK )
            {
                // create video source
                MJPEGStream mjpegSource = new MJPEGStream( form.URL );

                // open it
                OpenVideoSource( mjpegSource );
            }
        }

        // Open local video capture device
        private void localVideoCaptureDeviceToolStripMenuItem_Click( object sender, EventArgs e )
        {
            VideoCaptureDeviceForm form = new VideoCaptureDeviceForm( );

            if ( form.ShowDialog( this ) == DialogResult.OK )
            {
                // create video source
                VideoCaptureDevice videoSource = new VideoCaptureDevice( form.VideoDevice );

                // open it
                OpenVideoSource( videoSource );
            }
        }

        // Open video file using DirectShow
        private void openVideoFileusingDirectShowToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( openFileDialog.ShowDialog( ) == DialogResult.OK )
            {
                // create video source
                FileVideoSource fileSource = new FileVideoSource( openFileDialog.FileName );
                //fileSource.
                // open it
                OpenVideoSource( fileSource );
            }
        }

        // Open video source
        private void OpenVideoSource( IVideoSource source )
        {
            // set busy cursor
            this.Cursor = Cursors.WaitCursor;

            // close previous video source
            CloseVideoSource( );

            // start new video source
            videoSourcePlayer.VideoSource = new AsyncVideoSource( source );
            videoSourcePlayer.Start( );

            // reset statistics
            statIndex = statReady = 0;

            // start timers
            timer.Start( );
            alarmTimer.Start( );

            videoSource = source;

            this.Cursor = Cursors.Default;

            isNewAvi = true;
            // create new AVI file and open it
        }

        // Close current video source
        private void CloseVideoSource( )
        {
            // set busy cursor
            this.Cursor = Cursors.WaitCursor;

            // stop current video source
            videoSourcePlayer.SignalToStop( );

            // wait 2 seconds until camera stops
            for ( int i = 0; ( i < 50 ) && ( videoSourcePlayer.IsRunning ); i++ )
            {
                Thread.Sleep( 100 );
            }
            if ( videoSourcePlayer.IsRunning )
                videoSourcePlayer.Stop( );

            // stop timers
            timer.Stop( );
            alarmTimer.Stop( );

            motionHistory.Clear( );

            // reset motion detector
            if ( detector != null )
                detector.Reset( );

            videoSourcePlayer.BorderColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        // New frame received by the player
        private string BigCoord(double c)
        {
            double tmp = 0;
            string str = "";
            int h = (int)Math.Truncate(c);
            str = h.ToString("00") + "°";
            
            tmp = (c - h) * 60;
            int m = (int)Math.Truncate(tmp);
            str = str + m.ToString("00") + "'";
            double s = (tmp - m) * 60;
            str = str + s.ToString("00.0") + "\"";

            return str;
        }

        private void DrawGrid(Graphics gr, System.Drawing.Size size)
        {
            string curCoord1, curCoord2;
            double X = 0, Y = 0;

            Pen curPen = new Pen(Color.FromArgb(155, 255, 0, 0));
            curPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            curPen.Width = 3;

            Pen gridPen = new Pen(Color.FromArgb(155, 255, 255, 255));
            gridPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            gridPen.Width = 1;

            // Create string to draw.
            String drawString = "  ";
            Font drawFont = new Font("Arial", 7);
            Font drawFont1 = new Font("Arial", 9);
            SolidBrush drawBrush = new SolidBrush(Color.FromArgb(155, 0, 0, 0));
            SolidBrush Fill = new SolidBrush(Color.FromArgb(155, 255, 255, 255));

            int plW = size.Width;
            int plH = size.Height;

            gr.FillRectangle(Fill, plW - 80, plH - 50, 90, 30);

            if (checkBox6.Checked)
            {
                CoordTransform.WGStoPulkovo42(flyPt.Lat, flyPt.Lng, out X, out Y);
                curCoord1 = (X).ToString("0.000");
                curCoord2 = (Y).ToString("0.000");
            }
            else
            {
                curCoord1 = BigCoord(flyPt.Lat);
                curCoord2 = BigCoord(flyPt.Lng);
            }

            gr.DrawString(curCoord1 + "\n" + curCoord2, drawFont1, new SolidBrush(Color.FromArgb(255, 255, 0, 0)), plW - 80, plH - 50);
            // Create point for upper-left corner of drawing.
            PointF drawPoint = new PointF(10.0F, 10.0F);

            drawString = BigCoord(56.545342643634);
            System.Drawing.Size TextPadding = new Size(5, 5);
            System.Drawing.Size st = gr.MeasureString(drawString, drawFont).ToSize(); st.Width += 5;
            System.Drawing.Point posL = new System.Drawing.Point();
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(posL.X - TextPadding.Width / 2, posL.Y - TextPadding.Height / 2, st.Width + TextPadding.Width / 2, st.Height + TextPadding.Height / 2);

            gr.DrawLine(curPen, plW / 2 - 30, plH / 2+1, plW / 2 - 10, plH / 2+1);
            gr.DrawLine(curPen, plW / 2 + 30, plH / 2+1, plW / 2 + 10, plH / 2+1);
            gr.DrawLine(curPen, plW / 2, plH / 2 - 30, plW / 2, plH / 2 - 10);
            gr.DrawLine(curPen, plW / 2, plH / 2 + 30, plW / 2, plH / 2 + 10);

            gr.TranslateTransform(plW / 2, plH / 2);
            gr.RotateTransform(-(float)flyAz);
            gr.DrawLine(gridPen, -plW / 2-200, 0, plW / 2+200, 0);
            posL.X = -plW / 2 + 5;
            posL.Y = -plH / 4 * 0;
            rect = new System.Drawing.Rectangle(posL.X - TextPadding.Width / 2, posL.Y - TextPadding.Height / 2, st.Width + TextPadding.Width / 2, st.Height + TextPadding.Height / 2);
            gr.FillRectangle(Fill, rect);

            gr.DrawString(curCoord1, drawFont, drawBrush, posL.X, posL.Y);

            posL.X = plW / 2 - 50;
            posL.Y = -plH / 4 * 0;
            rect = new System.Drawing.Rectangle(posL.X - TextPadding.Width / 2, posL.Y - TextPadding.Height / 2, st.Width + TextPadding.Width / 2, st.Height + TextPadding.Height / 2);
            gr.FillRectangle(Fill, rect);
            gr.DrawString(curCoord1, drawFont, drawBrush, posL.X, posL.Y);

            gr.DrawLine(gridPen, 0, -plH / 2 - 200, 0, plH / 2 + 200);
            posL.X = -plW / 6 * 0 + 3;
            posL.Y = -plH / 2 + 5;
            rect = new System.Drawing.Rectangle(posL.X - TextPadding.Width / 2, posL.Y - TextPadding.Height / 2, st.Width + TextPadding.Width / 2, st.Height + TextPadding.Height / 2);
            gr.FillRectangle(Fill, rect);
            gr.DrawString(curCoord2, drawFont, drawBrush, posL.X, posL.Y);
            posL.X = -plW / 6 * 0 + 3;
            posL.Y = plH / 2 - 15;
            rect = new System.Drawing.Rectangle(posL.X - TextPadding.Width / 2, posL.Y - TextPadding.Height / 2, st.Width + TextPadding.Width / 2, st.Height + TextPadding.Height / 2);
            gr.FillRectangle(Fill, rect);
            gr.DrawString(curCoord2, drawFont, drawBrush, posL.X, posL.Y);

            for (int i = 1; i < 3; i++)
            {
                if (checkBox6.Checked)
                {
                    CoordTransform.WGStoPulkovo42(flyPt.Lat + 2 * i / 3600.0, flyPt.Lng, out X, out Y);
                    curCoord1 = X.ToString("0.000");
                    CoordTransform.WGStoPulkovo42(flyPt.Lat - 2 * i / 3600.0, flyPt.Lng, out X, out Y);
                    curCoord2 = X.ToString("0.000");
                }
                else
                {
                    curCoord1 = BigCoord(flyPt.Lat + 2 * i / 3600.0);
                    curCoord2 = BigCoord(flyPt.Lat - 2 * i / 3600.0);
                }
                gr.DrawLine(gridPen, -plW / 2-200, - plH / 4 * i, plW / 2+200, -plH / 4 * i);
                gr.DrawLine(gridPen, -plW / 2-200, +plH / 4 * i, plW / 2+200, +plH / 4 * i);

                posL.X = -plW / 2 + 5;
                posL.Y = -plH / 4 * i;
                rect = new System.Drawing.Rectangle(posL.X - TextPadding.Width / 2, posL.Y - TextPadding.Height / 2, st.Width + TextPadding.Width / 2, st.Height + TextPadding.Height / 2);
                gr.FillRectangle(Fill, rect);
                gr.DrawString(curCoord1, drawFont, drawBrush, posL.X, posL.Y);
                posL.X = plW / 2 - 60;
                posL.Y = -plH / 4 * i;
                rect = new System.Drawing.Rectangle(posL.X - TextPadding.Width / 2, posL.Y - TextPadding.Height / 2, st.Width + TextPadding.Width / 2, st.Height + TextPadding.Height / 2);
                gr.FillRectangle(Fill, rect);
                gr.DrawString(curCoord1, drawFont, drawBrush, posL.X, posL.Y);

                posL.X = -plW / 2 + 5;
                posL.Y = plH / 4 * i;
                rect = new System.Drawing.Rectangle(posL.X - TextPadding.Width / 2, posL.Y - TextPadding.Height / 2, st.Width + TextPadding.Width / 2, st.Height + TextPadding.Height / 2);
                gr.FillRectangle(Fill, rect);
                gr.DrawString(curCoord2, drawFont, drawBrush, posL.X, posL.Y);
                posL.X = plW / 2 - 60;
                posL.Y = plH / 4 * i;
                rect = new System.Drawing.Rectangle(posL.X - TextPadding.Width / 2, posL.Y - TextPadding.Height / 2, st.Width + TextPadding.Width / 2, st.Height + TextPadding.Height / 2);
                gr.FillRectangle(Fill, rect);
                gr.DrawString(curCoord2, drawFont, drawBrush, posL.X, posL.Y);
            }

            for (int i = 1; i < 4; i++)
            {
                if (checkBox6.Checked)
                {
                    CoordTransform.WGStoPulkovo42(flyPt.Lat, flyPt.Lng - 2 * i / 3600.0, out X, out Y);
                    curCoord1 = Y.ToString("0.000");
                    CoordTransform.WGStoPulkovo42(flyPt.Lat, flyPt.Lng +- 2 * i / 3600.0, out X, out Y);
                    curCoord2 = Y.ToString("0.000");
                }
                else
                {
                    curCoord1 = BigCoord(flyPt.Lng - 2 * i / 3600.0);
                    curCoord2 = BigCoord(flyPt.Lng + 2 * i / 3600.0);
                }
                posL.X = -plW / 6 * i + 3;
                posL.Y = -plH / 2 + 5;
                rect = new System.Drawing.Rectangle(posL.X - TextPadding.Width / 2, posL.Y - TextPadding.Height / 2, st.Width + TextPadding.Width / 2, st.Height + TextPadding.Height / 2);
                gr.FillRectangle(Fill, rect);
                gr.DrawString(curCoord1, drawFont, drawBrush, posL.X, posL.Y);
                posL.X = -plW / 6 * i + 3;
                posL.Y = plH / 2 - 15;
                rect = new System.Drawing.Rectangle(posL.X - TextPadding.Width / 2, posL.Y - TextPadding.Height / 2, st.Width + TextPadding.Width / 2, st.Height + TextPadding.Height / 2);
                gr.FillRectangle(Fill, rect);
                gr.DrawString(curCoord1, drawFont, drawBrush, posL.X, posL.Y);
                
                gr.DrawLine(gridPen, -plW / 6 * i, -plH / 2-200, -plW / 6 * i, plH / 2+200);

                posL.X = plW / 6 * i + 3;
                posL.Y = -plH / 2 + 5;
                rect = new System.Drawing.Rectangle(posL.X - TextPadding.Width / 2, posL.Y - TextPadding.Height / 2, st.Width + TextPadding.Width / 2, st.Height + TextPadding.Height / 2);
                gr.FillRectangle(Fill, rect);
                gr.DrawString(curCoord2, drawFont, drawBrush, posL.X, posL.Y);
                posL.X = plW / 6 * i + 3;
                posL.Y = plH / 2 - 15;
                rect = new System.Drawing.Rectangle(posL.X - TextPadding.Width / 2, posL.Y - TextPadding.Height / 2, st.Width + TextPadding.Width / 2, st.Height + TextPadding.Height / 2);
                gr.FillRectangle(Fill, rect);
                gr.DrawString(curCoord2, drawFont, drawBrush, posL.X, posL.Y);
               
                gr.DrawLine(gridPen, plW / 6 * i, -plH / 2-200, plW / 6 * i, plH / 2+200);
            }
        }


        // Делегат используется для записи в UI control из потока не-UI
        private delegate void SetTextDeleg(string text);
        private void si_DataReceived(string data)
        {
            textBox7.Text = data;
            textBox7.Invalidate();
        }
        private void si_DataReceived1(string data)
        {
            textBox8.Text = data;
            textBox8.Invalidate();
        }
        private void si_DataReceived2(string data)
        {
            textBox6.Text = data;
            textBox6.Invalidate();
        }

        private delegate void SetSizeDeleg();
        private void si_Size()
        {
            videoSourcePlayer.Location = curLocation;
            videoSourcePlayer.Size = curSize;
        }

        bool isResized = true;
        double koefX = 0;
        double koefY = 0;
        double koef = 0;
        System.Drawing.Size? ImSize = null;
        System.Drawing.Point curLocation;
        System.Drawing.Size curSize;

        private void CalcSize(System.Drawing.Size size)
        {
            System.Drawing.Size pSize = splitContainer2.Panel1.ClientSize;
            System.Drawing.Size iSize = size;
            koefX = (double)pSize.Width / (double)iSize.Width;
            koefY = (double)pSize.Height / (double)iSize.Height;

            if (iSize.Height * koefX > pSize.Height) koef = koefY;
            else koef = koefX;

            curLocation = new System.Drawing.Point((int)((pSize.Width - iSize.Width * koef) / 2), (int)((pSize.Height - iSize.Height * koef) / 2));
            curSize = new System.Drawing.Size((int)(iSize.Width * koef), (int)(iSize.Height * koef));
        }

        public void AddMarker(double Lat, double Lng)
        {
            string curCoord1, curCoord2;
            double X = 0, Y = 0;

            CoordTransform.WGStoPulkovo42(Lat, Lng, out X, out Y);

            listBoxRGN.Rows.Add(new string[] { (listBoxRGN.Rows.Count + 1).ToString(), X.ToString("0.000"), Y.ToString("0.000"), Lat.ToString(), Lng.ToString() });

            curCoord1 = "Lat: " + BigCoord(Lat) + "   Lon: " + BigCoord(Lng);
            curCoord2 = "X: " + X.ToString("0.000") + "   Y: " + Y.ToString("0.000"); 

            PointLatLng pos = new PointLatLng(Lat, Convert.ToDouble(Lng));//currentMarker.Position;
            GMarkerGoogle d = new GMarkerGoogle(pos, GMarkerGoogleType.red);

            d.ToolTip = new GMapToolTip(d);
            d.ToolTip.Stroke = new Pen(Color.FromArgb(0, 0, 0, 0));
            d.ToolTip.Fill = new SolidBrush(Color.FromArgb(50, 255, 255, 255));
            d.ToolTip.TextPadding = new System.Drawing.Size(3, 3);
            d.ToolTip.Offset = new System.Drawing.Point(8, -20);
            d.ToolTip.Foreground = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
            d.ToolTipText = curCoord2 + "\n" + curCoord1;
            d.ToolTip.Font = new Font(FontFamily.GenericSansSerif, 7, FontStyle.Regular);
            d.ToolTipMode = MarkerTooltipMode.Always;

            objectsS.Markers.Add(d);
        }

        public void SaveImg(Bitmap image, string curCoord1, string curCoord2)
        {
            if (checkBoxSaveNavigationMap.Checked)
            {
                int imWidth = 0;
                int imHeight = 0;
                imWidth = mapImage.Width + image.Width;
                if (mapImage.Height > image.Height) imHeight = mapImage.Height; else imHeight = image.Height;

                System.Drawing.Image mi = new Bitmap(imWidth, imHeight);
                Graphics gr = Graphics.FromImage(mi);
                gr.FillRectangle(new SolidBrush(Color.Black), 0, 0, imWidth, imHeight);
                gr.DrawImage(image, 0, 0);
                gr.DrawImage(mapImage, image.Width, 0);

                string tmpstr = DateTime.Now.ToString("ddMMyyyy_HHmmss");
                fileName = curDir + "\\Img\\img_" + tmpstr + ".jpg";
                mi.Save(fileName);
            }
            else
            {
                string tmpstr = DateTime.Now.ToString("ddMMyyyy_HHmmss");
                fileName = curDir + "\\Img\\img_" + tmpstr + ".jpg";
                image.Save(fileName);
            }
        }

        Font drawFont = new Font("Arial", 7);
        SolidBrush drawBrush = new SolidBrush(Color.FromArgb(155, 0, 0, 0));
        SolidBrush Fill = new SolidBrush(Color.FromArgb(155, 255, 255, 255));

        private void videoSourcePlayer_NewFrame( object sender, ref Bitmap image )
        {
            if (isResized)
            {
                ImSize = image.Size;
                CalcSize(image.Size);
                this.BeginInvoke(new SetSizeDeleg(si_Size), new object[] { });
                isResized = false;
            }
            pos++;
            lock ( this )
            {
                Graphics gr = Graphics.FromImage(image);

                Pen lpen = new Pen(Color.FromArgb(100, 255, 0, 0));
                lpen.Width = 2;

                //размер кадра в координатах (географ. или прямоугольные)
                string curCoord1 = "", curCoord2 = "";
                double X = 0, Y = 0;
                double widthX = 12.0 / 3600.0;
                double widthY = 8.0 / 3600.0;
                int tmpX = 0, tmpY = 0;
                double koefX = 0, koefY = 0;
                double curcoordLat = 0, curcoordLon = 0;
                double curcoordLatI = 0, curcoordLonI = 0;
                koefX = widthX / image.Width;
                koefY = widthY / image.Height;

                for (int i = 0; i < cntDcl; i++)
                {
                    gr.DrawLine(lpen, DclPt[i].X - 20, DclPt[i].Y - 20, DclPt[i].X - 20, DclPt[i].Y + 20);
                    gr.DrawLine(lpen, DclPt[i].X - 20, DclPt[i].Y - 20, DclPt[i].X - 13, DclPt[i].Y - 20);
                    gr.DrawLine(lpen, DclPt[i].X - 20, DclPt[i].Y + 20, DclPt[i].X - 13, DclPt[i].Y + 20);

                    gr.DrawLine(lpen, DclPt[i].X + 20, DclPt[i].Y - 20, DclPt[i].X + 20, DclPt[i].Y + 20);
                    gr.DrawLine(lpen, DclPt[i].X + 20, DclPt[i].Y - 20, DclPt[i].X + 13, DclPt[i].Y - 20);
                    gr.DrawLine(lpen, DclPt[i].X + 20, DclPt[i].Y + 20, DclPt[i].X + 13, DclPt[i].Y + 20);

                    tmpX = DclPt[i].X - image.Width / 2;
                    tmpY = DclPt[i].Y - image.Height / 2;

                    curcoordLon = tmpX * koefX;
                    curcoordLat = tmpY * koefY;

                    curcoordLonI = curcoordLon * Math.Cos(flyAz / 57.3) - curcoordLat * Math.Sin(flyAz / 57.3);
                    curcoordLatI = curcoordLon * Math.Sin(flyAz / 57.3) + curcoordLat * Math.Cos(flyAz / 57.3);

                    curcoordLonI = flyPt.Lng + curcoordLonI;
                    curcoordLatI = flyPt.Lat - curcoordLatI;

                    CoordTransform.WGStoPulkovo42(curcoordLatI, curcoordLonI, out X, out Y);

                    curCoord1 = "Lat: " + BigCoord(curcoordLatI) + "   Lon: " + BigCoord(curcoordLonI);
                    curCoord2 = "X: " + X.ToString("0.000") + "   Y: " + Y.ToString("0.000"); 

                    gr.FillRectangle(Fill, DclPt[i].X + 23, DclPt[i].Y - 23, 150, 25);
                    gr.DrawString(curCoord2 + "\n" + curCoord1, drawFont, drawBrush, DclPt[i].X + 25, DclPt[i].Y - 20);
                }

                if (checkBox4.Checked)
                {
                    DrawGrid(gr, image.Size);
                }
                if (checkBox3.Checked)
                {
                    if (isNewAvi)
                    {
                        writer.Close();
                        string tmpstr = DateTime.Now.ToString("ddMMyyyy_HHmmss");
                        fileName = curDir + "\\Video\\rec_" + tmpstr + ".avi";
                        dX = image.Width;
                        dY = image.Height;
                        writer.Open(fileName, dX, dY);
                            
                        isNewAvi = false;

                        this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { dX.ToString() });
                        this.BeginInvoke(new SetTextDeleg(si_DataReceived1), new object[] { dY.ToString() });
                        this.BeginInvoke(new SetTextDeleg(si_DataReceived2), new object[] { "rec_" + tmpstr + ".avi" });
                    }
                    else
                    {
                        writer.AddFrame(image);
                    }
                }
                if (isNewImg)
                {
                    isNewImg = false;

                    SaveImg(image, curCoord1, curCoord2);
                    cntDcl = 0;
                }

                if (isNewImgPr)
                {
                    isNewImgPr = false;
                    string tmpstr = DateTime.Now.ToString("ddMMyyyy_HHmmss");
                    fileName = curDir + "\\ImgPr\\imgpr_" + tmpstr + ".jpg";
                    image.Save(fileName);
                    cntDcl = 0;
                }
            }
        }

        // Update some UI elements
        private void Application_Idle( object sender, EventArgs e )
        {
            objectsCountLabel.Text = ( detectedObjectsCount < 0 ) ? string.Empty : "Objects: " + detectedObjectsCount;
        }

        // On timer event - gather statistics
        private void timer_Tick( object sender, EventArgs e )
        {
            IVideoSource videoSource = videoSourcePlayer.VideoSource;

            if ( videoSource != null )
            {
                // get number of frames for the last second
                statCount[statIndex] = videoSource.FramesReceived;

                // increment indexes
                if ( ++statIndex >= statLength )
                    statIndex = 0;
                if ( statReady < statLength )
                    statReady++;

                float fps = 0;

                // calculate average value
                for ( int i = 0; i < statReady; i++ )
                {
                    fps += statCount[i];
                }
                fps /= statReady;

                statCount[statIndex] = 0;

                fpsLabel.Text = fps.ToString( "F2" ) + " fps";
            }
        }


        
        private void MainForm_Load(object sender, EventArgs e)
        {
            writer = new AVIWriter();
            writer.Codec = "XVid";
        }

        // Application's main form is closing
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseVideoSource();
            writer.Close();
            StartRead = false;
            StartServer = false;
            Thread.Sleep(500);

            appSettings.Close();
            
        }

        private void comboBoxMapType_DropDownClosed(object sender, EventArgs e)
        {
            MainMap.Manager.MemoryCache.Clear();
            MainMap.Manager.CancelTileCaching();

            MainMap.MapProvider = comboBoxMapType.SelectedItem as GMapProvider;
            appSettings.MapProvider = MainMap.MapProvider.Name;
        }

        private void comboBoxMode_DropDownClosed(object sender, EventArgs e)
        {
            MainMap.Manager.MemoryCache.Clear();
            MainMap.Manager.CancelTileCaching();

            if (comboBoxMode.Text == "CacheOnly")
                appSettings.cacheMode = AppSettings.CacheMode.CacheOnly;
            else if (comboBoxMode.Text == "ServerAndCache")
                appSettings.cacheMode = AppSettings.CacheMode.ServerAndCache;
            else if (comboBoxMode.Text == "ServerOnly")
                appSettings.cacheMode = AppSettings.CacheMode.ServerOnly;

            MainMap.Manager.Mode = (AccessMode)comboBoxMode.SelectedValue;
            MainMap.ReloadMap();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();

            if (checkBox1.Checked)
            {
                MainMap.Position = flyPt;
                
                if (checkBox2.Checked)
                    MainMap.Bearing = (float)flyAz;
                else MainMap.Bearing = 0;
            }
            textBox1.Text = BigCoord(flyPt.Lat);
            textBox2.Text = BigCoord(flyPt.Lng);
            textBox3.Text = flyAlt.ToString("0.00000");
            textBox4.Text = flyAz.ToString("0.00000");

            double X = 0, Y = 0;
            
            CoordTransform.WGStoPulkovo42(flyPt.Lat, flyPt.Lng, out X, out Y);
            textBox10.Text = X.ToString("0.000");
            textBox9.Text = Y.ToString("0.000");

            if (isStartServer) 
                label6.Text = "Запущено"; 
            else label6.Text = "Зупинено";
            label9.Text = recbt.ToString() + " пакетів";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            recbt = 0;
            StartServer = true;
            StartRead = true;
            
            routesObj.Routes[0].Clear();

            timerTMP.Interval = Convert.ToInt32(textBox12.Text);
            timerTMP.Enabled = true;

            Thread thread = new Thread(new ThreadStart(delegate() { StartMServer(); }));
            thread.Start();
        }

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text, int c);

        private void SetText(string text, int c)
        {

        }

        long recbt = 0;
        public void StartMServer()
        {
            CultureInfo cinf = CultureInfo.CurrentCulture;
            string numbdecsep = cinf.NumberFormat.NumberDecimalSeparator;

            TcpListener listener = null;
            StreamReader reader = null;
            string[] tmpstr = new string[3];
            try
            {
                string message = string.Empty;
                //Console.WriteLine("Я сервер. Жду клиента..");
                listener = new TcpListener(System.Net.IPAddress.Any, 5000);
                listener.Start();
                isStartServer = true;
                while (StartServer)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    reader = new StreamReader(client.GetStream());
                    
                    isStopServer = false;
                    while (StartRead)
                    {
                        message = reader.ReadLine();
                        tmpstr = message.Split(' ');

                        if (numbdecsep == ",")
                        {
                            tmpstr[0] = tmpstr[0].Replace('.', ',');
                            tmpstr[1] = tmpstr[1].Replace('.', ',');
                            tmpstr[2] = tmpstr[2].Replace('.', ',');
                            tmpstr[3] = tmpstr[3].Replace('.', ',');
                        }
                        else
                        {
                            tmpstr[0] = tmpstr[0].Replace(',', '.');
                            tmpstr[1] = tmpstr[1].Replace(',', '.');
                            tmpstr[2] = tmpstr[2].Replace(',', '.');
                            tmpstr[3] = tmpstr[3].Replace(',', '.');
                        }

                        flyPt.Lat = float.Parse(tmpstr[0]);
                        flyPt.Lng = float.Parse(tmpstr[1]);
                        flyAz = float.Parse(tmpstr[2]);
                        flyAlt = float.Parse(tmpstr[3]);

                        recbt++;
                        if (message != string.Empty)
                        {
                            //SetText(message, 0);
                        }
                    }

                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                isStartServer = false;
                isStopServer = true;
            }
            finally
            {
                // Stop listening for new clients.
                listener.Stop();
                isStartServer = false;
                isStopServer = true;
            }
            isStartServer = false;
            isStopServer = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartRead = false;
            StartServer = false;
            timerTMP.Enabled = false;
            Thread.Sleep(500);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(textBox5.Text);
        }

        private void videoSourcePlayer_MouseClick(object sender, MouseEventArgs e)
        {
            double cek = 12.0 / videoSourcePlayer.Width;
            double sm = videoSourcePlayer.Width / 2 - e.X;
            double coordX = sm * cek; 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            isNewAvi = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mapImage = new Bitmap(MainMap.Width, MainMap.Height);
            Graphics sourceImageGraphics = Graphics.FromImage(mapImage);
            Rectangle srect = MainMap.RectangleToScreen(MainMap.ClientRectangle);
            System.Drawing.Size size = srect.Size;// new System.Drawing.Size(rect.Width, rect.Height);
            sourceImageGraphics.CopyFromScreen(srect.Left, srect.Top, 0, 0, size, CopyPixelOperation.SourceCopy);

            isNewImg = true;
            cntImg++;
            label13.Text = cntImg.ToString();
        }

        private void videoSourcePlayer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (cntDcl <= 9)
            {
                DclPt[cntDcl].X = (int)(e.X / koef);
                DclPt[cntDcl].Y = (int)(e.Y / koef);
                cntDcl++;
            }

            if (ImSize != null)
            {
                //размер кадра в координатах (географ. или прямоугольные)
                double widthX = 12.0 / 3600.0;
                double widthY = 8.0 / 3600.0;
                int tmpX = 0, tmpY = 0;
                double koefX = 0, koefY = 0;
                double curcoordLat = 0, curcoordLon = 0;
                double curcoordLatI = 0, curcoordLonI = 0;
                koefX = widthX / ((System.Drawing.Size)ImSize).Width;
                koefY = widthY / ((System.Drawing.Size)ImSize).Height;

                int DclPtX = (int)(e.X / koef);
                int DclPtY = (int)(e.Y / koef);


                tmpX = DclPtX - ((System.Drawing.Size)ImSize).Width / 2;
                tmpY = DclPtY - ((System.Drawing.Size)ImSize).Height / 2;

                curcoordLon = tmpX * koefX;
                curcoordLat = tmpY * koefY;

                curcoordLonI = curcoordLon * Math.Cos(flyAz / 57.3) - curcoordLat * Math.Sin(flyAz / 57.3);
                curcoordLatI = curcoordLon * Math.Sin(flyAz / 57.3) + curcoordLat * Math.Cos(flyAz / 57.3);
                
                curcoordLonI = flyPt.Lng + curcoordLonI;
                curcoordLatI = flyPt.Lat - curcoordLatI;

                double X = 0, Y = 0;

                CoordTransform.WGStoPulkovo42(curcoordLatI, curcoordLonI, out X, out Y);

                AddMarker(curcoordLatI, curcoordLonI);
            }
            if (checkBoxSaveOnDblClick.Checked)
            {
                mapImage = new Bitmap(MainMap.Width, MainMap.Height);
                Graphics sourceImageGraphics = Graphics.FromImage(mapImage);
                Rectangle srect = MainMap.RectangleToScreen(MainMap.ClientRectangle);
                System.Drawing.Size size = srect.Size;// new System.Drawing.Size(rect.Width, rect.Height);
                sourceImageGraphics.CopyFromScreen(srect.Left, srect.Top, 0, 0, size, CopyPixelOperation.SourceCopy);

                isNewImg = true;
                cntImg++;
                label13.Text = cntImg.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            isNewImgPr = true;
        }

        private void splitContainer2_Panel1_Resize(object sender, EventArgs e)
        {
            isResized = true;
        }

        private void radioButtonCT1_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCachePath.Text = "";

            MainMap.Manager.MemoryCache.Clear();
            MainMap.Manager.CancelTileCaching();

            if (radioButtonCT1.Checked)
            {
                GMap.NET.CacheProviders.SQLitePureImageCache ch = new GMap.NET.CacheProviders.SQLitePureImageCache();
                ch.CacheLocation = appSettings.DBCachePath;
                MainMap.Manager.PrimaryCache = ch;
                appSettings.cacheType = AppSettings.CacheType.DB;

                if (appSettings.DBCachePath != Application.StartupPath)
                    textBoxCachePath.Text = appSettings.DBCachePath;
            }
            else if (radioButtonCT3.Checked)
            {
                GMap.NET.CacheProviders.SASPureImageCache ch = new GMap.NET.CacheProviders.SASPureImageCache();
                ch.CacheFolder = appSettings.SASCachePath;
                MainMap.Manager.PrimaryCache = ch;
                appSettings.cacheType = AppSettings.CacheType.SASPlanet;

                if (appSettings.SASCachePath != Application.StartupPath + Path.DirectorySeparatorChar + "SASCache")
                    textBoxCachePath.Text = appSettings.SASCachePath;
            }

            MainMap.ReloadMap();
        }

        private void buttonChangeCacheDir_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Application.StartupPath;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                MainMap.Manager.MemoryCache.Clear();
                MainMap.Manager.CancelTileCaching();

                if (appSettings.cacheType == AppSettings.CacheType.DB)
                {
                    textBoxCachePath.Text = folderBrowserDialog1.SelectedPath;
                    appSettings.DBCachePath = textBoxCachePath.Text;
                    ((GMap.NET.CacheProviders.SQLitePureImageCache)MainMap.Manager.PrimaryCache).CacheLocation = appSettings.DBCachePath;
                }
                else if (appSettings.cacheType == AppSettings.CacheType.SASPlanet)
                {
                    textBoxCachePath.Text = folderBrowserDialog1.SelectedPath;
                    appSettings.SASCachePath = textBoxCachePath.Text;

                    ((GMap.NET.CacheProviders.SASPureImageCache)MainMap.Manager.PrimaryCache).CacheFolder = appSettings.SASCachePath;
                }

                MainMap.ReloadMap();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBoxCachePath.Text = "";
            MainMap.Manager.CancelTileCaching();

            if (appSettings.cacheType == AppSettings.CacheType.DB)
            {
                appSettings.DBCachePath = textBoxCachePath.Text;
            }
            else if (appSettings.cacheType == AppSettings.CacheType.SASPlanet)
            {
                appSettings.SASCachePath = textBoxCachePath.Text;
            }

            MainMap.Manager.MemoryCache.Clear();

            if (appSettings.cacheType == AppSettings.CacheType.DB)
            {
                ((GMap.NET.CacheProviders.SQLitePureImageCache)MainMap.Manager.PrimaryCache).CacheLocation = appSettings.DBCachePath;
            }
            else if (appSettings.cacheType == AppSettings.CacheType.SASPlanet)
            {
                ((GMap.NET.CacheProviders.SASPureImageCache)MainMap.Manager.PrimaryCache).CacheFolder = appSettings.SASCachePath;
            }

            MainMap.ReloadMap();
        }

        private void buttonLoadTrack_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox11.Text = openFileDialog1.FileName;
                string[] str = File.ReadAllLines(openFileDialog1.FileName);

                target = new Target[str.Length - 4];
                for (int i = 4; i < str.Length; i++)
                {
                    string[] tmp = str[i].Split(' ');
                    target[i - 4] = new Target();
                    target[i - 4].X = Convert.ToDouble(tmp[0]);
                    target[i - 4].Y = Convert.ToDouble(tmp[1]);
                }

                LoadTrack = true;
            }
        }

        private void checkBoxStartImitator_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStartImitator.Checked)
            {
                if (LoadTrack)
                {
                    currentPos = 0;
                    targetL = target[0].X;
                    targetB = target[0].Y;
                    routesObj.Routes[0].Clear();
                    timerImitator.Enabled = true;
                    timerTMP.Interval = Convert.ToInt32(textBox12.Text);
                    timerTMP.Enabled = true;
                }
            }
            else
            {
                timerImitator.Enabled = false;
                timerTMP.Enabled = false;
            }
        }

        private void timerImitator_Tick(object sender, EventArgs e)
        {
            try
            {
                double speed = Convert.ToDouble(textBoxSpeed.Text) * 10 / (111.1 * 1000.0 * 3.6 * timerImitator.Interval);
                //---------------пересчет скорости движения, расстояния для задания равномерного движения--------------------
                double tmpR = Math.Sqrt((target[currentPos].X - target[currentPos + 1].X) * (target[currentPos].X - target[currentPos + 1].X) + (target[currentPos].Y - target[currentPos + 1].Y) * (target[currentPos].Y - target[currentPos + 1].Y));
                double numer = (tmpR / speed);
                double tmpdX = Math.Abs(target[currentPos].X - target[currentPos + 1].X);
                double kof = (tmpdX / speed) / numer;
                //---------------------------------------------------------------------------------------------------------
                targetL += zn * speed * kof;
                if (target[currentPos + 1].X - target[currentPos].X == 0.0) targetB = target[currentPos + 1].Y;
                    else targetB = ((targetL - target[currentPos].X) * (target[currentPos + 1].Y - target[currentPos].Y)) / ((target[currentPos + 1].X - target[currentPos].X)) + target[currentPos].Y;

                double R = Math.Sqrt((targetL - target[currentPos + 1].X) * (targetL - target[currentPos + 1].X) + (targetB - target[currentPos + 1].Y) * (targetB - target[currentPos + 1].Y));
                if (R < Convert.ToDouble(textBoxAccuracy.Text))
                {
                    currentPos++;
                    if (currentPos == target.Length - 1)
                    {
                        currentPos = 0;
                    }
                    targetL = target[currentPos].X;
                    targetB = target[currentPos].Y;
                    if (target[currentPos].X > target[currentPos + 1].X) zn = -1;
                    else zn = 1;
                }
                Random rnd = new Random();

                double llong1 = 0;
                double llat1 = 0;
                double llong2 = 0;
                double llat2 = 0;

                llong1 = targetL;
                llat1 = targetB;

                llong2 = target[currentPos + 1].X;
                llat2 = target[currentPos + 1].Y;
                flyAz = CoordTransform.CalcAz(llong2, llat2, llong1, llat1);
                //flyAz = flyAz;
                flyPt.Lat = targetB;
                flyPt.Lng = targetL;
                flyAlt = 300 + rnd.Next(100) / 100.0;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void timerTMP_Tick(object sender, EventArgs e)
        {
            PointLatLng sCoord = new PointLatLng(flyPt.Lat, flyPt.Lng);
            routesObj.Routes[0].Points.Add(sCoord);
            MainMap.UpdateRouteLocalPosition(routesObj.Routes[0]);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MainMap.ZoomAndCenterMarkers("objectsS");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            objectsS.Markers.Clear();
            listBoxRGN.Rows.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PNG (*.png)|*.png";
                    sfd.FileName = DateTime.Now.ToString("ddMMyyyy_HHmmss");

                    System.Drawing.Image tmpImage = MainMap.ToImage();
                    if (tmpImage != null)
                    {
                        using (tmpImage)
                        {
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                tmpImage.Save(sfd.FileName);

                                MessageBox.Show("Image saved: " + sfd.FileName, "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image failed to save: " + ex.Message, "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex == 2)
            {
                imageListView1.Items.Clear();
                imageListView1.Items.AddRange(Directory.GetFiles(AppSettings.StartupPath + Path.DirectorySeparatorChar + "Img"));
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SaveConfigurationRgn();
        }

        private void SaveConfigurationRgn()
        {
            double Lon = 0, Lat = 0;
            double X = 0, Y = 0;
            string curCoord = "";

            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "KML (*.kml)|*.kml";
                    sfd.FileName = DateTime.Now.ToString("ddMMyyyy_HHmmss");

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        //tmpImage.Save(sfd.FileName);

                        string FileName = sfd.FileName;
                        XmlWriterSettings settings = new XmlWriterSettings();

                        // включаем отступ для элементов XML документа
                        // (позволяет наглядно изобразить иерархию XML документа)
                        settings.Indent = true;
                        settings.IndentChars = "    "; // задаем отступ, здесь у меня 4 пробела

                        // задаем переход на новую строку
                        settings.NewLineChars = "\n";

                        // Нужно ли опустить строку декларации формата XML документа
                        // речь идет о строке вида "<?xml version="1.0" encoding="utf-8"?>"
                        settings.OmitXmlDeclaration = false;

                        settings.Encoding = Encoding.UTF8;

                        //**********************************************************************
                        // FileName - имя файла, куда будет сохранен XML-документ
                        // settings - настройки форматирования (и не только) вывода
                        // (рассмотрен выше)
                        using (XmlWriter output = XmlWriter.Create(FileName, settings))
                        {
                            output.WriteStartDocument(true);
                            // Создали открывающийся тег
                            output.WriteStartElement("kml");

                            output.WriteEndElement();
                            // Сбрасываем буфферизированные данные
                            output.Flush();

                            // Закрываем фаил, с которым связан output
                            output.Close();
                        }

                        XmlDocument document = new XmlDocument();
                        document.Load(FileName);

                        for (int i = 0; i < listBoxRGN.Rows.Count; i++)
                        {
                            Lat = Convert.ToDouble(listBoxRGN.Rows[i].Cells[3].Value.ToString());
                            Lon = Convert.ToDouble(listBoxRGN.Rows[i].Cells[4].Value.ToString());
                            CoordTransform.WGStoPulkovo42(Lat, Lon, out X, out Y);

                            curCoord = "Об'єкт: " + listBoxRGN.Rows[i].Cells[0].Value.ToString() + "\n"
                                     + "X: " + X.ToString("0.000") + "   Y: " + Y.ToString("0.000") + "\n"
                                     + "Lat: " + BigCoord(Lat) + "   Lon: " + BigCoord(Lon);

                            XmlNode subelement = document.CreateElement("Placemark");
                            document.DocumentElement.AppendChild(subelement); // указываем родителя

                            XmlNode propert = document.CreateElement("name"); // даём имя
                            propert.InnerText = listBoxRGN.Rows[i].Cells[0].Value.ToString();
                            subelement.AppendChild(propert); // и указываем кому принадлежит

                            propert = document.CreateElement("description"); // даём имя
                            propert.InnerText = curCoord;
                            subelement.AppendChild(propert); // и указываем кому принадлежит


                            XmlNode subelement1 = document.CreateElement("Point");
                            subelement.AppendChild(subelement1); // указываем родителя


                            propert = document.CreateElement("extrude"); // даём имя
                            propert.InnerText = "1";
                            subelement1.AppendChild(propert); // и указываем кому принадлежит

                            propert = document.CreateElement("coordinates"); // даём имя
                            propert.InnerText = listBoxRGN.Rows[i].Cells[4].Value.ToString() + "," + listBoxRGN.Rows[i].Cells[3].Value.ToString() + ",0";
                            subelement1.AppendChild(propert); // и указываем кому принадлежит
                        }


                        List<PointLatLng> mList = routesObj.Routes[0].Points;
                        if (mList.Count != 0)
                        {
                            XmlNode subelement = document.CreateElement("Placemark");
                            document.DocumentElement.AppendChild(subelement); // указываем родителя

                            XmlNode propert = document.CreateElement("name"); // даём имя
                            propert.InnerText = "Track";
                            subelement.AppendChild(propert); // и указываем кому принадлежит

                            propert = document.CreateElement("description"); // даём имя
                            propert.InnerText = curCoord;
                            subelement.AppendChild(propert); // и указываем кому принадлежит


                            XmlNode subelement1 = document.CreateElement("LineString");
                            subelement.AppendChild(subelement1); // указываем родителя


                            propert = document.CreateElement("extrude"); // даём имя
                            propert.InnerText = "1";
                            subelement1.AppendChild(propert); // и указываем кому принадлежит

                            string coordStr = "";
                            for (int i = 0; i <= mList.Count-1; i++)
                            {
                                coordStr += mList[i].Lng.ToString() + "," + mList[i].Lat.ToString() + ",0 ";
                            }

                            propert = document.CreateElement("coordinates"); // даём имя
                            propert.InnerText = coordStr;
                            subelement1.AppendChild(propert); // и указываем кому принадлежит
                        }
                        document.Save(FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image failed to save: " + ex.Message, "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                MainMap.Overlays[1].IsVisibile = true;
            }
            else
                MainMap.Overlays[1].IsVisibile = false;
        }
    }
}