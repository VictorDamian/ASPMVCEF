﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AspMvcEF.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PRACTICAMVCEntities : DbContext
    {
        public PRACTICAMVCEntities()
            : base("name=PRACTICAMVCEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<USERS> USERS { get; set; }
        public virtual DbSet<USTATE> USTATE { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEE { get; set; }
    }
}
