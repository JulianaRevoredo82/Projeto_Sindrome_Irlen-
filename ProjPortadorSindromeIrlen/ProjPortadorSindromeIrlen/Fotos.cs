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
    
    public partial class Fotos
    {
        public int IdFoto { get; set; }
        public string Foto { get; set; }
        public string Nome { get; set; }
        public int Cidade { get; set; }
        public int Estado { get; set; }
    
        public virtual Cidade Cidade1 { get; set; }
        public virtual Estado Estado1 { get; set; }
    }
}
