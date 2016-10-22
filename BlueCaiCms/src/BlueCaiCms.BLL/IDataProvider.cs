using BlueCaiCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueCaiCms.BLL
{
    public interface IDataProvider
    {
        void Create(Student entity);

        List<Student> GetAllStudent();

        Student GetStudentById(Guid id);

        bool EditStudent(Student student);

        bool DeleteStudent(Guid id);
    }
}
