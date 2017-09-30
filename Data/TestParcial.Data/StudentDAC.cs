using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using TestParcial.Entities;

namespace TestParcial.Data
{
    
    public partial class StudentDAC : DataAccessComponent
    {
        
        public Student Create(Student student)
        {
            const string sqlStatement = "INSERT INTO dbo.Student ([Alias], [FirstName], [LastName], [Email], [City], [CountryId], [DateOfBirth], [Gender]) " +
               "VALUES(@Alias, @FirstName, @LastName, @Email, @City, @CountryId, @DateOfBirth, @Gender); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Alias", DbType.String, student.Alias);
                db.AddInParameter(cmd, "@FirstName", DbType.String, student.FirstName);
                db.AddInParameter(cmd, "@LastName", DbType.String, student.LastName);
                db.AddInParameter(cmd, "@Email", DbType.String, student.Email);
                db.AddInParameter(cmd, "@City", DbType.String, student.City);
                db.AddInParameter(cmd, "@CountryId", DbType.Int64, student.CountryId);
                db.AddInParameter(cmd, "@DateOfBirth", DbType.DateTime, student.DateOfBirth);
                db.AddInParameter(cmd, "@Gender", DbType.String, student.Gender);
                // Obtener el valor de la primary key.
                student.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return student;
        }
        public Student SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [Alias], [FirstName], [LastName], [Email], [City], [CountryId], [DateOfBirth], [Gender] " +
   "FROM dbo.Student WHERE [Id]=@Id ";

            Student student = null;
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) student = LoadStudent(dr);
                }
            }

            return student;
        }
        public List<Student> Select()
        {
            const string sqlStatement = "SELECT [Id], [Alias], [FirstName], [LastName], [Email], [City], [CountryId], [DateOfBirth], [Gender] FROM dbo.Student ";

            var result = new List<Student>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var student = LoadStudent(dr); // Mapper
                        result.Add(student);
                    }
                }
            }

            return result;
        }
        private Student LoadStudent(IDataReader dr)
        {
            Student student = new Student();

            student.Id = GetDataValue<int>(dr, "Id");
            student.Alias = GetDataValue<string>(dr, "Alias");
            student.FirstName = GetDataValue<string>(dr, "FirstName");
            student.LastName = GetDataValue<string>(dr, "LastName");
            student.Email = GetDataValue<string>(dr, "Email");
            student.City = GetDataValue<string>(dr, "City");
            student.CountryId = GetDataValue<int>(dr, "CountryId");
            student.DateOfBirth = GetDataValue<DateTime>(dr, "DateOfBirth");
            student.Gender = GetDataValue<string>(dr, "Gender");

            return student;
        }
    }
}

