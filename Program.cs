using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YieldOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            // yield

            var students = ToList(Generator.GetStudents());
            var enumerator = students.GetEnumerator();

            while (true)
            {
                if (enumerator.MoveNext())
                    System.Console.WriteLine(enumerator.Current.FirstName);
                else
                    break;
            }


            // foreach (var student in students)
            // {
            //     System.Console.WriteLine(student.FirstName);
            // }
        }

        static List<Student> ToList(IEnumerable<Student> students)
        {
            var result = new List<Student>();
            var enumerator = students.GetEnumerator();

            while (true)
            {
                if (enumerator.MoveNext())
                    result.Add(enumerator.Current);
                else
                    break;
            }

            return result;
        }

        private static IEnumerable<int> GetNumbers()
        {
            return new List<int>()
            {
                1,2,3,4,5
            };
        }
    }

    public class Generator
    {
        static int counter = 0;
        public static IEnumerable<int> GetOddNumbers()
        {
            while (true)
            {
                counter++;

                if (counter % 2 == 1)
                    yield return counter;
            }
        }

        public static IEnumerable<Student> GetStudents()
        {
            yield return GetStudent("Salih", "Cantekin");
            yield return GetStudent("Oğuz", "Kaplan");
            yield return GetStudent("Kerem", "Gün");
            yield break;
            yield return GetStudent("Ünal", "Top");
            yield return GetStudent("Emrah", "Yaman");


        }

        private static Student GetStudent(string firstName, string lastName)
        {
            Task.Delay(1000).Wait();
            return new Student(firstName, lastName);
        }

    }

    public class Student
    {
        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            System.Console.WriteLine("Student Class Generated");
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
