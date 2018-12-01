using Flagomaniak.GameUsers;
using System;
using System.Windows;

namespace Flagomaniak
{
    /// <summary>
    /// Logika interakcji z oknem wyboru użytkownika.
    /// </summary>
    public partial class PlayerWindow : Window
    {
        /// <summary>
        /// Wybrane imię użytkownika.
        /// </summary>
        private string _user;

        /// <summary>
        /// Zawiera zbiór wszystkich użytkowników w grze.
        /// </summary>
        private Users _users;

        /// <value>Zwraca imię wybranego użytkownika.</value>
        public string User
        {
            get { return _user; }
        }

        /// <summary>
        /// Konstruktor klasy.
        /// </summary>
        /// <param name="users">Zbiór wszystkich użytkowników w grze.</param>
        public PlayerWindow(Users users)
        {
            InitializeComponent();
            _users = users;
            this.DataContext = _users;
        }

        /// <summary>
        /// Wyjście z programu. Funkcja wywołuje się po wciśnięciu przycisku wyjdź.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie.</param>
        /// <param name="e">Informacje o zdarzeniu.</param>
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Start gry. Funkcja jest wywoływana po wciśnięciu przycisku start.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie.</param>
        /// <param name="e">Informacje o zdarzeniu.</param>
        private void start_Click(object sender, RoutedEventArgs e)
        {
            User user = (User)grid.SelectedValue;
            if (user == null)
            {
                MessageBox.Show("Wybierz użytkownika!");
                return;
            }
            this._user = user.UserName;
            this.Close();
        }

        /// <summary>
        /// Dodawanie nowego użytkownika. Funkcja jest wywoływana po wciśnięciu przycisku nowy gracz.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie.</param>
        /// <param name="e">Informacje o zdarzeniu.</param>
        private void newUser_Click(object sender, RoutedEventArgs e)
        {
            UserName userName = new UserName();
            userName.ShowDialog();
            if (userName.UName == null)
                return;
            _users.AddPlayer(userName.UName);
        }
    }
}
