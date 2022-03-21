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
    public partial class ListeTousLesEncheresEnCours : ContentPage
    {
        public ListeTousLesEncheresEnCours()
        {
            InitializeComponent();
            BindingContext = new ListeEnchereEnCoursVueModele();
        }
        private void ListeEnchere_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var current = (Enchere)e.CurrentSelection.FirstOrDefault();
            Navigation.PushAsync(new PageEnchereVue(current));
        }

        private void OnClickRetour2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListeEnchereEnCoursVue());
        }
    }
    
}