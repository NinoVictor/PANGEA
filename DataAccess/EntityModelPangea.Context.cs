﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PangeaConnection : DbContext
    {
        public PangeaConnection()
            : base("name=PangeaConnection")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Actividades> Actividades { get; set; }
        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<Asistentes> Asistentes { get; set; }
        public virtual DbSet<Comites> Comites { get; set; }
        public virtual DbSet<ConceptosFinancieros> ConceptosFinancieros { get; set; }
        public virtual DbSet<Cuentas> Cuentas { get; set; }
        public virtual DbSet<Eventos> Eventos { get; set; }
        public virtual DbSet<Horarios> Horarios { get; set; }
        public virtual DbSet<Materiales> Materiales { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<Presupuestos> Presupuestos { get; set; }
        public virtual DbSet<Tareas> Tareas { get; set; }
        public virtual DbSet<Tracks> Tracks { get; set; }
        public virtual DbSet<AsistentesEvento> AsistentesEvento { get; set; }
        public virtual DbSet<IncripcionActividades> IncripcionActividades { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
