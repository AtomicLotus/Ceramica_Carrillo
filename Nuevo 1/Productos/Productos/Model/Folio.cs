//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Folio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Folio()
        {
            this.DetalleFolio = new HashSet<DetalleFolio>();
        }
    
        public int IdFolio { get; set; }
        public double TotalVenta { get; set; }
        public System.DateTime FechaVenta { get; set; }
        public int IdPersonal { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleFolio> DetalleFolio { get; set; }
        public virtual Personal Personal { get; set; }
    }
}
