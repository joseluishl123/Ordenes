﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFFurniture.Service
{
    public static class UsuarioServicio
    {
        public static SwipeMenu.Models.ClienteModelo Cliente { get; set; }
        public static async Task<bool> EstadologinAsync()
        {
            var rep = false;
            try
            {
                var usu = await App.SQLiteDb.GetItemsAsync();
                if (usu != null && usu.Count > 0)
                {
                    Cliente = usu[0];
                    rep = true;
                }
            }
            catch (Exception ex)
            {
              await Application.Current.MainPage.DisplayAlert("Usu Servicio", ex.ToString(), "OK");
            }
            return rep;
        }
    }
}
