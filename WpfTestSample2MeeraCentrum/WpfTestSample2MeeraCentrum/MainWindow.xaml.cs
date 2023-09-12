using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
using WpfTestSample2MeeraCentrum.Properties;

namespace WpfTestSample2MeeraCentrum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TreeViewModel MyViewModel 
        {
            get { return DataContext as TreeViewModel; }
            set { DataContext = value; }
        }
        public TreeModel Wells;
        public TreeModel Rocks; 
        public TreeModel Polygones; 
        public TreeModel WellStrategies;

        public MainWindow()
        {
            InitializeComponent();
            MyViewModel = new TreeViewModel();

            Wells = new TreeModel("Wells", @"/Resources/Wells.jpg");
            MyViewModel.Items.Add(Wells);
            Wells.Items.Add(new TreeModel("R2_W123456789123456789", @"/Resources/WellsM.jpg"));
            Wells.Items.Add(new TreeModel("R1_W7", @"/Resources/WellsM.jpg"));
            Wells.Items.Add(new TreeModel("R1_W1", @"/Resources/WellsM.jpg"));
            Wells.Items.Add(new TreeModel("R1_W11", @"/Resources/WellsM.jpg"));
            Wells.Items.Add(new TreeModel("R1_W012", @"/Resources/WellsM.jpg"));
            Wells.Items.Add(new TreeModel("R2_W1", @"/Resources/WellsM.jpg"));
            Wells.Items.Add(new TreeModel("R2_W03", @"/Resources/WellsM.jpg"));


            Rocks = new TreeModel("Rocks", @"/Resources/Rocks.jpg");
            MyViewModel.Items.Add(Rocks);
            Rocks.Items.Add(new TreeModel("R1", @"/Resources/RocksM.jpg"));
            Rocks.Items.Add(new TreeModel("R2", @"/Resources/RocksM.jpg"));
            Rocks.Items.Add(new TreeModel("R3", @"/Resources/RocksM.jpg"));
            Rocks.Items.Add(new TreeModel("R4", @"/Resources/RocksM.jpg"));

            Polygones = new TreeModel("Polygones", @"/Resources/Polygones.jpg");
            MyViewModel.Items.Add(Polygones);


            WellStrategies = new TreeModel("WellStrategies", @"/Resources/WellStrategies.jpg");
            MyViewModel.Items.Add(WellStrategies);
            WellStrategies.Items.Add(new TreeModel("WS1", @"/Resources/WellStrategiesM.jpg"));
            WellStrategies.Items.Add(new TreeModel("WS2", @"/Resources/WellStrategiesM.jpg"));
            WellStrategies.Items.Add(new TreeModel("WS3", @"/Resources/WellStrategiesM.jpg"));
            
        }

        private void OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            MyViewModel.SelectedItem = e.NewValue as TreeModel;
        }

        // Delete Actions
        private void deleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            DeletePanel.Visibility = Visibility.Visible;
            RenamePanel.Visibility = Visibility.Collapsed;
        }

        private void btnAbortDelete_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Visible;
            DeletePanel.Visibility = Visibility.Collapsed;
            RenamePanel.Visibility = Visibility.Collapsed;

        }

        private void btnProceesDelete_Click(object sender, RoutedEventArgs e)
        {

            if (
                MyViewModel.SelectedItem.DisplayedImagePath == @"/Resources/Wells.jpg" ||
                MyViewModel.SelectedItem.DisplayedImagePath == @"/Resources/WellStrategies.jpg" ||
                MyViewModel.SelectedItem.DisplayedImagePath == @"/Resources/Polygones.jpg" ||
                MyViewModel.SelectedItem.DisplayedImagePath == @"/Resources/Rocks.jpg")
            {
                // This is because of  duplicate renaming error
                if (MyViewModel.SelectedItem.DisplayedImagePath == @"/Resources/Wells.jpg")
                {
                    Wells.Items.Clear();
                }
                else if (MyViewModel.SelectedItem.DisplayedImagePath == @"/Resources/WellStrategies.jpg")
                {
                    WellStrategies.Items.Clear();
                } 
                else if (MyViewModel.SelectedItem.DisplayedImagePath == @"/Resources/Rocks.jpg")
                {
                    Rocks.Items.Clear();
                }
                MyViewModel.Items.Remove(MyViewModel.SelectedItem);
            }
            else
            {
                Wells.Items.Remove(MyViewModel.SelectedItem);
                Rocks.Items.Remove(MyViewModel.SelectedItem);
                WellStrategies.Items.Remove(MyViewModel.SelectedItem);
                Polygones.Items.Remove(MyViewModel.SelectedItem);
            }
            
            HomePanel.Visibility = Visibility.Visible;
            DeletePanel.Visibility = Visibility.Collapsed;
            RenamePanel.Visibility = Visibility.Collapsed;

        }


        // Rename Actions
        private void renameMenuItem_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            DeletePanel.Visibility = Visibility.Collapsed;
            RenamePanel.Visibility = Visibility.Visible;
            txtRename.Text = MyViewModel.SelectedItem.Title;
        }

        private void btnAbortRename_Click(object sender, RoutedEventArgs e)
        {
            lblError.Content = string.Empty;
            HomePanel.Visibility = Visibility.Visible;
            DeletePanel.Visibility = Visibility.Collapsed;
            RenamePanel.Visibility = Visibility.Collapsed;
        }

        private void btnProceesRename_Click(object sender, RoutedEventArgs e)
        {

            if (
                (txtRename.Text.Length > 1) &&
                (!MyViewModel.Items.Any(x => x.Title == txtRename.Text)) &&
                (!Wells.Items.Any(x => x.Title == txtRename.Text)) &&
                (!Rocks.Items.Any(x => x.Title == txtRename.Text)) &&
                (!WellStrategies.Items.Any(x => x.Title == txtRename.Text))
             )
            {
                MyViewModel.SelectedItem.Title = txtRename.Text;
                HomePanel.Visibility = Visibility.Visible;
                DeletePanel.Visibility = Visibility.Collapsed;
                RenamePanel.Visibility = Visibility.Collapsed; 
            } 
            else if (txtRename.Text.Length < 2)
            {
                lblError.Content = "**Please choose a name with more than 2 characters!";
                HomePanel.Visibility = Visibility.Collapsed;
                DeletePanel.Visibility = Visibility.Collapsed;
                RenamePanel.Visibility = Visibility.Visible;
            }
            else
            {
                lblError.Content = "**duplicated name Please choose a new one!";
                HomePanel.Visibility = Visibility.Collapsed;
                DeletePanel.Visibility = Visibility.Collapsed;
                RenamePanel.Visibility = Visibility.Visible;
            }
            txtRename.Clear();
        }
    }

    
}
