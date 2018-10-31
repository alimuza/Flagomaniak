using Flagomaniak.Continents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flagomaniak.GameBoard
{
    /// <summary>
    /// Klasa opisyjąca zahcowanie gry
    /// </summary>
    class Game
    {
        /// <summary>
        /// Klasa przechowywująca wszystkie kontynety w grze.
        /// </summary>
        private ContinentCollection _continents;

        /// <summary>
        /// Aktualny kontynent w grze.
        /// </summary>
        private Continent _currentContinent;

        /// <summary>
        /// Zmienna typu Random do losowania liczb.
        /// </summary>
        private Random _random;
        /// <summary>
        /// Zmienna przechowywująca nazwy krajów aktualnego kontynetu w grze.
        /// </summary>
        private ObservableCollection<string> _names;
        /// <summary>
        /// Zmienna przechowywująca wszystkie flagi aktualnego kontynentu w grze.
        /// </summary>
        private ObservableCollection<string> _flags;


        public List<Continent> Continents => _continents.Continents;

        //wszytskie publiczne zmienne do interfejsu => powinny inplementować notify propery change!!!
        public ObservableCollection<string> Names => _names;
        public ObservableCollection<string> Flags => _flags;

        public string ContinentName
        {
           get { return _currentContinent.Name; }
           set { } 
        }

        public string ContinentMap
        {
            get { return _currentContinent.MapUri; }
            set { }
        }



        public Game()
        {
            _continents = new ContinentCollection();
            _names = new ObservableCollection<string>();
            _flags = new ObservableCollection<string>();
            _random = new Random();
        }

        /// <summary>
        /// Losuje kontynet spośród zbioru wszystkich kontynetów w grze.
        /// </summary>
        private void DrawContinent()
        {
            int count = _continents.Continents.Count;
            int index = _random.Next(count);

            _currentContinent = _continents.Continents[index];
            ContinentName = _currentContinent.Name;
            ContinentMap = _currentContinent.MapUri;
        }

        /// <summary>
        /// Ustwaia nazwy państw oraz flagi do wyswietlenia w graficznym interfejsie uzytkownika.
        /// </summary>
        private void SetNamesAndFlags()
        {
            _names.Clear();
            _flags.Clear();
            foreach(Country c in _currentContinent.Countries)
            {
                _names.Add(c.Name);
                _flags.Add(c.FlagUri);
            }
        }

        /// <summary>
        /// Ustawianie nowego kontynentu.
        /// </summary>
        public void NewContinent()
        {
            DrawContinent();
            SetNamesAndFlags();
        }

        


    }
}
