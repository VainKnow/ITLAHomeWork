using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

class Student
{
   
    public string Name;
    public int Age;

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }

 
    public void ShowInfo()
    {
        Console.WriteLine($"Student name: {Name}");
        Console.WriteLine($"Student age: {Age}");
    }
}

class Program
{
    static void Main()
    {
     
        Console.Write("Enter the student's name: ");
        string nameInput = Console.ReadLine();

        Console.Write("Enter the student's age: ");
        int ageInput = Convert.ToInt32(Console.ReadLine());

       
        Student student1 = new Student(nameInput, ageInput);

        
        Console.WriteLine("\n--- Student Information ---");
        student1.ShowInfo();
    }
}
