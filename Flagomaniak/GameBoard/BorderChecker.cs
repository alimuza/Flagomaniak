using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Flagomaniak.GameBoard
{
    /// <summary>
    /// Klasa zajmuje się sprawdzaniem, czy punkt znajduje się w granicach danego kształtu. Dostosowuje wymiary kształtu do wymiarów ekranu.
    /// </summary>
    class BorderChecker
    {
        /// <summary>
        /// Funkcja sprawdza, czy punkt na ekranie znajduje się w granicach danego kraju.
        /// </summary>
        /// <param name="polygon">Lista z punktami wyznaczającymi granice kształtu.</param>
        /// <param name="width">Aktualna szerokość wyświetlanej mapy.</param>
        /// <param name="height">Aktualna wysokość wyświetlanej mapy.</param>
        /// <param name="p">Punkt do sprawdzenia.</param>
        /// <returns></returns>
        public bool Check(List<Point> polygon, double width, double height, Point p)
        {
            List<Point> newPolygon = ScaleToScreen(polygon, width, height);

            if (IsPointInPolygon(newPolygon, p))
               return true;
        
            return false;
        }

        /// <summary>
        /// Funkcja sprawdza, czy dany punkt znajduję się w środku kształtu.
        /// </summary>
        /// <param name="polygon">Lista zawierająca punkty z granicami kształtu.</param>
        /// <param name="point">Współrzędne punktu.</param>
        /// <returns>Wynik typy bool wskazujący czy punkt znajduje się w granicach kształtu na mapie.</returns>
        private bool IsPointInPolygon(List<Point> polygon, Point point)
        {
            bool result = false;
            int j = polygon.Count() - 1;
            for (int i = 0; i < polygon.Count(); i++)
            {
                if (polygon[i].Y < point.Y && polygon[j].Y >= point.Y || polygon[j].Y < point.Y && polygon[i].Y >= point.Y)
                {
                    if (polygon[i].X + (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < point.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }

        /// <summary>
        /// Przeskalowanie wymiarów kraju w zależności od rozmiarów ekranu.
        /// </summary>
        /// <remarks>
        /// Granice kraju zostały wyznaczone w postaci ścieżki na obrazie w rozmiarze 2000x13010.
        /// Obraz będzie miał inne wymiary w zależności od wielkości ekranu/ rozmiaru okna, potrzebne jest przeskalowanie tej ścieżki w zależności od aktualnego rozmiaru wyświetlanej mapy.
        /// </remarks>
        /// <param name="polygon">Lista punktów z granicami kraju.</param>
        /// <param name="width">Aktualna szerokość mapy na ekranie.</param>
        /// <param name="height">Aktualna wysokość mapy na ekranie.</param>
        /// <returns>Punkty określające granice kraju dostosowane do aktualnych rozmiarów ekranu.</returns>
        private List<Point> ScaleToScreen(List<Point> polygon, double width, double height)
        {
            // 2000 X 1310 - prawdziwe wymiary wyświetlanej mapy
            double x = width / 2000;
            double y = height / 1310;

            List<Point> newPolygon = new List<Point>();
            foreach (var point in polygon)
            {
                newPolygon.Add(new Point(point.X * x, point.Y * y));
            }
            return newPolygon;
        }
    }
}
