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
    
    public partial class p_tipodoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public p_tipodoc()
        {
            this.p_tipoitem = new HashSet<p_tipoitem>();
            this.t_documento = new HashSet<t_documento>();
        }
        public int id { get; set; }
        public int id_subserie { get; set; }
        public string cod { get; set; }
        public string nombre { get; set; }
        public string img { get; set; }
        public int multiterceros { get; set; }
        public int principal { get; set; }
        public bool excluir { get; set; }

        public IEnumerable<p_tipoitem> items { get; set; }
        public IEnumerable<int> id_subseries { get; set; }
    
        public virtual p_subserie p_subserie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<p_tipoitem> p_tipoitem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_documento> t_documento { get; set; }

    }
}