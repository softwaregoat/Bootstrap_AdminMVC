//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace admindx.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_tercero
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_tercero()
        {
            this.t_carpeta = new HashSet<t_carpeta>();
            this.t_documento_tercero = new HashSet<t_documento_tercero>();
        }
    
        public int id { get; set; }
        public string identificacion { get; set; }
        public string nombres { get; set; }
        public string tipo_documento { get; set; }
        public Nullable<int> nro_tarjeta { get; set; }
        public string tipo_tercero { get; set; }
        public string lugar_exp { get; set; }
        public string apellidos { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_carpeta> t_carpeta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_documento_tercero> t_documento_tercero { get; set; }
    }
}
