using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
namespace AppDoHotel
{
    [Activity(Label = "Controle de Pragas 1.0", MainLauncher = true)]
    public class MainActivity : Activity
    {
        // Instancia os ImageView
        ImageView ImgLogo, ImgUsername, ImgPassword, ImgAcesso;

        // Instancia os EditText
        EditText EdtUsername, EdtPassword;

        // Instancia os Buttons
        Button BtnLogin;

        // Instancia dos TextViews
        TextView TxtAcesso, TxtUsuario;

        //Inicia o evento para criar aplicativos
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);

            //Defina nosso layout principal como exibição padrão
            SetContentView(Resource.Layout.Main);




            ExibeTelaLogin();

        
        }

        #region Telas

        private void ExibeTelaLogin()
        {
            
            // Chama a tela Login
            SetContentView(Resource.Layout.Main);

            // Instancia os elementos da tela
            #region Instancias

            // ImageView
            ImgLogo = FindViewById<Android.Widget.ImageView>(Resource.Id.ImgLogo);
            ImgUsername = FindViewById<Android.Widget.ImageView>(Resource.Id.ImgUsername);
            ImgPassword = FindViewById<Android.Widget.ImageView>(Resource.Id.ImgPassword);
            ImgAcesso = FindViewById<Android.Widget.ImageView>(Resource.Id.ImgAcesso);

            // EditText
            EdtUsername = FindViewById<Android.Widget.EditText>(Resource.Id.EdtUsername);
            EdtPassword = FindViewById<Android.Widget.EditText>(Resource.Id.EdtPassword);

            // TextView
            TxtAcesso = FindViewById<Android.Widget.TextView>(Resource.Id.TxtAcesso);
            TxtUsuario = FindViewById<Android.Widget.TextView>(Resource.Id.TxtUsuario);

            // Limpa os campos Usuario e senha e solicita o foco no campo usuario.
            Limpar();


            // Button
            BtnLogin = FindViewById<Android.Widget.Button>(Resource.Id.BtnLogin);

            // Relacionando as variaveis ImageView com os arquivos de imagem.png
            ImgLogo.SetImageResource(Resource.Drawable.logo);
            ImgUsername.SetImageResource(Resource.Drawable.usuarios);
            ImgPassword.SetImageResource(Resource.Drawable.senha);
            ImgAcesso.SetImageResource(Resource.Drawable.negado);

            #endregion

            // Habilita os eventos dos botões
            #region Event

            BtnLogin.Click += BtnLogin_Click;

            #endregion
        }

        #endregion

        #region Events Functions

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            ValidaLogin();
        }

        #endregion

        // Serve para se conectar com o banco.
        
        private void Limpar()
        {

            EdtUsername.Text = "";
            EdtPassword.Text = "";
            EdtUsername.RequestFocus();

        }

        // Função para validar o login.
        private void ValidaLogin()
        {

            // Verifica se o campo EdtUsername está vazio.
            if (EdtUsername.Text.ToString().Trim() == "")
            {
                // Caso o campo EdtUsername esteja vazio, uma mensagem é enviada ao usuário para que o preencha.
                Toast.MakeText(Application.Context, "Preencha o Usuário", ToastLength.Short).Show();
                // O RequestFocues() serve para solicitar o foco no campo que está o invocando.
                EdtUsername.RequestFocus();
                return;

            }
            // Verifica se o campo EdtPassword está vazio.
            if (EdtPassword.Text.ToString().Trim() == "")
            {
                // Caso o campo EdtPassword esteja vazio, uma mensagem é enviada ao usuário para que o preencha.
                Toast.MakeText(Application.Context, "Preencha o Senha", ToastLength.Short).Show();
                // O RequestFocues() serve para solicitar o foco no campo que está o invocando.
                EdtPassword.RequestFocus();
                return;

            }

            try
            {

                var sq = new SQLiteDB();
                var user = sq.GetUser(EdtUsername.Text, EdtPassword.Text);
                if (user != null)
                {
                    ImgAcesso.SetImageResource(Resource.Drawable.certo);
                    TxtUsuario.Text = user.Username;
                    TxtAcesso.Text = user.Nivel;
                    Toast.MakeText(Application.Context, "Logado com Sucesso", ToastLength.Long);
                    EdtUsername.Text = "";
                    EdtPassword.Text = "";
                    
                    return;


                }
                else
                {
                    Toast.MakeText((Context)Resource.Layout.secundario, "Usuario não cadastrado", ToastLength.Long);
                    Limpar();

                    ImgAcesso.SetImageResource(Resource.Drawable.negado);
                    
                    return;

                }


            }
            catch (Exception ex)
            {

                Toast.MakeText(Application.Context, "erro: "+ ex.Message, ToastLength.Long);
                return;
            }
        }
        //Lançada quando um item de ListView é clicada
        //void item_Clicked(object sender, AdapterView.ItemClickEventArgs e)
        //{
        //    //Obtém instância do objeto TextView de Layout record_view
        //    TextView shId = e.View.FindViewById<TextView>(Resource.Id.Id_linha);
        //    TextView shPraga = e.View.FindViewById<TextView>(Resource.Id.Praga_linha);
        //    TextView shDescricao = e.View.FindViewById<TextView>(
        //    Resource.Id.Descricao_linha);
        //    TextView shProdutor = e.View.FindViewById<TextView>(
        //    Resource.Id.Proprietario_linha);
        //    TextView shPropriedade = e.View.FindViewById<TextView>(
        //    Resource.Id.Propriedade_linha);
        //    TextView shTalhao = e.View.FindViewById<TextView>(Resource.Id.Talhao_linha);

        //    //Lê os valores e conjuntos de instâncias de objetos EditText
        //    txtPraga.Text = shPraga.Text;
        //    txtDescricao.Text = shDescricao.Text;
        //    txtProdutor.Text = shProdutor.Text;
        //    txtPropriedade.Text = shPropriedade.Text;
        //    txtTalhao.Text = shTalhao.Text;

        //    //Exibe mensagens para operações CRUD
        //    shMsg.Text = shId.Text;
        //}
        //Obtém a exibição cursor para mostrar todos os registros
        //void GetCursorView()
        //{
        //    Android.Database.ICursor sqldb_cursor = sqldb.GetRecordCursor();
        //    if (sqldb_cursor != null)
        //    {
        //        sqldb_cursor.MoveToFirst();
        //        string[] from = new string[]
        //        {"_id","Praga","Descricao","Produtor","Propriedade","Talhao" };
        //        int[] to = new int[] {
        //            Resource.Id.Id_linha,
        //            Resource.Id.Praga_linha,
        //            Resource.Id.Descricao_linha,
        //            Resource.Id.Proprietario_linha,
        //            Resource.Id.Propriedade_linha,
        //            Resource.Id.Talhao_linha
        //        };

        //        //Cria um SimpleCursorAdapter para ListView objeto
        //        SimpleCursorAdapter sqldb_adapter = new SimpleCursorAdapter(this, Resource.Layout.secundario, sqldb_cursor, from, to);
        //        listItems.Adapter = sqldb_adapter;
        //    }
        //    else
        //    {
        //        shMsg.Text = sqldb.Mensagem;
        //    }
        //}

        ////Obtém a exibição cursor para mostrar registros de acordo com critérios de pesquisa
        //void GetCursorView(string sqldb_column, string sqldb_value)
        //{
        //    Android.Database.ICursor sqldb_cursor = sqldb.GetRecordCursor
        //    (sqldb_column, sqldb_value);

        //    if (sqldb_cursor != null)
        //    {
        //        sqldb_cursor.MoveToFirst();
        //        string[] from = new string[]
        //        {"_id","Praga","Descricao","Produtor","Propriedade","Talhao" };
        //        int[] to = new int[]
        //        {
        //            Resource.Id.Id_linha,
        //            Resource.Id.Praga_linha,
        //            Resource.Id.Descricao_linha,
        //            Resource.Id.Proprietario_linha,
        //            Resource.Id.Propriedade_linha,
        //            Resource.Id.Talhao_linha
        //        };
        //        SimpleCursorAdapter sqldb_adapter = new SimpleCursorAdapter(this, Resource.Layout.secundario, sqldb_cursor, from, to);
        //        listItems.Adapter = sqldb_adapter;
        //    }
        //    else
        //    {
        //        shMsg.Text = sqldb.Mensagem;
        //    }
        //}

        //protected override void OnStart()
        //{
        //    base.OnStart();
        //    Log.Debug(tag, "OnStart Chamado");
        //}

        //// OnResume é chamado toda vez que a atividade começa, então vamos colocar nossas RequestLocationUpdates
        //// Código aqui, de modo que
        //protected override void OnResume()
        //{
        //    base.OnResume();
        //    Log.Debug(tag, "OnResume Chamado");

        //    // inicializar locação
        //    locMgr = GetSystemService(Context.LocationService) as LocationManager;


        //}
        //protected override void OnPause()
        //{
        //    base.OnPause();

        //    // Parar de enviar atualizações de localização quando o aplicativo vai para o fundo
        //    // Para aprender sobre a atualização do local em segundo plano, consulte o guia de backgrounding
        //    Http:docs.xamarin.com/guides/cross-platform/application_fundamentals / backgrounding /

        //    // RemoveUpdates leva uma intenção pendente - aqui, nós passamos a atividade atual
        //    locMgr.RemoveUpdates(this);
        //    Log.Debug(tag, "A localização parou porque a aplicação está entrando no fundo");
        //}

        //protected override void OnStop()
        //{
        //    base.OnStop();
        //    Log.Debug(tag, "OnStop Chamado");
        //}

        //public void OnLocationChanged(Android.Locations.Location location)
        //{
        //    Log.Debug(tag, "Localização mudou");
        //    latitude.Text = "Latitude: " + location.Latitude.ToString();
        //    longitude.Text = "Longitude: " + location.Longitude.ToString();
        //    provedor.Text = "Provedor: " + location.Provider.ToString();
        //}
        //public void OnProviderDisabled(string provider)
        //{
        //    Log.Debug(tag, provider + " desabilitado pelo usuário");
        //}
        //public void OnProviderEnabled(string provider)
        //{
        //    Log.Debug(tag, provider + " habilitado pelo usuário");
        //}
        //public void OnStatusChanged(string provider, Availability status, Bundle extras)
        //{
        //    Log.Debug(tag, provider + " disponibilidade mudou para " + status.ToString());
        //}
    }
}