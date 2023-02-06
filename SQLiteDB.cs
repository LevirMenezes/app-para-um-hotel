using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace AppDoHotel
{
    public partial class SQLiteDB
    {
        //database path
        private readonly string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MyDB4.db3");
        public SQLiteDB()
        {
            //Creating database, if it doesn't already exist 
            if (!File.Exists(dbPath))
            {
                var db = new SQLiteConnection(dbPath);

                db.CreateTable<Cargos>();
                db.CreateTable<Detalhes_Vendas>();
                db.CreateTable<Fornecedores>();
                db.CreateTable<Funcionarios>();
                db.CreateTable<Gastos>();
                db.CreateTable<Hospedes>();
                db.CreateTable<Movimentacoes>();
                db.CreateTable<Novo_Servico>();
                db.CreateTable<Ocupacoes>();
                db.CreateTable<Produtos>();
                db.CreateTable<Quartos>();
                db.CreateTable<Reservas>();
                db.CreateTable<Servicos>();
                db.CreateTable<Usuarios>();
                db.CreateTable<Vendas>();
                

                
                //  db.CreateTable<Students>();
            }
        }



        #region Inserts
        //  Inserts

        public void InsertUsuario(Usuarios novoUsuario)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(novoUsuario);
        }

        public void InsertCargo(Cargos novoFornecedor)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(novoFornecedor);
        }

        public void InsertDetalhesVenda(Detalhes_Vendas novoDetalhe)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(novoDetalhe);
        }

        public void InsertFornecedor(Fornecedores novoFornecedor)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(novoFornecedor);
        }


        public void InsertFuncionario(Funcionarios novoFuncionario)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(novoFuncionario);
        }


        public void InsertGasto(Gastos novoGasto)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(novoGasto);
        }


        public void InsertHospede(Hospedes novoHospede)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(novoHospede);
        }


        public void InsertMovimentacoes(Movimentacoes novaMovimentacao)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(novaMovimentacao);
        }

        public void InsertNovoServico(Novo_Servico novoServico)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(novoServico);
        }

        public void InsertOcupacoes(Ocupacoes novaOcupacao)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(novaOcupacao);
        }


        public void InsertProduto(Produtos novoProduto)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(novoProduto);
        }


        public void InsertQuarto(Quartos novoQuarto)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(novoQuarto);
        }


        public void InsertReserva(Reservas novaReserva)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(novaReserva);
        }



        public void InsertServico(Usuarios novoServico)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(novoServico);
        }
        
        
        public void InsertVenda(Usuarios novaVenda)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(novaVenda);
        }
        
        
        

        #endregion

        public Users GetUser(string username, string password)
        {
            var db = new SQLiteConnection(dbPath);
            Console.WriteLine("Reading data From Table");
            var table = db.Table<Users>();
            try
            {
                foreach (var s in table)
                {
                    if (string.Equals(s.Username, username) && string.Equals(s.Password, password))
                        return s;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        
        public Users GetUser(string username)
        {
            var db = new SQLiteConnection(dbPath);
            Console.WriteLine("Reading data From Table");
            var table = db.Table<Users>();
            try
            {
                foreach (var s in table)
                {
                    if (string.Equals(s.Username, username))
                        return s;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        
        public void UpdateUser(Users user)
        {
            var db = new SQLiteConnection(dbPath);
            db.Update(user);
        }

        public string GetAllUsers()
        {
            string data = "";
            var db = new SQLiteConnection(dbPath);
            
            Console.WriteLine("Reading data From Table");
            var table = db.Table<Users>();
            try
            {
                foreach (var s in table)
                    
                    data += s.UId + "\t" + s.Username + "\t" + s.Password + "\t" + s.Status + "\t" + s.Nivel + "\n";
                return data;
            }
            catch
            {
                return "Empty";
            }
        }


        [Table("Users")]
        public class Users
        {
            [PrimaryKey, AutoIncrement, Column("_uid")]
            public int UId { get; set; }
            [MaxLength(3)]
            public string Username { get; set; }
            [MaxLength(8)]
            public string Password { get; set; }
            [MaxLength(10)]
            public string Status { get; set; }
            [MaxLength(0)]
            public string Nivel { get; set; }
        }

        [Table("Cargos")]
        public class Cargos
        {
            [PrimaryKey, AutoIncrement, Column("_cid")]
            public int CId { get; set; }
            [MaxLength(30)]
            public string Cargo { get; set; }

        }


        [Table("Detalhes_Vendas")]
        public class Detalhes_Vendas
        {
            [PrimaryKey, AutoIncrement, Column("_dvid")]
            public int DVId { get; set; }
            [MaxLength(3)]
            public int Id_venda { get; set; }
            [MaxLength(40)]
            public string Produto { get; set; }
            [MaxLength(11)]
            public int Quantidade { get; set; }
            [MaxLength(10)]
            public double Valor_Unitario { get; set; }
            [MaxLength(10)]
            public double Valor_Total { get; set; }
            [MaxLength(30)]
            public string Funcionarioo { get; set; }
            [MaxLength(3)]
            public int Id_produto { get; set; }


        }

        [Table("Fornecedores")]
        public class Fornecedores
        {
            [PrimaryKey, AutoIncrement, Column("_forneid")]
            public int ForneId { get; set; }
            [MaxLength(40)]
            public string Nome { get; set; }
            [MaxLength(50)]
            public string Endereco { get; set; }
            [MaxLength(20)]
            public string Telefone { get; set; }



        }

        [Table("Funcionarios")]
        public class Funcionarios
        {
            [PrimaryKey, AutoIncrement, Column("_funcid")]
            public int FuncId { get; set; }
            [MaxLength(40)]
            public string Nome { get; set; }
            [MaxLength(20)]
            public string Cpf { get; set; }
            [MaxLength(80)]
            public string endereco { get; set; }
            [MaxLength(20)]
            public string telefone { get; set; }

            public Cargos cargo { get; set; }

            public DateTime Funcionarioo { get; set; }


        }

        [Table("Gastos")]
        public class Gastos
        {
            [PrimaryKey, AutoIncrement, Column("_gastosid")]
            public int GastosId { get; set; }
            [MaxLength(60)]
            public string Descricao { get; set; }
            [MaxLength(10)]
            public double Valor { get; set; }

            public Funcionarios Funcionario { get; set; }

            public DateTime Data { get; set; }


        }



        [Table("Hospedes")]
        public class Hospedes
        {
            [PrimaryKey, AutoIncrement, Column("_hospedeid")]
            public int HospedeId { get; set; }
            [MaxLength(30)]
            public string Nome { get; set; }
            [MaxLength(20)]
            public string Cpf { get; set; }
            [MaxLength(50)]
            public string Endereco { get; set; }
            [MaxLength(20)]
            public string Telefone { get; set; }
            [MaxLength(30)]
            public string Funcionario { get; set; }
            
            public DateTime Data { get; set; }


        }

        [Table("Movimentacoes")]
        public class Movimentacoes
        {
            [PrimaryKey, AutoIncrement, Column("_movimentaid")]
            public int MovimentaId { get; set; }
            [MaxLength(30)]
            public string Tipo { get; set; }
            [MaxLength(20)]
            public string Movimento { get; set; }
            [MaxLength(50)]
            public double Valor { get; set; }
            [MaxLength(20)]
            public string Funcionario { get; set; }
            [MaxLength(30)]
            public DateTime Data { get; set; }

            public int Id_movimento { get; set; }


        }


        [Table("Novo_Servico")]
        public class Novo_Servico
        {
            [PrimaryKey, AutoIncrement, Column("_newserviceid")]
            public int NewServiceId { get; set; }
            [MaxLength(30)]
            public string Hospede { get; set; }
            [MaxLength(20)]
            public string Servico { get; set; }
            [MaxLength(50)]
            public string Quarto { get; set; }
            [MaxLength(20)]
            public double Valor { get; set; }
            [MaxLength(30)]
            public string Funcionario { get; set; }

            public DateTime Data { get; set; }


        }

        [Table("Ocupacoes")]
        public class Ocupacoes
        {
            [PrimaryKey, AutoIncrement, Column("_ocupacoesid")]
            public int OcupacoesId { get; set; }
            [MaxLength(30)]
            public string Quarto { get; set; }
            
            public DateTime Data { get; set; }
            [MaxLength(50)]
            public string Funcionario { get; set; }
            [MaxLength(20)]
            public int Id_reserva { get; set; }
           

        }


        [Table("Produtos")]
        public class Produtos
        {
            [PrimaryKey, AutoIncrement, Column("_produtosid")]
            public int ProdutosId { get; set; }
            [MaxLength(40)]
            public string Nome { get; set; }
            [MaxLength(80)]
            public string Descricao { get; set; }
            [MaxLength(11)]
            public int Estoque { get; set; }
            [MaxLength(11)]
            public int Fornecedor { get; set; }
            [MaxLength(10)]
            public double Valor_Venda { get; set; }
            [MaxLength(10)]
            public double Valor_Compra { get; set; }

            public DateTime Data { get; set; }
            public long Imagem { get; set; }


        }

        [Table("Quartos")]
        public class Quartos
        {
            [PrimaryKey, AutoIncrement, Column("_quartosid")]
            public int QuartosId { get; set; }
            [MaxLength(5)]
            public string Quarto { get; set; }
            [MaxLength(10)]
            public double Valor { get; set; }
            [MaxLength(3)]
            public string Pessoas { get; set; }
            
        }

        [Table("Reservas")]
        public class Reservas
        {
            [PrimaryKey, AutoIncrement, Column("_reservaid")]
            public int ReservaId { get; set; }
            [MaxLength(5)]
            public string Quarto { get; set; }
            
            public DateTime Entrada { get; set; }
            
            public DateTime Saida { get; set; }
            [MaxLength(11)]
            public int Dias { get; set; }
            [MaxLength(10)]
            public double Valor { get; set; }
            [MaxLength(25)]
            public string Nome { get; set; }
            [MaxLength(20)]
            public string Telefone { get; set; }

            public DateTime Data { get; set; }
            [MaxLength(30)]
            public string Funcionario { get; set; }
            [MaxLength(15)]
            public string Status { get; set; }
            [MaxLength(5)]
            public string Checkin { get; set; }
            [MaxLength(5)]
            public string Checkout { get; set; }
            [MaxLength(5)]
            public string Pago { get; set; }


        }



        [Table("Servicos")]
        public class Servicos
        {
            [PrimaryKey, AutoIncrement, Column("_servicoid")]
            public int ServicoId { get; set; }
            [MaxLength(40)]
            public string Nome { get; set; }
            [MaxLength(10)]
            public double Valor { get; set; }

        }

        [Table("Usuarios")]
        public class Usuarios
        {
            [PrimaryKey, AutoIncrement, Column("_usuarioid")]
            public int UsuarioId { get; set; }
            [MaxLength(30)]
            public string Nome { get; set; }
            [MaxLength(30)]
            public string Cargo { get; set; }
            [MaxLength(30)]
            public string Usuario { get; set; }
            [MaxLength(30)]
            public string Senha { get; set; }
           
            public DateTime Data { get; set; }
            


        }


        [Table("Vendas")]
        public class Vendas
        {
            [PrimaryKey, AutoIncrement, Column("_vendaid")]
            public int VendaId { get; set; }
            [MaxLength(10)]
            public double Valor_Total { get; set; }
            [MaxLength(40)]
            public string Funcionario { get; set; }
            [MaxLength(25)]
            public string Status { get; set; }
            
            public DateTime Date { get; set; }

        }



    }
}