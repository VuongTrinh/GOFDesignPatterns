using System;

namespace FactoryPattern
{
    class Program
    {
        static void Main()
        {
            // Pizza
            Console.WriteLine("Yankees fan orders:");
            var yankees = new NyPizzaFactory();
            yankees.Order("Cheese");
            Console.WriteLine();
            Console.WriteLine("Cubs fan orders:");
            var cubs = new ChicagoPizzaFactory();
            cubs.Order("Clam");
            Console.WriteLine();
            //Monument
            MonumentHandler greekMonumentHandler =
                new MonumentHandler(new GreekMonumentFactory(), "Athena", "Pericles");

            greekMonumentHandler.IssueMessages();
            // The Olympian deity Athena demands tribute!
            // The noble Greek leader Pericles requests submission of taxes!

            MonumentHandler egyptianMonumentHandler =
                new MonumentHandler(new EgyptianMonumentFactory(), "Sekhmet", "Hatchepsut");

            egyptianMonumentHandler.IssueMessages();
            // Now accepting offerings to the Egyptian deity Sekhmet!
            // The mighty Egyptian pharaoh Hatchepsut demands payment of taxes!

        }
    }

    //The Abstract Factory Pattern and Thematic Configuration
    interface ITemple
    {
        void CollectOfferings();
    }

    class GreekTemple : ITemple
    {
        private string Deity;

        public GreekTemple(string deityName) => this.Deity = deityName;

        public void CollectOfferings() =>
            Console.WriteLine($"The Olympian deity {this.Deity} demands tribute!");
    }

    class EgyptianTemple : ITemple
    {
        private string Deity;

        public EgyptianTemple(string deityName) => this.Deity = deityName;

        public void CollectOfferings() =>
            Console.WriteLine($"Now accepting offerings to the Egyptian deity {this.Deity}!");
    }
    interface IPalace
    {
        void CollectTaxes();
    }

    class GreekPalace : IPalace
    {
        private string Leader;

        public GreekPalace(string leaderName) => this.Leader = leaderName;

        public void CollectTaxes() =>
            Console.WriteLine($"The noble Greek leader {this.Leader} requests submission of taxes!");
    }

    class EgyptianPalace : IPalace
    {
        private string Leader;

        public EgyptianPalace(string leaderName) => this.Leader = leaderName;

        public void CollectTaxes() =>
            Console.WriteLine($"The mighty Egyptian pharaoh {this.Leader} demands payment of taxes!");
    }

    interface IAbstractMonumentFactory
    {
        ITemple BuildTemple(string deityName);

        IPalace BuildPalace(string leaderName);
    }

    class GreekMonumentFactory : IAbstractMonumentFactory
    {
        public ITemple BuildTemple(string deityName) => new GreekTemple(deityName);

        public IPalace BuildPalace(string leaderName) => new GreekPalace(leaderName);
    }

    class EgyptianMonumentFactory : IAbstractMonumentFactory
    {
        public ITemple BuildTemple(string deityName) => new EgyptianTemple(deityName);

        public IPalace BuildPalace(string leaderName) => new EgyptianPalace(leaderName);
    }

    class MonumentHandler
    {
        private IAbstractMonumentFactory Factory;

        private ITemple Temple;

        private IPalace Palace;

        public MonumentHandler(IAbstractMonumentFactory factory, string deityName, string leaderName)
        {
            this.Factory = factory;
            this.Temple = factory.BuildTemple(deityName);
            this.Palace = factory.BuildPalace(leaderName);
        }

        public void IssueMessages()
        {
            this.Temple.CollectOfferings();
            this.Palace.CollectTaxes();
        }
    }
}
