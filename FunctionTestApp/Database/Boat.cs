//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FunctionTestApp.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Boat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Boat()
        {
            this.AccToBoats = new HashSet<AccToBoats>();
            this.Order = new HashSet<Order>();
        }
    
        public int Boat_ID { get; set; }
        public string Model { get; set; }
        public string BoatType { get; set; }
        public Nullable<int> NumberOfRowers { get; set; }
        public bool Mast { get; set; }
        public string Colour { get; set; }
        public string Wood { get; set; }
        public Nullable<int> BasePrice { get; set; }
        public Nullable<double> VAT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccToBoats> AccToBoats { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
