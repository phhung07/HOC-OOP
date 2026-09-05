using System;
using System.Collections.Generic;

namespace buoithu4
{
    internal class Clazz
    {
        public String ClassId { get; set; }
        public String ClassName { get; set; }

        private List<Student> students;

        public Clazz(string id, string name)
        {
            this.ClassId = id;
            this.ClassName = name;
            students = new List<Student>();///???????
        }

        /* public Clazz(string id, string name, List<Student> students)
         {
             this.ClassId = id;
             this.ClassName = name;
             this.students = students;
         }*/

        /// <summary>
        /// Thêm 1 sinh viên vào lớp
        /// </summary>
        /// <param name="student">là sinh viên cần thêm</param>
        /// <returns>true nếu thêm được</returns>
        public bool AddNewStudent(Student student)
        {
            if (students.Contains(student))
                return false;
            students.Add(student);
            return true;
        }

        public Student? GetStudentById(string id)
        {
            Student st = new Student(id, "", "");//quan tâm id (vì hashcode-equals)

            int index = students.IndexOf(st);//vị trí xuất hiện trong tập hợp
            if (index == -1)
                return null;//không có
            return students[index];
        }

        /// <summary>
        /// Lấy danh sách sinh viên của lớp
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudents()
        {
            return students;
        }


        /// <summary>
        /// Lấy danh sách sinh viên có GPA trên 1 mức
        /// </summary>
        /// <param name="gpaLimit">Múc cần lấy</param>
        /// <returns></returns>
        public List<Student>? GetStudentWithGpaGE(float gpaLimit)
        {
            List<Student> result = new List<Student>();
            foreach (var s in students)
            {
                if (s.GPA >= gpaLimit)
                    result.Add(s);
            }

            return result.Count > 0 ? result : null; //ternary
        }

        /// <summary>
        /// Câp5 nhật thông tin sv khi khi biết mã số
        /// </summary>
        /// <param name="id">id mssv cần cập nhật</param>
        /// <param name="newStudent">thông tin mới</param>
        /// <returns>Trả về đối tượng mới được cập nhật</returns>
        public Student UpdateStudent(string id, Student newStudent)
        {
            Student? st = GetStudentById(id);
            //không có thì làm sao cập nhật?
            if (st != null) return null;
            st = newStudent;//?????
            return newStudent;
        }

        /// <summary>
        /// Xóa sv khỏi ds khi biết id
        /// </summary>
        /// <param name="id">là mssv cần xóa</param>
        /// <returns>Sinh viên bị xoa nếu thành côn. 
        /// Null nếu không xóa được (không tồn tại)</returns>
        public Student DeleteById(string id)
        {
            Student? student = GetStudentById(id);
            if (student == null) return null;

            students.Remove(student);

            return student;
        }


        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj is Clazz other)
            {
                return this.ClassId.Equals(other.ClassId);
            }
            return false;
        }
        public override int GetHashCode()
        {
            ///? based on class id
            /////???
            return this.GetHashCode();
        }
        public override string ToString()
        {
            return ClassId + "; " + ClassName;
        }
    }
}
