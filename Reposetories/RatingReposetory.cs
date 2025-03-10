﻿using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposetories
{
    public class RatingReposetory : IRatingReposetory
    {
        MyShop328120357Context myShop;
        public RatingReposetory(MyShop328120357Context myShop)
        {
            this.myShop = myShop;

        }
        //public async Task<Rating> Post(Rating rating)
        //{
        //    await myShop.Rating.AddAsync(rating);
        //    await myShop.SaveChangesAsync();
        //    return rating;
        //}
        public async Task<Rating> Post(Rating rating)
        {

            string connaction = "data source=srv2\\pupils;initial catalog=MyShop_328120357;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=true";
            string query = "INSERT INTO RATING (HOST,METHOD,PATH,REFERE,USERAGENT,RECORDDATE)" +
                "VALUES (@Host,@Method,@Path,@Referer,@UserAgent,@RecordDate)";

            using (SqlConnection cn = new SqlConnection(connaction))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@Host", SqlDbType.Int).Value = rating.Host;
                cmd.Parameters.Add("@Method", SqlDbType.NChar, 20).Value = rating.Method;
                cmd.Parameters.Add("@Path", SqlDbType.NVarChar, int.MaxValue).Value = rating.Path;
                cmd.Parameters.Add("@Referer", SqlDbType.NVarChar, 50).Value = rating.Referer;
                cmd.Parameters.Add("@UserAgent", SqlDbType.NVarChar, 50).Value = rating.UserAgent;
                cmd.Parameters.Add("@RecordDate", SqlDbType.NVarChar, 50).Value = rating.RecordDate;

                cn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                cn.Close();




                return rating;

            }


        }

    }
}
