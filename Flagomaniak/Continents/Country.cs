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


        private string _coordinates;

        public string Coordinates => _coordinates;

        ///<value>Zwraca nazwę kraju.</value>
        public string Name => _name;

        ///<value>Zwraca ścieżkę dostępu do flagi kraju.</value>
        public string FlagUri => _flagUri; 

        /// <summary>
        /// Konstruktor klasy. Nadaje wartość nazwie kraju oraz ścieżce dostępy do flagi kraju.
        /// </summary>
        /// <param name="name">Nazwa kraju.</param>
        /// <param name="uri">Ścieżka dostępu do fali kraju.</param>
        public Country(string name, string uri, string cor)
        {
            this._name = name;
            this._flagUri = uri;
            this._coordinates = cor;
        }
    }
}
