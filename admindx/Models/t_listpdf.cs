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
    
    public partial class t_listpdf
    {
        public int id { get; set; }
        public string directorio { get; set; }
        public string nombre { get; set; }
        public long tamanio { get; set; }
        public Nullable<System.DateTime> fecha_modificacion { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public Nullable<System.DateTime> fecha_cargue { get; set; }
        public Nullable<int> ancho { get; set; }
        public Nullable<int> alto { get; set; }
        public Nullable<double> dpix { get; set; }
        public Nullable<double> dpiy { get; set; }
        public int paginas { get; set; }
        public Nullable<int> id_usuario { get; set; }
        public string ocr { get; set; }
        public Nullable<double> pag_ancho { get; set; }
        public Nullable<double> pag_alto { get; set; }
        public string escala_gris { get; set; }
        public Nullable<int> firma { get; set; }
        public Nullable<int> firma_valida { get; set; }
        public Nullable<double> dpi { get; set; }
        public string modificado { get; set; }
        public string metadata { get; set; }
        public string pdfa { get; set; }
        public string repetido { get; set; }
        public int id_proyecto { get; set; }
        public string msj_error { get; set; }
    
        public virtual p_proyecto p_proyecto { get; set; }
    }
}
