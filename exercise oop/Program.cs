using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Student
{
    private string name;
    private double score;
    private static int totalStudents = 0;

    public Student(string name, double score)
    {
        this.name = name;
        this.score = score;
        totalStudents++;
    }

    // TODO: write instance methods here
    public string GetName() // trả về tên của sinh viên
    {
        return name;
    }
    public double GetScore() // trả về điểm số của sinh viên
    {
        return score;
    }
   public bool Passed() // kiểm tra sinh viên có đậu hay không
    {
        return score >= 5.0;
    }
    public string phanloai() // phân loại học lực
    {
        if (score >= 8.0) return "Exellent";
        if (score >= 6.5) return "Good";
        else if (score >= 5.0) return "Average";
        else
        {
            return "Weak";
        }
    }

    // TODO: write static methods here
  
    // static int GetTotalStudents() —
    // returns the total number of students created
     public static int tongStudents()
     {
        return totalStudents;
     }
    //static Student FindTopStudent(Student[] students) 
    public static Student FindTopStudent(Student[] students) 
    {
        if (students == null || students.Length == 0)
        {
            return null;
        }
        Student topStudent = students[0]; // tạm thời coi sinh viên đầu tiên là người cao điểm nhất
        foreach (Student student in students) // duyệt từng sinh viên
        {
            if (student.score > topStudent.score)
            {
                topStudent = student;
            }
        }
        return topStudent;
    }
    //static double CalculateAverageScore(Student[] students)
    public static double CalculateAverageScore(Student[] students) 
    {
        if (students == null || students.Length == 0)
        {
            return 0;
        }
        double totalScore = 0;
        foreach (Student student in students)
        {
            totalScore += student.GetScore();
        }
        return totalScore / students.Length;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // TODO: create array of Student objects
        Student[] students = new Student[]
        {
            new Student("Nhu Y", 9.2),
            new Student("An", 4.5),
            new Student("Binh", 6.8),
            new Student("Chau", 7.5),
            new Student("Dung", 8.1)
        };

        //Print the total number of students created(using the static method).
        Console.WriteLine($"Tổng số sinh viên đã tạo: {Student.tongStudents()}");
        Console.WriteLine(new string('-', 50));

        //Print the list of students along with their classification and pass/ fail status(using instance methods).
        Console.WriteLine("Danh sách sinh viên:");
        foreach (var s in students)
        {
            string status = s.Passed() ? "Đậu" : "Rớt";
            Console.WriteLine($"Tên: {s.GetName(),-10} | Điểm: {s.GetScore():F1} | Trạng thái: {status,-4} | Xếp loại: {s.phanloai()}");
        }
        Console.WriteLine(new string('-', 50));

        //Print the top-scoring student(using the static method).
        Student top = Student.FindTopStudent(students);
        if (top != null)
        {
            Console.WriteLine($"Sinh viên xuất sắc nhất: {top.GetName()} (Điểm: {top.GetScore()})");
        }

        //Print the class average score(using the static method).
        Console.WriteLine($"Điểm trung bình của lớp: {Student.CalculateAverageScore(students):F2}");
        Console.ReadLine();
        // TODO: call static and instance methods as required
    }
}