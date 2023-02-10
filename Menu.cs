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
        Variaveis var = new Variaveis();
        double totalEntradas, totalSaidas, total;

        ImageView ImgUsuario, ImgMov;

        TextView TxtUsuarioMenu, TxtCargoMenu, TxtEntrada, TxtSaida, TxtTotal;

        ImageButton ImgGastos, ImgMoviment, ImgCheckIn, ImgReservas;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.menu);
            ImgUsuario = FindViewById<Android.Widget.ImageView>(Resource.Id.ImgUsuario);
            ImgMov     = FindViewById<Android.Widget.ImageView>(Resource.Id.ImgMov);

            ImgGastos   = FindViewById<Android.Widget.ImageButton>(Resource.Id.ImgGastos);
            ImgMoviment = FindViewById<Android.Widget.ImageButton>(Resource.Id.ImgMoviment);
            ImgCheckIn  = FindViewById<Android.Widget.ImageButton>(Resource.Id.ImgCheckIn);
            ImgReservas = FindViewById<Android.Widget.ImageButton>(Resource.Id.ImgReservas);

            TxtUsuarioMenu = FindViewById<Android.Widget.TextView>(Resource.Id.TxtUsuarioMenu);
            TxtCargoMenu   = FindViewById<Android.Widget.TextView>(Resource.Id.TxtCargoMenu);
            TxtEntrada     = FindViewById<Android.Widget.TextView>(Resource.Id.TxtEntrada);
            TxtSaida       = FindViewById<Android.Widget.TextView>(Resource.Id.TxtSaida);
            TxtTotal       = FindViewById<Android.Widget.TextView>(Resource.Id.TxtTotal);
            totalEntradas  = 0.0;
            totalSaidas    = 0.0;
            total          = 0.0;

            //recuper os parametros
            var.nomeUsuario = Intent.GetStringExtra("Nome");
            var.cargoUsuario = Intent.GetStringExtra("Cargo");

            ImgMov.SetImageResource(Resource.Drawable.Movimentacao);
            ImgUsuario.SetImageResource(Resource.Drawable.usuarios);

            ImgGastos.SetImageResource(Resource.Drawable.img_gastos);
            ImgMoviment.SetImageResource(Resource.Drawable.img_moviment);
            ImgCheckIn.SetImageResource(Resource.Drawable.img_checkin);
            ImgReservas.SetImageResource(Resource.Drawable.img_reservas);
            ImgGastos.Click += ImgGastos_Click;
            ImgMoviment.Click += ImgMoviment_Click;

            TxtUsuarioMenu.Text = "Usuario: " + var.nomeUsuario;
            TxtCargoMenu.Text = "Cargo: " + var.cargoUsuario;


            TotalizarEntradas();
            TotalizarSaidas();
            Totalizar();
        }

        private void ImgGastos_Click(object sender, EventArgs e)
        {
           
            var telaGasto = new Intent(this, typeof(GastosActivity));
            telaGasto.PutExtra("Nome", var.nomeUsuario);
            StartActivity(telaGasto);
        }

        private void ImgMoviment_Click(object sender, EventArgs e)
        {
            var telaMov = new Intent(this, typeof(Movimentacoes));
            telaMov.PutExtra("Nome", var.nomeUsuario);
            StartActivity(telaMov);
        }

        private void TotalizarEntradas()
        {
            try
            {
                SQLiteDB db = new SQLiteDB();
                List<SQLiteDB.Movimentacoes> movimentacoes = db.GetAllMovimentacoes();
                foreach (var mov in movimentacoes)
                {
                    if (mov.Tipo == "Entrada")
                    {
                        totalEntradas += mov.Valor;
                        
                    }
                }
                TxtEntrada.Text = "Entradas " + totalEntradas.ToString("C2");
                TxtEntrada.SetTextColor(Android.Graphics.Color.DarkGreen);
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void TotalizarSaidas()
        {
            try
            {
                SQLiteDB db = new SQLiteDB();
                List<SQLiteDB.Movimentacoes> movimentacoes = db.GetAllMovimentacoes();
                foreach (var mov in movimentacoes)
                {
                    if (mov.Tipo == "Saída")
                    {
                        totalSaidas += mov.Valor;

                    }
                }
                TxtSaida.Text = "Saidas " + totalSaidas.ToString("C2");
                TxtSaida.SetTextColor(Android.Graphics.Color.Red);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Totalizar()
        {
            try
            {
                total = totalEntradas - totalSaidas;
                
                TxtTotal.Text = "Total " + total.ToString("C2");

                if (total >= 0) 
                {
                    TxtTotal.SetTextColor(Android.Graphics.Color.DarkGreen);
                }
                else
                {
                    TxtTotal.SetTextColor(Android.Graphics.Color.Red);
                }
               
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}