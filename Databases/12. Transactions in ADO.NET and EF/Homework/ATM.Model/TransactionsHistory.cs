//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ATM.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TransactionsHistory
    {
        public int TransactionId { get; set; }
        public string CardNumber { get; set; }
        public System.DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
    }
}
