using StudentData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData
{

    internal class Student
    {
        public string Name { get; set; }

        public object Age { get; internal set; }

        public string Class { get; set; }
    }
    internal class Program
    {


        static void Main(string[] args)
        {

            //CreateAndWriteTextFile();

            ReadAndSortAndSearchStudentData();





            Console.Read();


        }


        private static void ReadAndSortAndSearchStudentData()
        {
            bool fileExists = File.Exists(@"C:\Users\Admin\Desktop\Practice_Exercise\Demos\StudentdataSearching\bin\Debug\StudentData.txt");

            if (fileExists)
            {
                try
                {
                    string[] lines = File.ReadAllLines(@"C:\Users\Admin\Desktop\Practice_Exercise\Demos\StudentdataSearching\bin\Debug\StudentData.txt");

                    
                    List<Student> students = new List<Student>();
                    foreach (string line in lines)
                    {
                        string[] data = line.Split(',');
                        if (data.Length >= 2)
                        {
                            string name = data[0].Trim();
                            int age;
                            if (int.TryParse(data[1].Trim(), out age))
                            {
                                string studentClass = data[2].Trim();
                                students.Add(new Student { Name = name, Age = age, Class = studentClass });
                            }
                        }
                    }

                    
                    students = students.OrderBy(s => s.Name).ToList();

                    
                    Console.WriteLine("Sorted Student Data:");
                    foreach (var student in students)
                    {
                        Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Class: {student.Class}");
                    }

                   
                    Console.Write("\nEnter student name to search: ");
                    string searchName = Console.ReadLine().Trim();
                    Student foundStudent = students.FirstOrDefault(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

                    if (foundStudent != null)
                    {
                        Console.WriteLine($"Student found - Name: {foundStudent.Name}, Age: {foundStudent.Age}, Class: {foundStudent.Class}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("File doesn't exist in the given location");
            }
        }

        private static void CreateAndWriteTextFile()
        {

            FileStream Fs = new FileStream(@"C:\Users\Admin\Desktop\Practice_Exercise\Demos\StudentdataSearching\bin\Debug\StudentData.txt", FileMode.Create, FileAccess.Write);

            StreamWriter writer = new StreamWriter(Fs);

            try
            {
                writer.WriteLine("Khushal,22,Class A");
                writer.WriteLine("Bimal,37,Class B");
                writer.WriteLine("Raja,52,Class C");



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                writer.Flush();

                writer.Close();
                writer.Dispose();
                Fs.Close();
                Fs.Dispose();
            }
        }

    }
}











