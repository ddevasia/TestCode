using CSVReadDBWriteApp.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSVReadDBWriteApp.DBAccessLayer
{
    public class StudentRepository
    {

        public bool InsertCSVDataRecords(List<Student> students)
        {
            DBContext db = new DBContext();
            // Delete Data each time import the file
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Students");

            var studentEntity = students.Select(s => new StudentEntity
            {
                StudentId = s.StudentId,
                FirstName = s.FirstName,
                Surname = s.Surname,
                Sex = s.Sex,
                Age = s.Age,
                Class = s.Class,
                Active = s.Active
            });
            // Add Data to The Database
            foreach (StudentEntity s in studentEntity)
            {
                db.Students.Add(s);
                db.SaveChanges();
            } 
            return true;
        }
    }
}