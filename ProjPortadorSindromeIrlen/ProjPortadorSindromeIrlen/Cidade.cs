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
    
    public partial class Cidade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cidade()
        {
            this.DepoimentoLeitura = new HashSet<DepoimentoLeitura>();
            this.Fotos = new HashSet<Fotos>();
            this.Profissionais = new HashSet<Profissionais>();
            this.Screnner = new HashSet<Screnner>();
        }
    
        public int IdCidade { get; set; }
        public string Cidade1 { get; set; }
        public int Estado { get; set; }
    
        public virtual Estado Estado1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepoimentoLeitura> DepoimentoLeitura { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fotos> Fotos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Profissionais> Profissionais { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Screnner> Screnner { get; set; }
    }
}
