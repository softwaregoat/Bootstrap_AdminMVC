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
    
    public partial class t_lote
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_lote()
        {
            this.t_carpeta = new HashSet<t_carpeta>();
        }
    
        public int id { get; set; }
        public string nom_lote { get; set; }
        public Nullable<int> id_subdependencia { get; set; }
        public Nullable<int> id_subserie { get; set; }
        public Nullable<int> id_proyecto { get; set; }
        public System.DateTime fecha_ingreso { get; set; }
        public string marco { get; set; }
    
        public virtual p_proyecto p_proyecto { get; set; }
        public virtual p_subdependencia p_subdependencia { get; set; }
        public virtual p_subserie p_subserie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_carpeta> t_carpeta { get; set; }
    }
}
