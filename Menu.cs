using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppDoHotel
{
    [Activity(Label = "Menu")]
    public class Menu : Activity
    {
        ImageView ImgUsuario, ImgMov;

        TextView TxtUsuarioMenu, TxtCargoMenu, TxtEntrada, TxtSaida, TxtTotal;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.menu);
            ImgUsuario = FindViewById<Android.Widget.ImageView>(Resource.Id.ImgUsuario);
            ImgMov = FindViewById<Android.Widget.ImageView>(Resource.Id.ImgMov);

            TxtUsuarioMenu = FindViewById<Android.Widget.TextView>(Resource.Id.TxtUsuarioMenu);
            TxtCargoMenu = FindViewById<Android.Widget.TextView>(Resource.Id.TxtCargoMenu);
            TxtEntrada = FindViewById<Android.Widget.TextView>(Resource.Id.TxtEntrada);
            TxtSaida = FindViewById<Android.Widget.TextView>(Resource.Id.TxtSaida);
            TxtTotal = FindViewById<Android.Widget.TextView>(Resource.Id.TxtTotal);


            //recuper os parametros
            string NomeUsuario = Intent.GetStringExtra("Nome");
            string CargoUsuario = Intent.GetStringExtra("Cargo");

            ImgMov.SetImageResource(Resource.Drawable.Movimentacao);
            ImgUsuario.SetImageResource(Resource.Drawable.usuario);
            TxtUsuarioMenu.Text = "Usuario: " + NomeUsuario;
            TxtCargoMenu.Text = "Cargo: " + CargoUsuario;


            TotalizarEntradas();
            TotalizarSaidas();
            Totalizar();
        }

        private void TotalizarEntradas()
        {
            try
            {
                SQLiteDB db = new SQLiteDB();
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void TotalizarSaidas()
        {
            throw new NotImplementedException();
        }
        private void Totalizar()
        {
            throw new NotImplementedException();
        }
    }
}