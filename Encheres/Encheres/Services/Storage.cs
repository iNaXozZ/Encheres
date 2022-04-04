using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Encheres.Services
{
    public static class Storage
    {
         public static async void StockerConnexion(string id, string Pseudo)
         {
             try
             {
                 await SecureStorage.SetAsync("ID", id);
                 await SecureStorage.SetAsync("PSEUDO", Pseudo);
             }
             catch (Exception ex)
             {
                 // Possible that device doesn't support secure storage on device.
             }
         }
    }
}
