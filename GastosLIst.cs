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
    public class GastosList
    {
        public int GastoId { get; set; }
        public string Gastos { get; set; }

        public double Valor { get; set; }

        public string Data { get; set; }
        public string Funcionario { get; set; }
    }
}