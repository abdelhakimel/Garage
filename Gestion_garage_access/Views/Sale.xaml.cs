using Gestion_garage_access.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
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
    /// Logique d'interaction pour Sale.xaml
    /// </summary>
    public partial class Sale : Window
    {
        Piece piece;
        public Sale(Piece piece)
        {
            InitializeComponent();
            this.piece=piece;
            refPiece.Text = piece.Ref_piece;
            nomPiece.Text = piece.Nom_piece;
            qualPiece.Text = piece.Qualite;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try{ 
            double nbr = Convert.ToDouble(nbrPiece.Text);
            if (nbr <= 0)
                MessageBox.Show("Erreur");
            else
            {
                Database database = new Database();
                Piece p = database.Pieces.Find(piece.Id_piece);
                if (p.Quantite < nbr)
                    MessageBox.Show("Quantite depasser");
                else
                {
                    if (p.Unite.Equals("Nombre"))
                    {
                        nbr = Convert.ToInt32(nbr);
                    }
                    p.Quantite -= nbr;
                    SaleClass sale = new SaleClass() {
                        Date = DateTime.Now,
                        Piece = p,
                        Number = nbr
                    };
                    database.Sales.Add(sale);
                    database.SaveChanges();
                    MessageBox.Show("Done");
                    this.Close();
                }

            } }
             catch (DbEntityValidationException el)
            {
                Debug.WriteLine("*****************************************************************");
                foreach (var eve in el.EntityValidationErrors)
                {
                    MessageBox.Show("Entity of type :" + eve.Entry.Entity.GetType().Name + " in state " + eve.Entry.State + " has the following validation errors:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        MessageBox.Show("- Property: " + ve.PropertyName + ", Error: " + ve.ErrorMessage);
                    }
                }
            }
        }
    }
}
