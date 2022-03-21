using Encheres.Modeles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Encheres.VuesModeles
{
    class PageEnchereVueModele : BaseVueModele
    {
        #region Attributs
        private Enchere _monEnchere;
        #endregion

        #region Constructeur
        public PageEnchereVueModele(Enchere param)
        {

            _monEnchere = param;
        }
        #endregion

        #region Getters/Setters
        public Enchere MonEnchere
        {
            get
            { return _monEnchere; }
            set
            {
                SetProperty(ref _monEnchere, value);

            }
        }
        #endregion

        #region Méthodes
        #endregion
    }
}
