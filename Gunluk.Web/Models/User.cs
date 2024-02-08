namespace Gunluk.Web.Models
{
    public class User : BaseModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
       
        public string Password { get; set; }
    }
}
