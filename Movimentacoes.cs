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
    [Activity(Label = "Movimentacoes")]
    public class Movimentacoes : Activity
    {
        double totalEntradas, totalSaidas, total;

        ImageView ImgMov;

        TextView TxtEntrada, TxtSaida, TxtTotal;

        CalendarView Data;

        ListView Lista;
        private string AuxData = DateTime.Today.ToString("dd/MM/yyyy");
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Movimentacoes);


            ImgMov = FindViewById<Android.Widget.ImageView>(Resource.Id.ImgMov);

            TxtEntrada = FindViewById<Android.Widget.TextView>(Resource.Id.TxtEntrada);
            TxtSaida = FindViewById<Android.Widget.TextView>(Resource.Id.TxtSaida);
            TxtTotal = FindViewById<Android.Widget.TextView>(Resource.Id.TxtTotal);



            Lista = FindViewById<Android.Widget.ListView>(Resource.Id.Lista);

            Data = FindViewById<Android.Widget.CalendarView>(Resource.Id.Data);

            Data.DateChange += Data_DateChange;
            BuscarData();

        }

        private void Data_DateChange(object sender, CalendarView.DateChangeEventArgs e)
        {
            ListaAdapter adapterSemDados = new ListaAdapter(this, new List<String>());
            Lista.Adapter = adapterSemDados;
            string DiaFormatado = (e.DayOfMonth.ToString().Length == 1 ? "0" + e.DayOfMonth.ToString() : e.DayOfMonth.ToString());
            string MesFormatado = ((e.Month + 1).ToString().Length == 1 ? "0" + (e.Month + 1).ToString() : (e.Month + 1).ToString());
            string Ano = e.Year.ToString();
            AuxData = DiaFormatado + "/" + MesFormatado + "/" + Ano;
            Toast.MakeText(Application.Context, AuxData, ToastLength.Long).Show();
            BuscarData();


        }

        private void BuscarData()
        {
            totalEntradas = 0.0;
            totalSaidas = 0.0;
            total = 0.0;
            try
            {

                SQLiteDB db = new SQLiteDB();
                var moviments = db.GetAllMovimentacoes();
                List<String> ListMov = new List<String>();


                if (moviments != null)
                {
                    foreach (var mov in moviments)
                    {
                        if (mov.Data == AuxData)
                        {
                            ListMov.Add(new String(mov.Tipo.ToString() + "  |  " + mov.Movimento + " : " + mov.Valor.ToString()));

                        }
                    }
                    ListaAdapter adapter = new ListaAdapter(this, ListMov);
                    Lista.Adapter= adapter;


                }




            }
            catch (Exception)
            {

                throw;
            }

            TotalizarEntradas();
            TotalizarSaidas();
            Totalizar();
        }

        private void TotalizarEntradas()
        {
            try
            {
                SQLiteDB db = new SQLiteDB();
                List<SQLiteDB.Movimentacoes> movimentacoes = db.GetAllMovimentacoes();
                foreach (var mov in movimentacoes)
                {
                    if (mov.Tipo == "Entrada" && mov.Data == AuxData)
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
                    if (mov.Tipo == "Saída" && mov.Data == AuxData)
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