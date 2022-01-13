using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DominandoEFCore.Domain
{
    public class Departamento
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }

        public byte[]? Image { get; set; }

        public List<Funcionario>? Funcionarios { get; set; }

        /*
        //Lazy Load - Não esta com o pacote Microsoft.EntityFrameworkCore.Proxies    
        //tipo 1
        public Departamento()
        {
        }

        private Action<object, string> _lazyLoader { get; set; }
        private Departamento(Action<object, string> lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        private List<Funcionario>? _Funcionarios;
        public List<Funcionario>? Funcionarios
        {
            get
            {
                _lazyLoader?.Invoke(this, nameof(Funcionarios));

                return _Funcionarios;
            }
            set => _Funcionarios = value;
        }

        //Tipo 2
        private ILazyLoader _lazyLoader { get; set; }
        private Departamento(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        private List<Funcionario>? _Funcionarios;
        public  List<Funcionario>? Funcionarios 
        {
            get => _lazyLoader.Load(this, ref _Funcionarios);
            set => _Funcionarios = value;
        }
        */
    }
}