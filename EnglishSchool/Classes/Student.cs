using System;

namespace EnglishSchool
{
    public class Student : EntityBase
    {
        /////////////Attributes
        private string Name { get; set; }
        private int Age { get; set; }
        private string DocumentNumber { get; set; }
        private string EnglishLevel { get; set; }
        private EnglishClass EnglishClass { get; set; }
        private bool Active { get; set; }


        /////////////Methods

        //Constructor
        public Student(int Id, string Name, int Age, string DocumentNumber, string EnglishLevel, EnglishClass EnglishClass)
        {
            this.Id = Id;
            this.Name = Name;
            this.Age = Age;
            this.DocumentNumber = DocumentNumber;
            this.EnglishLevel = EnglishLevel;
            this.EnglishClass = EnglishClass;
            this.Active = true;
            
        }

        //Modifying the ToString method

        public override string ToString()
        {
            
            string Return = "";
            Return += "Name: " + this.Name + Environment.NewLine;
            Return += "Age: " + this.Age + Environment.NewLine;
            Return += "Document Number: " + this.DocumentNumber + Environment.NewLine;
            Return += "English Level: " + this.EnglishLevel + Environment.NewLine;
            Return += "English Class: " + this.EnglishClass + Environment.NewLine;
            Return += "Active: " + this.Active + Environment.NewLine;
            return Return;   

            //Environment.NewLine is used to create a new line independent of the OS (MacOS, Windows or Linux) running the program 
            //the \n may not work on non-Windows OS's.
        }

        //Methods to perform the Get function on attributes above
        public int ReturnId()
        {
            return this.Id;
        }

        public string ReturnName()
        {
            return this.Name;
        }

        public bool ReturnActive()
        {
            return this.Active;
        }
        public EnglishClass ReturnEnglishClass()
        {
            return this.EnglishClass;
        }

        public void Disable(int value)
        {
            if(value == 2)
            {
                this.Active = false;
            }
            else
            {
                this.Active = true;
            }

        }
    }

}