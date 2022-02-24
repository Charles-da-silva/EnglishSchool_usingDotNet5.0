using System;

namespace EnglishSchool
{
    class Program
    {
        static StudentRepository repository = new StudentRepository();
        static void Main(string[] args)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Welcome to English Master School");

            string UserOption = GetUserOption();

            while (UserOption.ToUpper() != "X")
            {
                switch (UserOption)
                {
                    case "1":
                        InsertStudent();
                        break;
                    case "2":
                        ListStudents();
                        break;
                    case "3":
                        StudentDetails();
                        break;    
                    case "4":
                        UpdateStudent();
                        break;
                    case "5":
                        DeactivateOrActivate();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();                      
                }
                UserOption = GetUserOption();
            }
            System.Console.WriteLine("******  Thanks for use our systems!  ******");
            System.Console.ReadLine();
        }

        private static void StudentDetails()
        {
            System.Console.WriteLine("Please, inform the student ID in order to show details.");
            int userId = int.Parse(Console.ReadLine());
            System.Console.WriteLine();

            var user = repository.ReturnById(userId);
            System.Console.WriteLine(user);
        }

        private static void DeactivateOrActivate()
        {
            System.Console.WriteLine("Please, inform the student ID in order to disable or enable.");
            int userId = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Would you like to do:" + Environment.NewLine + "1 - Enable" + Environment.NewLine + "2 - Disable");
            int userActive = int.Parse(Console.ReadLine());

            repository.DeactivateOrActivate(userId, userActive);            
        }

        private static void UpdateStudent()
        {
            
            System.Console.WriteLine("--------------------  Updating an existent student  --------------------");
            System.Console.WriteLine();
            
            System.Console.WriteLine("Please, inform the user ID in order to update it:");          
            int userId = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Type the student NAME: ");
            string studentName = Console.ReadLine();

            System.Console.WriteLine("Type the student AGE: ");
            int studentAge = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Type the student DOCUMENT NUMBER: ");
            string studentDocument = Console.ReadLine();

            System.Console.WriteLine("Type the student ENGLISH LEVEL (A1, A2, B1, B2, C1 or C2): ");
            string studentLevel = Console.ReadLine().ToUpper();

            System.Console.WriteLine("Avaiable ENGLISH CLASSES: ");
            foreach(int i in Enum.GetValues(typeof(EnglishClass)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(EnglishClass), i));
            }
            
            System.Console.WriteLine("Type the class between the above option: ");
            int studentClass = int.Parse(Console.ReadLine());
            
            Student updateStudent = new Student(Id: userId, Name: studentName, Age: studentAge, 
                                            DocumentNumber: studentDocument, EnglishLevel: studentLevel, 
                                            EnglishClass: (EnglishClass)studentClass);

            repository.Update(userId, updateStudent);
        }

        private static void InsertStudent()
        {
            System.Console.WriteLine("--------------------  Insering a new student  --------------------");
            System.Console.WriteLine();

            System.Console.WriteLine("Type the student NAME: ");
            string studentName = Console.ReadLine();

            System.Console.WriteLine("Type the student AGE: ");
            int studentAge = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Type the student DOCUMENT NUMBER: ");
            string studentDocument = Console.ReadLine();

            System.Console.WriteLine("Type the student ENGLISH LEVEL (A1, A2, B1, B2, C1 or C2): ");
            string studentLevel = Console.ReadLine().ToUpper();

            System.Console.WriteLine("Avaiable ENGLISH CLASSES: ");
            foreach(int i in Enum.GetValues(typeof(EnglishClass)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(EnglishClass), i));
            }
            
            System.Console.WriteLine("Type the class between the above option: ");
            int studentClass = int.Parse(Console.ReadLine());

            Student newStudent = new Student(Id: repository.Next(), Name: studentName, Age: studentAge, 
                                            DocumentNumber: studentDocument, EnglishLevel: studentLevel, 
                                            EnglishClass: (EnglishClass)studentClass);

            repository.Insert(newStudent);
            
            
        }

        private static void ListStudents()
        {
            System.Console.WriteLine("--------------------  List students  --------------------");
            System.Console.WriteLine();

            var list = repository.List();

            if(list.Count == 0)
            {
                System.Console.WriteLine("No student registered.");
                System.Console.WriteLine();
                return;
            }
            foreach(var student in list)
            {
                var active = student.ReturnActive();
                
                System.Console.WriteLine("#ID {0}: - {1} {2}", student.ReturnId(), student.ReturnName(), (active ? "" : " **** Student deactivated"));
            }
            System.Console.WriteLine();            
        }

        private static string GetUserOption()
        {
            System.Console.WriteLine("------------------------------------------------------------------");
            System.Console.WriteLine();
            System.Console.WriteLine("Choose an option to continue:");
            System.Console.WriteLine();
            System.Console.WriteLine("1 - Insert new student");
            System.Console.WriteLine("2 - List students");
            System.Console.WriteLine("3 - Show student details");
            System.Console.WriteLine("4 - Update student");
            System.Console.WriteLine("5 - Active or Inactive student");
            System.Console.WriteLine("C - Clear screen");
            System.Console.WriteLine("X - Exit");
            System.Console.WriteLine();

            string UserOption = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return UserOption;
        }
    }
}
