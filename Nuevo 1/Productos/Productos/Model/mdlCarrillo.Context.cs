﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Productos.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BDCarrilloEntities : DbContext
    {
        public BDCarrilloEntities()
            : base("name=BDCarrilloEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Actividades> Actividades { get; set; }
        public virtual DbSet<Anomalias> Anomalias { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<DetalleFolio> DetalleFolio { get; set; }
        public virtual DbSet<Folio> Folio { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Solicitudes> Solicitudes { get; set; }
        public virtual DbSet<TipoProductos> TipoProductos { get; set; }
    }
}