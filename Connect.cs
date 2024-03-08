using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testapp
{
    public class Connect
    {
        public static DataSet ds = new DataSet();
        public static DataTable dt = new DataTable();

        public static NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Username=postgres;Password=123456;Database=demo;");

        public static void bind_data(string sql)
        {
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            conn.Close();
        }

        public void SQLtoDBwithChanges(string sql)
        {
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Product> getlistproducts(string sql)
        {
            bind_data(sql);
            List<Product> products = new List<Product>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Product product = new Product();
                product.title = dt.Rows[i][1].ToString();
                product.producttypeid = Convert.ToInt32(dt.Rows[i][2]);
                product.articlenumber = Convert.ToInt32(dt.Rows[i][3]);
                product.image = dt.Rows[i][4].ToString();
                product.productionworkshopnumber = Convert.ToInt32(dt.Rows[i][5]);
                product.mincostforagent = Convert.ToInt32(dt.Rows[i][6]);
                product.productionpersoncount = Convert.ToInt32(dt.Rows[i][7]);
                products.Add(product);
            }
            return products;
        }
    }
}
