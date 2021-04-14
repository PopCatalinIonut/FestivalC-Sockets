using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using Microsoft.Data.Sqlite;

namespace festival.persistance
{
    public class EmployeeRepository
    {
        public bool existsEmployee(String username, String password)
        {
            
            var con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Employee where username = @username and password = @password";
                comm.CommandType = CommandType.Text;
                var paramUsername = comm.CreateParameter();
               
                paramUsername.ParameterName = "@username";
                paramUsername.Value = username;
                comm.Parameters.Add(paramUsername);
               
                var paramPassword = comm.CreateParameter();
                paramPassword.ParameterName = "@password";
                paramPassword.Value = password;
                comm.Parameters.Add(paramPassword);
                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read()) 
                        return true;
                    return false;
                    
                }

                return false;
            }
        }
    }
}