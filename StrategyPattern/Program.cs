using Ducks;
using System;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var mallard = new MallardDuck { Quacker = new QuackNormal() };
            mallard.Display();
            mallard.Flyer = new FlyWings();
            mallard.Display();
        }
    }
}
