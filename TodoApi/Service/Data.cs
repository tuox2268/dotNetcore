﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using TodoApi.Enums;
using TodoApi.Service;
namespace TodoApi.Service
{
    public class Student
    {
        #region data

        public  string FirstName { get; set; } = "lack of First name for this object!";
        public string LastName { get; set; }
        public long Id { get; set; }
        public GradeLevel Year;
        public List<int> ExamScores { get; set; }

        
        #endregion

        // Helper method, used in GroupByRange.
        public int GetPercentile(Student s)
        {
            double avg = s.ExamScores.Average();
            return avg > 0 ? (int)avg / 10 : 0;
        }
        //Get all Data of students
        public static List<Student> Getallstudent()
        {
            return StudentService.students;
        }
        //Add a new student
        public List<Student> addNewStudent(Student X)
        {
            StudentService.students.Add(X);
            return StudentService.students;
        }

        //Get students have a HighScore(Average>score setting) 
    }
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    class Pet
    {
        public string Name { get; set; }
        public Person Owner { get; set; }
    }

    /// <summary>
    /// This example creates XML output from a grouped join.
    /// </summary>
    public class XML
    {
       public XElement GroupJoinXMLExample()
        {
        Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
        Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
        Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
        Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

        Pet barley = new Pet { Name = "Barley", Owner = terry };
        Pet boots = new Pet { Name = "Boots", Owner = terry };
        Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
        Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
        Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

        // Create two lists.
        List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
        List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

        // Create XML to display the hierarchical organization of people and their pets.
        XElement ownersAndPets = new XElement("PetOwners",
            from person in people
            join pet in pets on person equals pet.Owner into gj
            select new XElement("Person",
                new XAttribute("FirstName", person.FirstName),
                new XAttribute("LastName", person.LastName),
                from subpet in gj
                select new XElement("Pet", subpet.Name)));

        return ownersAndPets;
            }
    }
}

