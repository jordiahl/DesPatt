using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duck_Design {
    class Program {
        static void Main(string[] args) {
            Duck mallard = new MallardDuck();
            mallard.PerformQuack();
            mallard.PerformFly();
            mallard.display();
            mallard.Swim();
        }
    }
    
    public class MallardDuck:Duck {

        public MallardDuck() {
            flyBehavior = new FlyWithWings();
            quackBehavior = new Quack();
        }
        public override void display() {
            Console.WriteLine("I'm a real Mallard duck");
        }
    }

    public abstract class Duck {
        protected FlyBehavior flyBehavior;
        protected QuackBehavior quackBehavior;
        public abstract void display();
        
        public void PerformFly() {
            flyBehavior.fly();
        }
       public void PerformQuack() {
            quackBehavior.quack();
        }
        public void Swim() {
            Console.WriteLine("All ducks can swim");
        }
    }


   public interface FlyBehavior {
        void fly();
    }
    public class FlyWithWings : FlyBehavior {
        public void fly() {
            Console.WriteLine("Im flying");
        }
    }
    public class FlyNoWay: FlyBehavior {
        public void fly() {
            Console.WriteLine("I cant fly");
        }
    }

   public interface QuackBehavior {
        void quack();
    }
    public class Quack : QuackBehavior {
        public void quack() {
            Console.WriteLine("Quack");
        }
    }
    public class MuteQuack : QuackBehavior {
        public void quack() {
            Console.WriteLine("<<Silence>>");
        }
    }
    public class Squeak: QuackBehavior {
        public void quack() {
            Console.WriteLine("Squeak");
        }
    }
}
