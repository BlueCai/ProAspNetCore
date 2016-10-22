using BlueCaiCms.BLL;
using BlueCaiCms.Data.EF;
using BlueCaiCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueCaiCms.Data.DataProvider
{
    public class DataProvider : IDataProvider
    {
        #region CommonFunction
        private readonly BCDbContext dbContext;
        public DataProvider(BCDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        #endregion

        public List<Student> GetAllStudent()
        {
            return dbContext.Students.ToList();
        }

        public Student GetStudentById(Guid id)
        {
            return dbContext.Students.Where(c => c.Id == id).FirstOrDefault();
        }

        public void Create(Student student)
        {
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
        }

        public bool EditStudent(Student student)
        {
            try
            {
                var oldStudent = dbContext.Students.FirstOrDefault(c => c.Id == student.Id);
                oldStudent.Name = student.Name;
                oldStudent.NickName = student.NickName;
                oldStudent.Age = student.Age;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteStudent(Guid id)
        {
            dbContext.Students.Remove(dbContext.Students.FirstOrDefault(c => c.Id == id));
            dbContext.SaveChanges();
            return true;
        }
    }
}
