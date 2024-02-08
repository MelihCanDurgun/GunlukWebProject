using System.Data.SqlClient;

namespace Gunluk.Web
{
    public static class Db
    {
        public static SqlConnection Conn()
        {
            return new SqlConnection("Server=DESKTOP-3RLDHM4\\SQLEXPRESS; Database=Gunluk.Web; Integrated Security=True; TrustServerCertificate=Yes");
        }
    }
}
