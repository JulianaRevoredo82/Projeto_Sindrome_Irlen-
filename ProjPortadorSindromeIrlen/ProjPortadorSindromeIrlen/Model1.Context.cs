﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SindromeIrlenEntities5 : DbContext
    {
        public SindromeIrlenEntities5()
            : base("name=SindromeIrlenEntities5")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adm> Adm { get; set; }
        public virtual DbSet<CategoriaProfissionais> CategoriaProfissionais { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<DepoimentoLeitura> DepoimentoLeitura { get; set; }
        public virtual DbSet<DepoimentoVideo> DepoimentoVideo { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Fotos> Fotos { get; set; }
        public virtual DbSet<Parceiros> Parceiros { get; set; }
        public virtual DbSet<Profissionais> Profissionais { get; set; }
        public virtual DbSet<QuemSomos> QuemSomos { get; set; }
        public virtual DbSet<Screnner> Screnner { get; set; }
        public virtual DbSet<TipoDepoimento> TipoDepoimento { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}
