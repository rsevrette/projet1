using System.Threading.Tasks.Dataflow;

namespace projet1;
class Student
{
    public int ID { get; set; }
    public string name { get; set; }
    public float average { get; set; }
    public bool isScholarshipHolder { get; set; }
    private static int IDCounter = 1;

    public Student(){}
    public Student(string name, float average, bool isScholarshipHolder)
    {
        this.name = name;
        this.average = average;
        this.isScholarshipHolder = isScholarshipHolder;
        ID = IDCounter++;
    }

    public Student(string name, float average)
    {
        this.name = name;
        this.average = average;
        ID = IDCounter++;
    }
}

class Course
{
    public int ID { get; set; }
    public string name { get; set; }
    public int credits { get; set; }
    public bool isMandatory { get; set; }
    public List<Student> students { get; set; }
    private static int IDCounter = 1;

    public Course(){}
    public Course(string name, int credits, bool isMandatory)
    {
        this.name = name;
        this.credits = credits;
        this.isMandatory = isMandatory;
        students = new List<Student>();
        ID = IDCounter++;
    }
    public Course(string name)
    {
        this.name = name;
        students = new List<Student>();
        ID = IDCounter++;
    }
    public void AddStudent(Student student)
    {
        students.Add(student);
    }
    public void RemoveStudent(Student student)
    {
        students.Remove(student);
    }
    public void Display()
    {
        Console.WriteLine($"Course: {name}");
        Console.WriteLine($"Credits: {credits}, Mandatory: {isMandatory}");
        Console.WriteLine($"Number of students: {students.Count}");
        Console.WriteLine();
    }

    public void DisplayStudents()
    {
        Console.WriteLine($"Course: {name}");
        Console.WriteLine("Students enrolled:");
        Console.WriteLine($"Credits: {credits}, Mandatory: {isMandatory}");
        foreach (var student in students)
        {
            Console.WriteLine($"- {student.name} (Average: {student.average}, Scholarship Holder: {student.isScholarshipHolder})");
        }
        Console.WriteLine();
    }
}
class Program
{
    static void Main(string[] args)
    {
        /// creation des etudiants et des cours
        Student student1 = new Student("Alice", 15.5f, true);
        Student student2 = new Student("Bernard", 12.0f);
        Student student3 = new Student("Emma", 18.0f, true);
        Student student4 = new Student("Lucas", 10.0f);
        Student student5 = new Student("Sarah", 14.0f, false);

        Course course1 = new Course("Mathematiques", 3, true);
        Course course2 = new Course("Informatique");
        Course course3 = new Course("Anglais", 4, true);
        Course course4 = new Course("Histoire", 2, false);

        /// ajout des etudiants aux cours
        course1.AddStudent(student1);
        course1.AddStudent(student2);
        course1.AddStudent(student3);

        course2.AddStudent(student2);
        course2.AddStudent(student4);

        course3.AddStudent(student1);
        course3.AddStudent(student5);

        course4.AddStudent(student4);

        /// affichage des cours
        course1.Display();
        course2.Display();
        course3.Display();
        course4.Display();

        /// affichage des etudiants inscrits dans chaque cours
        course1.DisplayStudents();
        course2.DisplayStudents();
        course3.DisplayStudents();
        course4.DisplayStudents();

        /// affichage des cours obligatoires
        Console.WriteLine("Mandatory courses:");
        List<Course> courses = new List<Course> { course1, course2, course3, course4 };
        foreach (var course in courses)
        {
            if (course.isMandatory)
            {
                Console.WriteLine($"- {course.name}");
            }
        }
        Console.WriteLine();

        /// affichage des etudiants boursiers
        Console.WriteLine("Scholarship holders:");
        List<Student> students = new List<Student> { student1, student2, student3, student4, student5 };
        foreach (var student in students)
        {
            if (student.isScholarshipHolder)
            {
                Console.WriteLine($"- {student.name} (Average: {student.average})");
            }
        }
        Console.WriteLine();

        /// affichage des etudiants ayant une moyenne superieure a 15
        Console.WriteLine("Students with an average above 15:");
        foreach (var student in students)
        {
            if (student.average > 15)
            {
                Console.WriteLine($"- {student.name} (Average: {student.average})");
            }
        }
        Console.WriteLine();

        /// suppression d'un etudiant d'un cours
        course1.RemoveStudent(student2);
        course1.DisplayStudents();

        /// affichage des IDs des etudiants et des cours
        Console.WriteLine("Student IDs:");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.name} -> ID {student.ID}");
        }
        Console.WriteLine();

        Console.WriteLine("Course IDs:");
        foreach (var course in courses)
        {
            Console.WriteLine($"{course.name} -> ID {course.ID}");
        }
    }
}
/// Question:
/// 1. le compteur augmente chaque fois qu’on crée un objet. Quand un nouvel étudiant ou cours est créé, le programme ajoute 1 au compteur et donne cette valeur comme ID.
/// 2. Parce qu’elle doit être partagée par tous les objets de la classe. Si elle n’était pas static, chaque objet aurait son propre compteur, et les IDs seraient les mêmes.
