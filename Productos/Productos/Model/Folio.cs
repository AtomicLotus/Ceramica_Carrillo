//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CeramicaCarrillo.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Folio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Folio()
        {
            this.DetalleFolio = new HashSet<DetalleFolio>();
            this.Abonos = new HashSet<Abonos>();
        }
    
        public int IdFolio { get; set; }
        public double TotalVenta { get; set; }
        public System.DateTime FechaVenta { get; set; }
        public int IdPersonal { get; set; }
        public bool Status { get; set; }
        public double Faltante { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleFolio> DetalleFolio { get; set; }
        public virtual Personal Personal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Abonos> Abonos { get; set; }
    }
}
