using Flagomaniak.Continents;
using Flagomaniak.GameUsers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Flagomaniak.GameBoard
{
    /// <summary>
    /// Klasa opisująca logikę gry.
    /// </summary>
    /// <remarks>
    /// Klasa implementuje interfejs INotifyPropertyChanged, dzięki temu dane wyświetlane w oknie gry są uaktualniane.
    /// </remarks>
    class Game : INotifyPropertyChanged
    {
        /// <summary>
        /// Zmienna zawierająca wszystkie kontynenty w grze.
        /// </summary>
        private ContinentCollection _continents;

        /// <summary>
        /// Klasa zajmująca sprawdzaniem, czy dany punkt leży wewnątrz granic kraju.
        /// </summary>
        private BorderChecker _borderChecker;

        /// <summary>
        /// Aktualny kontynent w grze.
        /// </summary>
        private Continent _currentContinent;

        /// <summary>
        /// Zmienna typu Random do losowania liczb.
        /// </summary>
        private Random _random;

        /// <summary>
        /// Zmienna zawierająca nazwy krajów aktualnego kontynentu w grze.
        /// </summary>
        private ObservableCollection<string> _names;

        /// <summary>
        /// Zmienna zawierająca ścieżki do plików z flagami.
        /// </summary>
        private ObservableCollection<string> _flags;

        /// <summary>
        /// Klasa obsługująca historię użytkowników w grze.
        /// </summary>
        private Users _userCollection;

        /// <summary>
        /// Przechowuje aktualną punktację użytkownika.
        /// </summary>
        private int _points = 0;

        /// <summary>
        /// Imię aktualnie grającego użytkownika.
        /// </summary>
        private string _userName = "";

        /// <summary>
        /// Przechowuje dane o prawidłowych i złych odpowiedziach dla wszystkich krajów.
        /// </summary>
        private Dictionary<string, bool> _answers;

        /// <value>Zwraca imię aktualnego gracza.</value>
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }

        /// <value>Zwraca informację o poprawnych i złych odpowiedziach.</value>
        public Dictionary<string, bool> Answers
        {
            get { return _answers; }
            set
            {
                _answers = value;
                OnPropertyChanged("Answers");
            }
        }

        /// <value>Zwraca nazwy wszystkich krajów.</value>
        public ObservableCollection<string> Names => _names;

        /// <value>Zwraca ścieżki dostępu do wszystkich flag.</value>
        public ObservableCollection<string> Flags => _flags;

        /// <value>Zwraca nazwę kontynentu.</value>
        public string ContinentName
        {
           get { return _currentContinent.Name; }
           set { OnPropertyChanged("ContinentName"); }
        }

        /// <value>Zwraca ścieżkę dostępu do pliku z mapą kontynentu.</value>
        public string ContinentMap
        {
            get { return _currentContinent.MapUri; }
            set { OnPropertyChanged("ContinentMap"); }
        }

        /// <value>Zwraca aktualną punktację uzytkownika.</value>
        public int Points
        {
            get { return _points; }
            set
            {
                _points = value;
                OnPropertyChanged("Points");
            }
        }

        /// <summary>
        /// Konstruktor klasy. 
        /// </summary>
        public Game()
        {
            _answers = new Dictionary<string, bool>();
            _continents = new ContinentCollection();
            _names = new ObservableCollection<string>();
            _flags = new ObservableCollection<string>();
            _random = new Random();
            _borderChecker = new BorderChecker();
            _userCollection = new Users(@"../../../Usres.xml");
        }

        /// <summary>
        /// Losuje kontynent spośród zbioru wszystkich kontynentów w grze.
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
        /// Ustawia nazwy państw oraz flagi do wyświetlenia w graficznym interfejsie użytkownika.
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
            ShuffleList(ref _names);
            ShuffleList(ref _flags);
        }

        /// <summary>
        /// Funkcja miesza listy zawierające nazwy państw oraz flagi państw, aby nie pojawiały się zawsze w tej samej kolejności.
        /// </summary>
        /// <param name="list">Lista do wymieszania.</param>
        private void ShuffleList(ref ObservableCollection<string> list)
        {
            int count = list.Count;
            int index = 0;
            for(int i =0; i< count; i++)
            {
                index = _random.Next(0, count);
                list.Add(list[index]);
                list.RemoveAt(index);
            }
        }

        /// <summary>
        /// Ustawianie nowej gry.
        /// </summary>
        public void NewGame()
        {
            DrawContinent();
            SetNamesAndFlags();
            ChooseAPlayer();
        }

        /// <summary>
        /// Sprawdza, czy flaga bądź nazwa państwa zostały upuszczone w odpowiednim miejscu na mapie i zapisuje wyniki do odpowiedniej zmiennej.
        /// </summary>
        /// <param name="name">Nazwa kraju.</param>
        /// <param name="point">Punkt na mapie, w którym upuszono flagę bądź nazwę kraju.</param>
        /// <param name="width">Aktualna szerokość mapy.</param>
        /// <param name="height">Aktualna wysokość mapy.</param>
        public void CheckAnswer(string name, Point point, double width, double height)
        {
            Country country = _currentContinent.Countries.Find(c => c.Name == name);
            List<Point> countryBorders = country.Polygon;
            bool result;

            if(_borderChecker.Check(countryBorders, width, height, point))
                result = true;
            else
                result = false;
           
            if (!Answers.ContainsKey(name))
                Answers.Add(name, result);
            else
                Answers[name] = result;
        }

        /// <summary>
        /// Obliczanie ostatecznej punktacji na podstawie odpowiedzi oraz oznaczenie poprawnych odpowiedzi na zielono i złych odpowiedzi na czerwono.
        /// </summary>
        /// <param name="map">Lista flag oraz nazw państw na mapie.</param>
        public void GetFinalScore(UIElementCollection map)
        {
            foreach (var p in Answers)
            {
                if (p.Value == true)
                    Points += 25;
                else
                    Points -= 10;

                foreach (var elem in map)
                {
                    if (elem is Label)
                    {
                        Label label = elem as Label;
                        if ((string)label.Content == p.Key && p.Value == true)
                            label.Background = new SolidColorBrush(Colors.Green);
                        else if((string)label.Content == p.Key && p.Value == false)
                            label.Background = new SolidColorBrush(Colors.Red);
                    }
                }
            }
        }

        /// <summary>
        /// Funkcja służąca do wyboru użytkownika w grze. Wyświetla nowe okno z polem wyboru użytkownika.
        /// </summary>
        private void ChooseAPlayer()
        {
            PlayerWindow choosePlayer = new PlayerWindow(_userCollection);
            choosePlayer.ShowDialog();
            UserName = choosePlayer.User;
        }

        /// <summary>
        /// Zapisanie wyniku użytkownika do historii.
        /// </summary>
        public void SaveGame()
        {
            _userCollection.SavePlayer(_userName, _points);
        }

        /// <summary>
        /// Zdarzenie zmiany wartości właściwości klasy.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Funkcja wywołuje się, gdy zmieni się wartość właściwości.
        /// </summary>
        /// <param name="name">Nazwa właściwości, której wartość uległa zmianie.</param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
