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
    
    public partial class Solicitudes
    {
        public string idSolicitudes { get; set; }
        public string Descripcion { get; set; }
        public string Status { get; set; }
        public int IdPersonal { get; set; }
        public int IdProductos { get; set; }
    
        public virtual Personal Personal { get; set; }
        public virtual Productos Productos { get; set; }
    }
}
