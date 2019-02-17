using Gestion_garage_access.Models;
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
using System.Windows.Shapes;

namespace Gestion_garage_access.Views
{
    /// <summary>
    /// Logique d'interaction pour Modify.xaml
    /// </summary>
    public partial class Modify : Window
    {
        Piece piece;
        public Modify(Piece piece)
        {
            this.piece = piece;
            DataContext = piece;
            InitializeComponent();
            unites.Items.Add("Nombre");
            unites.Items.Add("Kg");
            unites.Items.Add("metres");
            this._ref.IsReadOnly = true;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Database db = new Database();
            try
            {
                Piece p = db.Pieces.Find(piece.Ref_piece);


                    p.Nom_piece = nom.Text;
                p.Prix_achat = Convert.ToDouble(prix_achat.Text);
                p.Prix_vente = Convert.ToDouble(prix_vente.Text);
                p.Cars = models.Text;
                p.Quantite = Convert.ToDouble(quantite.Text);
                p.Unite = unites.SelectedValue.ToString();
                
                int id = db.SaveChanges();
                if (id == 1)
                {
                    MessageBox.Show("تم الاضافة بنجاح");
                    this.Close();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("يوجد مشكل الرجاء التاكد من المعلومات التي تم ادخالها ");

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
