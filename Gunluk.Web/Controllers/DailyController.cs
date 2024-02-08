using Gunluk.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Gunluk.Web.Controllers
{
    public class DailyController : Controller
    {
        public IActionResult Index()
        {
            List<Daily> daily = new List<Daily>();
            SqlConnection conn = Db.Conn();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Dailys ", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                daily.Add(new Daily { GunlukId = (int)dr["Id"], DateCreated = (DateTime)dr["DateCreated"], Title = (string)dr["Title"], Description = (string)dr["Description"] });
            }
            conn.Close();
            return View(daily);

        }
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(Daily daily)
        {
            SqlConnection conn = Db.Conn();
            SqlCommand cmd = new SqlCommand("INSERT INTO Dailys (title, description, DateCreated) VALUES (@Title, @Description, @DateCreated)", conn);
            cmd.Parameters.AddWithValue("@Title", daily.Title);
            cmd.Parameters.AddWithValue("@Description", daily.Description);
            cmd.Parameters.AddWithValue("@DateCreated", daily.DateCreated);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            TempData["success"] = "Ekleme işlemi başarıyla tamamlandı";
            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            //Bize gönderilen Kategori id'si ile veritabanından ilgili kategorinin bütün bilgilerini çekip, sonrasında, bize İÇİ BU BİLGİLERLE DOLU bir sayfa return etmek için
            SqlConnection conn = Db.Conn();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Dailys WHERE Id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
           
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            Daily daily = new Daily
            {
                GunlukId = (int)dr["Id"],
                DateCreated = (DateTime)dr["DateCreated"],
                Title = (string)dr["Title"],
                Description = (string)dr["Description"]
            };
            
            conn.Close();
            return View(daily);

        }
        [HttpPost]
        public IActionResult Update(Daily daily)
        {
            SqlConnection conn = Db.Conn();
            SqlCommand cmd = new SqlCommand("UPDATE Dailys SET Title=@Title, Description=@Description WHERE Id=@id", conn);
            cmd.Parameters.AddWithValue("@id", daily.Id);
            cmd.Parameters.AddWithValue("@Title", daily.Title);
            cmd.Parameters.AddWithValue("@Description", daily.Description);
            cmd.Parameters.AddWithValue("@DateCreated", daily.DateCreated);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            TempData["success"] = "Güncelleme işlemi başarılı !";
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            SqlConnection conn = Db.Conn();
            SqlCommand cmd = new SqlCommand("DELETE FROM Dailys WHERE Id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            TempData["success"] = "SİLME işlemi başarılı !";
            return RedirectToAction("Index");
        }




    }
}
