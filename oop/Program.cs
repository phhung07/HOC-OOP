using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace oop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student[] liststudent =
            {
                new Student("Phan Tan Phat", 9),
                new Student("Nguyen Minh Duy", 5),
                new Student("Phan Gia Hau", 10),
                new Student("Pham Nguyen Dang Khoa", 3),
                new Student("Pham Hung", 8),
            };
            Console.WriteLine(Student.GettotalStudent());
            foreach (Student student in liststudent)
            {
                Console.WriteLine
                (
                    $"{student.Getname()} - " +
                    $"{student.Getscore()} - " +
                    $"{student.GetClassification()} - " +
                    $"{(student.IsPassed() ? "Passed" : "Failed")}"
                );
            }
            Console.WriteLine(
                $"Sinh vien diem cao nhat: {Student.FindTopStudent(liststudent).Getname()} - {Student.FindTopStudent(liststudent).Getscore()}"
            );

            Console.WriteLine(
                $"Diem trung binh: {Student.CalculateAverageScore(liststudent)}"
            );
        }
        public class Student
        {
            public string name;
            public double score;
            public static int totalStudent = 0;

            public Student(string name, double score)
            {
                this.name = name;
                this.score = score;
                totalStudent++;
            }
            public string Getname()
            {
                return name;
            }
            public double Getscore()
            {
                return score;
            }
            public bool IsPassed()
            {
                return score >= 5;
            }
            public string GetClassification()
            {
                if (score >= 8) return "Excellent";
                else if (score >= 6.5) return "Good";
                else if (score >= 5) return "Average";
                else return "Weak";
            }
            public static int GettotalStudent()
            {
                return totalStudent;
            }
            public static Student FindTopStudent(Student[] sst)
            {
                Student stu = sst[0];
                foreach (Student s in sst)
                {
                    if (stu.score < s.score)
                        stu = s;
                }
                return stu;
            }
            public static double CalculateAverageScore(Student[] students)
            {
                double tong = 0;
                foreach (Student s in students)
                {
                    tong += s.score;
                }
                return tong / students.Length;
            }
        }
    }
}
