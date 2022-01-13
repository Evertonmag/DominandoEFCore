using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominandoEFCore.Domain
{
    public class Documento
    {
        private string _cpf;

        public int Id { get; set; }

        public void SetCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                throw new System.Exception("CPF Ivalido ");

            _cpf = cpf;
        }

        [BackingField(nameof(_cpf))]
        public string CPF => _cpf;

        public string GetCPF() => _cpf;
    }
}
