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
    
    public partial class p_usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public p_usuario()
        {
            this.p_usuario_perfil = new HashSet<p_usuario_perfil>();
            this.t_carpeta = new HashSet<t_carpeta>();
            this.t_carpeta1 = new HashSet<t_carpeta>();
            this.t_carpeta_estado = new HashSet<t_carpeta_estado>();
            this.t_carpeta2 = new HashSet<t_carpeta>();
        }
    
        public int id { get; set; }
        public int identificacion { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string clave { get; set; }
        public string telefono { get; set; }
        public int activo { get; set; }
        public string usuario { get; set; }
        public p_usuario_perfil perfil { get; set; }
    
        public virtual p_estado p_estado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<p_usuario_perfil> p_usuario_perfil { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_carpeta> t_carpeta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_carpeta> t_carpeta1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_carpeta_estado> t_carpeta_estado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_carpeta> t_carpeta2 { get; set; }
    }
}
