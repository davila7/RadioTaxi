//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer6
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Tarifa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tarifa()
        {
            this.Empresa = new HashSet<Empresa>();
        }
    
        public int Id_Tarifa { get; set; }
        [DisplayName("Tarifa")]
        public string Desc_Tarifa { get; set; }
        [DisplayName("Valor Bandera")]
        public int Valor_bndra { get; set; }
        [DisplayName("Valor Metros")]
        public int Valor_mts { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
