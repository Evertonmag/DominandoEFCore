using DominandoEFCore.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Diagnostics;
using DominandoEFCore.Domain;
using System.Transactions;
using DominandoEFCore.Funcoes;

namespace DominandoEFCore
{
    class program
    {
        static void Main(string[] args)
        {

        }

        #region Performance
        //Performance
        //static void ConsultaProjetada()
        //{
        //    using var db = new ApplicationContext();

        //    var departamentos = db.Departamentos?.Select(p => p.Descricao).ToArray();

        //    var memoria = (System.Diagnostics.Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024) + " MB";
        //    Console.WriteLine(memoria);
        //}

        //static void Inserir_200_Departamentos_com_1MB()
        //{
        //    using var db = new ApplicationContext();
        //    db.Database.EnsureDeleted();
        //    db.Database.EnsureCreated();

        //    var random = new Random();

        //    db.Departamentos.AddRange(Enumerable.Range(1, 200).Select(p =>
        //        new Departamento
        //        {
        //            Descricao = "Departamento Teste",
        //            Image = getBytes()
        //        }));

        //    db.SaveChanges();

        //    byte[] getBytes()
        //    {
        //        var buffer = new byte[1024 * 1024];
        //        random.NextBytes(buffer);

        //        return buffer;
        //    }

        //}

        //static void ConsultaProjetadaERastreada()
        //{
        //    using var db = new ApplicationContext();

        //    var departamentos = db.Departamentos?
        //        .Include(p => p.Funcionarios)
        //        .Select(p => new
        //        {
        //            Departamento = p,
        //            TotalFuncionarios = p.Funcionarios.Count()
        //        })
        //        .ToList();

        //    departamentos[0].Departamento.Descricao = "Departamento teste Atualizado";

        //    db.SaveChanges();
        //}

        //static void ConsultaCustomizada()
        //{
        //    using var db = new ApplicationContext();

        //    db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;

        //    var funcionarios = db.funcionarios?
        //        //.AsNoTrackingWithIdentityResolution()
        //        .Include(p => p.Departamento)
        //        .ToList();
        //}

        //static void ConsultaComResolucaoDeIdentidade()
        //{
        //    using var db = new ApplicationContext();

        //    var funcionarios = db.funcionarios?
        //        .AsNoTrackingWithIdentityResolution()
        //        .Include(p => p.Departamento)
        //        .ToList();
        //}
        //static void ConsultaNaoRastreada()
        //{
        //    using var db = new ApplicationContext();

        //    var funcionarios = db.funcionarios?.AsNoTracking().Include(p => p.Departamento).ToList();
        //}

        //static void ConsultaRastreada()
        //{
        //    using var db = new ApplicationContext();

        //    var funcionarios = db.funcionarios?.Include(p => p.Departamento).ToList();
        //}

        //static void Setup()
        //{
        //    using var db = new ApplicationContext();
        //    db.Database.EnsureDeleted();
        //    db.Database.EnsureCreated();

        //    db.Departamentos?.Add(new Departamento
        //    {
        //        Descricao = "Departamento Teste",
        //        Ativo = true,
        //        Funcionarios = Enumerable.Range(1, 100).Select(p => new Funcionario
        //        {
        //            CPF = p.ToString().PadLeft(11, '0'),
        //            Nome = $"Funcionario {p}",
        //            RG = p.ToString()
        //        }).ToList()
        //    });

        //    db.SaveChanges();
        //}

        #endregion

        #region UDFs
        //UDFs
        //static void DateDIFF()
        //{
        //    CadastrarLivro();

        //    using var db = new ApplicationContext();

        //    /*
        //    var resultado = db
        //        .Livros
        //        .Select(p => EF.Functions.DateDiffDay(p.CadastradoEm, DateTime.Now));
        //    */

        //    var resultado = db
        //        .Livros
        //        .Select(p => MinhasFuncoes.DateDiff("DAY", p.CadastradoEm, DateTime.Now));

        //    foreach (var diff in resultado)
        //    {
        //        Console.WriteLine(diff);
        //    }
        //}
        //static void FuncaoDefinidaPeloUsuario()
        //{
        //    CadastrarLivro();

        //    using var db = new ApplicationContext();

        //    db.Database.ExecuteSqlRaw(@"
        //        CREATE FUNCTION ConverterParaLetrasMaiusculas(@dados VARCHAR(100))
        //        RETURNS VARCHAR(100)
        //        BEGIN
        //            RETURN UPPER(@dados)
        //        END");

        //    var resultado = db.Livros?.Select(p => MinhasFuncoes.LetrasMaiusculas(p.Titulo));

        //    foreach (var parteTitulo in resultado)
        //    {
        //        Console.WriteLine(parteTitulo);
        //    }
        //}
        //static void FuncaoLeft()
        //{
        //    CadastrarLivro();
        //    using var db = new ApplicationContext();

        //    var resultado = db.Livros.Select(p => MinhasFuncoes.Left(p.Titulo, 10));
        //    foreach(var parteTitulo in resultado)
        //    {
        //        Console.WriteLine(parteTitulo);
        //    }

        //}
        //static void CadastrarLivro()
        //{
        //    using (var db = new ApplicationContext())
        //    {
        //        db.Database.EnsureDeleted();
        //        db.Database.EnsureCreated();

        //        db.Livros.Add(
        //            new Livro
        //            {
        //                Titulo = "Introducao ao Entity Framework Core",
        //                Autor = "Rafael",
        //                CadastradoEm = DateTime.Now.AddDays(-1)
        //            });
        //        db.SaveChanges();
        //    }
        //}
        #endregion

        #region Transacoes
        //Transacoes
        //static void TransactionScope()
        //{
        //    CadastrarLivro();

        //    var transactionOptions = new TransactionOptions
        //    {
        //        IsolationLevel = IsolationLevel.ReadCommitted,
        //    };
        //    using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
        //    {
        //        ConsultarAtualizar();
        //        CadastrarLivroEnterprise();
        //        CadastrarLivroDominandoEFCore();

        //        scope.Complete();
        //    }
        //}
        //static void ConsultarAtualizar()
        //{
        //    using (var db = new ApplicationContext())
        //    {
        //        var livro = db.Livros.FirstOrDefault(p => p.Id == 1);
        //        livro.Autor = "Rafael Almeida";
        //        db.SaveChanges();
        //    }
        //}
        //static void CadastrarLivroEnterprise()
        //{
        //    using (var db = new ApplicationContext())
        //    {
        //        db.Livros.Add(
        //            new Livro
        //            {
        //                Titulo = "ASP.NET Core Enterprise Applications",
        //                Autor = "Eduardo Pires"
        //            });
        //        db.SaveChanges();
        //    }
        //}
        //static void CadastrarLivroDominandoEFCore()
        //{
        //    using (var db = new ApplicationContext())
        //    {
        //        db.Livros.Add(
        //            new Livro
        //            {
        //                Titulo = "Dominando Entity Framework Core",
        //                Autor = "Rafael Almeida"
        //            });
        //        db.SaveChanges();
        //    }
        //}
        //static void SalvarPontoTransacao()
        //{
        //    CadastrarLivro();

        //    using (var db = new ApplicationContext())
        //    {
        //        var transacao = db.Database.BeginTransaction();
        //        try
        //        {
        //            var livro = db.Livros.FirstOrDefault(p => p.Id == 1);
        //            livro.Autor = "Rafael Almeida";
        //            db.SaveChanges();

        //            transacao.CreateSavepoint("desfazer_apenas_insercao");

        //            db.Livros.Add(
        //                new Livro
        //                {
        //                    Titulo = "ASP.NET Core Enterprise Applications",
        //                    Autor = "Eduardo Pires"
        //                });
        //            db.SaveChanges();

        //            db.Livros.Add(
        //                new Livro
        //                {
        //                    Titulo = "Dominando o Entity Framework Core",
        //                    Autor = "Rafael Almeida".PadLeft(16, '*')
        //                });

        //            db.SaveChanges();

        //            transacao.Commit();
        //        }
        //        catch (DbUpdateException ex)
        //        {
        //            transacao.RollbackToSavepoint("desfazer_apenas_insercao");

        //            if (ex.Entries.Count(p=>p.State == EntityState.Added) == ex.Entries.Count)
        //            {
        //                transacao.Commit();
        //            }
        //        }
        //    }
        //}
        //static void ReverterTransacao()
        //{
        //    CadastrarLivro();

        //    using (var db = new ApplicationContext())
        //    {
        //        var transacao = db.Database.BeginTransaction();
        //        try
        //        {
        //        var livro = db.Livros.FirstOrDefault(p => p.Id == 1);
        //        livro.Autor = "Rafael Almeida";
        //        db.SaveChanges();

        //        db.Livros.Add(
        //            new Livro
        //            {
        //                Titulo = "Dominando o Entity Framework Core",
        //                Autor = "Rafael Almeida".PadLeft(16, '*')
        //            });


        //        db.SaveChanges();

        //        transacao.Commit();
        //        }
        //        catch (Exception ex)
        //        {
        //            transacao.Rollback();
        //        }
        //    }
        //}
        //static void GerenciandoTransacaoManualmente()
        //{
        //    CadastrarLivro();

        //    using (var db = new ApplicationContext())
        //    {
        //        var transacao = db.Database.BeginTransaction();

        //        var livro = db.Livros.FirstOrDefault(p => p.Id == 1);
        //        livro.Autor = "Rafael Almeida";
        //        db.SaveChanges();

        //        Console.ReadKey();

        //        db.Livros.Add(
        //            new Livro
        //            {
        //                Titulo = "Dominando o Entity Framework Core",
        //                Autor = "Rafael Almeida"
        //            });


        //        db.SaveChanges();

        //        transacao.Commit();
        //    }
        //}
        //static void ComportamentoPadrao()
        //{
        //    CadastrarLivro();

        //    using (var db = new ApplicationContext())
        //    {
        //        var livro = db.Livros.FirstOrDefault(p => p.Id == 1);
        //        livro.Autor = "Rafael Almeida";

        //        db.Livros.Add(
        //            new Livro
        //            {
        //                Titulo = "Dominando o Entity Framework Core",
        //                Autor = "Rafael Almeida"
        //            });


        //        db.SaveChanges();
        //    }
        //}
        //static void CadastrarLivro()
        //{
        //    using (var db = new ApplicationContext())
        //    {
        //        db.Database.EnsureDeleted();
        //        db.Database.EnsureCreated();

        //        db.Livros.Add(
        //            new Livro
        //            {
        //                Titulo = "Introducao ao Entity Framework Core",
        //                Autor = "Rafael"
        //            });
        //        db.SaveChanges();
        //    }
        //}
        #endregion

        #region Interceptacao
        //Interceptacao
        //static void TesteInterceptacaoSaveChanges()
        //{
        //    using (var db = new ApplicationContext())
        //    {
        //        db.Database.EnsureDeleted();
        //        db.Database.EnsureCreated();

        //        db.Funcoes.Add(new Funcao
        //        {
        //            Descricao1 = "Teste"
        //        });

        //        db.SaveChanges();
        //    }
        //}
        //static void TesteInterceptacao()
        //{
        //    using (var db = new ApplicationContext())
        //    {
        //        var consulta = db
        //            .Funcoes
        //            .TagWith("Use NOLOCk")
        //            .FirstOrDefault();

        //        Console.WriteLine($"Consulta: {consulta?.Descricao1}");
        //    }
        //}
        #endregion

        #region EF_Functions
        //EF_Functions
        //static void FuncaoCollate()
        //{
        //    using (var db = new ApplicationContext())
        //    {
        //        var consulta1 = db
        //            .Funcoes
        //            .FirstOrDefault(p => EF.Functions.Collate(p.Descricao1, "SQl_Latin1_General_CP1_CS_AS") == "Tela");

        //        var consulta2 = db
        //            .Funcoes
        //            .FirstOrDefault(p => EF.Functions.Collate(p.Descricao1, "SQl_Latin1_General_CP1_CI_AS") == "tela");

        //        Console.WriteLine($"Consulta1: {consulta1?.Descricao1} \nConsulta2: {consulta2?.Descricao2}");
        //    }
        //}
        //static void FuncaoProperty()
        //{
        //    ApagarCriarBancoDeDados();

        //    using (var db = new ApplicationContext())
        //    {
        //        var resultado = db
        //            .Funcoes
        //            //.AsNoTracking()
        //            .FirstOrDefault(p => EF.Property<string>(p, "PropriedadeSombra") == "Teste");

        //        var propriedadeSombra = db
        //            .Entry(resultado)
        //            .Property<string>("PropriedadeSombra")
        //            .CurrentValue;

        //        Console.WriteLine($"Resultado: {propriedadeSombra}");
        //    }
        //}
        //static void FuncaoDataLength()
        //{
        //    using (var db = new ApplicationContext())
        //    {
        //        var resultado = db
        //            .Funcoes
        //            .AsNoTracking()
        //            .Select(p => new
        //            {
        //                TotalBytesCampoData = EF.Functions.DataLength(p.Data1),
        //                TotalBytes1 = EF.Functions.DataLength(p.Descricao1),
        //                TotalBytes2 = EF.Functions.DataLength(p.Descricao2),
        //                Total1 = p.Descricao1.Length,
        //                Total2 = p.Descricao2.Length
        //            })
        //            .FirstOrDefault();

        //        Console.WriteLine($"Resultado: {resultado}");
        //    }
        //}
        //static void FuncaoLike()
        //{
        //    using (var db = new ApplicationContext())
        //    {
        //        var script = db.Database.GenerateCreateScript();

        //        Console.WriteLine(script);

        //        var dados = db
        //            .Funcoes
        //            .AsNoTracking()
        //            //.Where(p=>EF.Functions.Like(p.Descricao1, "Bo%"))
        //            .Where(p => EF.Functions.Like(p.Descricao1, "B[ao]%"))
        //            .Select(p => p.Descricao1)
        //            .ToArray();

        //        Console.WriteLine("Resultado: ");
        //        foreach (var descricao in dados)
        //        {
        //            Console.WriteLine(descricao);
        //        }
        //    }
        //}
        //static void FuncoesDeDatas()
        //{
        //    ApagarCriarBancoDeDados();

        //    using (var db = new ApplicationContext())
        //    {
        //        var script = db.Database.GenerateCreateScript();

        //        Console.WriteLine(script);

        //        var dados = db.Funcoes.AsNoTracking().Select(p =>
        //            new
        //            {
        //                Dias = EF.Functions.DateDiffDay(DateTime.Now, p.Data1),
        //                Meses = EF.Functions.DateDiffMonth(DateTime.Now, p.Data1),
        //                Data = EF.Functions.DateFromParts(2021,1,2),
        //                DataValida = EF.Functions.IsDate(p.Data2),
        //            });

        //        foreach (var f in dados)
        //        {
        //            Console.WriteLine(f);
        //        }
        //    }
        //}
        //static void ApagarCriarBancoDeDados()
        //{
        //    using var db = new ApplicationContext();
        //    db.Database.EnsureDeleted();
        //    db.Database.EnsureCreated();

        //    db.Funcoes.AddRange(
        //        new Funcao
        //        {
        //            Data1 = DateTime.Now.AddDays(2),
        //            Data2 = "2021-01-01",
        //            Descricao1 = "Bala 1 ",
        //            Descricao2 = "Bala 1 "
        //        },
        //        new Funcao
        //        {
        //            Data1 = DateTime.Now.AddDays(1),
        //            Data2 = "XX21-01-01",
        //            Descricao1 = "Bola 2",
        //            Descricao2 = "Bola 2"
        //        },
        //        new Funcao
        //        {
        //            Data1 = DateTime.Now.AddDays(1),
        //            Data2 = "XX21-01-01",
        //            Descricao1 = "Tela",
        //            Descricao2 = "Tela"
        //        });

        //    db.SaveChanges();
        //}
        #endregion

        #region Atributos_DataAnnotations
        //static void Atributos()
        //{
        //    using(var db = new ApplicationContext())
        //    {
        //        db.Database.EnsureDeleted();
        //        db.Database.EnsureCreated();

        //        var script = db.Database.GenerateCreateScript();

        //        Console.WriteLine(script);

        //        db.Atributos.Add(new Atributo
        //        {
        //            Descricao = "Exemplo",
        //            Observacao = "Observacao"
        //        });

        //        db.SaveChanges();
        //    }
        //}

        #endregion

        #region ModelodeDados
        //Modelo de dados
        //static void PacotesDePropriedade()
        //{
        //    using (var db = new ApplicationContext())
        //    {
        //        db.Database.EnsureDeleted();
        //        db.Database.EnsureCreated();

        //        var configuracao = new Dictionary<string, object>()
        //        {
        //            ["Chave"] = "SenhaBancoDeDados",
        //            ["Valor"] = Guid.NewGuid().ToString(),
        //        };

        //        db.Configuracoes.Add(configuracao);
        //        db.SaveChanges();

        //        var configuracoes = db
        //            .Configuracoes
        //            .AsNoTracking()
        //            .Where(p => p["Chave"] == "SenhaBancoDeDados")
        //            .ToArray();

        //        foreach (var dic in configuracoes)
        //            Console.WriteLine($"Chave: {dic["Chave"]} - Valor: {dic["Valor"]}");
        //    }
        //}
        //static void ExemploTPH()
        //{
        //    using (var db = new ApplicationContext())
        //    {
        //        db.Database.EnsureDeleted();
        //        db.Database.EnsureCreated();

        //        var pessoa = new Pessoa { Nome = "Fulano de Tal" };

        //        var instrutor = new Instrutor { Nome = "Rafael Almeida", Tecnologia = ".NET", Desde = DateTime.Now };

        //        var Aluno = new Aluno { Nome = "Everton Magagnatto Vicente", Idade = 18, DataContrato = DateTime.Now.AddDays(-1) };

        //        db.AddRange(pessoa, instrutor, Aluno);
        //        db.SaveChanges();

        //        var pessoas = db.Pessoas.AsNoTracking().ToArray();
        //        var instrutores = db.Instrutores.AsNoTracking().ToArray();
        //        //var Alunos = db.Alunos.AsNoTracking().ToArray();
        //        var Alunos = db.Pessoas.OfType<Aluno>().AsNoTracking().ToArray();

        //        Console.WriteLine("Pessoas ***************");
        //        foreach (var p in pessoas)
        //            Console.WriteLine($"Id: {p.Id} -> {p.Nome}");
        //        Console.WriteLine("Instrutores ***************");
        //        foreach (var p in instrutores)
        //            Console.WriteLine($"Id: {p.Id} -> {p.Nome}, Tecnologia {p.Tecnologia}, Desde: {p.Desde:d}");
        //        Console.WriteLine("Alunos ***************");
        //        foreach (var p in Alunos)
        //            Console.WriteLine($"Id: {p.Id} -> {p.Nome}, Idade: {p.Idade}, Data do Contrato {p.DataContrato:d}");

        //    }
        //}
        //static void CampoDeApoio()
        //{
        //    using(var db = new ApplicationContext())
        //    {
        //        db.Database.EnsureDeleted();
        //        db.Database.EnsureCreated();

        //        var documento = new Documento();
        //        documento.SetCPF("12345678933");

        //        db.Documentos.Add(documento);
        //        db.SaveChanges();

        //        foreach (var doc in db.Documentos.AsNoTracking())
        //        {
        //            Console.WriteLine($"CPF -> {doc.CPF}");
        //        }
        //    }
        //}
        //static void RelacionamentoMutosParaMuitos()
        //{
        //    using (var db = new ApplicationContext())
        //    {
        //        db.Database.EnsureDeleted();
        //        db.Database.EnsureCreated();

        //        var ator1 = new Ator { Nome = "Rafael" };
        //        var ator2 = new Ator { Nome = "Pires" };
        //        var ator3 = new Ator { Nome = "Bruno" };

        //        var filme1 = new Filme { Descricao = "A volta dos que não foram" };
        //        var filme2 = new Filme { Descricao = "De volta para o futuro" };
        //        var filme3 = new Filme { Descricao = "Poeira em alto mar filme" };

        //        ator1.Filmes.Add(filme1);
        //        ator1.Filmes.Add(filme2);

        //        ator2.Filmes.Add(filme1);

        //        filme3.Atores.Add(ator1);
        //        filme3.Atores.Add(ator2);
        //        filme3.Atores.Add(ator3);

        //        db.AddRange(ator1, ator2, filme3);

        //        db.SaveChanges();

        //        foreach (var ator in db.Atores.Include(e => e.Filmes))
        //        {
        //            Console.WriteLine($"Ator: {ator.Nome}");

        //            foreach (var filme in ator.Filmes)
        //            {
        //                Console.WriteLine($"\tFilme: {filme.Descricao}");
        //            }
        //        }
        //    }
        //}
        //static void Relacionamento1ParaMuitos()
        //{
        //    using (var db = new ApplicationContext())
        //    {
        //        db.Database.EnsureDeleted();
        //        db.Database.EnsureCreated();

        //        var estado = new Estado
        //        {
        //            Nome = "Sergipe",
        //            Governador = new Governador { Nome = "Rafael Almeida" }
        //        };

        //        estado.Cidades.Add(new Cidade { Nome = "Itabaiana" });

        //        db.Estados.Add(estado);

        //        db.SaveChanges();
        //    }
        //    using (var db = new ApplicationContext())
        //    {
        //        var estados = db.Estados.ToList();

        //        estados[0].Cidades.Add(new Cidade { Nome = "Aracaju" });

        //        db.SaveChanges();

        //        foreach (var est in db.Estados.Include(p => p.Cidades).AsNoTracking())
        //        {
        //            Console.WriteLine($"Estado: {est.Nome}, Governador: {est.Governador.Nome}");

        //            foreach (var cidade in est.Cidades)
        //            {
        //                Console.WriteLine($"\t Cidade: {cidade.Nome}");
        //            }
        //        }
        //    }
        //}
        //static void Relacionamento1Para1()
        //{
        //    using var db = new ApplicationContext();
        //    db.Database.EnsureDeleted();
        //    db.Database.EnsureCreated();

        //    var estado = new Estado
        //    {
        //        Nome = "Sergipe",
        //        Governador = new Governador { Nome = "Rafael Almeida"}
        //    };

        //    db.Estados.Add(estado);

        //    db.SaveChanges();

        //    var estados = db.Estados.AsNoTracking().ToList();

        //    estados.ForEach(cli =>
        //    {
        //        Console.WriteLine($"Estado: {estado.Nome}, Governador: {estado.Governador.Nome}");
        //    });
        //}
        //static void TiposDePropriedade()
        //{
        //    using var db = new ApplicationContext();
        //    db.Database.EnsureDeleted();
        //    db.Database.EnsureCreated();

        //    var cliente = new Cliente
        //    {
        //        Nome = "Fulano de Tal",
        //        Telefone = "(79) 98888-9999",
        //        Endereco = new Endereco { Bairro = "Centro", Cidade = "Sao Paulo" }
        //    };

        //    db.Clientes.Add(cliente);

        //    db.SaveChanges();

        //    var clientes = db.Clientes.AsNoTracking().ToList();

        //    var options = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };

        //    clientes.ForEach(cli =>
        //    {
        //        var json = System.Text.Json.JsonSerializer.Serialize(cli, options);
        //        Console.WriteLine(json);
        //    });
        //}
        //static void TrabalhandoComPropriedadeDeSombra()
        //{
        //    using var db = new ApplicationContext();
        //    db.Database.EnsureDeleted();
        //    db.Database.EnsureCreated();

        //    var departamento = new Departamento
        //    {
        //        Descricao = "Departamento Propriedade de sombra"
        //    };

        //    db.Departamentos.Add(departamento);

        //    db.Entry(departamento).Property("UltimaAtualizacao").CurrentValue = DateTime.Now;

        //    db.SaveChanges();
        //}
        //static void PropriedadesDeSombra()
        //{
        //    using var db = new ApplicationContext();
        //    db.Database.EnsureDeleted();
        //    db.Database.EnsureCreated();
        //}
        //static void ConversorCustomizado()
        //{
        //    using var db = new ApplicationContext();
        //    db.Database.EnsureDeleted();
        //    db.Database.EnsureCreated();

        //    db.Conversores.Add(
        //        new Conversor
        //        {
        //            Status = Status.Devolvido,
        //        });

        //    db.SaveChanges();

        //    var conversorEmAnalise = db.Conversores.AsNoTracking().FirstOrDefault(p=>p.Status == Status.Analise);

        //    var conversorDevolvido = db.Conversores.AsNoTracking().FirstOrDefault(p => p.Status == Status.Devolvido);
        //}
        //static void ConversorDeValor() => Esquema();
        //static void Esquema()
        //{
        //    using var db = new ApplicationContext();

        //    var script = db.Database.GenerateCreateScript();

        //    Console.WriteLine(script);
        //}
        //static void PropagarDados()
        //{
        //    using var db = new ApplicationContext();
        //    db.Database.EnsureDeleted();
        //    db.Database.EnsureCreated();

        //    var script = db.Database.GenerateCreateScript();
        //    Console.WriteLine(script);
        //}
        //static void Collations()
        //{
        //    using var db = new ApplicationContext();
        //    db.Database.EnsureDeleted();    
        //    db.Database.EnsureCreated();
        //}
        #endregion

        #region Consultas
        // Consultas
        //static void ConsultaViaProcedure()
        //{
        //    using var db = new Data.ApplicationContext();

        //    var dep = new SqlParameter("@dep", "Departamento");

        //    var departamentos = db.Departamentos
        //        //.FromSqlRaw("EXECUTE GetDepartamentos @dep", dep)
        //        .FromSqlInterpolated($"EXECUTE GetDepartamentos {dep}")
        //        .ToList();

        //    foreach (var departamento in departamentos)
        //    {
        //        Console.WriteLine(departamento.Descricao );
        //    }
        //}
        //static void CriarStoredProcedureDeConsulta()
        //{
        //    var criarDepartamento = @"
        //    CREATE OR ALTER PROCEDURE GetDepartamentos
        //        @Descricao varchar(50)
        //    AS
        //    BEGIN
        //        SELECT * FROM Departamentos WHERE Descricao Like @Descricao + '%'
        //    END
        //    ";

        //    using var db = new Data.ApplicationContext();

        //    db.Database.ExecuteSqlRaw(criarDepartamento);
        //}
        //static void InserirDadosViaProcedure()
        //{
        //    using var db = new ApplicationContext();

        //    db.Database.ExecuteSqlRaw("execute CriarDepartamento @p0, @p1", "Departamento Via Procedure", true);
        //}
        //static void CriarStoredProcedure()
        //{
        //    var criarDepartamento = @"
        //    CREATE OR ALTER PROCEDURE CriarDepartamento
        //        @Descricao varchar(50),
        //        @Ativo bit
        //    AS
        //    BEGIN
        //        INSERT INTO
        //            Departamentos(Descricao, Ativo, Excluido)
        //        VALUES(@descricao, @Ativo, 0)
        //    END
        //    ";

        //    using var db = new Data.ApplicationContext();

        //    db.Database.ExecuteSqlRaw(criarDepartamento);
        //}
        //static void DivisaoDeConsulta()
        //{
        //    using var db = new ApplicationContext();
        //    Setup(db);

        //    var departamentos = db.Departamentos
        //        .Include(p => p.Funcionarios)
        //        //.AsSplitQuery()
        //        .AsSingleQuery()
        //        .Where(p => p.Id < 3)
        //        .ToList();
        //    foreach (var departamento in departamentos)
        //    {
        //        Console.WriteLine($"Descrição: {departamento.Descricao}");
        //        foreach (var funcionario in departamento.Funcionarios)
        //        {
        //            Console.WriteLine($"\tNome: {funcionario.Nome}");
        //        }
        //    }
        //}
        //static void EntendendoConsulta1NN1()
        //{
        //    using var db = new ApplicationContext();
        //    Setup(db);

        //    /* // 1 para N
        //    var departamentos = db.Departamentos
        //        .Include(p=>p.Funcionarios)
        //        .ToList();

        //    foreach (var departamento in departamentos)
        //    {
        //        Console.WriteLine($"Descrição: {departamento.Descricao}");
        //        foreach (var funcionario in departamento.Funcionarios)
        //        {
        //            Console.WriteLine($"\tNome: {funcionario.Nome}");
        //        }
        //    }*/
        //    // N para 1
        //    var funcionarios = db.Funcionarios
        //       .Include(p => p.Departamento)
        //       .ToList();

        //   foreach (var funcionario in funcionarios)
        //   {
        //      Console.WriteLine($"Nome: {funcionario.Nome} / Descrição Dep: {funcionario.Departamento.Descricao}");
        //   }
        //}
        //static void ConsultaComTAG()
        //{
        //    using var db = new ApplicationContext();
        //    Setup(db);

        //    var departamentos = db.Departamentos
        //        .TagWith(@"Etou enviando um comentário para o servidor
        //        Segundo Comentário
        //        Terceiro Comentário")
        //        .ToList();

        //    foreach (var departamento in departamentos)
        //    {
        //        Console.WriteLine($"Descrição: {departamento.Descricao}");

        //    }
        //}
        //static void ConsultaInterpolada()
        //{
        //    using var db = new ApplicationContext();
        //    Setup(db);

        //    var id = 1;
        //    var departamentos = db.Departamentos
        //        .FromSqlInterpolated($"SELECT * FROM Departamentos WHERE Id> {id}")
        //        .ToList();

        //    foreach (var departamento in departamentos)
        //    {
        //        Console.WriteLine($"Descrição: {departamento.Descricao}");

        //    }
        //}
        //static void ConsultaParametrizada()
        //{
        //    using var db = new ApplicationContext();
        //    Setup(db);

        //    var id = new SqlParameter
        //    {
        //        Value = 1,
        //        SqlDbType = System.Data.SqlDbType.Int
        //    };
        //    var departamentos = db.Departamentos
        //        .FromSqlRaw("SELECT * FROM Departamentos WHERE Id>{0}", id)
        //        .Where(p => !p.Excluido)
        //        .ToList();

        //    foreach (var departamento in departamentos)
        //    {
        //        Console.WriteLine($"Descrição: {departamento.Descricao}");

        //    }
        //}
        //static void ConsultaProjetada()
        //{
        //    using var db = new ApplicationContext();
        //    Setup(db);

        //    var departamentos = db.Departamentos
        //        .Where(p => p.Id > 0)
        //        .Select(p => new { p.Descricao, Funcionarios = p.Funcionarios.Select(f => f.Nome) })
        //        .ToList();

        //    foreach (var departamento in departamentos)
        //    {
        //        Console.WriteLine($"Descrição: {departamento.Descricao}");

        //        foreach (var funcionario in departamento.Funcionarios)
        //        {
        //            Console.WriteLine($"Funcionário: {funcionario}");
        //        }
        //    }
        //}
        //static void IgnoreFiltroGlobal()
        //{
        //    using var db = new ApplicationContext();
        //    Setup(db);

        //    var departamentos = db.Departamentos.IgnoreQueryFilters().Where(p => p.Id > 0).ToList();

        //    foreach (var departamento in departamentos)
        //    {
        //        Console.WriteLine($"Descrição: {departamento.Descricao} \tExcluido: {departamento.Excluido}");
        //    }
        //}
        //static void FiltroGlobal()
        //{
        //    using var db = new ApplicationContext();
        //    Setup(db);

        //    var departamentos = db.Departamentos.Where(p => p.Id > 0).ToList();

        //    foreach (var departamento in departamentos)
        //    {
        //        Console.WriteLine($"Descrição: {departamento.Descricao} \tExcluido: {departamento.Excluido}");
        //    }
        //}
        //static void Setup(ApplicationContext db)
        //{
        //    if (db.Database.EnsureCreated())
        //    {
        //        db.Departamentos.AddRange(
        //            new Domain.Departamento
        //            {
        //                Ativo = true,
        //                Descricao = "Departamento 01",
        //                Funcionarios = new List<Domain.Funcionario>
        //                {
        //                    new Domain.Funcionario
        //                    {
        //                        Nome = "Rafael Almeida",
        //                        CPF = "99999999911",
        //                        RG = "2100062"
        //                    }
        //                },
        //                Excluido = true
        //            },
        //            new Domain.Departamento
        //            { 
        //                Ativo = true,
        //                Descricao = "Departamento 02",
        //                Funcionarios = new System.Collections.Generic.List<Domain.Funcionario>
        //                {
        //                    new Domain.Funcionario
        //                    {
        //                        Nome = "Bruno Brito",
        //                        CPF = "88888888811",
        //                        RG = "310062"
        //                    },
        //                    new Domain.Funcionario
        //                    {
        //                        Nome = "Eduardo Pires",
        //                        CPF = "77777777711",
        //                        RG = "110062"
        //                    }
        //                }
        //            });
        //        db.SaveChanges();
        //        db.ChangeTracker.Clear();
        //    }
        //}
        #endregion

        #region Infraestrutura
        //Infraestrutura
        //static void ExecutarEstrategiaResiliencia()
        //{
        //    using var db = new ApplicationContext();

        //    var strategy = db.Database.CreateExecutionStrategy();
        //    strategy.Execute(() =>
        //    {
        //        using var transaction = db.Database.BeginTransaction();

        //        db.Departamentos.Add(new Departamento { Descricao = "Departamento Transacao" });
        //        db.SaveChanges();

        //        transaction.Commit();
        //    });
        //}
        //static void TempoComandoGeral()
        //{
        //    using var db = new ApplicationContext();

        //    db.Database.SetCommandTimeout(10);

        //    db.Database.ExecuteSqlRaw("WAITFOR DELAY '00:00:07'; SELECT 1");
        //}
        //static void HabilitandoBatchSize()
        //{
        //    using var db = new ApplicationContext();
        //    db.Database.EnsureDeleted();
        //    db.Database.EnsureCreated();

        //    for (var i = 0; i < 50; i++)
        //    {
        //        db.Departamentos.Add(
        //            new Departamento
        //            {
        //                Descricao = "Departamento " + i
        //            });
        //    }
        //    db.SaveChanges();
        //}
        //static void DadosSensiveis()
        //{
        //    using var db = new ApplicationContext();

        //    var descricao = "Departamento";

        //    var departamentos = db.Departamentos.Where(p => p.Descricao == descricao).ToArray();
        //}
        //static void ConsultarDepartamentos()
        //{
        //    using var db = new ApplicationContext();

        //    var departamentos = db.Departamentos.Where(p => p.Id > 0).ToArray();
        //}
        #endregion
    }
}
