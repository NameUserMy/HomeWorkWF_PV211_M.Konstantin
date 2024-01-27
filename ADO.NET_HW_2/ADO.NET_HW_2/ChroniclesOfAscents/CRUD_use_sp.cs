using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ADO.NET_HW_2.ChroniclesOfAscents
{
    
    internal class CRUD_use_sp
    {
        private readonly SqlConnection _connection;
        #region Mountaineer group
        public void AddGroup(string nameGroup)//add club in DB
        {

            SqlCommand use_sp = new SqlCommand("sp_AddMountaineerGroup", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 20) {Value = nameGroup});
            use_sp.ExecuteNonQuery();

        }
        public void UpdatedGroup(string nameGroup, int id)
        {

            SqlCommand use_sp = new SqlCommand("sp_updateMountaineerGroup", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 20) { Value = nameGroup });
            use_sp.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
            use_sp.ExecuteNonQuery();

        }
        public void DeletedGroup(int id)
        {

            SqlCommand use_sp = new SqlCommand("sp_deleteMountaineerGroup", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
            use_sp.ExecuteNonQuery();

        }
        #endregion

        #region Mountaineer
        public void AddMountaineer(List<Mountaineer> mountaineers)//Add rock climber in DB
        {
            foreach (var item in mountaineers)
            {
                SqlCommand use_sp = new SqlCommand("sp_AddMountaineer", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.AddRange(new SqlParameter[] {
            new SqlParameter("@name", SqlDbType.NVarChar,20){Value=item.Name},
            new SqlParameter("@adress", SqlDbType.NVarChar,30){Value=item.Adress},
            new SqlParameter("@groupId", SqlDbType.Int){Value=item.GroupId}
            });
                use_sp.ExecuteNonQuery();
            }
           
        }
        public void UpdateMountaineer(Mountaineer mountaineer)
        {

            SqlCommand use_sp = new SqlCommand("sp_updateMountaineer", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.AddRange(new SqlParameter[] {
            new SqlParameter("@name", SqlDbType.NVarChar,20){Value=mountaineer.Name},
            new SqlParameter("@adress", SqlDbType.NVarChar,30){Value=mountaineer.Adress},
            new SqlParameter("@groupId", SqlDbType.Int){Value=mountaineer.GroupId},
            new SqlParameter("@Id", SqlDbType.Int){Value=mountaineer.Id}
            });
            use_sp.ExecuteNonQuery();


        }

        public void DeleteMountaineer( int id)
        {

            SqlCommand use_sp = new SqlCommand("sp_deleteMountaineer", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
            use_sp.ExecuteNonQuery();

        }
        #endregion

        #region Mountain
        public void AddMountain(string name,float height,string country)//Add Mountain IN DB
        {
            SqlCommand use_sp = new SqlCommand("sp_AddMountain", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.AddRange(new SqlParameter[] {
            new SqlParameter("@name", SqlDbType.NVarChar,20){Value=name},
            new SqlParameter("@height", SqlDbType.Float){Value=height},
            new SqlParameter("@country", SqlDbType.NVarChar,(30)){Value=country}
            });
            use_sp.ExecuteNonQuery();

        }
        public void UpdateMountain(string name, float height, string country,int id)
        {
            SqlCommand use_sp = new SqlCommand("sp_updateMountain", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.AddRange(new SqlParameter[] {
            new SqlParameter("@name", SqlDbType.NVarChar,20){Value=name},
            new SqlParameter("@height", SqlDbType.Float){Value=height},
            new SqlParameter("@country", SqlDbType.NVarChar,(30)){Value=country},
            new SqlParameter("@Id", SqlDbType.Int){Value=id}
            });
            use_sp.ExecuteNonQuery();

        }
        public void DeleteMountain(int id)
        {

            SqlCommand use_sp = new SqlCommand("sp_deleteMountain", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
            use_sp.ExecuteNonQuery();

        }

        #endregion

        public void AddClimbing(int MountGroupId,int MountianId,string startDate,string endDate) //Add climbing information in DB
        {

            SqlCommand use_sp = new SqlCommand("sp_Climbing", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            use_sp.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@MountaineerGroupID", SqlDbType.Int,20){Value=MountGroupId},
                new SqlParameter("@MountainID", SqlDbType.Int){Value=MountianId},
                new SqlParameter("@start", SqlDbType.Date){Value=startDate},
                new SqlParameter("@end", SqlDbType.Date){ Value=endDate}
                });
            use_sp.ExecuteNonQuery();
        }
        public CRUD_use_sp(SqlConnection connectServer)
        {
            _connection = connectServer;
        }
    }
}

 