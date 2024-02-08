namespace Gunluk.Web.Models
{
    public class Content : BaseModel
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int GunlukId { get; set; }
    }
}
