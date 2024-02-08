namespace Gunluk.Web.Models
{
    public class BaseModel
    {

        public int KullaniciId { get; set; }
        public int GunlukId { get; set; }
        public DateTime DateCreated { get; set; }= DateTime.Now;
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }


    }
}
