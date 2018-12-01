using System.Collections.Generic;
using System.Windows;

namespace Flagomaniak.Continents
{
    /// <summary>
    /// Klasa opisująca pojedynczy kraj w grze.
    /// </summary>
    class Country
    {
        /// <summary>
        /// Zmienna zawierająca nazwę kraju.
        /// </summary>
        private string _name;
        /// <summary>
        /// Zmienna zawierająca ścieżkę do pliku z obrazem flagi.
        /// </summary>
        private string _flagUri;

        /// <summary>
        /// Lista punktów określająca granice kraju na mapie.
        /// </summary>
        private List<Point> _polygon;

        /// <value>Zwraca nazwę kraju.</value>
        public string Name => _name;

        /// <value>Zwraca ścieżkę dostępu do flagi kraju.</value>
        public string FlagUri => _flagUri;

        /// <value>Zwraca listę punktów określających granicę kraju na mapie.</value>
        public List<Point> Polygon => _polygon;

        /// <summary>
        /// Konstruktor klasy. Nadaje wartość nazwie kraju oraz ścieżce dostępu do flagi kraju.
        /// Zamienia przekazany ciąg znaków z granicami kraju w listę punktów na mapie.
        /// </summary>
        /// <param name="name">Nazwa kraju.</param>
        /// <param name="uri">Ścieżka dostępu do fali kraju.</param>
        /// <param name="cor">Ciąg punktów na mapie określający granicę kraju.</param>
        public Country(string name, string uri, string cor)
        {
            _name = name;
            _flagUri = uri;
            _polygon = StringToPolygon(cor);
        }

        /// <summary>
        /// Funkcja zmienia string zawierający współrzędne granicy kraju w listę punktów na mapie.
        /// </summary>
        /// <param name="coordinates">Lista punktów określających granicę kraju na mapie.</param>
        /// <returns>Ciąg znaków określający granicę kraju na mapie.</returns>
        private List<Point> StringToPolygon(string coordinates)
        {
            var cor = coordinates.Replace('C', ' ').Split(' ');
            var polygon = new List<Point>();

            foreach (var c in cor)
            {
                if (c == "")
                    continue;
                var point = c.Split(',');
                polygon.Add(new Point(double.Parse(point[0].Replace('.', ',')),
                                       double.Parse(point[1].Replace('.', ','))));
            }
            return polygon;
        }
    }
}
