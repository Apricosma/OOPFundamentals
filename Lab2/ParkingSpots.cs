using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementDemo
{
    // ParkingSpot tracks the relationship between Vehicles and CarParks
    // many-to-many relationship
    // vehicles can be parked at many different carparks
    // carparks can store many different vehicles
    public class ParkingSpot
    {
        private int _number;
        private Vehicle _vehicle;
        private CarPark _carPark;

        // exposes the CarPark object on the ParkingSpot
        // but we have total control over what is exposed on the CarPark object itself
        public CarPark CarPark { get { return _carPark; } }

        // exposes the _carPark value to be set
        public void SetCarPark(CarPark carPark)
        {
            _carPark = carPark;
        }

        public Vehicle Vehicle
        {
            get { return _vehicle; }
            set { _vehicle = value; }
        }

        public ParkingSpot(int number, CarPark carPark)
        {
            _number = number;
            _carPark = carPark;
        }

        public ParkingSpot(int number)
        {
            _number = number;
        }
    }
}