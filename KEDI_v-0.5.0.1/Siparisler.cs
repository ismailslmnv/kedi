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
    
    public partial class Siparisler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Siparisler()
        {
            this.Odemes = new HashSet<Odeme>();
        }
    
        public int SiparisID { get; set; }
        public string SiparisAdi { get; set; }
        public int MasaID { get; set; }
        public int UrunID { get; set; }
        public decimal UrunSayi { get; set; }
        public System.DateTime Tarih { get; set; }
        public int KullaniciID { get; set; }
        public string Notlar { get; set; }
    
        public virtual Masalar Masalar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Odeme> Odemes { get; set; }
        public virtual Personel Personel { get; set; }
        public virtual Urunler Urunler { get; set; }
    }
}
