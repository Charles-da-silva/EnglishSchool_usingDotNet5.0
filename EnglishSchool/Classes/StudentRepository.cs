using System;
using System.Collections.Generic;
using EnglishSchool.Interfaces;

namespace EnglishSchool
{
    public class StudentRepository : IRepository<Student>
    {
        private List<Student> listStudent = new List<Student>();
        
        public void DeactivateOrActivate(int Id, int value)
        {
            listStudent[Id].Disable(value);
        }

        public void Insert(Student Object)
        {
            listStudent.Add(Object);
        }

        public List<Student> List()
        {
            return listStudent;
        }

        public int Next()
        {
             return listStudent.Count;
        }

        public Student ReturnById(int Id)
        {
            return listStudent[Id];
        }

        public void Update(int Id, Student Object)
        {
            listStudent[Id] = Object;
        }
    }
}