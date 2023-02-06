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
        ImageView imgUsuario;

        TextView TxtUsuarioMenu, TxtCargoMenu;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.menu);
            imgUsuario = FindViewById<Android.Widget.ImageView>(Resource.Id.ImgUsuario);
            TxtUsuarioMenu = FindViewById<Android.Widget.TextView>(Resource.Id.TxtUsuarioMenu);
            TxtCargoMenu = FindViewById<Android.Widget.TextView>(Resource.Id.TxtCargoMenu);

            //recuper os parametros
            string NomeUsuario = Intent.GetStringExtra("Nome");
            string CargoUsuario = Intent.GetStringExtra("Cargo");

            imgUsuario.SetImageResource(Resource.Drawable.usuario);
            TxtUsuarioMenu.Text = "Usuario: " + NomeUsuario;
            TxtCargoMenu.Text = "Cargo: " + CargoUsuario;
        }
    }
}