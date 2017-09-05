using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_pattern {
    class Program {
        static void Main(string[] args) {
            string avoid;

            EnemyShip theEnemy = null;

            EnemyshipFactory shipFactory = new EnemyshipFactory();

            Console.WriteLine("What type of ship? (U/R/B)");
            string userInput = Console.ReadLine();

            theEnemy = shipFactory.makeEnemyShip(userInput);


            if (theEnemy!=null) {
                doStuffEnemy(theEnemy);
            }
            else {
                Console.WriteLine("the enemy is null");
            }

            avoid = Console.ReadLine();
        }
   
        

        public static void doStuffEnemy(EnemyShip  anEnemyShip) {
            anEnemyShip.displayEnemyShip();
            anEnemyShip.followHeroShip();
            anEnemyShip.enemyShipShoots();
        }

    
    }
}



public abstract class EnemyShip {
    private string name;
    private double amtDamage;


    public string getName() { return name; }
    public void setName(string newName) { name = newName; }

    public void setDamage(double newDamage) { amtDamage = newDamage; }
    public double getDamage() { return amtDamage; }

    public void followHeroShip() {
        Console.WriteLine(getName() + " is following the hero");
    }

    public void enemyShipShoots() {
        Console.WriteLine(getName() + " attacks " + getDamage());
    }

    public void displayEnemyShip() {
        Console.WriteLine(getName()+" is on the screen");
    }
}


public class UFOEnemyShip:EnemyShip{
    public UFOEnemyShip() {
        setName("UFO Enemy Ship");
        setDamage(20.0);
    }
}



public class RocketEnemyShip : EnemyShip {
    public RocketEnemyShip() {
        setName("Rocket Enemy Ship");
        setDamage(10.0);
    }
}


public class BigUFOEnemyShip : EnemyShip {
    public BigUFOEnemyShip() {
        setName("Big UFO Enemy Ship");
        setDamage(40.0);
    }
}

public class EnemyshipFactory:EnemyShip {
    public EnemyShip makeEnemyShip(string newShipType) {
        EnemyShip newShip = null;

        if (newShipType.Equals("U", StringComparison.Ordinal)) {
            return new UFOEnemyShip();
        }
        else {
            if (newShipType.Equals("R", StringComparison.Ordinal)) {
                return new RocketEnemyShip();
            }
            else {
                if (newShipType.Equals("B", StringComparison.Ordinal)) {
                    return new BigUFOEnemyShip();
                }
                else {
                    return null;
                }
            }
        }
    }
}