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
    
    public partial class Conductor_vehiculo
    {
        public string RutConductor { get; set; }
        public string PatenteVehiculo { get; set; }
        public int Id_cond_vehi { get; set; }
    
        public virtual Conductor Conductor { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}
