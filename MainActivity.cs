using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using System.Threading;
namespace AppDoHotel
{
    [Activity(Label = "Controle de Pragas 1.0", MainLauncher = true)]
    public class MainActivity : Activity
    {
        #region Variaveis da tela Login

        // Instancia os ImageView
        ImageView ImgLogo, ImgUsername, ImgPassword;

        // Instancia os EditText
        EditText EdtUsername, EdtPassword;

        // Instancia os Buttons
        Button BtnLogin, BtnCadastrar;

        #endregion

        #region Variaveis da tela de Cadastro

        ImageView ImgNomeCadastro, ImgCargoCadastro, ImgUsuarioCadastro, ImgSenhaCadastro, ImgLogoCadastro;

        EditText EdtNomeCadastro, EdtCargoCadastro, EdtUsuarioCadastro, EdtSenhaCadastro;

        Button BtnRealizarCadastro, BtnCancelarCadastro;

        #endregion

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


            // EditText
            EdtUsername = FindViewById<Android.Widget.EditText>(Resource.Id.EdtUsername);
            EdtPassword = FindViewById<Android.Widget.EditText>(Resource.Id.EdtPassword);



            // Limpa os campos Usuario e senha e solicita o foco no campo usuario.
            Limpar();


            // Button
            BtnLogin = FindViewById<Android.Widget.Button>(Resource.Id.BtnLogin);
            BtnCadastrar = FindViewById<Android.Widget.Button>(Resource.Id.BtnCadastrar);

            // Relacionando as variaveis ImageView com os arquivos de imagem.png
            ImgLogo.SetImageResource(Resource.Drawable.logo);
            ImgUsername.SetImageResource(Resource.Drawable.usuarios);
            ImgPassword.SetImageResource(Resource.Drawable.senha);


            #endregion

            // Habilita os eventos dos botões
            #region Event

            BtnLogin.Click += BtnLogin_Click;
            BtnCadastrar.Click += BtnCadastrar_Click;

            #endregion
        }

        private void ExibeTelaCadastro()
        {

            // Chama a tela Login
            SetContentView(Resource.Layout.Cadastro);

            // Instancia os elementos da tela
            #region Instancias

            // ImageView
            ImgLogoCadastro = FindViewById<Android.Widget.ImageView>(Resource.Id.ImgLogoCadastro);
            ImgNomeCadastro = FindViewById<Android.Widget.ImageView>(Resource.Id.ImgNomeCadastro);
            ImgCargoCadastro = FindViewById<Android.Widget.ImageView>(Resource.Id.ImgCargoCadastro);
            ImgUsuarioCadastro = FindViewById<Android.Widget.ImageView>(Resource.Id.ImgUsuarioCadastro);
            ImgSenhaCadastro = FindViewById<Android.Widget.ImageView>(Resource.Id.ImgSenhaCadastro);

            // EditText
            EdtNomeCadastro = FindViewById<Android.Widget.EditText>(Resource.Id.EdtNomeCadastro);
            EdtCargoCadastro = FindViewById<Android.Widget.EditText>(Resource.Id.EdtCargoCadastro);
            EdtUsuarioCadastro = FindViewById<Android.Widget.EditText>(Resource.Id.EdtUsuarioCadastro);
            EdtSenhaCadastro = FindViewById<Android.Widget.EditText>(Resource.Id.EdtSenhaCadastro);



            // Button
            BtnRealizarCadastro = FindViewById<Android.Widget.Button>(Resource.Id.BtnRealizarCadastro);
            BtnCancelarCadastro = FindViewById<Android.Widget.Button>(Resource.Id.BtnCancelarCadastro);

            // Relacionando as variaveis ImageView com os arquivos de imagem.png
            ImgLogoCadastro.SetImageResource(Resource.Drawable.add_user);
            ImgNomeCadastro.SetImageResource(Resource.Drawable.name);
            ImgCargoCadastro.SetImageResource(Resource.Drawable.sacola);
            ImgUsuarioCadastro.SetImageResource(Resource.Drawable.usuario);
            ImgSenhaCadastro.SetImageResource(Resource.Drawable.padlock);

            #endregion

            // Habilita os eventos dos botões
            #region Event

            BtnRealizarCadastro.Click += BtnRealizarCadastro_Click;
            BtnCancelarCadastro.Click += BtnCancelarCadastro_Click;



            #endregion
        }


        #endregion

        #region Events Functions
        private void BtnCancelarCadastro_Click(object sender, EventArgs e)
        {
            ExibeTelaLogin();
        }

        private void BtnRealizarCadastro_Click(object sender, EventArgs e)
        {
            ValidaCadastro();
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            ExibeTelaCadastro();
        }

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


        // Função para validar cadastro
        private void ValidaCadastro()
        {
            if (String.IsNullOrWhiteSpace(EdtNomeCadastro.Text))
            {
                EdtNomeCadastro.Text = "";
                // Caso o campo EdtUsername esteja vazio, uma mensagem é enviada ao usuário para que o preencha.
                Toast.MakeText(Application.Context, "Preencha o Nome", ToastLength.Short).Show();
                // O RequestFocues() serve para solicitar o foco no campo que está o invocando.
                EdtNomeCadastro.RequestFocus();
                return;
            }

            if (String.IsNullOrWhiteSpace(EdtCargoCadastro.Text))
            {
                EdtCargoCadastro.Text = "";
                // Caso o campo EdtUsername esteja vazio, uma mensagem é enviada ao usuário para que o preencha.
                Toast.MakeText(Application.Context, "Preencha o Cargo", ToastLength.Short).Show();
                // O RequestFocues() serve para solicitar o foco no campo que está o invocando.
                EdtCargoCadastro.RequestFocus();
                return;
            }

            if (String.IsNullOrWhiteSpace(EdtUsuarioCadastro.Text))
            {
                EdtUsuarioCadastro.Text = "";
                // Caso o campo EdtUsername esteja vazio, uma mensagem é enviada ao usuário para que o preencha.
                Toast.MakeText(Application.Context, "Preencha o Usuario", ToastLength.Short).Show();
                // O RequestFocues() serve para solicitar o foco no campo que está o invocando.
                EdtUsuarioCadastro.RequestFocus();
                return;
            }

            if (String.IsNullOrWhiteSpace(EdtSenhaCadastro.Text))
            {
                EdtSenhaCadastro.Text = "";
                // Caso o campo EdtUsername esteja vazio, uma mensagem é enviada ao usuário para que o preencha.
                Toast.MakeText(Application.Context, "Preencha a Senha", ToastLength.Short).Show();
                // O RequestFocues() serve para solicitar o foco no campo que está o invocando.
                EdtSenhaCadastro.RequestFocus();
                return;
            }
            try
            {

                SQLiteDB db = new SQLiteDB();


                SQLiteDB.Usuarios user = db.GetUsuario(EdtNomeCadastro.Text.Trim());
                if (user == null)
                {
                    try
                    {

                        SQLiteDB.Usuarios newuser = new SQLiteDB.Usuarios();
                        newuser.Nome = EdtNomeCadastro.Text.Trim();
                        newuser.Cargo = EdtCargoCadastro.Text.Trim();
                        newuser.Usuario = EdtUsuarioCadastro.Text.Trim();
                        newuser.Senha = EdtSenhaCadastro.Text.Trim();
                        db.InsertUsuario(newuser);
                        Toast.MakeText(Application.Context, "Usuario criado com sucesso!", ToastLength.Long).Show();
                        Thread.Sleep(2000);
                        
                        return;
                    }
                    catch (Exception ex)
                    {

                        Toast.MakeText(Application.Context, "Usuairo não inserido!!! " + ex.Message, ToastLength.Long).Show();
                        Thread.Sleep(2000);
                        return;
                    }
                }
                else
                {
                    Toast.MakeText(Application.Context, "Nome de usuario em uso, escolha outro nome de usuario!", ToastLength.Long).Show();
                    EdtUsuarioCadastro.Text = "";
                    EdtUsuarioCadastro.RequestFocus();
                    Thread.Sleep(2000);
                    return;
                }

            }
            catch (Exception ex)
            {

                Toast.MakeText(Application.Context, "erro: a conexão falhou " + ex.Message,ToastLength.Long).Show();
                Thread.Sleep(2000);
                return;
            }


        }

        // Função para validar o login.
        private void ValidaLogin()
        {

            // Verifica se o campo EdtUsername está vazio.
            if (String.IsNullOrWhiteSpace(EdtUsername.Text))
            {
                EdtUsername.Text = "";
                // Caso o campo EdtUsername esteja vazio, uma mensagem é enviada ao usuário para que o preencha.
                Toast.MakeText(Application.Context, "Preencha o Usuário", ToastLength.Short).Show();
                // O RequestFocues() serve para solicitar o foco no campo que está o invocando.
                EdtUsername.RequestFocus();
                return;

            }
            // Verifica se o campo EdtPassword está vazio.
            if (String.IsNullOrWhiteSpace(EdtPassword.Text))
            {
                EdtPassword.Text = "";
                // Caso o campo EdtPassword esteja vazio, uma mensagem é enviada ao usuário para que o preencha.
                Toast.MakeText(Application.Context, "Preencha o Senha", ToastLength.Short).Show();
                // O RequestFocues() serve para solicitar o foco no campo que está o invocando.
                EdtPassword.RequestFocus();
                return;

            }

            try
            {

                var db = new SQLiteDB();
                var user = db.GetUsuario(EdtUsername.Text, EdtPassword.Text);
                if (user != null)
                {


                    Toast.MakeText(Application.Context, "Logado com Sucesso", ToastLength.Long).Show();
                    //Intent para passar parametros por activity
                    EdtUsername.Text = "";
                    EdtPassword.Text = "";
                    Thread.Sleep(1000);

                    var tela = new Intent(this, typeof(Menu));
                    tela.PutExtra("Nome", user.Nome);
                    tela.PutExtra("Cargo", user.Cargo);
                    StartActivity(tela);




                }
                else
                {
                    Toast.MakeText((Context)Resource.Layout.secundario, "Usuario não cadastrado", ToastLength.Long).Show();
                    Limpar();



                    return;

                }


            }
            catch (Exception ex)
            {

                Toast.MakeText(Application.Context, "erro: " + ex.Message, ToastLength.Long);
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