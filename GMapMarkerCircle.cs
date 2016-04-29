
namespace Demo.WindowsForms.CustomMarkers
{
    using System.Drawing;
    using GMap.NET.WindowsForms;
    using GMap.NET.WindowsForms.Markers;
    using GMap.NET;
    using System;
    using System.Runtime.Serialization;
    using System.Drawing.Drawing2D;

#if !PocketPC
   [Serializable]
   public class GMapMarkerCircle : GMapMarker, ISerializable
#else
   public class GMapMarkerCircle : GMapMarker
#endif
   {
       [NonSerialized]
       public GMarkerGoogle InnerMarker;

      /// <summary>
      /// In Meters
      /// </summary>
      public int Radius;
      public int VirtRadius;
      public int PulseRadius;
      public int maxPulse;
      public double maxSpeed;
      public int currTime;
      public double accelerate;
      public double position;
      /// <summary>
      /// specifies how the outline is painted
      /// </summary>
      [NonSerialized]
#if !PocketPC
      GMarkerGoogle m;
      public int alphaC = 155;
      public Pen Stroke = new Pen(Color.FromArgb(155, Color.Red));
      public Pen BigR = new Pen(Color.FromArgb(155, Color.Red));
      public bool selectedFlag = false;
      public bool pulseFlag = false;
      public bool errorFlag = false;
      //public bool SignalFlag = false;


      public bool showEffRad = true;
      public int alpha;
      System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

#else
      public Pen Stroke = new Pen(Color.MidnightBlue);
#endif

      /// <summary>
      /// background color
      /// </summary>
      [NonSerialized]
#if !PocketPC
      public Brush Fill = new SolidBrush(Color.FromArgb(100, Color.Red));
      public Brush FillSel = new SolidBrush(Color.FromArgb(70, Color.Orange));
      public Brush FillPulse = new SolidBrush(Color.FromArgb(50, Color.Red));
      public Brush FillError = new SolidBrush(Color.FromArgb(50, 255, 255, 0));
#else
      public Brush Fill = new System.Drawing.SolidBrush(Color.AliceBlue);
#endif

      /// <summary>
      /// is filled
      /// </summary>
      public bool IsFilled = true;

      public GMapMarkerCircle(PointLatLng p)
         : base(p)
      {
         alpha = 100;
         Radius = 30; // 100m
         VirtRadius = 50;
         IsHitTestVisible = true;
         BigR.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
         BigR.Width = 2;

          // S = (vx^2 - vox^2)/2ax
          // x(t) = xo + vot + at^2/2
         PulseRadius = 0;
         currTime = 0;
         maxPulse = 30;
         maxSpeed = 10;
         accelerate = -(maxSpeed * maxSpeed) / (4 * maxPulse);
         position = 0;
      }

      // This is the method to run when the timer is raised.
      private void TimerEventProcessor(Object myObject,
                                              EventArgs myEventArgs)
      {
          currTime++;

          position = maxSpeed * currTime + accelerate * currTime * currTime / 2;
          //if (cc)
          if (position >= maxPulse)
              PulseRadius = (int)(maxPulse * 2 - position);
          else PulseRadius = (int)position;

          if (position >= maxPulse * 2)
          {
              myTimer.Stop();
              myTimer.Enabled = false;
              myTimer.Interval = 1000;
              myTimer.Tick -= new EventHandler(TimerEventProcessor);
              currTime = 0;
          }
          Overlay.Control.Refresh();
      }


      public override void OnRender(Graphics g)
      {
          Size = new System.Drawing.Size(VirtRadius + PulseRadius, VirtRadius + PulseRadius);
          Offset = new System.Drawing.Point(-Size.Width / 2, -Size.Height / 2);
          int R = (int)((Radius) / Overlay.Control.MapProvider.Projection.GetGroundResolution((int)Overlay.Control.Zoom, Position.Lat)) * 2;

          if (showEffRad)
          {
              if (IsFilled)
              {
                  if (pulseFlag && !errorFlag)
                  {
                      g.FillEllipse(FillPulse, new System.Drawing.Rectangle(LocalPosition.X - R / 2 - Offset.X, LocalPosition.Y - R / 2 - Offset.Y, R, R));
                  }
                  else
                      if (!pulseFlag && !errorFlag)
                      {
                          g.FillEllipse(Fill, new System.Drawing.Rectangle(LocalPosition.X - R / 2 - Offset.X, LocalPosition.Y - R / 2 - Offset.Y, R, R));
                      }
                      else
                          if (errorFlag)
                              g.FillEllipse(FillError, new System.Drawing.Rectangle(LocalPosition.X - 25 - Offset.X, LocalPosition.Y - 25 - Offset.Y, 50, 50));
              }
              else
              {
                  g.DrawEllipse(Stroke, new System.Drawing.Rectangle(LocalPosition.X - R / 2 - Offset.X, LocalPosition.Y - R / 2 - Offset.Y, R, R));
              }
          }

          Brush mFill = new SolidBrush(Color.FromArgb(alpha, Color.AliceBlue));
          if (IsFilled)
          {
              g.FillEllipse(mFill, new System.Drawing.Rectangle(LocalPosition.X + (VirtRadius + PulseRadius) / 2 - 5, LocalPosition.Y + (VirtRadius + PulseRadius) / 2 - 5, 10, 10));
          }

          if (selectedFlag)
          {
              g.FillEllipse(FillSel, new System.Drawing.Rectangle(LocalPosition.X, LocalPosition.Y, VirtRadius + PulseRadius, VirtRadius + PulseRadius));
              g.DrawEllipse(BigR, new System.Drawing.Rectangle(LocalPosition.X, LocalPosition.Y, VirtRadius + PulseRadius, VirtRadius + PulseRadius));
          }

          g.DrawEllipse(BigR, new System.Drawing.Rectangle(LocalPosition.X, LocalPosition.Y, VirtRadius + PulseRadius, VirtRadius + PulseRadius));
      }

      public override void Dispose()
      {
         if(Stroke != null)
         {
            Stroke.Dispose();
            Stroke = null;
         }

         if(Fill != null)
         {
            Fill.Dispose();
            Fill = null;
         }

         if (BigR != null)
         {
             BigR.Dispose();
             BigR = null;
         }

         if (InnerMarker != null)
         {
             InnerMarker.Dispose();
             InnerMarker = null;
         }
         base.Dispose();
      }

#if !PocketPC

      #region ISerializable Members

      void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
      {
         base.GetObjectData(info, context);

         // TODO: Radius, IsFilled
      }

      protected GMapMarkerCircle(SerializationInfo info, StreamingContext context)
         : base(info, context)
      {
         // TODO: Radius, IsFilled
      }

      #endregion

#endif
   }
}
