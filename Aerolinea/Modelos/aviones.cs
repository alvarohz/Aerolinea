//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aerolinea.Modelos
{
    using System;
    using System.Collections.Generic;
    
    public partial class aviones
    {
        public aviones()
        {
            this.vuelos = new HashSet<vuelos>();
        }
    
        public int idavion { get; set; }
        public int capacidad { get; set; }
        public string descripcion { get; set; }
    
        public virtual ICollection<vuelos> vuelos { get; set; }
    }
}