//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjPortadorSindromeIrlen
{
    using System;
    using System.Collections.Generic;
    
    public partial class DepoimentoVideo
    {
        public int IdDepVideo { get; set; }
        public string Nome { get; set; }
        public int Tipo { get; set; }
        public string Titulo { get; set; }
        public string Video { get; set; }
    
        public virtual TipoDepoimento TipoDepoimento { get; set; }
    }
}
