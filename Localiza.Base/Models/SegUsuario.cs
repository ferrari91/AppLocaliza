﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Localiza.Base.Models
{
    public partial class SegUsuario
    {
        public SegUsuario()
        {
            CadLocacao = new HashSet<CadLocacao>();
        }

        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<CadLocacao> CadLocacao { get; set; }
    }

    public class Usuario
    {
        public string usuario { get; set; }

        public string senha { get; set; }

    }

}