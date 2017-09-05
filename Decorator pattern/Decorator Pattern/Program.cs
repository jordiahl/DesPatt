using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern {
    class Program {
        static void Main(string[] args) {
            Beverage beverage = new Espresso();
            Console.WriteLine(beverage.getDescription()+" $ "+ beverage.cost());
            Beverage beverage2 = new HouseBlend();
            Console.WriteLine(beverage2.getDescription() + " $ " + beverage2.cost());
            beverage2 = new Mocha(beverage2);
            Console.WriteLine(beverage2.getDescription() + " $ " + beverage2.cost());
        }
    }
}


public abstract class Beverage {
   protected string description = "Unknown Beverage";
    public string getDescription() {
        return description;
    }
    public abstract double cost();

}

public abstract class CondimentDecorator : Beverage {
    public abstract new string  getDescription();
}


public class Espresso : Beverage {
    public Espresso() {
        description = "Espresso";
    }
    public override double cost() {
        return 1.99;
    }
}

public class HouseBlend : Beverage {
    public HouseBlend() {
        description = "House Blend Coffe";
    }
    public override double cost() {
        return .89;
    }
}

public class Mocha: CondimentDecorator {
    Beverage beverage;
    public Mocha(Beverage beverage) {
        this.beverage = beverage;
    }
    public override string getDescription() {
        return beverage.getDescription() + ", Mocha";
    }
    public override double cost() {
        return .20 + beverage.cost();
    }
}








