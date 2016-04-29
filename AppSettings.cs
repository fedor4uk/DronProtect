using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Globals
{
    public class AppSettings
    {
        public string[] HatchStyles = Enum.GetNames(typeof(HatchStyle)); //Get Current System.Drawing.Drawing2D.DashStyles
        public string[] DashStyles = Enum.GetNames(typeof(DashStyle)); //Get Current System.Drawing.Drawing2D.DashStyles
        public enum SatZoneMode { None = 0, ShowAllZone, ShowActiveSatZone };
        public enum RadioZoneMode { None = 0, ShowAllZone, ShowActiveRadioZone };
        public enum CacheType { DB = 0, File, SASPlanet };
        public enum CacheMode { CacheOnly = 0, ServerOnly, ServerAndCache };
        public enum CacheLang { EN = 0, RU };

        static public string StartupPath = "";
        
        string fileName = ""; 
        string mapProvider;

        double lMap, bMap;
        int sizeMap;

        int curMainTab;
        int mapTabVState;
        int mapTabHState;


        public SatZoneMode satZoneMode = SatZoneMode.ShowActiveSatZone;
        public RadioZoneMode radioZoneMode = RadioZoneMode.ShowActiveRadioZone;
        public CacheType cacheType = CacheType.DB;
        public CacheLang cacheLang = CacheLang.EN;
        public CacheMode cacheMode = CacheMode.ServerAndCache;
        string dbCachePath = "";
        string fileCachePath = "";
        string sasCachePath = "";

        public int LineWidthActiveSat;
        public int LineStyleActiveSat;
        public int HatchStyleActiveSat;
        public string LineColorActiveSat;
        public int TranspLineActiveSat;
        public bool IsFillActiveSat;
        public int BrushStyleActiveSat;
        public string ForeColorActiveSat;
        public string BackColorActiveSat;
        public int TransForeActiveSat;
        public int TransBackActiveSat;
        public bool ShowImgActiveSat;
        public int FontActiveSat;
        public bool ShowShadowActiveSat;
        public string FontForeColorActiveSat;
        public string FontBackColorActiveSat;


        public int LineWidthOtherSat;
        public int LineStyleOtherSat;
        public string LineColorOtherSat;
        public int TransLineOtherSat;
        public bool ShowImgOtherSat;
        public int FontOtherSat;
        public bool ShowShadowOtherSat;
        public string FontForeColorOtherSat;
        public string FontBackColorOtherSat;
        public bool IsFillOtherSat;
        public int BrushStyleOtherSat;
        public int HatchStyleOtherSat;
        public string ForeColorOtherSat;
        public string BackColorOtherSat;
        public int TransForeOtherSat;
        public int TransBackOtherSat;

        public int LineWidthRadio;
        public int LineStyleRadio;
        public string LineColorRadio;
        public int TransLineRadio;
        public bool ShowImgRadio;
        public int FontRadio;
        public bool ShowShadowRadio;
        public string FontForeColorRadio;
        public string FontBackColorRadio;
        public bool IsFillRadio;
        public int BrushStyleRadio;
        public int HatchStyleRadio;
        public string ForeColorRadio;
        public string BackColorRadio;
        public int TransForeRadio;
        public int TransBackRadio;

        public int WidthTrack;
        public int LineStyleTrack;
        public string PrevColorTrack;
        public string CurColorTrack;
        public string NextColorTrack;
        public int TransTrack;

        string language;

        public string DBCachePath
        {
            get 
            {
                if (Directory.Exists(dbCachePath)) return dbCachePath;
                else return Application.StartupPath;
            }
            set 
            { 
                dbCachePath = value;
                if (!Directory.Exists(dbCachePath)) dbCachePath = "";
            }
        }

        public string FileCachePath
        {
            get 
            {
                if (Directory.Exists(fileCachePath)) return fileCachePath;
                else return Application.StartupPath;
            }
            set 
            { 
                fileCachePath = value;
                if (!Directory.Exists(fileCachePath)) fileCachePath = "";
            }
        }

        public string SASCachePath
        {
            get 
            {
                if (Directory.Exists(sasCachePath)) return sasCachePath;
                else return Application.StartupPath + Path.DirectorySeparatorChar + "SASCache";
            }
            set 
            {
                sasCachePath = value;
                if (!Directory.Exists(sasCachePath)) sasCachePath = "";
            }
        }
        
         

        public string MapProvider
        {
            get { return mapProvider; }
            set { mapProvider = value; }
        }

        public double LMap
        {
            get { return lMap; }
            set { lMap = value; }
        }

        public double BMap
        {
            get { return bMap; }
            set { bMap = value; }
        }

        public int SizeMap
        {
            get { return sizeMap; }
            set { sizeMap = value; }
        }

        public int CurMainTab
        {
            get { return curMainTab; }
            set { curMainTab = value; }
        }

        public int MapTabVState
        {
            get { return mapTabVState; }
            set { mapTabVState = value; }
        }

        public int MapTabHState
        {
            get { return mapTabHState; }
            set { mapTabHState = value; }
        }

        public string Language
        {
            get { return language; }
            set { language = value; }
        }

        public void LoadDefaultsStyle()
        {
            satZoneMode = SatZoneMode.ShowActiveSatZone;
            radioZoneMode = RadioZoneMode.ShowActiveRadioZone;

            cacheType = CacheType.DB;
            cacheLang = CacheLang.EN;
            cacheMode = CacheMode.ServerAndCache;

            language = "ru-RU";

            dbCachePath = "";
            fileCachePath = "";
            sasCachePath = "";

            LineWidthActiveSat = 2;
            LineStyleActiveSat = 0;
            HatchStyleActiveSat = 20;
            LineColorActiveSat = Color.Green.Name;
            TranspLineActiveSat = 150;
            IsFillActiveSat = true;
            BrushStyleActiveSat = 0;
            ForeColorActiveSat = Color.Green.Name;
            BackColorActiveSat = Color.White.Name;
            TransForeActiveSat = 30;
            TransBackActiveSat = 50;
            ShowImgActiveSat = true;
            FontActiveSat = 15;
            ShowShadowActiveSat = true;
            FontForeColorActiveSat = Color.Black.Name;
            FontBackColorActiveSat = Color.Gainsboro.Name;


            LineWidthOtherSat = 1;
            LineStyleOtherSat = 0;
            LineColorOtherSat = Color.Gray.Name;
            TransLineOtherSat = 150;
            ShowImgOtherSat = true;
            FontOtherSat = 13;
            ShowShadowOtherSat = true;
            FontForeColorOtherSat = Color.Black.Name;
            FontBackColorOtherSat = Color.Gainsboro.Name;
            IsFillOtherSat = false;
            BrushStyleOtherSat = 1;
            HatchStyleOtherSat = 20;
            ForeColorOtherSat = Color.LightGray.Name;
            BackColorOtherSat = Color.White.Name;
            TransForeOtherSat = 10;
            TransBackOtherSat = 50;

            LineWidthRadio = 2;
            LineStyleRadio = 0;
            LineColorRadio = Color.Red.Name;
            TransLineRadio = 150;
            ShowImgRadio = true;
            FontRadio = 15;
            ShowShadowRadio = true;
            FontForeColorRadio = Color.Black.Name;
            FontBackColorRadio = Color.Gainsboro.Name;
            IsFillRadio = true;
            BrushStyleRadio = 0;
            HatchStyleRadio = 20;
            ForeColorRadio = Color.Red.Name;
            BackColorRadio = Color.White.Name;
            TransForeRadio = 30;
            TransBackRadio = 50;

            WidthTrack = 2;
            LineStyleTrack = 0;
            PrevColorTrack = Color.Gray.Name;
            CurColorTrack = Color.Green.Name;
            NextColorTrack = Color.Yellow.Name;
            TransTrack = 150;
        }
        public AppSettings()
        {
            // Create default application settings.
            fileName = StartupPath + "\\AppSettings#@@#.dat";
            mapProvider = "GoogleMap";
            language = "ru-RU";
            bMap = 50.198838912108;
            lMap = 28.5602688789368;
            sizeMap = 5;

            curMainTab = 1;
            mapTabVState = 0;
            mapTabHState = 1;

            satZoneMode = SatZoneMode.ShowActiveSatZone;
            radioZoneMode = RadioZoneMode.ShowActiveRadioZone;
            cacheType = CacheType.DB;
            cacheLang = CacheLang.EN;
            cacheMode = CacheMode.ServerAndCache;
          
            dbCachePath = "";
            fileCachePath = "";
            sasCachePath = "";

            LineWidthActiveSat = 2;
            LineStyleActiveSat = 0;
            HatchStyleActiveSat = 20;
            LineColorActiveSat = Color.Green.Name;
            TranspLineActiveSat = 150;
            IsFillActiveSat = true;
            BrushStyleActiveSat = 0;
            ForeColorActiveSat = Color.Green.Name;
            BackColorActiveSat = Color.White.Name;
            TransForeActiveSat = 30;
            TransBackActiveSat = 50;
            ShowImgActiveSat = true;
            FontActiveSat = 15;
            ShowShadowActiveSat = true;
            FontForeColorActiveSat = Color.Black.Name;
            FontBackColorActiveSat = Color.Gainsboro.Name;


            LineWidthOtherSat = 1;
            LineStyleOtherSat = 0;
            LineColorOtherSat = Color.Gray.Name;
            TransLineOtherSat = 150;
            ShowImgOtherSat = true;
            FontOtherSat = 13;
            ShowShadowOtherSat = true;
            FontForeColorOtherSat = Color.Black.Name;
            FontBackColorOtherSat = Color.Gainsboro.Name;
            IsFillOtherSat = false;
            BrushStyleOtherSat = 1;
            HatchStyleOtherSat = 20;
            ForeColorOtherSat = Color.LightGray.Name;
            BackColorOtherSat = Color.White.Name;
            TransForeOtherSat = 10;
            TransBackOtherSat = 50;

            LineWidthRadio = 2;
            LineStyleRadio = 0;
            LineColorRadio = Color.Red.Name;
            TransLineRadio = 150;
            ShowImgRadio = true;
            FontRadio = 15;
            ShowShadowRadio = true;
            FontForeColorRadio = Color.Black.Name;
            FontBackColorRadio = Color.Gainsboro.Name;
            IsFillRadio = true;
            BrushStyleRadio = 0;
            HatchStyleRadio = 20;
            ForeColorRadio = Color.Red.Name;
            BackColorRadio = Color.White.Name;
            TransForeRadio = 30;
            TransBackRadio = 50;

            WidthTrack = 2;
            LineStyleTrack = 0;
            PrevColorTrack = Color.Gray.Name;
            CurColorTrack = Color.Green.Name;
            NextColorTrack = Color.Yellow.Name;
            TransTrack = 150;

            if (File.Exists(fileName))
            {
                BinaryReader binReader =
                    new BinaryReader(File.Open(fileName, FileMode.Open));
                try
                {
                    mapProvider = binReader.ReadString();
                    language = binReader.ReadString();
                    lMap = binReader.ReadDouble();
                    bMap = binReader.ReadDouble();
                    sizeMap = binReader.ReadInt32();

                    curMainTab = binReader.ReadInt32();
                    mapTabVState = binReader.ReadInt32();
                    mapTabHState = binReader.ReadInt32();


                    satZoneMode = (SatZoneMode)binReader.ReadInt32();
                    radioZoneMode = (RadioZoneMode)binReader.ReadInt32();
                    cacheType = (CacheType)binReader.ReadInt32(); ;
                    cacheLang = (CacheLang)binReader.ReadInt32();
                    cacheMode = (CacheMode)binReader.ReadInt32();

                    dbCachePath = binReader.ReadString();
                    fileCachePath = binReader.ReadString();
                    sasCachePath = binReader.ReadString();

                    LineWidthActiveSat = binReader.ReadInt32();
                    LineStyleActiveSat = binReader.ReadInt32();
                    HatchStyleActiveSat = binReader.ReadInt32();
                    LineColorActiveSat = binReader.ReadString();
                    TranspLineActiveSat = binReader.ReadInt32();
                    IsFillActiveSat = binReader.ReadBoolean();
                    BrushStyleActiveSat = binReader.ReadInt32();
                    ForeColorActiveSat = binReader.ReadString();
                    BackColorActiveSat = binReader.ReadString();
                    TransForeActiveSat = binReader.ReadInt32();
                    TransBackActiveSat = binReader.ReadInt32();
                    ShowImgActiveSat = binReader.ReadBoolean();
                    FontActiveSat = binReader.ReadInt32();
                    ShowShadowActiveSat = binReader.ReadBoolean();
                    FontForeColorActiveSat = binReader.ReadString();
                    FontBackColorActiveSat = binReader.ReadString();


                    LineWidthOtherSat = binReader.ReadInt32();
                    LineStyleOtherSat = binReader.ReadInt32();
                    LineColorOtherSat = binReader.ReadString();
                    TransLineOtherSat = binReader.ReadInt32();
                    ShowImgOtherSat = binReader.ReadBoolean();
                    FontOtherSat = binReader.ReadInt32();
                    ShowShadowOtherSat = binReader.ReadBoolean();
                    FontForeColorOtherSat = binReader.ReadString();
                    FontBackColorOtherSat = binReader.ReadString();
                    IsFillOtherSat = binReader.ReadBoolean();
                    BrushStyleOtherSat = binReader.ReadInt32();
                    HatchStyleOtherSat = binReader.ReadInt32();
                    ForeColorOtherSat = binReader.ReadString();
                    BackColorOtherSat = binReader.ReadString();
                    TransForeOtherSat = binReader.ReadInt32();
                    TransBackOtherSat = binReader.ReadInt32();

                    LineWidthRadio = binReader.ReadInt32();
                    LineStyleRadio = binReader.ReadInt32();
                    LineColorRadio = binReader.ReadString();
                    TransLineRadio = binReader.ReadInt32();
                    ShowImgRadio = binReader.ReadBoolean();
                    FontRadio = binReader.ReadInt32();
                    ShowShadowRadio = binReader.ReadBoolean();
                    FontForeColorRadio = binReader.ReadString();
                    FontBackColorRadio = binReader.ReadString();
                    IsFillRadio = binReader.ReadBoolean();
                    BrushStyleRadio = binReader.ReadInt32();
                    HatchStyleRadio = binReader.ReadInt32();
                    ForeColorRadio = binReader.ReadString();
                    BackColorRadio = binReader.ReadString();
                    TransForeRadio = binReader.ReadInt32();
                    TransBackRadio = binReader.ReadInt32();

                    WidthTrack = binReader.ReadInt32();
                    LineStyleTrack = binReader.ReadInt32();
                    PrevColorTrack = binReader.ReadString();
                    CurColorTrack = binReader.ReadString();
                    NextColorTrack = binReader.ReadString();
                    TransTrack = binReader.ReadInt32();
                }

                // If the end of the stream is reached before reading
                // the four data values, ignore the error and use the
                // default settings for the remaining values.
                catch (EndOfStreamException e)
                {
                    Console.WriteLine("{0} caught and ignored. " +
                        "Using default values.", e.GetType().Name);
                }
                finally
                {
                    binReader.Close();
                }
            }

        }

        // Create a file and store the application settings.
        public void Close()
        {
            using (BinaryWriter binWriter =
                new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                binWriter.Write(mapProvider);
                binWriter.Write(language);
                binWriter.Write(lMap);
                binWriter.Write(bMap);
                binWriter.Write(sizeMap);

                binWriter.Write(curMainTab);
                binWriter.Write(mapTabVState);
                binWriter.Write(mapTabHState);
                
                binWriter.Write((int)satZoneMode);
                binWriter.Write((int)radioZoneMode);

                binWriter.Write((int)cacheType);
                binWriter.Write((int)cacheLang);
                binWriter.Write((int)cacheMode);

                binWriter.Write(dbCachePath);
                binWriter.Write(fileCachePath);
                binWriter.Write(sasCachePath);
          
                binWriter.Write(LineWidthActiveSat); 
                binWriter.Write(LineStyleActiveSat); 
                binWriter.Write(HatchStyleActiveSat);
                binWriter.Write(LineColorActiveSat); 
                binWriter.Write(TranspLineActiveSat);
                binWriter.Write(IsFillActiveSat);    
                binWriter.Write(BrushStyleActiveSat);
                binWriter.Write(ForeColorActiveSat); 
                binWriter.Write(BackColorActiveSat); 
                binWriter.Write(TransForeActiveSat); 
                binWriter.Write(TransBackActiveSat); 
                binWriter.Write(ShowImgActiveSat);   
                binWriter.Write(FontActiveSat);      
                binWriter.Write(ShowShadowActiveSat);    
                binWriter.Write(FontForeColorActiveSat); 
                binWriter.Write(FontBackColorActiveSat); 

                binWriter.Write(LineWidthOtherSat); 
                binWriter.Write(LineStyleOtherSat); 
                binWriter.Write(LineColorOtherSat); 
                binWriter.Write(TransLineOtherSat); 
                binWriter.Write(ShowImgOtherSat);        
                binWriter.Write(FontOtherSat);           
                binWriter.Write(ShowShadowOtherSat);     
                binWriter.Write(FontForeColorOtherSat);  
                binWriter.Write(FontBackColorOtherSat);  
                binWriter.Write(IsFillOtherSat);         
                binWriter.Write(BrushStyleOtherSat);     
                binWriter.Write(HatchStyleOtherSat);     
                binWriter.Write(ForeColorOtherSat);      
                binWriter.Write(BackColorOtherSat);      
                binWriter.Write(TransForeOtherSat);      
                binWriter.Write(TransBackOtherSat);      

                binWriter.Write(LineWidthRadio);  
                binWriter.Write(LineStyleRadio);  
                binWriter.Write(LineColorRadio);  
                binWriter.Write(TransLineRadio);  
                binWriter.Write(ShowImgRadio);    
                binWriter.Write(FontRadio);       
                binWriter.Write(ShowShadowRadio); 
                binWriter.Write(FontForeColorRadio); 
                binWriter.Write(FontBackColorRadio); 
                binWriter.Write(IsFillRadio);     
                binWriter.Write(BrushStyleRadio); 
                binWriter.Write(HatchStyleRadio); 
                binWriter.Write(ForeColorRadio); 
                binWriter.Write(BackColorRadio); 
                binWriter.Write(TransForeRadio); 
                binWriter.Write(TransBackRadio); 

                binWriter.Write(WidthTrack);      
                binWriter.Write(LineStyleTrack);  
                binWriter.Write(PrevColorTrack);  
                binWriter.Write(CurColorTrack);   
                binWriter.Write(NextColorTrack);
                binWriter.Write(TransTrack);      

            }
            Save();
        }

        public void Save()
        {
            string xfileName = Application.StartupPath + "\\appSettings#@@#.xml";

            if (File.Exists(xfileName)) File.Delete(xfileName);

            using (FileStream fs = new FileStream(xfileName, FileMode.Create))
            {
                XmlSerializer xser = new XmlSerializer(typeof(AppSettings));
                xser.Serialize(fs, this);
                fs.Close();
            }
        }

        public static AppSettings Load()
        {
            AppSettings appSettings = null;

            string fileName = Application.StartupPath + "\\appSettings#@@#.xml";

            if (File.Exists(fileName))
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    XmlSerializer xser = new XmlSerializer(typeof(AppSettings));
                    appSettings = (AppSettings)xser.Deserialize(fs);
                    fs.Close();
                }
            }
            else appSettings = new AppSettings();

            return appSettings;
        }
    }
}
