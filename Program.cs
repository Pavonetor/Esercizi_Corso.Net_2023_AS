using System;

namespace CalcoloRDC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person Citizen = new Person();
                "Marco",
                "Giordano",
                63,
                100,
                27,
                false,
                2,
                false,
                100000000M
                );

            Citizen.getValues();

            Citizen.University = 28;
            

        }
        internal class Person
        {
            static int counter = 0;
            string _name;
            string _surname;
            int _age;
            decimal _pil;
            int _highschool;
            int _university;
            int _children;
            bool _military;
            bool _debts;
            int _score;
            

            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public string FullName { get { return _name + " " + _surname; } }

            public int Age
            {
                get
                { return _age; }
                set
                {
                    if (value > 60)
                    {
                        _score += 6;

                    
                    }
                    _age = value;   
                }
            }

            public decimal Pil
            {
                get { return _pil; }
                set
                {
                    if (value < 1000)
                    {
                        _score += 4;
                    }
                    _pil = value;
                }
            }

            public int Highschool
            {
                get => _highschool;
                set
                {
                    if (_highschool >= 90)
                    {
                        _score += 7;
                    }
                    _highschool = value;
                }
            }

            public int University
            {
                get => _university;
                set
                {
                    if (_university >= 28)
                    {
                        _score += 6;

                    }
                    _university = value;
                }
            } 

            public int Children
            {
                get => _children
                set
                {
                    if (_children >= 1)
                    {
                        _score += 1;
                    }
                    _children = value;
                }
                

               
                

            }
            public bool Military
            {
                get; set;
            }
            
            public bool Debts
            {
                get; set;

                
            }

            public Person(

                string Name,
                string Surname,
                int Age,
                int Highschore,
                int University,
                int Children,
                bool Military,
                bool Debts,
                decimal Pil
                ) 
            {
                _name = Name;
                _surname = Surname;
                
            }
            public void getValues()
            {
           
                Console.WriteLine($"Age:{Age}");
                Console.WriteLine($"Maturita:{Highschool}");
                Console.WriteLine($"University:{University}");
                Console.WriteLine($"Debiti:{Debts}");
                Console.WriteLine($"Militare:{Military}");
                Console.WriteLine($"Figli:{Children}");
            }
            public int getCounter()
            {
                return counter;
            }


           

        }

    }
}