﻿using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFFurniture.ViewModels;

namespace WorkingWithMaps.Vistas.Reservas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagosVista : ContentPage
    {
        MainPageViewModel Contexto => ((MainPageViewModel)BindingContext);
        public PagosVista()
        {
            InitializeComponent();
            Webview.IsVisible = true;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await progress.ProgressTo(0.9, 900, Easing.SpringIn);
            await TasAsync();
        }

        protected void OnNavigating(object sender, WebNavigatingEventArgs e)
        {
            progress.IsVisible = true;
        }

        protected async void OnNavigated(object sender, WebNavigatedEventArgs e)
        {
            progress.IsVisible = false;
            try
            {
                Contexto.IsBusy = true;
                var urlweb = e.Url;
                var url = urlweb.Split('?');
                var ref_payco = url[1].Split('=');
                if (ref_payco[0] == "ref_payco")
                {
                    await DisplayAlert("", ref_payco[1], "OK");
                    await Epayco(ref_payco[1]);
                }
            }
            catch (Exception)
            {
            }
            Contexto.IsBusy = false;
        }

        async Task Epayco(string refe)
        {
            //var epayco = await ReservasEpayCo.CmabiarEstadoAsync(refe, Contexto);
            //if (!string.IsNullOrEmpty(epayco))
            //{
            //    await DisplayAlert("Pagos", epayco, "OK");
            //}
        }

        async Task TasAsync()
        {
            Webview.IsVisible = false;
            await Task.Delay(2000);
            Webview.IsVisible = true;
            //var url1 = $"http://192.168.1.10:8080/prueba/prueba.php?hora={Contexto.HoraInicio}&horario={Contexto.Idhorario}&tel={Contexto.Tel}&precio={Contexto.HoraFinal}&descripcion={Contexto.Reserva1.Replace(" ", "%20")}";
            //var url = $"http://bismarckaragon.com/jose/prueba.php?hora={Contexto.HoraInicio}&horario={Contexto.Idhorario}&tel={Contexto.Tel}&precio={Contexto.HoraFinal}&descripcion={Contexto.Reserva1.Replace(" ", "%20")}";
            Webview.Source = "http://192.168.1.10:8080/prueba/prueba.php?precio=10000&descripcion=Descripcion";
        }
    }
}