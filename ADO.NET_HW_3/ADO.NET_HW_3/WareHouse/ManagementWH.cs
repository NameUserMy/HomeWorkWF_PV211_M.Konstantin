using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_HW_3.WareHouse
{
    internal class ManagementWH
    {
        private readonly SqlConnection? _connection; 
        public void GetAllProduct()
        {
            SqlCommand use_sp = new SqlCommand("sp_selectAllProduct", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.ExecuteNonQuery();

            using (SqlDataReader reader = use_sp.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Name : {reader.GetString(0)}\t" +
                            $"Count : {reader.GetInt32(1)}\tCategoty : {reader.GetString(2)}\t " +
                            $"Contractor : {reader.GetString(3)}\t Stock : {reader.GetString(4)}\n");

                    }
                }

            }

        }
        public void GetProduct(int productId)
        {
            SqlCommand use_sp = new SqlCommand("sp_selectProduct", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.Add("@productId",SqlDbType.Int).Value = productId;
            use_sp.ExecuteNonQuery();

            using (SqlDataReader reader = use_sp.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Name : {reader.GetString(0)}\t" +
                            $"Count : {reader.GetInt32(1)}\tCategoty : {reader.GetString(2)}\t " +
                            $"Contractor : {reader.GetString(3)}\t Stock : {reader.GetString(4)}\n");

                    }
                }

            }


        }
        public void GetAllContractor()
        {
            SqlCommand use_sp = new SqlCommand("sp_selectAllContractor", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.ExecuteNonQuery();

            using (SqlDataReader reader = use_sp.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Name : {reader.GetString(0)}\n");

                    }
                }

            }

        }
        public void GetMaxCountProduct()
        {
            SqlCommand use_sp = new SqlCommand("sp_selectMaxCoubtProduct", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.ExecuteNonQuery();

            using (SqlDataReader reader = use_sp.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Name : {reader.GetString(0)}\t Count : {reader.GetInt32(1)}");

                    }
                }

            }

        }
        public void GetMinCountProduct()
        {
            SqlCommand use_sp = new SqlCommand("sp_selectMinCoubtProduct", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.ExecuteNonQuery();

            using (SqlDataReader reader = use_sp.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Name : {reader.GetString(0)}\t Count : {reader.GetInt32(1)}");

                    }
                }

            }

        }
        public void GetProductByCategory(int categoryId)
        {

            SqlCommand use_sp = new SqlCommand("sp_selectProductByCategory", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryId;
            use_sp.ExecuteNonQuery();

            using (SqlDataReader reader = use_sp.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Name : {reader.GetString(0)}\n");

                    }
                }

            }


        }

        public void GetProductByContractor(int contractorId)
        {

            SqlCommand use_sp = new SqlCommand("sp_selectProductByContractor", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.Add("@ContractorId", SqlDbType.Int).Value = contractorId;
            use_sp.ExecuteNonQuery();

            using (SqlDataReader reader = use_sp.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Name : {reader.GetString(0)}\n");

                    }
                }

            }


        }

        public void GetOldProduct()
        {
            SqlCommand use_sp = new SqlCommand("sp_selectOldProduct", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.ExecuteNonQuery();

            using (SqlDataReader reader = use_sp.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Name : {reader.GetString(0)}\t Date : {reader.GetDateTime(1)}");

                    }
                }

            }

        }

        public void GetOAVGProduct()
        {
            SqlCommand use_sp = new SqlCommand("sp_selectAVGProductCategory", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.ExecuteNonQuery();

            using (SqlDataReader reader = use_sp.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Name : {reader.GetString(0)}\t AVG count product : {reader.GetInt32(1)}");

                    }
                }

            }

        }
        public ManagementWH(SqlConnection connection) => _connection = connection;
    }
}
