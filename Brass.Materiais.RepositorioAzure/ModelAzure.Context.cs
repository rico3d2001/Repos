﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Brass.Materiais.RepositorioAzure
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CatalogoBRASSEntities : DbContext
    {
        public CatalogoBRASSEntities()
            : base("name=CatalogoBRASSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CatalogoPlant3d> CatalogoPlant3d { get; set; }
        public virtual DbSet<CT_Idioma> CT_Idioma { get; set; }
        public virtual DbSet<ItemEngenharia> ItemEngenharia { get; set; }
        public virtual DbSet<PropriedadeEng> PropriedadeEng { get; set; }
        public virtual DbSet<PropriedadeItemEng> PropriedadeItemEng { get; set; }
        public virtual DbSet<PrpiedadesRelacionadas> PrpiedadesRelacionadas { get; set; }
        public virtual DbSet<TipoItem> TipoItem { get; set; }
        public virtual DbSet<TipoPropriedade> TipoPropriedade { get; set; }
        public virtual DbSet<Valores> Valores { get; set; }
    }
}