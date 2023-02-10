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
    [Activity(Label = "Gastos")]
    public class GastosActivity : Activity
    {
        SQLiteDB db = new SQLiteDB();
        Variaveis var = new Variaveis();
        EditText EdtGasto, EdtValor;
        Button BtnSalvar;
        ListView ListaGastos;
        string AuxData = DateTime.Now.ToString("dd/MM/yyyy");
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.Gastos);
            var.nomeUsuario = Intent.GetStringExtra("Nome");
            EdtGasto = FindViewById<Android.Widget.EditText>(Resource.Id.EdtGasto);
            EdtValor = FindViewById<Android.Widget.EditText>(Resource.Id.EdtValor);
            BtnSalvar = FindViewById<Android.Widget.Button>(Resource.Id.BtnSalvar);
            ListaGastos = FindViewById<Android.Widget.ListView>(Resource.Id.ListaGastos);
            BtnSalvar.Click += BtnSalvar_Click;
            ListaGastos.ItemClick += ListaGastos_ItemClick;
            Listar();
        }

        private void ListaGastos_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            GastosAdapter adapter = ListaGastos.Adapter as GastosAdapter;
            GastosList Gasto = adapter[e.Position][e.Position];
            SQLiteDB.Gastos ObjGasto = new SQLiteDB.Gastos();
            ObjGasto.GastosId = Gasto.GastoId;
            ObjGasto.Data = Gasto.Data;
            ObjGasto.Descricao = EdtGasto.Text;
            ObjGasto.Funcionario = var.nomeUsuario;
            ObjGasto.Valor = Gasto.Valor;
            //ExcluirGasto(ObjGasto);
            Listar();

        }

        private void ExcluirGasto(SQLiteDB.Gastos gasto)
        {
            SQLiteDB.Gastos ObjGasto = gasto;
            db.DeleteGasto(gasto);
            ExcluirMoviment(gasto.GastosId);
        }

        private void ExcluirMoviment(int id_movimento)
        {
            var tbMoviment = db.GetAllMovimentacoes();

            if (tbMoviment != null)
            {
                foreach (var mov in tbMoviment)
                {
                    if (mov.Id_movimento == id_movimento)
                    {
                        db.DeleteMovimentacao(mov);
                    }
                }
            }

        }
        private void SalvarGasto()
        {

            try
            {
                // Insert na tabela Gastos
                SQLiteDB.Gastos ObjGasto = new SQLiteDB.Gastos();
                ObjGasto.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ObjGasto.Descricao = EdtGasto.Text;
                ObjGasto.Funcionario = var.nomeUsuario;
                ObjGasto.Valor = double.Parse(EdtValor.Text);
                db.InsertGasto(ObjGasto);


            }
            catch (Exception ex)
            {

                Toast.MakeText(Application.Context, "Erro: " + ex.Message, ToastLength.Long).Show();
            }
        }

        private void SalvarMoviment(int id)
        {
            try
            {
                // Insert na tabela Movimentações
                SQLiteDB.Movimentacoes ObjMoviment = new SQLiteDB.Movimentacoes();
                ObjMoviment.Tipo = "Saída";
                ObjMoviment.Movimento = "Gasto";
                ObjMoviment.Valor = double.Parse(EdtValor.Text);
                ObjMoviment.Funcionario = var.nomeUsuario;
                ObjMoviment.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ObjMoviment.Id_movimento = id;
                db.InsertMovimentacoes(ObjMoviment);
            }
            catch (Exception ex)
            {
                Toast.MakeText(Application.Context, "Erro: " + ex.Message, ToastLength.Long).Show();
            }
        }

        private void Listar(bool save = false)
        {
            try
            {
                ListaGastos.Adapter = new ListaAdapter(this, new List<String>());
                SQLiteDB db = new SQLiteDB();
                var tbGastos = db.GetAllGastos();
                List<GastosList> Gastos = new List<GastosList>();
                if (tbGastos != null)
                {
                    foreach (var gastoitem in tbGastos)
                    {
                        
                        GastosList GastoObj = new GastosList();
                        GastoObj.GastoId = gastoitem.GastosId;
                        GastoObj.Data = gastoitem.Data;
                        GastoObj.Gastos = gastoitem.Descricao;
                        GastoObj.Funcionario = gastoitem.Funcionario;
                        GastoObj.Valor = gastoitem.Valor;
                        Gastos.Add(GastoObj);
                    }
                    if (save == true)
                    {
                        int UltimoId = tbGastos.Last().GastosId;
                        SalvarMoviment(UltimoId);
                    }
                    GastosAdapter adapter = new GastosAdapter(this, Gastos);
                    ListaGastos.Adapter = adapter;
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(Application.Context, "Erro: " + ex.Message, ToastLength.Long).Show();
            }
        }
        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                bool ponto = (String.IsNullOrWhiteSpace(EdtValor.Text) ? false : (EdtValor.Text[0].ToString() == "." ? true : false));
                bool virgula = (String.IsNullOrWhiteSpace(EdtValor.Text) ? false : (EdtValor.Text[0].ToString() == "," ? true : false));
                bool sinalMenos = (String.IsNullOrWhiteSpace(EdtValor.Text) ? false : (EdtValor.Text[0].ToString() == "-" ? true : false));
                bool sinalMais = (String.IsNullOrWhiteSpace(EdtValor.Text) ? false : (EdtValor.Text[0].ToString() == "+" ? true : false));
                bool sinalmulti = (String.IsNullOrWhiteSpace(EdtValor.Text) ? false : (EdtValor.Text[0].ToString() == "*" ? true : false));
                bool pontoVirgula = (String.IsNullOrWhiteSpace(EdtValor.Text) ? false : (EdtValor.Text[0].ToString() == ";" ? true : false));
                bool barra = (String.IsNullOrWhiteSpace(EdtValor.Text) ? false : (EdtValor.Text[0].ToString() == "/" ? true : false));
                bool parenteseFechado = (String.IsNullOrWhiteSpace(EdtValor.Text) ? false : (EdtValor.Text[0].ToString() == "(" ? true : false));
                bool parenteseAberto = (String.IsNullOrWhiteSpace(EdtValor.Text) ? false : (EdtValor.Text[0].ToString() == ")" ? true : false));

                // Verifica se o campo EdtUsername está vazio.
                if (String.IsNullOrWhiteSpace(EdtGasto.Text))
                {
                    EdtGasto.Text = "";
                    // Caso o campo EdtUsername esteja vazio, uma mensagem é enviada ao usuário para que o preencha.
                    Toast.MakeText(Application.Context, "Preencha o Gasto", ToastLength.Short).Show();
                    //Toast.MakeText(Application.Context, System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), ToastLength.Short).Show();
                    // O RequestFocues() serve para solicitar o foco no campo que está o invocando.
                    EdtGasto.RequestFocus();
                    return;

                } // Verifica se o campo EdtPassword está vazio.
                else if (String.IsNullOrWhiteSpace(EdtValor.Text))
                {
                    EdtValor.Text = "";
                    // Caso o campo EdtPassword esteja vazio, uma mensagem é enviada ao usuário para que o preencha.
                    Toast.MakeText(Application.Context, "Preencha o Valor", ToastLength.Short).Show();
                    // O RequestFocues() serve para solicitar o foco no campo que está o invocando.
                    EdtValor.RequestFocus();
                    return;

                }
                else if (ponto || virgula || sinalMenos || sinalMais || sinalmulti || pontoVirgula || barra || parenteseFechado || parenteseAberto)
                {
                    EdtValor.Text = "";
                    // Caso o campo EdtPassword esteja vazio, uma mensagem é enviada ao usuário para que o preencha.
                    Toast.MakeText(Application.Context, "Preencha com um valor válido!", ToastLength.Short).Show();
                    // O RequestFocues() serve para solicitar o foco no campo que está o invocando.
                    EdtValor.RequestFocus();
                    return;
                }
                else
                {
                    SalvarGasto();
                    Listar(true);
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(Application.Context, "Erro: " + ex.Message, ToastLength.Long).Show();
            }
        }
    }
}

