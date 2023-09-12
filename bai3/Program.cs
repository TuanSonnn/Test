using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    class Person
    {
        private string ID;
        private string fullName;
        public string StudentID
        {
            get => ID;
            set => ID = value;
        }
        public string FullName
        {
            get => fullName;
            set => fullName = value;
        }

        public Person(string ID, string fullName)
        {
            this.ID = ID;
            this.fullName = fullName;
        }
        public Person()
        {
        }
        public void Input()
        {
            Console.Write("Nhap MSSV:");
            StudentID = Console.ReadLine();
            Console.Write("Nhap Ho ten Sinh vien:");
            FullName = Console.ReadLine();
        }
        public void Show()
        {
            Console.WriteLine("MSSV:{0} Ho Ten:{1}",
           this.StudentID, this.fullName);
        }
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();
            List<Teacher> teacherList = new List<Teacher>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Them giao vien");
                Console.WriteLine("3. Hien thi danh sach sinh vien");
                Console.WriteLine("4. Hien thi danh sach giao vien");
                Console.WriteLine("5. So luong tung danh sach (tong so sinh vien, tong so giao vien)");
                Console.WriteLine("6. Xuat ra thong tin cua cac SV deu thuoc khoa “CNTT”");
                Console.WriteLine("7. Xuat ra thong tin cua cac GV deu thuoc nhom “Quan 9”");
                Console.WriteLine("8. Xuat ra danh sach sinh vien co diem trung binh cao nhat va thuoc khoa “CNTT” ");
                Console.WriteLine("9. Hay cho biet so luong cua tung xep loai trong danh sach?");
                Console.WriteLine("10. Thoat");
                Console.Write("Chon chuc nang (0-9): ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;
                    case "3":
                        DisplayStudentList(studentList);
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Ket thuc chuong trinh.");
                        break;
                    case "2":
                        AddTeacher(teacherList);
                        break;
                    case "4":
                        DisplayTeacherList(teacherList);
                        break;
                    case "5":
                        Console.WriteLine("So luong tung danh sach(tong so sinh vien la {0}, tong so giao vien {1})", studentList.Count, teacherList.Count);
                        break;
                    case "6":
                        DisplayStudentsByFaculty(studentList, "CNTT");
                        break;
                    case "7":
                        DisplayTeacherByFaculty(teacherList, "Quan 9");
                        break;
                    case "8":
                        DisplayStudentsWithHighestAverageScoreByFaculty(studentList, "CNTT");
                        break;
                    case "9":
                        DisplayStudentRank(studentList);
                        break;

                    default:
                        Console.WriteLine("Tuy chon khong hop le. Vui long chon lai.");
                        break;
                }
                Console.WriteLine();
            }
        }
        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("=== Nhap thong tin sinh vien ===");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Them sinh vien thanh cong!");
        }
        static void AddTeacher(List<Teacher> teacherList)
        {
            Console.WriteLine("=== Nhap thong tin giao vien ===");
            Teacher teacher = new Teacher();
            teacher.Input();
            teacherList.Add(teacher);
            Console.WriteLine("Them giao vien thanh cong!");
        }
        static void DisplayStudentList(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sach chi tiet thong tin sinh vien ===");
            foreach (Student student in studentList)
            {
                student.Show();
            }
        }
        static void DisplayTeacherList(List<Teacher> teacherList)
        {
            Console.WriteLine("=== Danh sach chi tiet thong tin sinh vien ===");
            foreach (Teacher teacher in teacherList)
            {
                teacher.Show();
            }
        }
        static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("=== Danh sach sinh vien thuoc khoa {0}", faculty);
            var students = studentList.Where(s => s.Faculty.Equals(faculty,
            StringComparison.OrdinalIgnoreCase));
            DisplayStudentList(studentList);
        }
        static void DisplayTeacherByFaculty(List<Teacher> teacherList, string address)
        {
            Console.WriteLine("=== Danh sach giao vien thuoc o {0}", address);
            var teacher = teacherList.Where(s => s.Faculty.Equals(address,
            StringComparison.OrdinalIgnoreCase));
            DisplayTeacherList(teacherList);
        }
        //case 7
        static void DisplayStudentsWithHighestAverageScoreByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("=== Danh sach sinh vien có diem TB cao nhat và thuoc khoa {0}", faculty);
            var students = studentList.Where(
                                            s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)
                                            ).ToList();
            float maxAverageScore = students.Max(s => s.AverageScore);
            var students1 = students.Where(
                                            s => s.AverageScore == maxAverageScore
                                            ).ToList();
            DisplayStudentList(students1);
        }
        //case 8
        private static void DisplayStudentRank(List<Student> studentList)
        {
            int[] xeploaiCount = new int[6];
            foreach (var sv in studentList)
            {
                if (sv.AverageScore >= 9)
                {
                    xeploaiCount[0]++;
                }
                else if (sv.AverageScore >= 8)
                {
                    xeploaiCount[1]++;
                }
                else if (sv.AverageScore >= 7)
                {
                    xeploaiCount[2]++;
                }
                else if (sv.AverageScore >= 5)
                {
                    xeploaiCount[3]++;
                }
                else if (sv.AverageScore >= 4)
                {
                    xeploaiCount[4]++;
                }
                else
                {
                    xeploaiCount[5]++;
                }
            }
            Console.WriteLine("===Thong ke so luong cua tung xep loai trong danh sach ===");
            Console.WriteLine($"Xuat sac: {xeploaiCount[0]} sinh vien");
            Console.WriteLine($"Gio: {xeploaiCount[1]} sinh vien");
            Console.WriteLine($"Kha: {xeploaiCount[2]} sinh vien");
            Console.WriteLine($"Trung binh: {xeploaiCount[3]} sinh vien");
            Console.WriteLine($"Yeu: {xeploaiCount[4]} sinh vien");
            Console.WriteLine($"Kem: {xeploaiCount[5]} sinh vien");
        }
    }
    class Student : Person
    {
        //1. Field 
        private float averageScore;
        private string faculty;
        //2. Property 
        public float AverageScore
        {
            get => averageScore;
            set => averageScore = value;
        }
        public string Faculty
        {
            get => faculty;
            set => faculty = value;
        }
        //3.Constructor 

        public Student(float averageScore, string faculty) : base()
        {

            this.averageScore = averageScore;
            this.faculty = faculty;
        }
        public Student()
        {
        }
        public new void Input()
        {
            Console.Write("Nhap Điem TB:");
            AverageScore = float.Parse(Console.ReadLine());
            Console.Write("Nhap Khoa:");
            Faculty = Console.ReadLine();
        }
        public new void Show() => Console.Write("Khoa:{0} ĐiemTB:{1}", this.Faculty, this.AverageScore);
    }
    class Teacher : Person
    {
        //1. Field 
        private string address;
        //2. Property 
        public string Faculty
        {
            get => address;
            set => address = value;
        }
        //3.Constructor 

        public Teacher(string address) : base()
        {
            this.address = address;
        }
        public Teacher()
        {
        }
        public new void Input()
        {
            Console.Write("Nhap dia chi:");
            address = Console.ReadLine();
        }
        public new void Show()
        {
            Console.Write("Dia chi:{0} ", this.Faculty, this.address);
        }

    }

}
