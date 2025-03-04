using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposetories
{
    public class RatingReposetories : IRatingReposetories
    {
        MyShop328120357Context myShop;
        public RatingReposetories(MyShop328120357Context myShop)
        {
            this.myShop = myShop;
        }
        public async Task Post(Rating rating)
        {

            string connaction = "data source=srv2\\pupils;initial catalog=MyShop328120357;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=true";
            string query = "INSERT INTO RATING (HOST,METHOD,PATH,REFERER,USER_AGENT,Record_Date)" +
                "VALUES (@HOST,@METHOD,@PATH,@REFERER,@USER_AGENT,@Record_Date)";

            using (SqlConnection cn = new SqlConnection(connaction))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@HOST", SqlDbType.NVarChar,50).Value = rating.Host;
                cmd.Parameters.Add("@METHOD", SqlDbType.NChar, 10).Value = rating.Method;
                cmd.Parameters.Add("@PATH", SqlDbType.NVarChar,50).Value = rating.Path;
                cmd.Parameters.Add("@REFERER", SqlDbType.NVarChar, 100).Value = rating.Referer;
                cmd.Parameters.Add("@USER_AGENT", SqlDbType.NVarChar,1000).Value = rating.UserAgent;
                cmd.Parameters.Add("@Record_Date", SqlDbType.DateTime, 50).Value = rating.RecordDate;

                cn.Open();
                int rowAffected = await cmd.ExecuteNonQueryAsync();
                cn.Close();





            }


        }

    }
    
}
