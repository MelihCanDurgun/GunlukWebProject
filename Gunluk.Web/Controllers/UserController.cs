using Gunluk.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Drawing;

namespace Gunluk.Web.Controllers
{
    public class UserController : Controller
    {
        
        public IActionResult Index()
        {             
                return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            if (ModelState.IsValid) // Kullanıcı adı ve şifrenin doğruluğunu kontrol etmeden önce modelin doğruluğunu kontrol et
            {
                if (!string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password)) // Kullanıcı adı ve şifre boş olmamalı
                {
                    SqlConnection conn = Db.Conn();
                    SqlCommand cmd = new SqlCommand("SELECT Id FROM Users WHERE Username=@username AND Password=@password", conn);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    conn.Open();
                    var sonuc = cmd.ExecuteScalar();
                    conn.Close();
                    if (sonuc != null)
                    {
                        Console.WriteLine("Hoşgeldiniz");
                        return RedirectToAction("Index", "Daily");

                    }
                }
            }
            Console.WriteLine("Kullanıcı Adı veya Şifre Yanlış");
            return View();
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            SqlConnection conn = Db.Conn();
            SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, Password) VALUES (@Username, @password)", conn);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Password", user.Password);

            conn.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            TempData["success"] = "Ekleme işlemi başarıyla tamamlandı";
            return RedirectToAction("Index");


        }
    }
}
