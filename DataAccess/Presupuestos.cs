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
    
    public partial class Presupuestos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Presupuestos()
        {
            this.ConceptosFinancieros = new HashSet<ConceptosFinancieros>();
        }
    
        public int Id { get; set; }
        public double Gasto_tentativo { get; set; }
        public Nullable<double> Gasto_real { get; set; }
        public Nullable<int> IdEvento { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConceptosFinancieros> ConceptosFinancieros { get; set; }
        public virtual Eventos Eventos { get; set; }
    }
}
