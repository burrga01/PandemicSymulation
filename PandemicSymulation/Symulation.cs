using System;
using System.Collections.Generic;
using System.Text;

namespace PandemicSymulation
{
    class Symulation
    {
        public Symulation(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;
        }
        public int NumberOfPeople
            {
            get;
            }
        public void UpdateExposedPeople(Person person, int day)
        {
            if ((day - person.DateExposed) > 14 && !person.Infected && person.Exposed)
            {
                person.Exposed = false;
                person.DateExposed = 0;
            }
        }
        public void UpdateContagiousPeople(Person person, int day)
        {
            if (day - person.DateInfected >= 7 && person.Exposed)
            {
                person.Contagious = false;
            }
        }
        public void UpdateInfectedPeople(Person person, int day)
        {
            if ((day - person.DateExposed) > 2 && !person.Infected && person.Exposed)
            {
                double random;
                if ((random = randomDouble()) < INFECTIONRATE)
                {
                    person.Infected = true;
                    person.Contagious = true;
                    person.DateInfected = day;
                }
            }
        }

        public void PrintInfectionChart(List<Person> people, int day, int newCases)
        {
            Console.WriteLine($"\nDAY: {day}    Cases: {Person.NumberOfPeopleInfected}      New Cases: {newCases}      Person {people[0]} meetings: {people[0].NumberOfMeetingsPerDay}");
            //foreach (Person person in people)
            //{
            //    Console.WriteLine($"Person {person.Name}? |infection: {person.Infected}| exposed: {person.Exposed}| contagious: {person.Contagious}");
            //}
        }
        public Person GetRandomPerson(List<Person> people)
        {
            Person randomPerson;
            var random = new Random();

            randomPerson = people[random.Next(0, NumberOfPeople)];

            return randomPerson;
        }
        public void PrintGraph(int NumberOfNewCases)
        {
            for (int i = 0; i < NumberOfNewCases; i += 5)
                Console.Write("-");

            Console.WriteLine("");
        }
        public void Meet(Person person1, Person person2)
        {
            person1.NumberOfMeetingsPerDay++;
            person2.NumberOfMeetingsPerDay++;
            if (person1.Contagious && person2.Contagious)
            {

            }
            else if (person1.Infected)
            {
                person2.Exposed = true;
                //if(randomDouble() < INFECTIONRATE)
                //{
                //    person2.Infected = true;
                //}
            }
            else if (person2.Infected)
            {
                person1.Exposed = true;
                //if (randomDouble() < INFECTIONRATE)
                //{
                //    person1.Infected = true;
                //}
            }
        }

        private static double randomDouble()
        {
            var random = new Random();
            return random.NextDouble();
        }
        const double INFECTIONRATE = .05;
    }
}
