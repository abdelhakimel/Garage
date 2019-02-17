using Gestion_garage_access.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Gestion_garage_access.Views
{
    /// <summary>
    /// Logique d'interaction pour All_Pieces.xaml
    /// </summary>
    public partial class All_Pieces : UserControl
    {
        Database database = new Database();
        ObservableCollection<Piece> Pieces; 

        public All_Pieces()
        {
            InitializeComponent();
            Pieces= new ObservableCollection<Piece>(database.Pieces.ToList());
            DataContext = Pieces;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add_Piece_Window add = new Add_Piece_Window();
            add.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Piece piece = datagrid.SelectedItem as Piece;
            if(piece!=null)
            {
                Modify modify = new Modify(piece);
                modify.Show();

            }else
            MessageBox.Show("Selectionnez-vous une piece ...! ");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Piece piece = datagrid.SelectedItem as Piece;
            if (piece != null)
            {
                database.Pieces.Remove(piece);
                database.SaveChanges();
                MessageBox.Show("Done");
            }
            else
                MessageBox.Show("Selectionnez-vous une piece ...! ");

        }

        private void Datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Pieces = new ObservableCollection<Piece>(database.Pieces.ToList());
           datagrid.ItemsSource = Pieces;
        }

        private void BtnRech_Click(object sender, RoutedEventArgs e)
        {
            string rechRe = rechRef.Text;
            string rechName = rechNom.Text;
            string rechAut = rechAuto.Text;
            if(rechRe.Equals("") && rechAut.Equals("") && rechName.Equals(""))
            {
                datagrid.ItemsSource = Pieces;
            }
            else
            {
                ObservableCollection<Piece> pieces = new ObservableCollection<Piece>(database.Pieces.
                    Where(p => p.Ref_piece.Contains(rechRe) &&
                               p.Nom_piece .Contains(rechName)&&
                                    p.Cars.Contains(rechAut )
                ).ToList());
                datagrid.ItemsSource = pieces;


            }
        }

        private void Datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new Sale((datagrid.SelectedItem as Piece)).Show();
        }
    }
}
