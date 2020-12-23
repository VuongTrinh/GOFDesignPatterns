using System;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var turkey = new WildTurkey();
            var adapter = new TurkeyAdapter(turkey);

            Tester(adapter);
        }

        private static void Tester(IDuck duck)
        {
            duck.Fly();
            duck.Quack();
        }
    }
}
