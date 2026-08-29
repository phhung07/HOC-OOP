using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buoithu4
{
    internal class StudentMS
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Student s1 = new Student("1001", "Than Thi Det", "det@gmail.com");
            Student s2 = new Student("1002", "Nguyen Van Coi", "coi@hotmail.com");
            Student s3 = new Student("1003", "Tran Van Tun", "tun@outlook.com");

            Clazz cls = new Clazz("SE00003", "Lớp KTPM03");

            cls.AddNewStudent(s1);
            cls.AddNewStudent(s2);
            bool kq = cls.AddNewStudent(s3);
            if (!kq) Console.WriteLine("Them that bai");

            Console.WriteLine("Danh sach sinh vien");
            var lst = cls.GetStudents();
            foreach (var s in lst)
                Console.WriteLine(s);
        }
    }
}
