using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperP.Models
{

        public class UserRepository
    {
        string connectionString = null;
        public UserRepository(string conn)
        {
            connectionString = conn;
            //using (IDbConnection db = new SqlConnection(connectionString))
            //{
            //    var sqlQuery = "IF NOT EXIST(SELECT * FROM sys.databases WHERE name = 'userbd') BEGIN CREATE DATABASE userbd USE userbd; CREATE TABLE (Id INT PRIMARY KEY IDENTITY, IpAddress INT, Name NVARCHAR(20), Age INT, Gender NVARCHAR(20))  END";
            //    db.Execute(sqlQuery);
            //}
        }
        public List<User> GetUsers()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>("SELECT * FROM Users").ToList();
            }
        }
        public User Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>("SELECT * FROM Users Where Id = @id", new { id }).FirstOrDefault();
            }
        }
        public void Create (User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Users (IpAdress, Name, Age, Gender) VALUES( @IpAdress, @Name, @Age, @Gender);";
                db.Execute(sqlQuery, user);
            }
        }
        public void Update(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Users SET IpAdress = @IpAdress, Name = @Name, Age = @Age, Gender = @Gender WHERE Id = @Id";
                db.Execute(sqlQuery, user);
            }
        }
        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Users WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

    }
}
