using System;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RdcAbstract
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Cittadino Marco = new Studente("Marco", "Giordani", 23, 3, 103, true, false, 99);
            Comune Napoli = new Comune("Napoli", 104, "Comune");
            Napoli.Calculate(Marco);

            Cittadino Giovanna = new StudenteUniversitario("Giovanna", "Callegari", 21, 5, 100, true, 99, 28, false);
            Napoli.Calculate(Giovanna);

        }

    }

    abstract class Person
    {
       
        protected string _name;
        protected string _surName;
        protected int _age;

        public string GetName()
        {
            return _name + " " + _surName;
        }

        public Person(string Name, string surName, int age)
        {
            _name = Name;
            _surName = surName;
            _age = age;
        }
        public string Name { get { return _name; } }
        public string SurName { get { return _surName; } }
        public int Age { get { return _age; } }

        public abstract void Getinfo();
        

        
    }

    class Cittadino : Person
    {

        protected int _figli;
        protected decimal _PilComune;
        protected bool _debt;
        protected bool _salary;


        public Cittadino(string Name, string surName, int age, int Figli, decimal PilComune, bool Debt, bool Salary)
               : base(Name, surName, age)

        {
            _debt = Debt;
            _figli = Figli;
            _PilComune = PilComune;
            _salary = Salary;
        }

        public int Figli { get { return _figli; } }
        public decimal PilComune { get { return _PilComune; } }
        public bool Debt { get { return _debt; } }
        public bool Salary { get { return _salary; } }

        public override void Getinfo()
        {
            Console.WriteLine(_name+ _surName + _age );
        }
    }

    class Studente : Cittadino
    {
        protected decimal _votoDiploma;

        public Studente(string Name, string surName, int age, int Figli, decimal PilComune, bool Debt, bool Salary, decimal votoDiploma)
               : base(Name, surName, age, Figli, PilComune, Debt, Salary)

        {
            _votoDiploma = votoDiploma;

        }

        public decimal VotoDiploma { get { return _votoDiploma; } }
        public override void Getinfo()
        {
            Console.WriteLine(_votoDiploma);
        }
    }

    class StudenteUniversitario : Studente
    {
        protected decimal _votoUni;

        public StudenteUniversitario(string Name, string surName, int age, int Figli, decimal PilComune, bool Debt, decimal votoDiploma, decimal VotoUni, bool Salary)
               : base(Name, surName, age, Figli, PilComune, Debt, Salary, votoDiploma)
        {
            _votoUni = VotoUni;
        }

        public decimal VotoUniversitario { get { return _votoUni; } }
        public override void Getinfo()
        {
            Console.WriteLine(_votoUni);
        }
    }

    class Militare : Cittadino
    {
        protected int _servizioAnni;

        public Militare(string Name, string surName, int age, int Figli, decimal PilComune, bool Debt, int ServizioAnni, bool Salary)
                       : base(Name, surName, age, Figli, PilComune, Debt, Salary)
        {
            _servizioAnni = ServizioAnni;
        }
        public int Servizio { get { return _servizioAnni; } }
        public override void Getinfo()
        {
            Console.WriteLine(_servizioAnni);
        }
    }


}

namespace RdcAbstract
{

    abstract class Ente
    {
        protected string _NomeEnte;

        public Ente(string nomeEnte)
        {
            _NomeEnte = nomeEnte;
        }

    }
    class Comune : Ente
    {
        protected string _nomeComune;
        protected int _PilComune;

        public Comune(string nomeComune, int pilComune, string nomeEnte) : base(nomeEnte)
        {
            _nomeComune = nomeComune;
            _PilComune = pilComune;
        }

        public int Rdc(Cittadino cittadino)
        {
            int count = 0;
            int inc = 5;

            if (cittadino.PilComune < 100)
            {
                count += inc;
            }

            if (cittadino.Figli > 1)
            {
                count += inc;
            }

            if (cittadino.Debt)
            {
                count += inc;
            }

            if ((cittadino.Age >= 18 && cittadino.Age <= 25) || (cittadino.Age >= 60 && !cittadino.Salary))
            {
                count += inc;
            }

            if (cittadino is Militare)
            {
              
                Militare _militare = (Militare)cittadino;

                if (_militare.Servizio > 0)
                {
                    count += inc;
                }
            }

            if (cittadino is Studente)
            {
                Studente _studente = (Studente)cittadino;
                if (_studente.VotoDiploma >= 90)
                {
                    count += inc;
                }

            }

            if (cittadino is StudenteUniversitario)
            {
                StudenteUniversitario _uni = (StudenteUniversitario)cittadino;
                if (_uni.VotoUniversitario >= 28 && (cittadino.Age >= 18 && cittadino.Age <= 25))
                {
                    count += inc;
                }
            }


            return count;

        }

        public void Calculate(Cittadino cittadino)
        {
            int count = Rdc(cittadino);

            if (count >= 25)
            {
                Console.WriteLine("Il Cittadino ha diritto al RDC " + count);
            }
            else
            {
                Console.WriteLine("Il Cittadino non ha diritto al RDC " + count);
            }

        }
    }
}

