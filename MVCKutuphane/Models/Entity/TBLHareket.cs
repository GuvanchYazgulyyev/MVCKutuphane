//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCKutuphane.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLHareket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLHareket()
        {
            this.TBLCeza = new HashSet<TBLCeza>();
        }
    
        public int ID { get; set; }
        public Nullable<int> Kitap { get; set; }
        public Nullable<int> Uye { get; set; }
        public Nullable<byte> Personel { get; set; }
        public Nullable<System.DateTime> AlisTarih { get; set; }
        public Nullable<System.DateTime> IadeTarih { get; set; }
        public Nullable<bool> islemDurum { get; set; }
        public Nullable<System.DateTime> UyeGetirTarih { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLCeza> TBLCeza { get; set; }
        public virtual TBLUyeler TBLUyeler { get; set; }
        public virtual TBLKitap TBLKitap { get; set; }
        public virtual TBLPersonel TBLPersonel { get; set; }
    }
}
