using Flagomaniak.GameBoard;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Flagomaniak
{
    /// <summary>
    /// Logika interakcji z głównym oknem gry.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Klasa opisująca zachowanie się gry.
        /// </summary>
        private Game _game;

        /// <summary>
        /// Odtwarzacz dźwięków w grze.
        /// </summary>
        private MediaPlayer _sound;

        /// <summary>
        /// Konstruktor klasy.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _game = new Game();
            _sound = new MediaPlayer();
            _game.NewGame();
            this.DataContext = _game;

            coutriesNames.ItemsSource = _game.Names;
            coutriesFlags.ItemsSource = _game.Flags;
        }

        /// <summary>
        /// Lista, z której elementy są przeciągane na mapę przez użytkownika.
        /// </summary>
        ListBox source;

        /// <summary>
        /// Funkcja obsługująca zdarzenie kliknięcia myszką na listę zawierającą flagi bądź nazwy państw.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie.</param>
        /// <param name="e">Informacje o zdarzeniu.</param>
        private void coutriesNames_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            source = parent;
            object data = GetDataFromListBox(source, e.GetPosition(parent));

            if (data != null)
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Copy);
 
        }

        /// <summary>
        /// Funkcja zwracająca kliknięty element listy.
        /// </summary>
        /// <param name="source">Lista z obiektami.</param>
        /// <param name="point">Punkt, w którym kliknięto na listę.</param>
        /// <returns>Dane z listy.</returns>
        private static object GetDataFromListBox(ListBox source, Point point)
        {
            UIElement elem = source.InputHitTest(point) as UIElement;
            if (elem != null)
            {
                object result = DependencyProperty.UnsetValue;
                while (result == DependencyProperty.UnsetValue)
                {
                    result = source.ItemContainerGenerator.ItemFromContainer(elem);

                    if (result == DependencyProperty.UnsetValue)
                        elem = VisualTreeHelper.GetParent(elem) as UIElement;

                    if (elem == source)
                        return null;
                }

                if (result != DependencyProperty.UnsetValue)
                    return result;
            }
            return null;
        }

        /// <summary>
        /// Funkcja obsługująca zdarzenie upuszczenia elementu na mapę. Dodaje do mapy flagę bądź nazwę kraju.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie.</param>
        /// <param name="e">Informacje o zdarzeniu.</param>
        private void map_Drop(object sender, DragEventArgs e)
        {
            string countryName = " ";
            object data = e.Data.GetData(typeof(string));
            Point p = e.GetPosition(map);

            if (source == coutriesFlags)
            {
                Image img = new Image();
                BitmapImage flag = new BitmapImage();
                flag.BeginInit();
                flag.UriSource = new Uri((string)data, UriKind.Relative);
                flag.EndInit();
                img.Source = flag;
                img.Width = 25;
                img.Height = 15;
                Canvas.SetLeft(img, p.X - 12.5);
                Canvas.SetTop(img, p.Y - 7.5);
                map.Children.Add(img);
                int index = flag.UriSource.ToString().LastIndexOf('/');
                countryName = flag.UriSource.ToString().Remove(0, index +1).Replace(".png", "");
            }

            if (source == coutriesNames)
            {
                Label label = new Label();
                label.Content = (string)data;
                label.FontSize = 9;
                Canvas.SetLeft(label, p.X - 12.5);
                Canvas.SetTop(label, p.Y - 7.5);
                map.Children.Add(label);
                countryName = (string)data;
            }

            ((IList<string>)source.ItemsSource).Remove((string)data);

            _sound.Open(new Uri(@"../../Resources/Sounds/Click2.wav", UriKind.Relative));
            _sound.Play();
            //Sprawdzenie, czy element został dodany w odpowiednim miejscu na mapie.
            _game.CheckAnswer(countryName, p, map.ActualWidth, map.ActualHeight);
        }

        /// <summary>
        /// Domyślne powiększenie mapy.
        /// </summary>
        double zoom = 1;
        /// <summary>
        /// Minimalne powiększenie mapy.
        /// </summary>
        double zoomMin = 1;
        /// <summary>
        /// Maksymalne powiększenie mapy.
        /// </summary>
        double zoomMax = 6;

        /// <summary>
        /// Funkcja obsługująca powiększanie i pomniejszanie mapy.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie.</param>
        /// <param name="e">Informacje o zdarzeniu.</param>
        private void map_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Point p = e.GetPosition(map);  
            double rate = 0.01;
            zoom += rate * e.Delta;
            if (zoom < zoomMin)
                zoom = zoomMin;
            if (zoom > zoomMax)
                zoom = zoomMax;

            if (e.Delta > 0)
            {
                map.RenderTransform = new ScaleTransform(zoom, zoom, p.X, p.Y);
            }
            else
            {
                map.RenderTransform = new ScaleTransform(zoom, zoom, p.X, p.Y);
            }
          
        }

        /// <summary>
        /// Funkcja wywołująca się po naciśnięciu przycisku sprawdź.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie.</param>
        /// <param name="e">Informacje o zdarzeniu.</param>
        private void btnCheckAnswer_Click(object sender, RoutedEventArgs e)
        {
            if(_game.Names.Count != 0 || _game.Flags.Count != 0)
            {
                MessageBox.Show("Wciąż masz flagi lub nazwy państw do dopasowania!");
                return;
            }

            map.AllowDrop = false;
            undo.IsHitTestVisible = false;
            btnCheckAnswer.IsEnabled = false;

            _game.GetFinalScore(map.Children); 
            lblPoints.Visibility = Visibility.Visible;
            if(_game.Points == 1000)
            {
                _sound.Open(new Uri(@"../../Resources/Sounds/winer.wav", UriKind.Relative));
                _sound.Play();
            }
            _game.SaveGame();
            lblPoints.Visibility = Visibility.Visible;
            pointLabel.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Funkcja cofająca poprzedni ruch użytkownika. Wywołuje się po wciśnięciu przycisku cofnij.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie.</param>
        /// <param name="e">Informacje o zdarzeniu.</param>
        private void undo_Click(object sender, RoutedEventArgs e)
        {
            int index = map.Children.Count - 1;
            if (index < 0)
                return;
            UIElement element = map.Children[index];
            map.Children.RemoveAt(index);
            string data = "";

            if (element is Image)
            {
                Image img = (Image)element;
                data = img.Source.ToString();
                _game.Flags.Add(data);
            }
            else
            {
                Label label = (Label)element;
                data = (string)label.Content;
                _game.Names.Add(data);
            }
        }

        /// <summary>
        /// Nowa gra. Funkcja wywołuje się po wciśnięciu przycisku nowa gra. 
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie.</param>
        /// <param name="e">Informacje o zdarzeniu.</param>
        private void newGame_Click(object sender, RoutedEventArgs e)
        {
            btnCheckAnswer.IsEnabled = true;
            map.AllowDrop = true;
            map.Children.Clear();
            _game.NewGame();
            _game.Points = 0;
            lblPoints.Visibility = Visibility.Hidden;
            pointLabel.Visibility = Visibility.Hidden;
        }
    }
}
