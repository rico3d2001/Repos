﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Brass.Materiais.Plant3dDiagramas.RepoSQLServerEF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Plant3d_PnIdEntities : DbContext
    {
        public Plant3d_PnIdEntities()
            : base("name=Plant3d_PnIdEntities")
        {
        }
     
        
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<PnPDrawings> PnPDrawings { get; set; }
    }
}
