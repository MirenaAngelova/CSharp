﻿using System;
using Software_Academy.Interfaces;
using Software_Academy.Models;

namespace Software_Academy
{
    class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            CourseFactory factory = new CourseFactory();
            ITeacher nakov = factory.CreateTeacher("Nakov");
            Console.WriteLine(nakov);
            nakov.Name = "Svetlin Nakov";
            ICourse oop = factory.CreateLocalCourse("OOP", nakov, "Light");
            oop.AddTopic("Using Classes and Objects");
            oop.AddTopic("Defining Classes");
            oop.AddTopic("OOP Principles");
            oop.AddTopic("Teamwork");
            oop.AddTopic("Exam Preparation");
            Console.WriteLine(oop);
            ICourse html = factory.CreateOffsiteCourse("HTML", nakov, "Plovdiv");
            html.AddTopic("Using Classes and Objects");
            html.AddTopic("Defining Classes");
            html.AddTopic("OOP Principles");
            html.AddTopic("Teamwork");
            html.AddTopic("Exam Preparation");
            Console.WriteLine(html);
            nakov.AddCourse(oop);
            nakov.AddCourse(html);
            Console.WriteLine(nakov);
            oop.Name = "Object-Oriented Programming";
            (oop as ILocalCourse).Lab = "Enterprise";
            oop.Teacher = factory.CreateTeacher("George Georgiev");
            oop.AddTopic("Practical Exam");
            Console.WriteLine(oop);
            html.Name = "HTML Basics";
            (html as IOffsiteCourse).Town = "Varna";
            html.Teacher = oop.Teacher;
            html.AddTopic("Practical Exam");
            Console.WriteLine(html);
           ICourse css = factory.CreateLocalCourse("CSS", null, "Ultimate");
            Console.WriteLine(css);
            ICourse css2 = factory.CreateOffsiteCourse("CSS", null, "Ultimate");
            Console.WriteLine(css2);
        }
    }
}
