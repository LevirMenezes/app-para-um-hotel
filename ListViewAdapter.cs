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
    public class ListaAdapter : BaseAdapter<List<String>>
    {

        //private readonly Context context;
        private readonly List<String> Lista;
        private readonly Activity Context;

        public ListaAdapter(Activity Context, List<String> Lista)
        {
            this.Context = Context;
            this.Lista = Lista;
        }

        public override List<String> this[int position]
        {
            get { return Lista; }
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }
        public override int Count
        {
            get {return Lista.Count; }
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
                view = Context.LayoutInflater.Inflate(Resource.Layout.Item_ListView_Movimentacoes, null);

            view.FindViewById<TextView>(Resource.Id.texto).Text = item;

            return view;
        }
    }
}