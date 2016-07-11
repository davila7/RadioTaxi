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
    
    public partial class Reserva
    {
        public int Id_Reserva { get; set; }
        public int Cliente_Id { get; set; }
        public string RutConductor { get; set; }
        public string PatenteVehiculo { get; set; }
        public Nullable<System.DateTime> Fecha_trx { get; set; }
        public Nullable<System.DateTime> Fecha_viaje { get; set; }
        public string Lng_origen { get; set; }
        public string Lat_origen { get; set; }
        public string Dir_origen { get; set; }
        public string Lng_destino { get; set; }
        public string Lat_destino { get; set; }
        public string Dir_destino { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Conductor Conductor { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}
