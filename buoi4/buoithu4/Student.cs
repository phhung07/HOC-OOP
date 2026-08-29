namespace buoithu4
{
    internal class Student
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        private float gpa;//giả sử tính toán -read-only

        public float GPA
        {
            get { return gpa; }
        }

        public override bool Equals(object? obj) //khả năng bằng nhau
        {
            if (obj == null || !(obj is Student)) return false;
            Student s = (Student)obj;
            return this.Id.ToLower().Equals(s.Id.ToLower());
        }
        public override int GetHashCode()//duy nhất trong tập hợp
        {
            return Id.GetHashCode();
        }


        public Student(string id, string fullName, string email)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            this.gpa = 0f;
        }

        /*public Student()
        {
            Id = "no-id";
            FullName = "No-name";
            Email = "no-email";
            this.gpa = 0f;
        }*/

        public Student() : this("No-Id", "No-Name", "NoEmail")
        {
            this.gpa = 0f;
        }


        public float TakeExam(Subject subject)
        {
            //.....
            float result = subject.Result;
            float gpa = calculateGPA(result);
            return gpa;
        }

        private float calculateGPA(float result)
        {
            //throw new NotImplementedException();
            //...
            //..
            return 5f;// giả định cho vui
        }


        public override string ToString()
        {
            return Id + "," + FullName + ", " + Email;
        }
    }
}
