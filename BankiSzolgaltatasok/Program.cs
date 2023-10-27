namespace BankiSzolgaltatasok
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            OsszEgyenleg();
            Console.WriteLine("----------------------------------------");
            LegnagyobbEgyenleg();
            Console.WriteLine("----------------------------------------");
            OsszHitel();
        }

        public static void OsszEgyenleg()
        {
            Bank bank = new Bank();
            Tulajdonos t1 = new Tulajdonos("Teszt Elek1");
            Tulajdonos t2 = new Tulajdonos("Teszt Elek2");
            Tulajdonos t3 = new Tulajdonos("Teszt Elek3");
            Szamla sz1 = bank.SzamlaNyitas(t1, 0);
            Szamla sz2 = bank.SzamlaNyitas(t1, 1);
            Szamla sz3 = bank.SzamlaNyitas(t2, 0);
            Szamla sz4 = bank.SzamlaNyitas(t2, 1);
            Szamla sz5 = bank.SzamlaNyitas(t3, 0);
            Szamla sz6 = bank.SzamlaNyitas(t3, 1);
            sz1.Befizet(15000);
            sz2.Befizet(10000);
            sz3.Befizet(30000);
            sz4.Befizet(35000);
            sz5.Befizet(70000);
            sz6.Befizet(75000);
            Console.WriteLine($"{t1.Nev} - {bank.GetOsszEgyenleg(t1)}Ft");
            Console.WriteLine($"{t2.Nev} - {bank.GetOsszEgyenleg(t2)}Ft");
            Console.WriteLine($"{t3.Nev} - {bank.GetOsszEgyenleg(t3)}Ft");
        }
        public static void LegnagyobbEgyenleg()
        {
            Bank bank = new Bank();
            Tulajdonos t1 = new Tulajdonos("Teszt Elek4");
            Tulajdonos t2 = new Tulajdonos("Teszt Elek5");
            Tulajdonos t3 = new Tulajdonos("Teszt Elek6");
            Szamla sz1 = bank.SzamlaNyitas(t1, 0);
            Szamla sz2 = bank.SzamlaNyitas(t1, 1);
            Szamla sz3 = bank.SzamlaNyitas(t2, 0);
            Szamla sz4 = bank.SzamlaNyitas(t2, 1);
            Szamla sz5 = bank.SzamlaNyitas(t3, 0);
            Szamla sz6 = bank.SzamlaNyitas(t3, 1);
            sz1.Befizet(85000);
            sz2.Befizet(10000);
            sz3.Befizet(30000);
            sz4.Befizet(35000);
            sz5.Befizet(75000);
            sz6.Befizet(70000);
            Console.WriteLine($"{t1.Nev} - {bank.GetLegnagyobbEgyenleguSzamla(t1).AktualisEgyenleg}Ft");
            Console.WriteLine($"{t2.Nev} - {bank.GetLegnagyobbEgyenleguSzamla(t2).AktualisEgyenleg}Ft");
            Console.WriteLine($"{t3.Nev} - {bank.GetLegnagyobbEgyenleguSzamla(t3).AktualisEgyenleg}Ft");
        }
        public static void OsszHitel()
        {
            Bank bank = new Bank();
            Tulajdonos t1 = new Tulajdonos("Teszt Elek7");
            Tulajdonos t2 = new Tulajdonos("Teszt Elek8");
            Tulajdonos t3 = new Tulajdonos("Teszt Elek9");
            bank.SzamlaNyitas(t1, 0);
            bank.SzamlaNyitas(t1, 10000);
            bank.SzamlaNyitas(t2, 0);
            bank.SzamlaNyitas(t2, 15000);
            bank.SzamlaNyitas(t3, 0);
            bank.SzamlaNyitas(t3, 20000);
            Console.WriteLine($"{t3.Nev} - {bank.OsszHitelkeret}Ft");
        }
    }
}