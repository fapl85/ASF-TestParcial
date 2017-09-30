using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TestParcial.Entities;
using TestParcial.Data;


namespace TestParcial.Business
{
    /// <summary>
    /// Student business component.
    /// </summary>
    public partial class StudentBusiness
    {

        public List<Student> All()
        {
            var StudentDAC = new StudentDAC();
            var result = StudentDAC.Select();
            return result;
        }
        public Student Add(Student student)
        {
            var StudentDAC = new StudentDAC();
            return StudentDAC.Create(student);

        }
    }
}
