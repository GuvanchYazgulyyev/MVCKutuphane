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
    
    public partial class TBLKitap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLKitap()
        {
            this.TBLHareket = new HashSet<TBLHareket>();
        }
    
        public int ID { get; set; }
        public string Ad { get; set; }
        public Nullable<byte> Kategori { get; set; }
        public Nullable<int> Yazar { get; set; }
        public string BasimYil { get; set; }
        public string YayinEvi { get; set; }
        public string Sayfa { get; set; }
        public Nullable<bool> Durum { get; set; }
        public string KitapGorsel { get; set; }
    
        public virtual TBLKategori TBLKategori { get; set; }
        public virtual TBLYazar TBLYazar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLHareket> TBLHareket { get; set; }
    }
}
