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
    
    public partial class t_documento_tercero
    {
        public int id { get; set; }
        public int id_documento { get; set; }
        public int id_tercero { get; set; }
    
        public virtual t_documento t_documento { get; set; }
        public virtual t_tercero t_tercero { get; set; }
    }
}
