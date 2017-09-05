using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns {
    class Program {
        static void Main(string[] args) {
            WeatherData weatherData = new WeatherData();
            CurrentConditionDisplay currentDisplay = new CurrentConditionDisplay(weatherData);

            weatherData.SetMeasurements(80, 65, 30.4f);
            weatherData.SetMeasurements(82, 70, 29.2f);
            weatherData.SetMeasurements(78, 90, 29.2f);
        }
    }

   

    public interface Subject {
        void RegisterObserver(Observer o);
        void RemoveObserver(Observer o);
        void NotifyObservers();
    }

    public interface Observer {
        void Update(float temp, float humidity, float pressure);
    }

    public interface DisplayElement {
        void Display();
    }

    public class WeatherData : Subject {
        private List<Observer> observers;
        private float temperature;
        private float humidity;
        private float pressure;

        public WeatherData() {
            observers = new List<Observer>();
        }

        public void RegisterObserver(Observer o) {
            observers.Add(o);
        }

        public void RemoveObserver(Observer o) {
            int i = observers.IndexOf(o);
            if (i>=0) {
                observers.RemoveAt(i);
            }
        }

        public void NotifyObservers() {
            for (int i = 0; i < observers.Count; i++) {
                observers[i].Update(temperature, humidity, pressure);
            }
        }
        public void MeasurementChanged() {
            NotifyObservers();
        }

        public void SetMeasurements(float temperature,float humidity,float pressure) {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            MeasurementChanged();
        }

    }

    public class CurrentConditionDisplay : Observer, DisplayElement {
        private float temperature;
        private float humidity;
        private Subject weatherData;


        public CurrentConditionDisplay(Subject weatherData) {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }


        public void Display() {
            Console.WriteLine("Current conditions: "+temperature+" F degrees and "+humidity+" % humidity");
        }

        public void Update(float temperature, float humidity, float pressure) {
            this.temperature = temperature;
            this.humidity = humidity;
            Display();
        }

    }

    




}
