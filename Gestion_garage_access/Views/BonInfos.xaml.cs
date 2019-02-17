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
    /// Logique d'interaction pour BonInfos.xaml
    /// </summary>
    public partial class BonInfos : Window
    {
        public Bon Bon { get; set; }
        public BonInfos(Bon bon)
        {
            InitializeComponent();
        }
    }
}
