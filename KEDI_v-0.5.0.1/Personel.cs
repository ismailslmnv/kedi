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
    
    public partial class Personel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personel()
        {
            this.Siparislers = new HashSet<Siparisler>();
            this.GirisLogs = new HashSet<GirisLog>();
        }
    
        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public int YetkiID { get; set; }
        public string Sifre { get; set; }
        public System.DateTime Tarih { get; set; }
        public string TelefonNum { get; set; }
        public bool Aktif { get; set; }
        public bool Enabled { get; set; }
        public Nullable<System.DateTime> DisableTarih { get; set; }
    
        public virtual Yetkiler Yetkiler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Siparisler> Siparislers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GirisLog> GirisLogs { get; set; }
    }
}
