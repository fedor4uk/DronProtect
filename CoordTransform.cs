using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordTools
{
    class CoordTransform
    {

        /// <summary>
        /// Преобразование геодезических координат в плоские прямоугольные
        /// </summary>
        /// <param name="Lat">Геодезическая широта</param>
        /// <param name="Lon">Геодезическая долгота</param>
        /// <param name="X">Плоские прямоугольные координаты точки в проекции Гаусса-Крюгера</param>
        /// <param name="Y">Плоские прямоугольные координаты точки в проекции Гаусса-Крюгера</param>
         public static void WGStoPulkovo42(double Lat, double Lon, out double X, out double Y)
        {
            int n; //Номер шестиградусной зоны в проекции Гаусса-Крюгера
            double l; //Расстояние от определяемой точки до осевого меридиана зоны, рад

            Lat = Lat * Math.PI / 180.0;

            n = (int)Math.Truncate((6 + Lon) / 6);

            l = (Lon - (3 + 6 * (n - 1))) * Math.PI / 180.0;

            X = 6367558.4968 * Lat - Math.Sin(2 * Lat) * (16002.8900 + 66.9607 * Math.Pow(Math.Sin(Lat), 2) + 0.3515 * Math.Pow(Math.Sin(Lat), 4) -
                l * l * (1594561.25 + 5336.535 * Math.Pow(Math.Sin(Lat), 2) + 26.790 * Math.Pow(Math.Sin(Lat), 4) + 0.149 * Math.Pow(Math.Sin(Lat), 6) + l * l * (672483.4 -
                811219.9 * Math.Pow(Math.Sin(Lat), 2) + 5420.0 * Math.Pow(Math.Sin(Lat), 4) - 10.6 * Math.Pow(Math.Sin(Lat), 6) + l * l * (278194 - 830174 * Math.Pow(Math.Sin(Lat), 2) +
                572434 * Math.Pow(Math.Sin(Lat), 4) + 16010 * Math.Pow(Math.Sin(Lat), 6) + l * l * (109500 - 574700 * Math.Pow(Math.Sin(Lat), 2) + 863700 * Math.Pow(Math.Sin(Lat), 4) - 398600 * Math.Pow(Math.Sin(Lat), 6))))));

            Y = (5 + 10 * n) * 1e5 + l * Math.Cos(Lat) * (6378245 + 21346.1415 * Math.Pow(Math.Sin(Lat), 2) + 107.1590 * Math.Pow(Math.Sin(Lat), 4) + 0.5977 * Math.Pow(Math.Sin(Lat), 6) +
                l * l * (107024.16 - 213826.66 * Math.Pow(Math.Sin(Lat), 2) + 17.98 * Math.Pow(Math.Sin(Lat), 4) - 11.99 * Math.Pow(Math.Sin(Lat), 6) +
                l * l * (270806 - 1523417 * Math.Pow(Math.Sin(Lat), 2) + 1327645 * Math.Pow(Math.Sin(Lat), 4) - 21701 * Math.Pow(Math.Sin(Lat), 6) +
                l * l * (79690 - 866190 * Math.Pow(Math.Sin(Lat), 2) + 1730360 * Math.Pow(Math.Sin(Lat), 4) - 945460 * Math.Pow(Math.Sin(Lat), 6)))));

        }

        public static double CalcAz(double llong1, double llat1, double llong2, double llat2)
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
            //double dist = ad * rad;
            //distan = dist;
            //вычисление начального азимута
            x = (cl1 * sl2) - (sl1 * cl2 * cdelta);
            y = sdelta * cl2;
            double z = (Math.Atan(-y / x)) * 180.0 / Math.PI;

            if (x < 0)
                z = z + 180.0;

            double z2 = (z + 180.0) % 360.0; //- 180.0;
            z2 = -z2 * Math.PI / 180.0;
            double anglerad2 = z2 - ((2 * Math.PI) * Math.Floor((z2 / (2 * Math.PI))));
            double angledeg = (anglerad2 * 180.0) / Math.PI;

            //print 'Distance >> %.0f' % dist, ' [meters]'
            //print 'Initial bearing >> ', angledeg, '[degrees]'
            return angledeg;
        }
    }
}
