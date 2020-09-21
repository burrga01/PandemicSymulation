using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace PandemicSymulation
{
    class Person
    {
        public bool Infected
        {
            get
            {

                return _infected;
            }
            set
            {
                NumberOfPeopleInfected++;
                _infected = value;
            }
        }
        private bool _infected;
        public int NumberOfMeetingsPerDay
        {
            get; set;
        }
        public bool Exposed
        {
            get; set;
        } 
        public bool Contagious
        {
            set; get;
        }
        public int DateExposed
        {
            set; get;
        }
        public int DateInfected
        {
            set; get;
        }
        public int Name
        {
            get;
        }
        public Person(int name)
        {
            _infected = false;
            Name = name;
            Contagious = false;
            Exposed = false;
            NumberOfMeetingsPerDay = 0;

        }
        public static int NumberOfPeopleInfected = 0;

    }
}
