//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Actividades
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Actividades()
        {
            this.ConceptosFinancieros = new HashSet<ConceptosFinancieros>();
            this.Horarios = new HashSet<Horarios>();
            this.IncripcionActividades = new HashSet<IncripcionActividades>();
            this.Materiales = new HashSet<Materiales>();
            this.Tareas = new HashSet<Tareas>();
        }
    
        public int Id { get; set; }
        public int IdEvento { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool Gratuito { get; set; }
        public double Costo { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string Tipo { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public Nullable<int> IdArticulo { get; set; }
    
        public virtual Articulos Articulos { get; set; }
        public virtual Eventos Eventos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConceptosFinancieros> ConceptosFinancieros { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Horarios> Horarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IncripcionActividades> IncripcionActividades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Materiales> Materiales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tareas> Tareas { get; set; }
    }
}
