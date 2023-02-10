using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AppDoHotel
{
    public class GastosAdapter : BaseAdapter<List<GastosList>>
    {

        //private readonly Context context;
        private readonly List<GastosList> Lista;
        private readonly Activity Context;
        
        
        public GastosAdapter(Activity Context, List<GastosList> Lista)
        {
            this.Context = Context;
            this.Lista = Lista;
        }

        public override List<GastosList> this[int position]
        {
            get { return Lista; }
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }
        public override int Count
        {
            get { return Lista.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            var item = Lista[position];

            if (view == null)
                view = Context.LayoutInflater.Inflate(Resource.Layout.Item_ListView_Gastos, null);

            view.FindViewById<TextView>(Resource.Id.texto1).Text = item.Gastos;
            view.FindViewById<TextView>(Resource.Id.texto2).Text = item.Valor.ToString("F2", CultureInfo.InvariantCulture);

            return view;
        }
    }
}