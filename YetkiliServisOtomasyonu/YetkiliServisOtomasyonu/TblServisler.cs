//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YetkiliServisOtomasyonu
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblServisler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblServisler()
        {
            this.TblServisDurum = new HashSet<TblServisDurum>();
        }
    
        public int Id { get; set; }
        public Nullable<int> CariId { get; set; }
        public Nullable<System.DateTime> ServisTarihi { get; set; }
        public Nullable<bool> ServisDurum { get; set; }
        public string ServisAciklama { get; set; }
        public string KayitEden { get; set; }
        public Nullable<System.DateTime> KayitTarih { get; set; }
        public string Aciklama { get; set; }
        public string TalepSaat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblServisDurum> TblServisDurum { get; set; }
        public virtual TblCari TblCari { get; set; }
    }
}
