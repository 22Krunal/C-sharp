using System;
using System.ComponentModel;

namespace ThermoStateApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!!!!");
        }
    }

    public class ThermoStat : IThermoStat
    {
        private ICoolingMechanism _coolingMechanism = null;
        private IHeatSensor _heatSensor = null;
        private IDevice _device = null;

        private const double WarningLevel = 27;
        private const double EmergencyLevel = 75;

        public ThermoStat(IDevice device, IHeatSensor heatSensor, ICoolingMechanism coolingMechanism)
        {
            _device = device;
            _coolingMechanism = coolingMechanism;
            _heatSensor = heatSensor;
        }

        private void WireUpEventToEventHandlers()
        {
            _heatSensor.TemperatureReachesWarningLevelEventHandler += HeatSensor_TemperatureReachesWarningLevelEventHandler;
            _heatSensor.TemperatureFailsBelowWarningLevelEventHandler += HeatSensor_TemperatureFailsBelowWarningLevelEventHandler;
            _heatSensor.TemperatureReachesEmergencyLevelEventHandler += HeatSensor_TemperatureReachesEmergencyLevelEventHandler;
        }

        private void HeatSensor_TemperatureReachesWarningLevelEventHandler(object sender, TemperatureEventArgs e)
        {

        }
        private void HeatSensor_TemperatureFailsBelowWarningLevelEventHandler(object sender, TemperatureEventArgs e)
        {

        }

        private void HeatSensor_TemperatureReachesEmergencyLevelEventHandler(object sender, TemperatureEventArgs e)
        {

        }
        public void RunThermoStat()
        {
            Console.WriteLine("Thermostat is Running.........");

        }
    }
    public interface IThermoStat
    {
        void RunThermoStat();
    }
    public interface IDevice
    {
        void RunDevice();
        void HandleEmergency();
    }
    public interface ICoolingMechanism
    {
        void On();
        void Off();
    }

    public class CoolingMechanism : ICoolingMechanism
    {
        public void On()
        {
            Console.WriteLine();
            Console.WriteLine("Switching cooling mechanism off.....");
            Console.WriteLine();
        }
        public void Off()
        {
            Console.WriteLine();
            Console.WriteLine("Switching cooling mechanism off.....");
            Console.WriteLine();
        }
    }
    public class HeatSensor : IHeatSensor
    {
        double _warningLevel = 0;
        double _emergencyLevel = 0;

        bool _hasReachedWarningTemperature = false;

        protected EventHandlerList _listEventDelegates = new EventHandlerList();

        static readonly object _temperatureReachedWarningLevelKey = new object();
        static readonly object _temperatureFallsBelowWarningLevelKey = new object();
        static readonly object _temperatureReachesEmergencyLevelKey = new object();

        private double[] _temperatureData = null;
        public HeatSensor(double warningLevel, double emergencyLevel)
        {
            _warningLevel = warningLevel;
            _emergencyLevel = emergencyLevel;

            SeedData();
        }

        private void MonitorTemperature()
        {
            foreach(double temp in  _temperatureData)
            {
                Console.ResetColor();
                Console.WriteLine($"DateTime: {DateTime.Now}, Temperature: {temp}");

                if(temp >= _emergencyLevel)
                {
                    TemperatureEventArgs e = new TemperatureEventArgs
                    {
                        Temperature = temp,
                        CurrentDateTime = DateTime.Now,
                    };
                    OnTemperatureReachedEmergencyLevel(e);
                }
                else if(temp >= _warningLevel)
                {
                    _hasReachedWarningTemperature = true;
                    TemperatureEventArgs e = new TemperatureEventArgs
                    {
                        Temperature = temp,
                        CurrentDateTime = DateTime.Now,
                    };
                    OnTemperatureReachesWarningLevel(e);
                }
                else if (temp < _warningLevel && _hasReachedWarningTemperature)
                {
                    _hasReachedWarningTemperature = false;
                    TemperatureEventArgs e = new TemperatureEventArgs
                    {
                        Temperature = temp,
                        CurrentDateTime = DateTime.Now,
                    };
                    OnTemperatureFallsBelowWarningLevel(e);
                }

                System.Threading.Thread.Sleep(1000);
            }
        }
        private void SeedData()
        {
            _temperatureData = new double[]{ 16, 17, 5, 18, 19, 22, 24, 26, 75, 28, 7, 27, 6, 26, 24, 22, 68, 86, 45 };

        }

        event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachesEmergencyLevelEventHandler
        {
            add
            {
                _listEventDelegates.AddHandler(_temperatureReachesEmergencyLevelKey, value);
            }

            remove
            {
                _listEventDelegates.RemoveHandler(_temperatureReachesEmergencyLevelKey, value);
            }
        }

        event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachesWarningLevelEventHandler
        {
            add
            {
                _listEventDelegates.AddHandler(_temperatureReachedWarningLevelKey, value);
            }

            remove
            {
                _listEventDelegates.RemoveHandler(_temperatureReachedWarningLevelKey, value);
            }
        }

        event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureFailsBelowWarningLevelEventHandler
        {
            add
            {
                _listEventDelegates.AddHandler(_temperatureFallsBelowWarningLevelKey, value);
            }

            remove
            {
                _listEventDelegates.RemoveHandler(_temperatureFallsBelowWarningLevelKey, value);
            }
        }
        public void RunHeatSensor()
        {
            Console.WriteLine("Heat sensor is Running......");
            MonitorTemperature();
        }

        protected void OnTemperatureReachesWarningLevel(TemperatureEventArgs e)
        {
            EventHandler<TemperatureEventArgs> handler = (EventHandler<TemperatureEventArgs>)_listEventDelegates[_temperatureReachesEmergencyLevelKey];

            if(handler != null)
            {
                handler(this, e);
            }
        }
        protected void OnTemperatureFallsBelowWarningLevel(TemperatureEventArgs e)
        {
            EventHandler<TemperatureEventArgs> handler = (EventHandler<TemperatureEventArgs>)_listEventDelegates[_temperatureFallsBelowWarningLevelKey];

            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected void OnTemperatureReachedEmergencyLevel(TemperatureEventArgs e)
        {
            EventHandler<TemperatureEventArgs> handler = (EventHandler<TemperatureEventArgs>)_listEventDelegates[_temperatureReachesEmergencyLevelKey];

            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
    public interface IHeatSensor
    {
        event EventHandler<TemperatureEventArgs> TemperatureReachesEmergencyLevelEventHandler;
        event EventHandler<TemperatureEventArgs> TemperatureReachesWarningLevelEventHandler;
        event EventHandler<TemperatureEventArgs> TemperatureFailsBelowWarningLevelEventHandler;

        void RunHeatSensor();
    }
    public class TemperatureEventArgs : EventArgs
    {
        public double Temperature { get; set; }
        public DateTime CurrentDateTime { get; set; }
    }
}