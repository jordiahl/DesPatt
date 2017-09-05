using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Pattern {
    class MainClass {
        static void Main(string[] args) {
            StockGrabber stockGrabber = new StockGrabber();
            StockObserver observer1 = new StockObserver(stockGrabber);

            stockGrabber.SetIBMPrice(197.00);
            stockGrabber.SetAAPLPrice(677.60);
            stockGrabber.SetGOOGPrice(676.40);

        }
    }

    public interface Subject {
        void Register(Observer o);
        void Unregister(Observer o);
        void NotifyObserver();
    }

    public interface Observer {
        void Update(double ibmPrice, double aaplPrice, double googPrice);

    }

    public class StockGrabber : Subject {
        private List<Observer> observers;
        private double ibmPrice;
        private double aaplPrice;
        private double googPrice;

        public StockGrabber() {

            observers = new List<Observer>();
        }

        public void Register(Observer newObserver) {
            observers.Add(newObserver);
        }

        public void Unregister(Observer deleteObserver) {
            int observerIndex = observers.IndexOf(deleteObserver);
            Console.WriteLine("Observer" + (observerIndex + 1) + "Deleted");
            observers.RemoveAt(observerIndex);
        }

        public void NotifyObserver() {
            foreach (Observer observer in observers) {
                observer.Update(ibmPrice, aaplPrice, googPrice);
            }
        }

        public void SetIBMPrice(double newIBMPrice) {
            ibmPrice = newIBMPrice;
            NotifyObserver();
        }

        public void SetAAPLPrice(double newAAPLPrice) {
            aaplPrice= newAAPLPrice;
            NotifyObserver();
        }

        public void SetGOOGPrice(double newGoogPrice) {
            googPrice = newGoogPrice;
            NotifyObserver();
        }
    }

    public class StockObserver : Observer {

        private double ibmPrice;
        private double aaplPrice;
        private double googlPrice;

        private static int observerIDTracker = 0;

        private int observerID;

        private Subject stockGrabber;

        public StockObserver(Subject stockGrabber) {
            this.stockGrabber = stockGrabber;
            this.observerID = ++observerIDTracker;
            Console.WriteLine("New observer" + this.observerID);
            stockGrabber.Register(this);
        }

        public void Update(double ibmPrice, double aaplPrice, double googlPrice) {
            this.ibmPrice = ibmPrice;
            this.aaplPrice = aaplPrice;
            this.googlPrice = googlPrice;
            PrintThePrices();
        }

        public void PrintThePrices() {
            Console.WriteLine(observerID+ "\nIBM:"+ ibmPrice);
            Console.WriteLine("aapl:" + aaplPrice);
            Console.WriteLine("googlPrice:" + googlPrice);
        }
    }
}