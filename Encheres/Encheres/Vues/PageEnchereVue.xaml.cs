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
        PageEnchereVueModele VuesModele;
        Enchere _monEnchere;
        public List<Button> ListeButton = new List<Button>();
        public PageEnchereVue(Enchere param)
        {
            InitializeComponent();
            BindingContext = VuesModele = new PageEnchereVueModele(param);
            _monEnchere = param;
            AfficherGrilleFlash();
        }

        private void OnClickEncheresEnCours(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListeEnchereEnCoursVue());
        }

        private void OnClickVoirDernieresEncheres(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistreEnchereVue(_monEnchere));
        }
        
        /// <summary>
        /// Cette méthode permet l'affichage d'une grille de boutons généré dynamiquement afin de pouvoir recouvrir l'image d'une enchère flash
        /// </summary>
        private void AfficherGrilleFlash()
        {
            //string[] textSplit = VuesModele.MonEnchere.TableauFlash.Split(',');
            //int nb = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 5; j++)
                {

                    var button = new Button();
                    button.Text = i.ToString();
                    button.BackgroundColor = Color.CadetBlue;
                    button.TextColor = Color.White;

                    GrilleFlash.Children.Add(button, j, i);
                    /*ListeButton.Add(button);
                    nb++;*/
                }

            } 
        }
       

        protected override void OnDisappearing()
        {
            VuesModele.OnCancel = true;
            base.OnDisappearing();
        }



    }
}