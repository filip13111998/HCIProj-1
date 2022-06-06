using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GMap.NET;
using GMap.NET.WindowsPresentation;
using Serbia_Train.models;
using Line = Serbia_Train.models.Line;

namespace Serbia_Train.pages
{
    /// <summary>
    /// Interaction logic for MapPage.xaml
    /// </summary>
    public partial class MapPage : Page
    {


        public static String Line_Name { get; set; }

        public static Line My_Line { get; set; }

        public static List<PointLatLng> gpollist = new List<PointLatLng>();

        public static GMapPolygon gpol = new GMapPolygon(gpollist);
        public MapPage()
        {
            InitializeComponent();

            Find_Line();

            Station_Name_Filed.GotFocus += RemoveName;
            Station_Name_Filed.LostFocus += AddName;

            Longitude_Name_Filed.GotFocus += RemoveLongitude;
            Longitude_Name_Filed.LostFocus += AddLongitude;

            Latitude_Name_Filed.GotFocus += RemoveLatitude;
            Latitude_Name_Filed.LostFocus += AddLatitude;


        }

        public void Find_Line()
        {

            this.Lab_Name.Content = Line_Name;

            My_Line = Line.Line_List.Where(l => l.Name.ToLower().Equals(Line_Name.ToLower())).FirstOrDefault();

            this.DataContext = My_Line;

        }

        public void Add_Station(object sender , RoutedEventArgs e)
        {

            Station s = new Station();
            s.Name = this.Station_Name_Filed.Text;
            s.Longitude = Double.Parse( this.Longitude_Name_Filed.Text);
            s.Latitude = Double.Parse(this.Latitude_Name_Filed.Text);

            My_Line.ListaStanica.Add(s);
            Console.WriteLine(My_Line.ListaStanica.Count);

            MapView_Loaded(sender,e);


        }

        public void Delete_Station(object sender, RoutedEventArgs e)
        {


            Station s = Station_Left_Menu.SelectedItem as Station;

            My_Line.ListaStanica.Remove(s);

            MapView_Loaded(sender, e);

        }

        public void RemoveName(object sender, EventArgs e)
        {


            if (Station_Name_Filed.Text == "Enter Name")
            {

                Station_Name_Filed.Text = "";
            }
        }

        public void AddName(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Station_Name_Filed.Text))
                Station_Name_Filed.Text = "Enter Name";
        }

        public void RemoveLongitude(object sender, EventArgs e)
        {


            if (Longitude_Name_Filed.Text == "Enter Longitude")
            {

                Longitude_Name_Filed.Text = "";
            }
        }

        public void AddLongitude(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Longitude_Name_Filed.Text))
                Longitude_Name_Filed.Text = "Enter Longitude";
        }

        public void RemoveLatitude(object sender, EventArgs e)
        {


            if (Latitude_Name_Filed.Text == "Enter Latitude")
            {

                Latitude_Name_Filed.Text = "";
            }
        }

        public void AddLatitude(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Latitude_Name_Filed.Text))
                Latitude_Name_Filed.Text = "Enter Latitude";
        }



        public String Curr { get; set; }

        public void Mouse_Click(object sender, MouseEventArgs ev)
        {

            if (ev.LeftButton == MouseButtonState.Pressed)
            {
                Ellipse el = sender as Ellipse;
                Console.WriteLine(el.Name);
                Curr = el.Name;
                DragDrop.DoDragDrop((Ellipse)sender, (Ellipse)sender, DragDropEffects.Move);

            }


           
        }


        public void Map_Drop(object sender, DragEventArgs e)
        {


            double x = e.GetPosition(mapView).X;
            double y = e.GetPosition(mapView).Y;

            double lat = mapView.FromLocalToLatLng(Convert.ToInt32(x), Convert.ToInt32(y)).Lat;
            double lng = mapView.FromLocalToLatLng(Convert.ToInt32(x), Convert.ToInt32(y)).Lng;


            String str_longtd = Curr.Split('e')[1];

            double num_longtd = 0;
            if (str_longtd.StartsWith("_"))
            {
                num_longtd = -Double.Parse(str_longtd.Substring(1))/10000;
            }
            else
            {
                num_longtd = Double.Parse(str_longtd) / 10000;
            }

            String str_latt = Curr.Split('e')[2];

            double num_lat = 0;
            if (str_latt.StartsWith("_"))
            {
                num_lat = -Double.Parse(str_latt.Substring(1)) / 10000;
            }
            else
            {
                num_lat = Double.Parse(str_latt) / 10000;
            }

            double longtd = num_longtd;
            double ltd = num_lat;


            foreach (GMapMarker gmm in mapView.Markers)
            {

                if (ltd == gmm.Position.Lat && longtd == gmm.Position.Lng)
                {

                    Console.WriteLine("PRAVE Long" + longtd);
                    Console.WriteLine("PRAVE Lat" + ltd);

                    foreach (Station stat in My_Line.ListaStanica)
                    {
                        Console.WriteLine("Long" + stat.Longitude);
                        Console.WriteLine("Lat" + stat.Latitude);
                    }

                    Station s = My_Line.ListaStanica.Where(st => st.Longitude == longtd && st.Latitude == ltd).FirstOrDefault();

                    if (s ==null)
                    {
                        Draw_Route();
                        return;
                    }

                    double new_lat = Math.Round(lat ,4);
                    double new_ltd = Math.Round(lng , 4);


                    s.Latitude = new_lat;
                    s.Longitude = new_ltd;

                    gmm.Position = new PointLatLng(new_lat, new_ltd);

                    String str_lat = "";
                    if (new_lat < 0)
                    {
                        str_lat = "_" + Math.Abs(new_lat*10000);
                    }
                    else
                    {
                        str_lat = "" + (new_lat * 10000);
                    }

                    String str_lng = "";
                    if (new_ltd < 0)
                    {
                        str_lng = "_" + Math.Abs(new_ltd * 10000);
                    }
                    else
                    {
                        str_lng = "" + (new_ltd * 10000);
                    }



                    String temp_name = "e"+ str_lng + "e"+ str_lat ;


                    Ellipse elp = gmm.Shape as Ellipse;
                    elp.Name = temp_name;


                    
                }
                
            }
            Draw_Route();

        }

        private void MapView_Loaded(object sender, RoutedEventArgs e)
        {

           

            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            // choose your provider here
            mapView.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            mapView.MinZoom = 2;
            mapView.MaxZoom = 17;
            // whole world zoom
            mapView.Zoom = 2;
            mapView.AllowDrop = true;

            // lets the map use the mousewheel to zoom
            mapView.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;


            mapView.Drop += this.Map_Drop;

            mapView.ShowCenter = false;

            mapView.Markers.Clear();

            foreach (Station st in My_Line.ListaStanica)
            {
                PointLatLng p = new PointLatLng(st.Latitude, st.Longitude);
                GMapMarker marker = new GMapMarker(p)
                {

                    Shape = new Ellipse
                    {
                        Name = "elipsa",
                        
                        Width = 40,
                        Height = 40,
                        Stroke = Brushes.BlueViolet,
                        StrokeThickness = 1.5
                    }

                };
                
                Ellipse elp = marker.Shape as Ellipse;


                String str_lng = "";
                String str_lat = "";

                if (p.Lng<0)
                {
                    str_lng = "_" + Math.Abs(p.Lng*10000);
                }
                else
                {
                    str_lng = "" + p.Lng * 10000;
                }

                if (p.Lat < 0)
                {
                    str_lat = "_" + Math.Abs(p.Lat * 10000);
                }
                else
                {
                    str_lat = "" + p.Lat * 10000;
                }

                String temp_name = "e" + str_lng + "e" + str_lat;
                //elp.Name = "e" + p.Lng * 10000 + "e" + p.Lat * 10000;

                elp.Name = temp_name;

                   elp.Fill = new ImageBrush() {
                    ImageSource= new BitmapImage(new Uri("pack://application:,,,/assets/st2.png")),
                    Stretch = Stretch.Fill
                };

                marker.Shape.MouseMove += new MouseEventHandler(this.Mouse_Click);

                mapView.Markers.Add(marker);
            }


            Draw_Route();


        }

        public void Draw_Route()
        {
            mapView.Markers.Remove(gpol);

            gpollist = new List<PointLatLng>();

            foreach (Station s in My_Line.ListaStanica)
            {
                PointLatLng p = new PointLatLng(s.Latitude, s.Longitude);
                gpollist.Add(p);
            }

            foreach (Station s in My_Line.ListaStanica.Reverse().Skip(1))
            {
                PointLatLng p = new PointLatLng(s.Latitude, s.Longitude);
                gpollist.Add(p);
            }

            gpol = new GMapPolygon(gpollist);



            mapView.Markers.Add(gpol);
        }


    }
}
