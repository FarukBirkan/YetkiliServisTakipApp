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
    
    public partial class TblKasaDurum
    {
        public int Id { get; set; }
        public Nullable<int> KasaId { get; set; }
        public Nullable<int> KasaGiris { get; set; }
        public Nullable<int> KasaCikis { get; set; }
        public string Aciklama { get; set; }
        public Nullable<decimal> ToplamKasa { get; set; }
    
        public virtual TblKasa TblKasa { get; set; }
        public virtual TblKasaCikis TblKasaCikis { get; set; }
        public virtual TblKasaGiris TblKasaGiris { get; set; }
    }
}
