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
        private readonly string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myhotelapp.db");
        public SQLiteDB()
        {
            try
            {
                //Creating database, if it doesn't already exist 
                if (!File.Exists(dbPath))
                {
                    var db = new SQLiteConnection(dbPath);


                    #region Drops

                    db.Query<Cargos>("DROP TABLE IF EXISTS Cargos;");

                    db.Query<Detalhes_Vendas>("DROP TABLE IF EXISTS Detalhes_Vendas;");

                    db.Query<Fornecedores>("DROP TABLE IF EXISTS Fornecedores;");

                    db.Query<Funcionarios>("DROP TABLE IF EXISTS Funcionarios;");

                    db.Query<Gastos>("DROP TABLE IF EXISTS Gastos;");

                    db.Query<Hospedes>("DROP TABLE IF EXISTS Hospedes;");

                    db.Query<Movimentacoes>("DROP TABLE IF EXISTS Movimentacoes;");

                    db.Query<Novo_Servico>("DROP TABLE IF EXISTS Novo_Servico;");

                    db.Query<Ocupacoes>("DROP TABLE IF EXISTS Ocupacoes;");

                    db.Query<Produtos>("DROP TABLE IF EXISTS Produtos;");

                    db.Query<Quartos>("DROP TABLE IF EXISTS Quartos;");

                    db.Query<Reservas>("DROP TABLE IF EXISTS Reservas;");

                    db.Query<Servicos>("DROP TABLE IF EXISTS Servicos;");

                    db.Query<Usuarios>("DROP TABLE IF EXISTS Usuarios;");

                    db.Query<Vendas>("DROP TABLE IF EXISTS Vendas;");

                    #endregion 

                    #region Creates
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

                    #endregion

                    #region Inserts de criacao

                    db.Query<Cargos>(@"INSERT INTO  Cargos (cargo) VALUES
('Manobrista'),
('Cozinheiro'),
('Camareira'),
('Garçom'),
('Recepcionista'),
('Gerente'),
('Tesoureiro');
");

                    db.Query<Detalhes_Vendas>(@"INSERT INTO  Detalhes_VendaS (id_venda , produto , quantidade , valor_unitario , valor_total , funcionario , id_produto ) VALUES
(10,'Agua Mineral',3,5.00,15.00,'Hugo Freitas',4),
(10,'Refrigerante Lata',2,5.50,11.00,'Hugo Freitas',1),
(11,'Chocolate Barra',1,9.00,9.00,'Hugo Freitas',3),
(11,'Refrigerante Lata',6,5.50,33.00,'Hugo Freitas',1),
(12,'Cereal Barra',1,4.00,4.00,'Hugo Freitas',5),
(12,'Cerveja Lata',2,8.00,16.00,'Hugo Freitas',2),
(13,'Refrigerante Lata',6,5.50,33.00,'Hugo Freitas',1),
(15,'Cerveja Lata',3,8.00,24.00,'Hugo Freitas',2),
(15,'Refrigerante Lata',2,5.50,11.00,'Hugo Freitas',1),
(15,'Chocolate Barra',1,9.00,9.00,'Hugo Freitas',3),
(16,'Cerveja Lata',3,8.00,24.00,'Hugo Freitas',2),
(16,'Refrigerante Lata',2,5.50,11.00,'Hugo Freitas',1),
(18,'Cerveja Lata',5,8.00,40.00,'Hugo Freitas',2),
(19,'Cerveja Lata',3,8.00,24.00,'Hugo Freitas',2),
(20,'Cerveja Lata',5,8.00,40.00,'Hugo Freitas',2);");

                    db.Query<Fornecedores>(@"INSERT INTO  Fornecedores (nome , endereco , telefone ) VALUES
('Paula Campos','Rua 650','(56) 56656-5656'),
('Marcela','Rua 9','(89) 65656-5656');
");

                    db.Query<Funcionarios>(@"INSERT INTO  Funcionarios (nome , cpf , endereco , telefone , cargo , data ) VALUES
('Marcos Pedro','111.111.111-11','Rua A','(65) 22222-2222','Manobrista','2019-05-06 00:00:00'),
('Marcela','266.565.656-56','Rua C','(55) 55555-5555','Recepcionista','2019-05-06 00:00:00'),
('Hugo','121.212.121-21','Rua A','(55) 54545-4560','Gerente','2019-05-06 00:00:00'),
('Pedro','123.659.999-99','Rua 5','(56) 22222-2222','Manobrista','2019-05-06 00:00:00');");

                    db.Query<Gastos>(@"INSERT INTO  Gastos (descricao , valor , funcionario , data ) VALUES
('Compra de Produtos',30.00,'Hugo Freitas','13/05/2019'),
('Gasto com Cadeira',90.00,'Hugo Freitas','13/05/2019'),
('Concerto de TV',450.00,'Hugo Freitas','14/05/2019'),
('Compra de Produtos',30.00,'Hugo Freitas','20/05/2019'),
('Compra de Mesas',600.00,'Hugo Freitas','21/05/2019'),
('Compra de Produtos',40.00,'Hugo Freitas','21/05/2019');");

                    db.Query<Hospedes>(@"INSERT INTO  Hospedes (nome , cpf , endereco , telefone , funcionario , data ) VALUES
('Marcela','000.002.222-22','Rua','(55) 55555-5555','Hugo Freitas','2019-05-13 00:00:00'),
('Paola','111.111.111-11','Rua 5','(89) 55555-5555','Hugo Freitas','2019-05-13 00:00:00'),
('Matheus','222.222.222-22','Rua 10','(66) 66666-6333','Hugo Freitas','2019-05-13 00:00:00'
);
");

                    db.Query<Movimentacoes>(@"INSERT INTO  Movimentacoes (tipo , movimento , valor , funcionario , data , id_movimento ) VALUES
('Saída','Gasto',90.00,'Hugo Freitas', '08/02/2023',2),
('Entrada','Venda',40.00,'Hugo Freitas','13/05/2019',18),
('Entrada','Serviço',150.00,'Hugo Freitas','14/05/2019',1),
('Entrada','Serviço',150.00,'Hugo Freitas','14/05/2019',4),
('Entrada','Serviço',90.00,'Hugo Freitas','14/05/2019',5),
('Saída','Gasto',450.00,'Hugo Freitas','14/05/2019',5),
('Entrada','Serviço',90.00,'Hugo Freitas','14/05/2019',6),
('Entrada','Reserva',450.00,'Hugo Freitas','16/05/2019',5),
('Entrada','Reserva',450.00,'Hugo Freitas','16/05/2019',7),
('Entrada','Reserva',900.00,'Hugo Freitas','16/05/2019',9),
('Entrada','Reserva',450.00,'Hugo Freitas','16/05/2019',10),
('Entrada','Reserva',1000.00,'Hugo Freitas','20/05/2019',17),
('Entrada','Reserva',450.00,'Hugo Freitas','20/05/2019',18),
('Entrada','Reserva',600.00,'Hugo Freitas','20/05/2019',19),
('Saída','Gasto',30.00,'Hugo Freitas','20/05/2019',6),
('Entrada','Reserva',450.00,'Hugo Freitas','20/05/2019',22),
('Entrada','Reserva',450.00,'Hugo Freitas','21/05/2019',25),
('Entrada','Venda',24.00,'Hugo Freitas','21/05/2019',19),
('Saída','Gasto',600.00,'Hugo Freitas','21/05/2019',7),
('Entrada','Reserva',400.00,'Hugo Freitas','21/05/2019',28),
('Entrada','Venda',40.00,'Hugo Freitas','21/05/2019',20),
('Saída','Gasto',40.00,'Hugo Freitas','21/05/2019',8);");

                    db.Query<Novo_Servico>(@"INSERT INTO  Novo_Servico (hospede , servico , quarto , valor , funcionario , data ) VALUES
('Paola','Cabelereira','101',150.00,'Hugo Freitas','2019-05-12 00:00:00'),
('Matheus','Personal Trainner','101',150.00,'Hugo Freitas','2019-05-14 00:00:00'),
('Paola','Massagem','203',90.00,'Hugo Freitas','2019-05-14 00:00:00'),
('Matheus','Massagem','302',90.00,'Hugo Freitas','2019-05-14 00:00:00');");

                    db.Query<Ocupacoes>(@"INSERT INTO  Ocupacoes (id , quarto , data , funcionario , id_reserva ) VALUES
(150,'101','2019-05-17 00:00:00','Hugo Freitas','20'),
(151,'101','2019-05-18 00:00:00','Hugo Freitas','20'),
(152,'101','2019-05-19 00:00:00','Hugo Freitas','20'),
(153,'101','2019-05-20 00:00:00','Hugo Freitas','20'),
(154,'101','2019-05-01 00:00:00','Hugo Freitas','21'),
(155,'101','2019-05-02 00:00:00','Hugo Freitas','21'),
(156,'101','2019-05-03 00:00:00','Hugo Freitas','21'),
(157,'103','2019-05-20 00:00:00','Hugo Freitas','22'),
(158,'103','2019-05-21 00:00:00','Hugo Freitas','22'),
(159,'103','2019-05-22 00:00:00','Hugo Freitas','22'),
(165,'202','2019-05-19 00:00:00','Hugo Freitas','24'),
(166,'202','2019-05-20 00:00:00','Hugo Freitas','24'),
(167,'101','2019-05-21 00:00:00','Hugo Freitas','25'),
(168,'101','2019-05-22 00:00:00','Hugo Freitas','25'),
(169,'101','2019-05-23 00:00:00','Hugo Freitas','25'),
(173,'101','2019-05-26 00:00:00','Hugo Freitas','27'),
(174,'101','2019-05-27 00:00:00','Hugo Freitas','27'),
(175,'101','2019-05-28 00:00:00','Hugo Freitas','27'),
(176,'101','2019-05-29 00:00:00','Hugo Freitas','27'),
(177,'202','2019-05-21 00:00:00','Hugo Freitas','28'),
(178,'202','2019-05-22 00:00:00','Hugo Freitas','28');");

                    db.Query<Produtos>(@"INSERT INTO  Produtos (nome , descricao , estoque , fornecedor , valor_venda , valor_compra , data) VALUES
('Refrigerante Lata','Lata 350 ML',23,2,5.50,2.00,'2019-05-07 00:00:00'),
('Cerveja Lata','Lata 350 ML',31,2,8.00,2.00,'2019-05-07 00:00:00'),
('Chocolate Barra','Barra 175 Gramas',20,2,9.00,3.00,'2019-05-08 00:00:00'),
('Agua Mineral','Garrafa 200 ML',24,2,5.00,3.00,'2019-05-08 00:00:00'),
('Cereal Barra','Barra Cereal 80 G',21,2,4.00,1.50,'2019-05-08 00:00:00'),
('Suco Caixinha','Caixa 200 ML',15,2,5.00,2.00,'2019-05-08 00:00:00'),
('Suco Lata','Lata 350 ML',20,1,6.00,2.00,'2019-05-08 00:00:00');
");

                    db.Query<Quartos>(@"INSERT INTO  Quartos (quarto , valor , pessoas ) VALUES
('101',150.00,'2'),
('102',150.00,'2'),
('103',150.00,'2'),
('201',200.00,'3'),
('202',200.00,'3'),
('203',200.00,'3'),
('301',300.00,'2'),
('302',300.00,'2'),
('303',450.00,'2');");

                    db.Query<Reservas>(@"INSERT INTO  Reservas ( id , quarto , entrada , saida , dias , valor , nome , telefone , data , funcionario , status , checkin , checkout , pago ) VALUES
(18,'101','2019-05-18 00:00:00','2019-05-20 00:00:00',3,450.00,'Paloma','(22) 22222-2222','2019-05-20 00:00:00','Hugo Freitas','Confirmada','Sim','Sim','Sim'),
(20,'101','2019-05-17 00:00:00','2019-05-20 00:00:00',4,600.00,'Marcelo','(22) 65656-5656','2019-05-20 00:00:00','Hugo Freitas','Confirmada','Não','Não','Não'),
(21,'101','2019-05-01 00:00:00','2019-05-03 00:00:00',3,450.00,'Paloma','(11) 58989-8984','2019-05-20 00:00:00','Hugo Freitas','Confirmada','Não','Não','Não'),
(22,'103','2019-05-20 00:00:00','2019-05-22 00:00:00',3,450.00,'Francisco','(25) 89898-9899','2019-05-20 00:00:00','Hugo Freitas','Confirmada','Sim','Não','Sim'),
(23,'201','2019-05-20 00:00:00','2019-05-24 00:00:00',5,1000.00,'Matheus','(99) 88989-8989','2019-05-20 00:00:00','Hugo Freitas','Confirmada','Não','Sim','Não'),
(25,'101','2019-05-21 00:00:00','2019-05-23 00:00:00',3,450.00,'Paulo','(22) 22222-2222','2019-05-21 00:00:00','Hugo Freitas','Confirmada','Sim','Não','Sim'),
(26,'102','2019-05-19 00:00:00','2019-05-21 00:00:00',3,450.00,'Marcos','(22) 22222-2222','2019-05-21 00:00:00','Hugo Freitas','Confirmada','Não','Sim','Não'),
(27,'101','2019-05-26 00:00:00','2019-05-29 00:00:00',4,600.00,'Thiago','(55) 65656-6565','2019-05-21 00:00:00','Hugo Freitas','Confirmada','Não','Não','Não'),
(28,'202','2019-05-21 00:00:00','2019-05-22 00:00:00',2,400.00,'Marcel','(22) 22222-2222','2019-05-21 00:00:00','Hugo Freitas','Confirmada','Sim','Não','Sim');");

                    db.Query<Servicos>(@"INSERT INTO  Servicos (nome , valor ) VALUES
('Cabelereira',150.00),
('Massagem',90.00),
('Personal Trainner',75.00);");

                    db.Query<Usuarios>("DELETE FROM Usuarios WHERE senha = '123'");
                    db.Query<Usuarios>(@"INSERT INTO  Usuarios ( nome , cargo , usuario , senha , data ) VALUES
                    ('Marcos', 'Recepcionista', 'marcos', '123', '2019-05-06 00:00:00'),
                    ('Hugo Freitas', 'Gerente', 'hugo', '123', '2019-05-06 00:00:00'),
                    ('Paloma', 'Recepcionista', 'paloma', '123', '2019-05-06 00:00:00');");

                    db.Query<Vendas>(@"INSERT INTO Vendas (id , valor_total , funcionario , status , data ) VALUES
(9,31.50,'Hugo Freitas','Cancelada','2019-05-07 00:00:00'),
(10,26.00,'Hugo Freitas','Efetuada','2019-05-07 00:00:00'),
(11,42.00,'Hugo Freitas','Efetuada','2019-05-09 00:00:00'),
(12,20.00,'Hugo Freitas','Efetuada','2019-05-08 00:00:00'),
(13,33.00,'Hugo Freitas','Efetuada','2019-05-09 00:00:00'),
(14,32.00,'Hugo Freitas','Cancelada','2019-05-09 00:00:00'),
(15,44.00,'Hugo Freitas','Efetuada','2019-05-09 00:00:00'),
(16,35.00,'Hugo Freitas','Efetuada','2019-05-13 00:00:00'),
(17,10.00,'Hugo Freitas','Cancelada','2019-05-13 00:00:00'),
(18,40.00,'Hugo Freitas','Efetuada','2019-05-13 00:00:00'),
(19,24.00,'Hugo Freitas','Efetuada','2019-05-21 00:00:00'),
(20,40.00,'Hugo Freitas','Efetuada','2019-05-21 00:00:00');");

                    #endregion

                }


            }
            catch (Exception)
            {

                throw;
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
            try
            {

                
                var db = new SQLiteConnection(dbPath);
                db.Insert(novaMovimentacao);



            }
            catch (Exception)
            {

                throw;
            }


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

        public Usuarios GetLogin(string usuario, string senha)
        {
            var db = new SQLiteConnection(dbPath);
            Console.WriteLine("Reading data From Table");
            var table = db.Table<Usuarios>();
            try
            {
                foreach (var s in table)
                {
                    if (string.Equals(s.Usuario, usuario) && string.Equals(s.Senha, senha))
                        return s;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }


        public Usuarios GetUsuario(string username)
        {
            var db = new SQLiteConnection(dbPath);
            Console.WriteLine("Reading data From Table");
            var table = db.Table<Usuarios>();
            try
            {
                foreach (var s in table)
                {
                    if (string.Equals(s.Usuario, username))
                        return s;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }


        public void UpdateUsuario(Usuarios usuarios)
        {
            var db = new SQLiteConnection(dbPath);
            db.Update(usuarios);
            
        }

        public void DeleteGasto(Gastos gasto)
        {
            var db = new SQLiteConnection(dbPath);
           
            db.Delete(gasto);
        }
        
        public void DeleteMovimentacao(Movimentacoes movimento)
        {
            var db = new SQLiteConnection(dbPath);
           
            db.Delete(movimento);
        }

        #region Getalls()
        public List<Usuarios> GetAllUsers()
        {
            
            var db = new SQLiteConnection(dbPath);

            Console.WriteLine("Reading data From Table");
            var table = db.Table<Usuarios>().ToList();
            try
            {
                //foreach (var s in table)

                //    data += s.UsuarioId + "\t" + s.Usuario + "\t" + s.Senha + "\t" + s.Nome + "\t" + s.Cargo + "\t" + s.Data + "\n";
                return table;
            }
            catch
            {
                return null;
            }
        }

        public List<Movimentacoes> GetAllMovimentacoes()
        {

            var db = new SQLiteConnection(dbPath);

            Console.WriteLine("Reading data From Table");
            var table = db.Table<Movimentacoes>().ToList();
            try
            {

                return table;
            }
            catch
            {
                return null;
            }
        }


        public List<Gastos> GetAllGastos()
        {
            try
            {
                var db = new SQLiteConnection(dbPath);

                var table = db.Table<Gastos>().ToList();

                return table;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Classes Tables

        [Table("Usuarios")]
        public class Usuarios
        {
            [PrimaryKey, AutoIncrement, Column("_usuarioid")]
            public int UsuarioId { get; set; } = 55;
            [Column("nome"), MaxLength(30)]
            public string Nome { get; set; }
            [Column("cargo"), MaxLength(30)]
            public string Cargo { get; set; }
            [Column("usuario"), MaxLength(30)]
            public string Usuario { get; set; }
            [Column("senha"), MaxLength(30)]
            public string Senha { get; set; }
            [Column("data"), MaxLength(30)]
            public string Data { get; set; }



        }


        [Table("Cargos")]
        public class Cargos
        {
            [PrimaryKey, AutoIncrement, Column("_cid")]
            public int CId { get; set; }
            [Column("cargo"), MaxLength(30)]
            public string Cargo { get; set; }

        }


        [Table("Detalhes_Vendas")]
        public class Detalhes_Vendas
        {
            [PrimaryKey, AutoIncrement, Column("_dvid")]
            public int DVId { get; set; }
            [Column("id_venda"), MaxLength(3)]
            public int Id_venda { get; set; }
            [Column("produto"), MaxLength(40)]
            public string Produto { get; set; }
            [Column("quantidade"), MaxLength(11)]
            public int Quantidade { get; set; }
            [Column("valor_unitario"), MaxLength(10)]
            public double Valor_Unitario { get; set; }
            [Column("valor_total"), MaxLength(10)]
            public double Valor_Total { get; set; }
            [Column("funcionario"), MaxLength(30)]
            public string Funcionarioo { get; set; }
            [Column("id_produto"), MaxLength(3)]
            public int Id_produto { get; set; }


        }

        [Table("Fornecedores")]
        public class Fornecedores
        {
            [PrimaryKey, AutoIncrement, Column("_forneid")]
            public int ForneId { get; set; }
            [Column("nome"), MaxLength(40)]
            public string Nome { get; set; }
            [Column("endereco"), MaxLength(50)]
            public string Endereco { get; set; }
            [Column("telefone"), MaxLength(20)]
            public string Telefone { get; set; }



        }

        [Table("Funcionarios")]
        public class Funcionarios
        {
            [PrimaryKey, AutoIncrement, Column("_funcid")]
            public int FuncId { get; set; }
            [Column("nome"), MaxLength(40)]
            public string Nome { get; set; }
            [Column("cpf"), MaxLength(20)]
            public string Cpf { get; set; }
            [Column("endereco"), MaxLength(80)]
            public string endereco { get; set; }
            [Column("telefone"), MaxLength(20)]
            public string telefone { get; set; }
            [Column("cargo"), MaxLength(20)]
            public string cargo { get; set; }
            [Column("data")]
            public DateTime Data { get; set; }


        }

        [Table("Gastos")]
        public class Gastos
        {
            [PrimaryKey, AutoIncrement, Column("_gastosid")]
            public int GastosId { get; set; }
            [Column("descricao"), MaxLength(60)]
            public string Descricao { get; set; }
            [Column("valor"), MaxLength(10)]
            public double Valor { get; set; }
            [Column("funcionario"), MaxLength(20)]
            public string Funcionario { get; set; }
            [Column("data"), MaxLength(30)]
            public string Data { get; set; }


        }



        [Table("Hospedes")]
        public class Hospedes
        {
            [PrimaryKey, AutoIncrement, Column("_hospedeid")]
            public int HospedeId { get; set; }
            [Column("nome"), MaxLength(30)]
            public string Nome { get; set; }
            [Column("cpf"), MaxLength(20)]
            public string Cpf { get; set; }
            [Column("endereco"), MaxLength(50)]
            public string Endereco { get; set; }
            [Column("telefone"), MaxLength(20)]
            public string Telefone { get; set; }
            [Column("funcionario"), MaxLength(30)]
            public string Funcionario { get; set; }
            [Column("data")]
            public DateTime Data { get; set; }


        }

        [Table("Movimentacoes")]
        public class Movimentacoes
        {
            [PrimaryKey, AutoIncrement, Column("_movimentaid")]
            public int MovimentaId { get; set; }
            [Column("tipo"), MaxLength(30)]
            public string Tipo { get; set; }
            [Column("movimento"), MaxLength(20)]
            public string Movimento { get; set; }
            [Column("valor"), MaxLength(50)]
            public double Valor { get; set; }
            [Column("funcionario"), MaxLength(20)]
            public string Funcionario { get; set; }
            [MaxLength(30), Column("data")]
            public string Data { get; set; }
            [Column("id_movimento"), MaxLength(11)]
            public int Id_movimento { get; set; }


        }


        [Table("Novo_Servico")]
        public class Novo_Servico
        {
            [PrimaryKey, AutoIncrement, Column("_newserviceid")]
            public int NewServiceId { get; set; }
            [Column("hospede"), MaxLength(30)]
            public string Hospede { get; set; }
            [Column("servico"), MaxLength(20)]
            public string Servico { get; set; }
            [Column("quarto"), MaxLength(50)]
            public string Quarto { get; set; }
            [Column("valor"), MaxLength(20)]
            public double Valor { get; set; }
            [Column("funcionario"), MaxLength(30)]
            public string Funcionario { get; set; }
            [Column("data")]
            public DateTime Data { get; set; }


        }

        [Table("Ocupacoes")]
        public class Ocupacoes
        {
            [Column("id"), PrimaryKey]
            public int Id { get; set; }
            [Column("quarto"), MaxLength(30)]
            public string Quarto { get; set; }
            [Column("data")]
            public DateTime Data { get; set; }
            [Column("funcionario"), MaxLength(50)]
            public string Funcionario { get; set; }
            [Column("id_reserva"), MaxLength(20)]
            public string Id_reserva { get; set; }


        }


        [Table("Produtos")]
        public class Produtos
        {
            [PrimaryKey, AutoIncrement, Column("_produtosid")]
            public int ProdutosId { get; set; }
            [Column("nome"), MaxLength(40)]
            public string Nome { get; set; }
            [Column("descricao"), MaxLength(80)]
            public string Descricao { get; set; }
            [Column("estoque"), MaxLength(11)]
            public int Estoque { get; set; }
            [Column("fornecedor"), MaxLength(11)]
            public int Fornecedor { get; set; }
            [Column("valor_venda"), MaxLength(10)]
            public double Valor_Venda { get; set; }
            [Column("valor_compra"), MaxLength(10)]
            public double Valor_Compra { get; set; }
            [Column("data")]
            public DateTime Data { get; set; }



        }

        [Table("Quartos")]
        public class Quartos
        {
            [PrimaryKey, AutoIncrement, Column("_quartosid")]
            public int QuartosId { get; set; }
            [Column("quarto"), MaxLength(5)]
            public string Quarto { get; set; }
            [Column("valor"), MaxLength(10)]
            public double Valor { get; set; }
            [Column("pessoas"), MaxLength(3)]
            public string Pessoas { get; set; }

        }

        [Table("Reservas")]
        public class Reservas
        {
            [PrimaryKey, Column("id")]
            public int Id { get; set; }
            [Column("quarto"), MaxLength(5)]
            public string Quarto { get; set; }
            [Column("entrada")]
            public DateTime Entrada { get; set; }
            [Column("saida")]
            public DateTime Saida { get; set; }
            [Column("dias"), MaxLength(11)]
            public int Dias { get; set; }
            [Column("valor"), MaxLength(10)]
            public double Valor { get; set; }
            [Column("nome"), MaxLength(25)]
            public string Nome { get; set; }
            [Column("telefone"), MaxLength(20)]
            public string Telefone { get; set; }
            [Column("data")]
            public DateTime Data { get; set; }
            [Column("funcionario"), MaxLength(30)]
            public string Funcionario { get; set; }
            [Column("status"), MaxLength(15)]
            public string Status { get; set; }
            [Column("checkin"), MaxLength(5)]
            public string Checkin { get; set; }
            [Column("checkout"), MaxLength(5)]
            public string Checkout { get; set; }
            [Column("pago"), MaxLength(5)]
            public string Pago { get; set; }


        }



        [Table("Servicos")]
        public class Servicos
        {
            [PrimaryKey, AutoIncrement, Column("_servicoid")]
            public int ServicoId { get; set; }
            [Column("nome"), MaxLength(40)]
            public string Nome { get; set; }
            [Column("valor"), MaxLength(10)]
            public double Valor { get; set; }

        }



        [Table("Vendas")]
        public class Vendas
        {
            [PrimaryKey, Column("id")]
            public int Id { get; set; }
            [Column("valor_total"), MaxLength(10)]
            public double Valor_Total { get; set; }
            [Column("funcionario"), MaxLength(40)]
            public string Funcionario { get; set; }
            [Column("status"), MaxLength(25)]
            public string Status { get; set; }
            [Column("data")]
            public DateTime Date { get; set; }

        }

        #endregion



    }
}
