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
    
    public partial class TBLYazar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLYazar()
        {
            this.TBLKitap = new HashSet<TBLKitap>();
        }
    
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Detay { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLKitap> TBLKitap { get; set; }
    }
}
