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
    
    public partial class usuarios
    {
        public usuarios()
        {
            this.reservaciones = new HashSet<reservaciones>();
        }
    
        public string idusuario { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string clave { get; set; }
        public int idpais { get; set; }
        public int idrol { get; set; }
    
        public virtual paises paises { get; set; }
        public virtual ICollection<reservaciones> reservaciones { get; set; }
        public virtual roles roles { get; set; }
    }
}
