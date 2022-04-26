using Encheres.Modeles;
using Encheres.VuesModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encheres.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEnchereVue : ContentPage
    {
        Enchere _monEnchere;
        public PageEnchereVue(Enchere param)
        {
            InitializeComponent();
            BindingContext = new PageEnchereVueModele(param);
            _monEnchere = param;
        }

        private void OnClickEncheresEnCours(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListeEnchereEnCoursVue());
        }

        private void OnClickVoirDernieresEncheres(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistreEnchereVue(_monEnchere));
        }
        

    }
}