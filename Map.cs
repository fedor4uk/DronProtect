
namespace MotionDetectorSample
{
   using System.Windows.Forms;
   using GMap.NET.WindowsForms;
   using GMap.NET;
   using System.Drawing;
   using System;
   using System.Globalization;

   /// <summary>
   /// custom map of GMapControl
   /// </summary>
   public class Map : GMapControl
   {
       //public Form1 ownerForm = null;

      public long ElapsedMilliseconds;

#if DEBUG
      private int counter;
      readonly Font DebugFont = new Font(FontFamily.GenericSansSerif, 7, FontStyle.Regular);
      readonly Font DebugFontSmall = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
      DateTime start;
      DateTime end;
      int delta;

      protected override void OnPaint(PaintEventArgs e)
      {
         start = DateTime.Now;

         base.OnPaint(e);
         end = DateTime.Now;
         delta = (int)(end - start).TotalMilliseconds;
      }

      /// <summary>
      /// any custom drawing here
      /// </summary>
      /// <param name="drawingContext"></param>
      protected override void OnPaintOverlays(System.Drawing.Graphics g)
      {
         base.OnPaintOverlays(g);

         g.DrawString(string.Format(CultureInfo.InvariantCulture, "{0:0.0}", Zoom) + "z, " + MapProvider + ", refresh: " + counter++ + ", load: " + ElapsedMilliseconds + "ms, render: " + delta + "ms", DebugFont, Brushes.Blue, this.Width - 255, DebugFont.Height - 5);
      }


      private double CalcAz(double llong1, double llat1, double llong2, double llat2)
      {
          double rad = 6372795;

          //в радианах
          double lat1 = llat1 * Math.PI / 180.0;
          double lat2 = llat2 * Math.PI / 180.0;
          double long1 = llong1 * Math.PI / 180.0;
          double long2 = llong2 * Math.PI / 180.0;

          //косинусы и синусы широт и разницы долгот
          double cl1 = Math.Cos(lat1);
          double cl2 = Math.Cos(lat2);
          double sl1 = Math.Sin(lat1);
          double sl2 = Math.Sin(lat2);
          double delta = long2 - long1;
          double cdelta = Math.Cos(delta);
          double sdelta = Math.Sin(delta);

          //вычисления длины большого круга
          double y = Math.Sqrt(Math.Pow(cl2 * sdelta, 2) + Math.Pow(cl1 * sl2 - sl1 * cl2 * cdelta, 2));
          double x = sl1 * sl2 + cl1 * cl2 * cdelta;
          double ad = Math.Atan2(y, x);
          double dist = ad * rad;

          //вычисление начального азимута
          x = (cl1 * sl2) - (sl1 * cl2 * cdelta);
          y = sdelta * cl2;
          double z = (Math.Atan(-y / x)) * 180.0 / Math.PI;

          if (x < 0)
              z = z + 180.0;

          double z2 = (z + 180.0) % 360.0 - 180.0;
          z2 = -z2 * Math.PI / 180.0;
          double anglerad2 = z2 - ((2 * Math.PI) * Math.Floor((z2 / (2 * Math.PI))));
          double angledeg = (anglerad2 * 180.0) / Math.PI + 90;

          return angledeg;
      }

      private void InitializeComponent()
      {
            this.SuspendLayout();
 
            this.Name = "Map";
            this.Size = new System.Drawing.Size(312, 219);
            this.ResumeLayout(false);

      }     
#endif
   }
}
