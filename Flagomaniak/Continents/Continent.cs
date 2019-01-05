using System.Collections.Generic;

namespace Flagomaniak.Continents
{
    /// <summary>
    /// Klasa opisująca pojedynczy kontynent w grze.
    /// </summary>
    class Continent
    {
        /// <summary>
        /// Nazwa kontynentu.
        /// </summary>
        private string _name;

        /// <summary>
        /// Ścieżka dostępu do pliku z mapą kontynentu.
        /// </summary>
        private string _mapUri;

        /// <summary>
        /// Lista zawierająca kraje znajdujące się na kontynencie.
        /// </summary>
        private List<Country> _countries;

        /// <value>Zwraca nazwę kontynentu.</value>
        public string Name => _name;

        /// <value>Zwraca ścieżkę dostępu do pliku z mapą kontynentu.</value>
        public string MapUri => _mapUri;

        /// <value>Zwraca listę krajów znajdujących się na kontynencie.</value>
        public List<Country> Countries => _countries;

        /// <summary>
        /// Konstruktor klasy. Nadaje wartości nazwie kraju, ścieżce dostępu do mapy kontynentu, oraz liście krajów.
        /// </summary>
        /// <param name="name">Nazwa kontynentu.</param>
        /// <param name="uri">Ścieżka dostępu do mapy kraju.</param>
        /// <param name="countries">Lista krajów kontynentu.</param>
        public Continent(string name, string uri, List<Country> countries)
        {
            _name = name;
            _mapUri = uri;
            _countries = countries;
        }
    }
}
