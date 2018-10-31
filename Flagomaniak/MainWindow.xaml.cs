using Flagomaniak.GameBoard;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Linq;


namespace Flagomaniak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game _game;

        public MainWindow()
        {
            InitializeComponent();
            _game = new Game();
            _game.NewContinent();
            this.DataContext = _game;

   
         
            coutriesNames.ItemsSource = _game.Names;
            coutriesFlags.ItemsSource = _game.Flags;
           
        }

        ListBox source;

     
        private void coutriesNames_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            source = parent;
            object data = GetDataFromListBox(source, e.GetPosition(parent));

            if (data != null)
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Copy);
 
        }


        private static object GetDataFromListBox(ListBox source, Point point)
        {
            UIElement element = source.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = source.ItemContainerGenerator.ItemFromContainer(element);

                    if (data == DependencyProperty.UnsetValue)
                        element = VisualTreeHelper.GetParent(element) as UIElement;

                    if (element == source)
                        return null;
                }

                if (data != DependencyProperty.UnsetValue)
                    return data;
            }
            return null;
        }

        private void test_Drop(object sender, DragEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            object data = e.Data.GetData(typeof(string));

            parent.Items.Add(data);
            ((IList<string>)source.ItemsSource).Remove((string)data);            
        }

        private void map_Drop(object sender, DragEventArgs e)
        {
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
                img.Width = 40;
                img.Height = 30;
                Canvas.SetLeft(img, p.X - 20);
                Canvas.SetTop(img, p.Y - 15);
                map.Children.Add(img);
            }

            if (source == coutriesNames)
            {
                Label label = new Label();
                label.Content = (string)data;
                Canvas.SetLeft(label, p.X - 20);
                Canvas.SetTop(label, p.Y - 15);
                map.Children.Add(label);
            }

            //zrobić tak żeby położenie się zgadzało tam gdzie upuszczę flagę!!!! 
            ((IList<string>)source.ItemsSource).Remove((string)data);


            //sprawdzam czy jest label dobrze dodany
            CheckBoxIfPoland("Poland", p);
        }

        




        //accual rendered size of map
        private void CheckSize()
        {
            double width = map.ActualHeight;
            double height = map.ActualWidth;

            MessageBox.Show($"Width: {width} Height: {height}");
        }

        //try to check correct aswer
        private void CheckBoxIfPoland(string name, Point p)
        {
            
            string coordinates = _game.Continents.Find(c => c.Name == "Europa").Countries.Find(c => c.Name == "Polska").Coordinates;

            //zamienić te wpółrzędne jakoś do densownej fomy i sprawdzić czy punkt gdzie 
            //włorzyłam flagę/label jest w środku tych wpółrzędnych
            //i od razu po kilknięciu to sprawdzać, a punkty wyświetlać na końcu
            //zapisywać sobie wyniki do jakiegoś góna i dobre podświtlac na zielono, a złe wyniki na czerwono

            //wyskubanie danych z tego stringa głuipego, debilnego
            //ale ten projekt jest debilny, mogłam go nie brać wogóle
            bool isPoland = true;

            var cor = coordinates.Replace('C', ' ').Split(' ').Skip(2).Reverse().Skip(1);

            List<Point> polygon = new List<Point>();
            //tzreba przeskalować współrzędne tego karju do rozmiaru CANVAS!!!

            //wpółrzędne jako liczby
            foreach(var c in cor)
            {
                if (c == "")
                    continue;

                var point = c.Split(',');

                polygon.Add(new Point(double.Parse(point[0].Replace('.', ',')), 
                                       double.Parse(point[0].Replace('.', ','))));
              
            }

            MessageBox.Show($"X: {p.X}, Y: {p.Y}");
            isPoland = IsInPolygon(p, polygon);

            if (isPoland == true)
                MessageBox.Show("Yes it is Poland!!!!");
            else
                MessageBox.Show("this is not Poland!!!");
        }

        public static bool IsInPolygon(Point point, List<Point> polygon)
        {
            bool result = false;
            var a = polygon.Last();
            foreach (var b in polygon)
            {
                if ((b.X == point.X) && (b.Y == point.Y))
                    return true;

                if ((b.Y == a.Y) && (point.Y == a.Y) && (a.X <= point.X) && (point.X <= b.X))
                    return true;

                if ((b.Y < point.Y) && (a.Y >= point.Y) || (a.Y < point.Y) && (b.Y >= point.Y))
                {
                    if (b.X + (point.Y - b.Y) / (a.Y - b.Y) * (a.X - b.X) <= point.X)
                        result = !result;
                }
                a = b;
            }
            return result;
        }





    }
}
