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
    
    public partial class OrderDetails
    {
        public int Detail_ID { get; set; }
        public int Accessory_ID { get; set; }
        public int Order_ID { get; set; }
    
        public virtual Accessory Accessory { get; set; }
        public virtual Order Order { get; set; }
    }
}