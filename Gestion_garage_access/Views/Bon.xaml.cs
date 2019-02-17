using Gestion_garage_access.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gestion_garage_access.Views
{
    /// <summary>
    /// Logique d'interaction pour Bon.xaml
    /// </summary>
    public partial class Bone : UserControl
    {
       public ViewMod viewMod { get; set; }
        Database Database = new Database();
        public Bone()
        {
            viewMod= new ViewMod();
            InitializeComponent();
            foreach (var item in Database.Entreprises)
            {
                emEntreprise.Items.Add(item.Name);

            }
            foreach (var item in Database.Employers)
            {
                boEmployer.Items.Add(item.Name);
            }
            DataContext = viewMod;
            dgBons.ItemsSource = Database.Bons.ToList();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(viewMod.Entreprise.Name.Equals("") || viewMod.Entreprise.Tel.Equals(""))
            {
                MessageBox.Show("معطيات خاطئة !!");
            }
            else
            {
                try
                {
                    Database.Entreprises.Add(viewMod.Entreprise);
                    Database.SaveChanges();

                    MessageBox.Show("تم بنجاح");
                    emEntreprise.Items.Add(viewMod.Entreprise.Name);
                    enName.Text = "";
                    enTel.Text= "";
                }
                catch (DbEntityValidationException el)
                {
                    Trace.WriteLine("*****************************************************************");
                    foreach (var eve in el.EntityValidationErrors)
                    {
                        MessageBox.Show("Entity of type :" + eve.Entry.Entity.GetType().Name + " in state " + eve.Entry.State + " has the following validation errors:");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            MessageBox.Show("- Property: " + ve.PropertyName + ", Error: " + ve.ErrorMessage);
                        }
                    }
                    throw;
                }

            }
                
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            enName.Text = "";
            enTel.Text = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (viewMod.Employer.Name.Equals("") || viewMod.Employer.Tel.Equals("") )
            {
                MessageBox.Show("معطيات خاطئة !!");
            }
            else
            {
                try

                {
                    Entreprise et = Database.Entreprises.Where(em=>em.Name== emEntreprise.SelectedItem.ToString()).SingleOrDefault();
                    Employer employer = new Employer()
                    {
                        Name=emName.Text,
                        Tel=emTel.Text,
                        Id_Entreprise=et.Id_Entreprise,
                        Entreprise=et

                    };
                    Database.Employers.Add(employer);
                    Database.SaveChanges();
                    boEmployer.Items.Add(viewMod.Employer.Name);
                    MessageBox.Show("تم بنجاح");
                    emName.Text = "";
                    emTel.Text = "";
                }
                catch (DbEntityValidationException el)
                {
                    Trace.WriteLine("*****************************************************************");
                    foreach (var eve in el.EntityValidationErrors)
                    {
                        MessageBox.Show("Entity of type :"+ eve.Entry.Entity.GetType().Name + " in state "+ eve.Entry.State + " has the following validation errors:");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            MessageBox.Show("- Property: "+ ve.PropertyName+", Error: "+ ve.ErrorMessage  );
                        }
                    }
                }

            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            emName.Text = "";
            emTel.Text = "";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (viewMod.Bon.TotalePrix==0 )
            {
                MessageBox.Show("معطيات خاطئة !!");
            }
            else
            {
                try
                {
                    viewMod.Bon.Id_Enmployer = Database.Employers.Where(em=> em.Name==boEmployer.SelectedItem.ToString()).SingleOrDefault().Id_Enmployer;
                    viewMod.Bon.Date = DateTime.Now;
                    if (viewMod.Bon.RestPrix > 0)
                        viewMod.Bon.Status = false;
                    else viewMod.Bon.Status = true;
                    Database.Bons.Add(viewMod.Bon);
                    Database.SaveChanges();
                    MessageBox.Show("تم بنجاح");
                    boTotal.Text = "";
                    prixTotal.Text = "";
                }
                catch (DbEntityValidationException el)
                {
                    Trace.WriteLine("*****************************************************************");
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

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Bon bon=(Bon)dgBons.SelectedItem;
            if (bon != null)
                new BonInfos(bon);
            else
                MessageBox.Show("قم بالاختيار رجاء");
        }
    }
    public class ViewMod : INotifyDataErrorInfo
    {
        public Entreprise Entreprise { get; set; }
        public Employer Employer { get; set; }
        public Bon Bon { get; set; }

        public ViewMod()
        {
            Entreprise = new Entreprise();
            Employer = new Employer();
            Bon = new Bon();

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
