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
    
    public partial class Empresa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empresa()
        {
            this.Cliente = new HashSet<Cliente>();
        }
    
        public int Id_empr { get; set; }
        public string Rut { get; set; }
        public string Dig { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public Nullable<int> Descuento { get; set; }
        public string FormaDePago { get; set; }
        public Nullable<int> Tarifa_id { get; set; }
        public int IdDireccion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual Direccion Direccion { get; set; }
        public virtual Tarifa Tarifa { get; set; }
    }
}
