using System.Collections.Generic;
using System.Linq;

namespace Flagomaniak.GameUsers
{
    /// <summary>
    /// Klasa opisująca użytkownika gry.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Imię użytkownika gry.
        /// </summary>
        private string _userName;

        /// <summary>
        /// Zapisane wyniki użytkownika.
        /// </summary>
        private List<int> _userHistory;

        /// <value>
        /// Zwraca imię użytkownika.
        /// </value>
        public string UserName
        {
            get { return this._userName; }
            set { _userName = value; }
        }

        /// <value>
        /// Zwraca najlepszy wynik gracza.
        /// </value>
        public int HeightestScore
        {
            get { return this._userHistory.Max(); }
            set { }
        }
            
        /// <value>
        /// Zwraca historię wyników gracza.
        /// </value>
        public List<int> UserHistory
        {
            get { return _userHistory; }
            set { }
        }

        /// <summary>
        /// Konstruktor klasy użytkownika. Inicjalizuję imię oraz historię wyników.
        /// </summary>
        /// <param name="name">Imię użytkownika.</param>
        public User(string name)
        {
            _userHistory = new List<int>();
            _userName = name;
            _userHistory.Add(0);
        }

        /// <summary>
        /// Konstruktor bez parametrów. Jest on potrzebny w celu zapisu historii do pliku XML.
        /// </summary>
        public User()
        {
            _userHistory = new List<int>();
            _userHistory.Add(0);
        }

        /// <summary>
        /// Dodanie wyniku do historii wyników użytkownika.
        /// </summary>
        /// <param name="points">Punkty zdobyte przez gracza.</param>
        public void Add(int points) 
        {
            this._userHistory.Add(points);
        } 
    }
}
