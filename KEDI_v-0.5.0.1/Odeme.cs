//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KEDI_v_0._5._0._1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Odeme
    {
        public int OdemeID { get; set; }
        public int SiparisID { get; set; }
        public int OdemeYontemi { get; set; }
        public Nullable<int> IndirimID { get; set; }
        public string Notlar { get; set; }
        public System.DateTime Tarih { get; set; }
    
        public virtual Indirimler Indirimler { get; set; }
        public virtual Siparisler Siparisler { get; set; }
    }
}
