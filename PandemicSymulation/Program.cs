using System;
using System.Collections.Generic;

namespace PandemicSymulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            for(int i = 0; i < NUMBEROFPEOPLE; i++)
            {
                people.Add(new Person(i));
            }

            people[0].Infected = true;
            people[0].Exposed = true;
            people[0].DateExposed = 0;
            people[0].DateInfected = 0;
            people[0].Contagious = true;

            int day = 0;
            int NumberOfNewCases = 0;
            int NumberOfCasesYesterday;

            Symulation symulation = new Symulation(NUMBEROFPEOPLE);

            while(Person.NumberOfPeopleInfected < NUMBEROFPEOPLE)
            {
                NumberOfCasesYesterday = Person.NumberOfPeopleInfected;
                day++;
                foreach (Person person in people)
                {
                    symulation.UpdateInfectedPeople(person, day);
                    symulation.UpdateContagiousPeople(person, day);
                    symulation.UpdateExposedPeople(person, day);
                    for (int i = 0; i < MEETINGSPERDAY; i++)
                    {
                        symulation.Meet(person, symulation.GetRandomPerson(people));
                    }
                }
                NumberOfNewCases = Person.NumberOfPeopleInfected - NumberOfCasesYesterday;
                //PrintInfectionChart(people, day, NumberOfNewCases);
                if(day % 5 == 1)
                    symulation.PrintGraph(NumberOfNewCases);
                foreach(Person person in people)
                {
                    person.NumberOfMeetingsPerDay = 0;
                }
            }

            //Console.WriteLine($"number of days for everyone to be infected: {day}");
            symulation.PrintInfectionChart(people, day, NumberOfNewCases);
        }

        const int MEETINGSPERDAY = 1;
        const int NUMBEROFPEOPLE = 20000;
        const double DEATHRATE = .03;
    }
}
