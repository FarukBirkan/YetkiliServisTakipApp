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
    
    public partial class TblCariTür
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblCariTür()
        {
            this.TblCari = new HashSet<TblCari>();
        }
    
        public int Id { get; set; }
        public string CariTürAdi { get; set; }
        public string CariTürAciklama { get; set; }
        public string KayitEden { get; set; }
        public Nullable<System.DateTime> KayitTarih { get; set; }
        public string Aciklama { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblCari> TblCari { get; set; }
    }
}
