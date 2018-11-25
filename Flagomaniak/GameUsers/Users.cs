using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;

namespace Flagomaniak.GameUsers
{
    /// <summary>
    /// Klasa opisująca zbiór użytkowników w grze.
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Ścieżka do pliku z zapisaną historią użytkowników.
        /// </summary>
        private string _path;

        /// <summary>
        /// Lista użytkowników w grze.
        /// </summary>
        /// <remarks>
        private ObservableCollection<User> _users;

        /// <value>
        /// Zwraca listę użytkowników gry.
        /// </value>
        public ObservableCollection<User> UsersList
        {
            get { return this._users;  }
        }

        /// <summary>
        /// Konstruktor klasy zawierającej użytkowników. Wczytuje on listę użytkowników z pliku XML.
        /// </summary>
        /// <param name="filePath">Ścieżka dostępu do pliku z historią użytkowników.</param>
        public Users(string filePath)
        {
            _path = filePath;
            if (File.Exists(_path))
            {
                StreamReader reader = new StreamReader(_path);
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<User>));
                this._users = (ObservableCollection<User>)serializer.Deserialize(reader);
                reader.Close();
            }
            else
            {
                this._users = new ObservableCollection<User>();
            }
        }

        /// <summary>
        /// Zapisuje wszystkich użytkowników gry wraz z historią wyników do pliku XML.
        /// </summary>
        public void SaveToFile()
        {
            StreamWriter writer = new StreamWriter(_path);
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<User>));
            serializer.Serialize(writer, this.UsersList);
            writer.Close();
        }

        /// <summary>
        /// Dodaje wynik użytkownika gry do historii.
        /// </summary>
        /// <param name="name">Imię gracza.</param>
        /// <param name="points">Wynik gracza.</param>
        public void SavePlayer(string name, int points)
        {
            _users.First(p => p.UserName == name).Add(points);
            this.SaveToFile();
        }

        /// <summary>
        /// Dodaje użytkownika do grona użytkowników gry.
        /// </summary>
        /// <param name="name">Imię nowego użytkownika.</param>
        public void AddPlayer(string name)
        {
            if(_users.Any(p => p.UserName == name))
            {
                MessageBox.Show("Gracz o takim imieniu już istnieje!");
                return;
            }

            User newUser = new User(name);
            this._users.Add(newUser);
            this.SaveToFile();
        }
    }
}
