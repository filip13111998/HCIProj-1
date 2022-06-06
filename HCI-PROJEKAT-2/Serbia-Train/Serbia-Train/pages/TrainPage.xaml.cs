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
using Serbia_Train.models;

namespace Serbia_Train.pages
{
    /// <summary>
    /// Interaction logic for TrainPage.xaml
    /// </summary>
    /// 

   

    public partial class TrainPage : Page
    {

        //public String Temp_Train_Name { get; set; }

        public String Image { get; set; } = "/assets/train2.png";

        MainWindow Mw { get; set; }
        public TrainPage(MainWindow mw)
        {
            InitializeComponent();
            this.Mw = mw;
            this.Trains_Left_Menu.DataContext = Train.Trains;

            Wagon_Order_Filed.GotFocus += RemoveWagonOrder;
            Wagon_Order_Filed.LostFocus += AddWagonOrder;

            Add_Train_Filed.GotFocus += RemoveAddTrain;
            Add_Train_Filed.LostFocus += AddAddTrain;

            Set_Menu();
        }
        public void Set_Menu()
        {
            this._MenuNavigationBarFrame.Navigate(new MenuPage(this.Mw));

        }


        public void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {

            
            var row = (DataGridRow)sender;

            if (row == null) return;

            var train = row.Item as Train;

            this.Train_Name.Content =  train.Name;

            //this.Temp_Train_Name = train.Name;


            //Draw New Composition
            this.Draw_Composition(train);

        }


        public void Draw_Composition(Train train)
        {

            //Clear Previous Composition
            this.Train_Composition.Children.Clear();

            var id = 0;

            StackPanel sp_vertical_train = new StackPanel() { Orientation = Orientation.Vertical, Name = "train" + id };

            Image img_train = new Image() { Width = 70, Height = 70 };

            StackPanel sp_tr = new StackPanel() { Height = 70 };

            img_train.Source = new BitmapImage(new Uri("/assets/train22.png", UriKind.Relative));

            sp_vertical_train.Children.Add(sp_tr);
            sp_vertical_train.Children.Add(img_train);

            this.Train_Composition.Children.Add(sp_vertical_train);

            foreach (var wagon in train.Wagons)
            {
                StackPanel sp_vertical = new StackPanel() { Orientation = Orientation.Vertical, Name = train.Name + "_" + id };

                Button btn = new Button()
                {
                    Name = train.Name + "_" + id,
                    Width = 70,
                    Height = 70,
                    Background = new SolidColorBrush(Colors.Transparent)
                    ,
                    Content = new Image
                    {
                        Source = new BitmapImage(new Uri("/assets/del2.png", UriKind.Relative)),
                        VerticalAlignment = VerticalAlignment.Center
                    }
                };



                sp_vertical.Margin = new Thickness(20, 0, 0, 0);

                btn.Click += Remove_Wagon;

                Image img = new Image() { Width = 70, Height = 70 };

                img.Source = new BitmapImage(new Uri(wagon.GetImage(), UriKind.Relative));

                sp_vertical.Children.Add(btn);
                sp_vertical.Children.Add(img);

                this.Train_Composition.Children.Add(sp_vertical);

                id++;
            }

        }

        public void Remove_Wagon(object sender,RoutedEventArgs e)
        {

            Button btn = sender as Button;

            String name_Str = btn.Name.Split('_')[0];
            String id_str = btn.Name.Split('_')[1];

            Train tr = Train.Trains.Where(t=> t.Name.Equals(name_Str)).FirstOrDefault();

            tr.Wagons.RemoveAt(Int32.Parse(id_str));

            this.Draw_Composition(tr);

            Console.WriteLine(tr.Name);

            Console.WriteLine(btn.Name);
        }


        public void Add_Wagon_Click(object sender , RoutedEventArgs e)
        {
            int id = 0;


            //try
            //{
            //    id = Int32.Parse(this.Wagon_Order_Filed.Text);
            //}
            //catch
            //{
            //    MessageBox.Show("Wrong input SINE.");
            //    return;
            //}

            Int32.TryParse(this.Wagon_Order_Filed.Text, out id);

            ComboBoxItem typeItem = (ComboBoxItem) this.Combo.SelectedItem;

            StackPanel sp = typeItem.Content as StackPanel;

            FrameworkElement fe = sp.Children[1] as FrameworkElement;

            TextBlock tb = fe as TextBlock;



            string wagon_type = tb.Text;

            Console.WriteLine(wagon_type);

            

            Wagon w;
            if (wagon_type == "MALI")
            {
                w = new Wagon(TypeWagon.MALI);
            }
            else if (wagon_type == "SREDNJI") {
                w = new Wagon(TypeWagon.SREDNJI);
            }
            else
            {
                w = new Wagon(TypeWagon.VELIKI);
            }

            Train tr = Train.Trains.Where(t => t.Name.Equals(this.Train_Name.Content)).FirstOrDefault();

            if ( tr == null )
            {
                MessageBox.Show("NULL MSG");
                return;
            }

            if (id> tr.Wagons.Count || id<0)
            {
                id = tr.Wagons.Count;
            }

            tr.Wagons.Insert(id,w);

            this.Draw_Composition(tr);


        }

        public void Add_Train_Click(object sender, RoutedEventArgs e)
        {

            String Train_Str_Name = this.Add_Train_Filed.Text;

            Train tr = Train.Trains.Where(t => t.Name.Equals(Train_Str_Name)).FirstOrDefault();

            if(tr != null)
            {
                Console.WriteLine("VEC POSTOJI VOZ");
                return;
            }

            Train New_Train = new Train() { Name = Train_Str_Name };

            Train.Trains.Add(New_Train);

        }

        public void RemoveAddTrain(object sender, EventArgs e)
        {

            if (Add_Train_Filed.Text == "Add Train")
            {
                Add_Train_Filed.Text = "";
            }
        }

        public void AddAddTrain(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Add_Train_Filed.Text))
                Add_Train_Filed.Text = "Add Train";
        }

        public void RemoveWagonOrder(object sender, EventArgs e)
        {

            
            if (Wagon_Order_Filed.Text == "Enter Wagon Number")
            {
                
                Wagon_Order_Filed.Text = "";
            }
        }

        public void AddWagonOrder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Wagon_Order_Filed.Text))
                Wagon_Order_Filed.Text = "Enter Wagon Number";
        }

        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Console.WriteLine("POZVAN");
            e.Row.Header = (e.Row.GetIndex()).ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
