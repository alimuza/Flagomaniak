using System.Windows;

namespace Flagomaniak
{
    /// <summary>
    /// Logika interakcji z oknem wpisywania nowego użytkownika.
    /// </summary>
    public partial class UserName : Window
    {
        /// <summary>
        /// Wpisane imię użytkownika.
        /// </summary>
        private string _userName;

        /// <value>Zwraca nowe imię użytkownika.</value>
        public string UName
        {
            get { return _userName; }
        }

        /// <summary>
        /// Konstruktor klasy.
        /// </summary>
        public UserName()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Potwierdzenie wyboru imienia.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie.</param>
        /// <param name="e">Informacje o zdarzeniu.</param>
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(userName.Text))
                MessageBox.Show("Podaj imię gracza!");
            else
            {
                _userName = userName.Text;
                this.Close();
            }
        }

        /// <summary>
        /// Anulowanie wyboru imienia użytkownika.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie.</param>
        /// <param name="e">Informacje o zdarzeniu.</param>
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            _userName = null;
            this.Close();
        }
    }
}
