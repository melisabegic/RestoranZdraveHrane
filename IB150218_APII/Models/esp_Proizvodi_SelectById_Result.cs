//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IB150218_APII.Models
{
    using System;
    
    public partial class esp_Proizvodi_SelectById_Result
    {
        public int ProizvodID { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public decimal Cijena { get; set; }
        public int VrstaID { get; set; }
        public int JedinicaMjereID { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public bool Status { get; set; }
        public string VrstaProizvoda { get; set; }
        public Nullable<decimal> ProsjecnaOcjena { get; set; }
    }
}
