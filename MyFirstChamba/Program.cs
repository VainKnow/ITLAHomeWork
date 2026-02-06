using System;
using MyFirstChamba.Entities;

namespace MyFirstChamba
{
  class Program
    {
        static void Main(string[] args)
        {
            
            Student student = new Student
            {
                id = 1,
                Name = "Juan Pérez",
                age = 20,
                Description = "Estudiante de Ingeniería",
                Carrier = "Ingeniería de Software",
                Semester = 4
            };

            Console.WriteLine("=== STUDENT ===");
            student.Mostrarinfo();
            Console.WriteLine($"Carrera: {student.Carrier}");
            Console.WriteLine($"Semestre: {student.Semester}");

            Console.WriteLine();

        
            ExStudent exStudent = new ExStudent
            {
                id = 2,
                Name = "María Gómez",
                age = 25,
                Description = "Ex alumna",
                Reason = "Graduación",
                ExclusionDate = new DateTime(2024, 6, 10),
                Graduated = true
            };

            Console.WriteLine("=== EX STUDENT ===");
            exStudent.Mostrarinfo();
            Console.WriteLine($"Motivo: {exStudent.Reason}");
            Console.WriteLine($"Fecha: {exStudent.ExclusionDate.ToShortDateString()}");
            Console.WriteLine($"Graduado: {exStudent.Graduated}");

            Console.WriteLine();

            
            Teacher teacher = new Teacher
            {
                id = 3,
                Name = "Carlos Ruiz",
                age = 40,
                Description = "Profesor de Programación",
                Salary = 60000,
                Job = "Docente",
                Subject = "Programación en C#",
                HoursPerWeek = 20
            };

            Console.WriteLine("=== TEACHER ===");
            teacher.Mostrarinfo();
            Console.WriteLine($"Materia: {teacher.Subject}");
            Console.WriteLine($"Horas por semana: {teacher.HoursPerWeek}");
            Console.WriteLine($"Salario: {teacher.Salary}");

            Console.WriteLine();

        
            Administrator admin = new Administrator
            {
                id = 4,
                Name = "Ana López",
                age = 45,
                Description = "Administrador académico",
                Salary = 80000,
                Job = "Administrador",
                Subject = "Gestión Académica",
                AccessLevel = 5
            };

            Console.WriteLine("=== ADMINISTRATOR ===");
            admin.Mostrarinfo();
            Console.WriteLine($"Nivel de acceso: {admin.AccessLevel}");
            Console.WriteLine($"Salario: {admin.Salary}");

            Console.ReadKey();
        }
    }
}

