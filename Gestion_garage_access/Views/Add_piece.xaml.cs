using Gestion_garage_access.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logique d'interaction pour Add_piece.xaml
    /// </summary>
    public partial class Add_piece : UserControl
    {
        public Add_piece()
        {
            InitializeComponent();
            unites.Items.Add("Nombre");
            unites.Items.Add("Kg");
            unites.Items.Add("metres");
            qualite.Items.Add("1");
            qualite.Items.Add("2");
            qualite.Items.Add("3");
            this.DataContext = new ViewModel();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            
            Database db = new Database();
            try
            {
                db.Pieces.Add(new Piece()
                {
                    Ref_piece = _ref.Text,
                    Nom_piece = nom.Text,
                    Prix_achat = Convert.ToDouble(prix_achat.Text),
                    Prix_vente = Convert.ToDouble(prix_vente.Text),
                    Cars = models.Text,
                    Quantite = Convert.ToDouble(quantite.Text),
                    Unite = unites.SelectedValue.ToString(),
                    Qualite=qualite.SelectedValue.ToString()
                });
                int id = db.SaveChanges();
                if (id == 1)
                {
                    MessageBox.Show("تم الاضافة بنجاح");
                    empty();
                }
                
            }
            catch (Exception)
            {

                MessageBox.Show("يوجد مشكل الرجاء التاكد من المعلومات التي تم ادخالها ");

            }


        }
        public void empty()
        {
            _ref.Text = "";
            nom.Text = "";
            models.Text = "";
            unites.SelectedItem = "";
            prix_achat.Text = "0";
            prix_vente.Text = "0";
            quantite.Text = "0";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            empty();
        }
    }

    internal class ViewModel: INotifyDataErrorInfo
    {
        public Piece Piece { get; set; }


        public ViewModel()
        {
            this.Piece = new Piece();
        }

        Dictionary<string, List<string>> propErrors = new Dictionary<string, List<string>>();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

       
        public bool HasErrors
        {
            get
            {
                try
                {
                    var propErrorsCount = propErrors.Values.FirstOrDefault(r => r.Count > 0);
                    if (propErrorsCount != null)
                        return true;
                    else
                        return false;
                }
                catch { }
                return true;
            }
        }
        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            List<string> errors = new List<string>();
            if (propertyName != null)
            {
                propErrors.TryGetValue(propertyName, out errors);
                return errors;
            }
            else
                return null;
        }
    }
   
    }



