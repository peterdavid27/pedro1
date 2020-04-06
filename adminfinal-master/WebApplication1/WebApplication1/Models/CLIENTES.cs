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

    public partial class CLIENTES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENTES()
        {
            this.RECEPCION = new HashSet<RECEPCION>();
        }
    
        public int ID_CLIENTE { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string CEDULA { get; set; }
        public string GENERO { get; set; }
        public string TELEFONO { get; set; }
        public Nullable<int> SUCURSAL { get; set; }
        [EmailAddress]
        public string CORREO { get; set; }
        public string USUARIO { get; set; }
        [Key]
        public string CLAVE { get; set; }
    
        public virtual SUCURSAL SUCURSAL1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RECEPCION> RECEPCION { get; set; }
    }
}