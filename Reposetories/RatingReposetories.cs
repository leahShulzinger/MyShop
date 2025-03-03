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
        MyShop214935017Context myShop;
        public RatingReposetories(MyShop214935017Context myShop)
        {
            this.myShop = myShop;
        }
        public async void Post(Rating rating)
        {
            string connection = "data source=srv2\\pupils;initial catalog=MyShop_214935017;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=true";
            string query = "INSERT INTO RATING (HOST, METHOD, PATH, REFERER, USER_AGENT, Record_Date) " +
                           "VALUES (@Host, @Method, @Path, @Referer, @UserAgent, @RecordDate)";

            using (SqlConnection cn = new SqlConnection(connection))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@Host", SqlDbType.NVarChar, 50).Value = rating.Host ;
                cmd.Parameters.Add("@Method", SqlDbType.NChar, 10).Value = rating.Method ;
                cmd.Parameters.Add("@Path", SqlDbType.NVarChar, 50).Value = rating.Path ;
                cmd.Parameters.Add("@Referer", SqlDbType.NVarChar, 100).Value = rating.Referer ;
                cmd.Parameters.Add("@UserAgent", SqlDbType.NVarChar, int.MaxValue).Value = rating.UserAgent;
                cmd.Parameters.Add("@RecordDate", SqlDbType.DateTime).Value = rating.RecordDate;

                int rowAffected = 0;
                await cn.OpenAsync();
                rowAffected = await cmd.ExecuteNonQueryAsync();
                cn.Close();
            }
        }

    }
    
}
