using Encheres.Modeles;
using Encheres.VuesModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encheres.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeEnchereEnCoursVue : ContentPage
    {
        public ListeEnchereEnCoursVue()
        {
            InitializeComponent();
            BindingContext = new ListeEnchereEnCoursVueModele();
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var current = (Enchere)e.CurrentSelection.FirstOrDefault();
            Navigation.PushAsync(new PageEnchereVue(current));
        }

        private  void OnClickVoirTousLesEncheresEnCours(object sender, EventArgs e)
        {
            SecureStorage.Remove("ID");
            SecureStorage.Remove("PSEUDO");
            Navigation.PushAsync(new LoginPageVue());
        }
    }
}