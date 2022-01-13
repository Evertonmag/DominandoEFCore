﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominandoEFCore.Domain
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
    }
    public class Instrutor : Pessoa
    {
        public DateTime Desde { get; set; }
        public string? Tecnologia { get; set; }
    }
    public class Aluno : Pessoa
    {
        public int Idade { get; set; }
        public DateTime DataContrato { get; set; }
    }
}
