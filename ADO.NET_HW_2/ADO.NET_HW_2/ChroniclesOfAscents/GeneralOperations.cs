using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ADO.NET_HW_2.ChroniclesOfAscents
{
    internal class GeneralOperations
    {
        private readonly SqlConnection _connection;

        public void GetListGroup()
        {
            SqlCommand use_sp = new SqlCommand("sp_listGroup", _connection)
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
                        Console.WriteLine($" Group name : {reader.GetString(0)} ,  Mountain name : {reader.GetString(1)} , Date : {reader.GetDateTime(2)}");
                    }
                }

            }
        }
        public void GetСlimbersRangeDate(string startRange,string endRange)
        {

            SqlCommand use_sp = new SqlCommand("sp_getСlimbersRangeDate", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@startRange",SqlDbType.Date){Value=startRange},
                new SqlParameter("@endRange",SqlDbType.Date){Value=endRange}

            });
            use_sp.ExecuteNonQuery();
            using (SqlDataReader reader = use_sp.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Name : {reader.GetString(0)} , Date : {reader.GetDateTime(1)}");
                    }
                }

            }

        }
        public void AddMountaineer(string name, string adress, int groupId)
        {
            SqlCommand use_sp = new SqlCommand("sp_AddMountaineer", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.AddRange(new SqlParameter[] {
            new SqlParameter("@name", SqlDbType.NVarChar,20){Value=name},
            new SqlParameter("@adress", SqlDbType.NVarChar,30){Value=adress},
            new SqlParameter("@groupId", SqlDbType.Int){Value=groupId}
            });
            use_sp.ExecuteNonQuery();
        }
        public void GetCountClimbing()
        {

            SqlCommand use_sp = new SqlCommand("sp_getCountClimbing", _connection)
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
                        Console.WriteLine($"Name : {reader.GetString(0)} , Mountian : {reader.GetString(1)} , Count Climbing :  {reader.GetInt32(2)}");
                    }
                }

            }

        }
        public void GetCountOnMountaing()
        {

            SqlCommand use_sp = new SqlCommand("sp_countMountaineerOnMountain", _connection)
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
                        Console.WriteLine($"Name Mountain: {reader.GetString(0)} , Count Mountaineer : {reader.GetInt32(1)} ");
                    }
                }

            }

        }
        public void UpdateMountainInfo(int MountGroupId, int MountianId, string startDate, string endDate,bool isSuccess)
        {
            SqlCommand use_sp = new SqlCommand("sp_updateInfoClimbing", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            use_sp.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@MountaineerGroupID", SqlDbType.Int,20){Value=MountGroupId},
                new SqlParameter("@MountainID", SqlDbType.Int){Value=MountianId},
                new SqlParameter("@start", SqlDbType.Date){Value=startDate},
                new SqlParameter("@end", SqlDbType.Date){ Value=endDate},
                new SqlParameter("@isSuccess", SqlDbType.Bit){ Value=isSuccess}
                });
            use_sp.ExecuteNonQuery();

        }
        public void AddNewGroup(string groupName,int mountainID,string stardDate)
        {


            SqlCommand use_sp = new SqlCommand("sp_addNewGroup", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.AddRange(new SqlParameter[] {
            new SqlParameter("@groupName", SqlDbType.NVarChar,20){Value=groupName},
            new SqlParameter("@MountainID", SqlDbType.Int){Value=mountainID},
            new SqlParameter("@start", SqlDbType.Date){Value=stardDate}
            });
            use_sp.ExecuteNonQuery();




        }
        public GeneralOperations(SqlConnection connection) {


            _connection = connection;
        
        }
    }
}
