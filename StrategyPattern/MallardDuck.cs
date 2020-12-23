namespace Ducks
{
    internal class MallardDuck : Duck
    {
        public MallardDuck()
        {
            Flyer = new FlyNope();
            Quacker = new QuackNope();
        }

        public void Display()
        {
            PerformFly();
            PerformQuack();
        }
    }
}
