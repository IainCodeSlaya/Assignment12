//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sale_Line_Pet
    {
        public int Pet_ID { get; set; }
        public int Sale_ID { get; set; }
        public Nullable<int> Pet_Sale_Q { get; set; }
    
        public virtual Pet Pet { get; set; }
        public virtual Sale_Pet Sale_Pet { get; set; }
    }
}
