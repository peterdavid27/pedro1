//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class SUCURSAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUCURSAL()
        {
            this.CLIENTES = new HashSet<CLIENTES>();
            this.RECEPCION = new HashSet<RECEPCION>();
        }
    
        public int ID_SUCURSAL { get; set; }

        [Display(Name ="Sucursal")]
        public string NOMBRE { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string CORREO { get; set; }
        public string HORARIO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTES> CLIENTES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RECEPCION> RECEPCION { get; set; }
    }
}
