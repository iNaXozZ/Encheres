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
    public partial class RegistreEnchereVue : ContentPage
    {
        RegistreEncherirVueModele VuesModele;
        Enchere _monEnchere;
        public RegistreEnchereVue(Enchere param)
        {
            InitializeComponent();
            BindingContext = VuesModele = new RegistreEncherirVueModele(param);
            _monEnchere = param;

        }

        private void OnClickRetourPageEnchere(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageEnchereVue(_monEnchere));
        }

        protected override void OnDisappearing()
        {
            VuesModele.OnCancel = true;
            base.OnDisappearing();
        }
    }
}