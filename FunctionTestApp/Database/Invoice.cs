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
    
    public partial class Invoice
    {
        public int Invoice_ID { get; set; }
        public int Contract_ID { get; set; }
        public bool Settled { get; set; }
        public int Sum { get; set; }
        public double Sum_inclVAT { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Contract Contract { get; set; }
    }
}
