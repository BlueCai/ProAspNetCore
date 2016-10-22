using BlueCaiCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueCaiCms.BLL
{
    public class StudentService
    {
        private IDataProvider dataProvider;

        public StudentService(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public void Add(Student student)
        {
            dataProvider.Create(student);
        }

        public List<Student> GetAll()
        {
            return dataProvider.GetAllStudent();
        }

        public Student GetStudentById(Guid id)
        {
            return dataProvider.GetStudentById(id);
        }

        public bool Edit(Student student)
        {
            return dataProvider.EditStudent(student);
        }

        public bool Delete(Guid id)
        {
            return dataProvider.DeleteStudent(id);
        }
    }
}
