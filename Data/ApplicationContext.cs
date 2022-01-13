using DominandoEFCore.Configurations;
using DominandoEFCore.Conversores;
using DominandoEFCore.Domain;
using DominandoEFCore.Funcoes;
using DominandoEFCore.Interceptadores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace DominandoEFCore.Data
{
    internal class ApplicationContext : DbContext
    {
        //private readonly StreamWriter _writer = new StreamWriter("meu_log_do_ef_core.txt", append: true);

        #region DbSets
        public DbSet<Departamento>? Departamentos { get; set; }
        public DbSet<Funcionario>? funcionarios { get; set; }
        //public DbSet<Conversor>? Conversores { get; set; }
        //public DbSet<Cliente>? Clientes { get; set; }
        //public DbSet<Estado>? Estados { get; set;}
        //public DbSet<Ator>? Atores { get; set; }
        //public DbSet<Filme>? Filmes { get; set; }
        //public DbSet<Documento>? Documentos { get; set; }
        //public DbSet<Pessoa>? Pessoas { get; set; }
        //public DbSet<Instrutor>? Instrutores { get; set; }
        //public DbSet<Aluno>? Alunos { get; set; }
        //public DbSet<Atributo>? Atributos { get; set; }
        //public DbSet<Aeroporto>? Aeroportos { get; set; }
        //public DbSet<Dictionary<string, object>> Configuracoes => Set< Dictionary<string, object> > ("Configuracoes");
        //public DbSet<Funcao>? Funcoes { get; set; }
        //public DbSet<Livro>? Livros { get; set; }
        #endregion

        #region Consultas_infraestrutura
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    /*
        //     * //Consultas
        //    const string strConnection = "Data source=(localdb)\\mssqllocaldb; Initial Catalog=DevIO-02;Integrated Security=true";
        //    optionsBuilder
        //        //.UseSqlServer(strConnection, p=>p.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery))
        //        .UseSqlServer(strConnection)
        //        .EnableSensitiveDataLogging()
        //        .LogTo(Console.WriteLine, LogLevel.Information);
        //    */
        //    // Infraesrtutura
        //
        //    const string connectionString = "Insira a linha de conexao";
        //
        //    optionsBuilder
        //        .UseSqlServer(
        //            connectionString,
        //                o => o
        //                    .MaxBatchSize(100)
        //                    .CommandTimeout(5)
        //                    .EnableRetryOnFailure(4, TimeSpan.FromSeconds(10), null))
        //        .LogTo(Console.WriteLine, LogLevel.Information)
        //        /*//ConsultarDepartamentos
        //         * .LogTo(Console.WriteLine,
        //            new[] {CoreEventId.ContextInitialized, RelationalEventId.CommandExecuted},
        //            LogLevel.Information,
        //            DbContextLoggerOptions.LocalTime | DbContextLoggerOptions.SingleLine 
        //            )
        //        */
        //        //DadosSensiveis
        //        //.LogTo(_writer.WriteLine, LogLevel.Information)
        //        //.EnableDetailedErrors()
        //        .EnableSensitiveDataLogging()
        //        ; 
        //}
        //// Consultas
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    //modelBuilder.Entity<Departamento>().HasQueryFilter(p => !p.Excluido);
        //} 

        //public override void Dispose()
        //{
        //    base.Dispose();
        //    _writer.Dispose();
        //}
        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "Insira a linha de conexao";

            optionsBuilder
                .UseSqlServer(connectionString)
                //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        #region Interceptadores
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    

        //    optionsBuilder
        //        .UseSqlServer(connectionString)
        //        .LogTo(Console.WriteLine, LogLevel.Information)
        //        .EnableSensitiveDataLogging()
        //        .AddInterceptors(new InteceptadorDeComandos())
        //        .AddInterceptors(new InterceptadoresDeConexao())
        //        .AddInterceptors(new InterceptadorPersistencia());
        //}
        #endregion

        #region UDFs
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //MinhasFuncoes.RegistrarFuncoes(modelBuilder);

        //    modelBuilder
        //        .HasDbFunction(_minhaFuncao)
        //        .HasName("LEFT")
        //        .IsBuiltIn();

        //    modelBuilder
        //        .HasDbFunction(_letrasMaiusculas)
        //        .HasName("ConverterParaLetrasMaiusculas")
        //        .HasSchema("dbo");

        //    modelBuilder
        //        .HasDbFunction(_dateDiff)
        //        .HasName("DATEDIFF")
        //        .HasTranslation(p =>
        //        {
        //            var argumentos = p.ToList();

        //            var constante = (SqlConstantExpression)argumentos[0];
        //            argumentos[0] = new SqlFragmentExpression(constante.Value.ToString());

        //            return new SqlFunctionExpression("DATEDIFF", argumentos, false, new[] { false, false, false }, typeof(int), null );
        //        })
        //        .IsBuiltIn();
        //}

        //private static MethodInfo _minhaFuncao = typeof(MinhasFuncoes)
        //        .GetRuntimeMethod("Left", new[] { typeof(string), typeof(int) });

        //private static MethodInfo _letrasMaiusculas = typeof(MinhasFuncoes)
        //        .GetRuntimeMethod(nameof(MinhasFuncoes.LetrasMaiusculas), new[] { typeof(string) });

        //private static MethodInfo _dateDiff = typeof(MinhasFuncoes)
        //        .GetRuntimeMethod(nameof(MinhasFuncoes.DateDiff), new[] { typeof(string), typeof(DateTime), typeof(DateTime) });

        ////[DbFunction(name: "LEFT", IsBuiltIn = true)]
        ////public static string Left(string dados, int quantidade)
        ////{
        ////    throw new NotImplementedException();
        ////}
        #endregion

        #region EF Functions
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .Entity<Funcao>(conf =>
        //        {
        //            conf.Property<string>("PropriedadeSombra")
        //                .HasColumnType("VARCHAR(100)")
        //                .HasDefaultValueSql("'Teste'");
        //        });
        //}
        #endregion

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    /*
        //    // Collations
        //    modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AI");
        //    //RAFAEL -> rafael
        //    //João -> Joao

        //    modelBuilder.Entity<Departamento>().Property(p => p.Descricao).UseCollation("SQL_Latin1_General_CP1_CI_AS");

        //    // Sequencias
        //    modelBuilder.HasSequence<int>("MinhaSequencia", "sequencias")
        //        .StartsAt(1)
        //        .IncrementsBy(2)
        //        .HasMin(1)
        //        .HasMax(10)
        //        .IsCyclic();

        //    modelBuilder.Entity<Departamento>().Property(p => p.Id).HasDefaultValueSql("NEXT VALUE FOR sequencias.MinhaSequencia");

        //    // Indices
        //    modelBuilder
        //        .Entity<Departamento>()
        //        .HasIndex(p => new { p.Descricao, p.Ativo })
        //        .HasDatabaseName("idx_meu_indice_composto")
        //        .HasFilter("descricao IS NOT NULL")
        //        .HasFillFactor(80)
        //        .IsUnique();

        //    // Propagação de dados
        //    modelBuilder.Entity<Estado>().HasData(new[]
        //    {
        //        new Estado { Id = 1, Nome = "São Paulo"},
        //        new Estado { Id = 2, Nome = "Sergipe"}
        //    });

        //    // Esquemas
        //    modelBuilder.HasDefaultSchema("cadastros");

        //    modelBuilder.Entity<Estado>().ToTable("Estado", "segundo Esquema");

        //    // Conversores de Valores
        //    var conversao = new ValueConverter<Versao, string>(p => p.ToString(), p => (Versao)Enum.Parse(typeof(Versao), p));

        //    var conversao1 = new EnumToStringConverter<Versao>();

        //    modelBuilder
        //        .Entity<Conversor>()
        //        .Property(p => p.Versao)
        //        .HasConversion(conversao1);
        //    //.HasConversion(conversao);
        //    //.HasConversion(p => p.ToString(), p => (Versao)Enum.Parse(typeof(Versao), p));
        //    //.HasConversion<string>();

        //    // Criando um conversor de valor customizado
        //    modelBuilder
        //        .Entity<Conversor>()
        //        .Property(p => p.Status)
        //        .HasConversion(new ConversorCustomizado());

        //    // Consfigurando uma propriedade de sombra
        //    modelBuilder
        //        .Entity<Departamento>()
        //        .Property<DateTime>("UltimaAtualizacao");
        //    */

        //    //modelBuilder.ApplyConfiguration(new CLienteConfiguration());
        //    //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

        //    // Sacola de Propriedades
        //    modelBuilder.SharedTypeEntity<Dictionary<string, object>>("Configuracoes", b =>
        //    {
        //        b.Property<int>("Id");

        //        b.Property<string>("Chave")
        //            .HasColumnType("Varchar(40)")
        //            .IsRequired();

        //        b.Property<string>("Valor")
        //            .HasColumnType("Varchar(255)")
        //            .IsRequired();
        //    });

        //}
    }
}
