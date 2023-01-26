using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementDemo
{
    public class CarPark
    {
        private HashSet<ParkingSpot> _parkingSpots = new HashSet<ParkingSpot>();

        // expose specific methods on the collection, not the entire collection
        public void AddParkingSpot(ParkingSpot parkingSpot)
        {
            _parkingSpots.Add(parkingSpot);
            // bi-directional relationship -- set this CarPark as the parking spot's property
            parkingSpot.SetCarPark(this);
        }

        // expose a COPY of our list (not a reference)
        public HashSet<ParkingSpot> GetParkingSpots()
        {
            HashSet<ParkingSpot> spotReferenceCopies;

            // toHashSet returns a HashSet of Elements stored in a collection
            // it does not return the original collection
            spotReferenceCopies = _parkingSpots.ToHashSet();

            // create a new hashset of the parking spots that is a copy of the original hashset, so that the original cannot be modified with this Get Method
            return spotReferenceCopies;
        }

        private int _capacity;
        public int Capacity { get { return _capacity; } }
        private void _setCapacity(int newCapacity)
        {
            if (newCapacity > 0)
            {
                _capacity = newCapacity;
            }
            else
            {
                throw new Exception("Capacity must exceed 0");
            }
        }

        private void _initializeEmptySpots()
        {
            for (int i = 1; i <= Capacity; i++)
            {
                _parkingSpots.Add(new ParkingSpot(i, this));
            }
        }
        private int _spotCount = 1;
        public CarPark(int capacity)
        {
            _setCapacity(capacity);
            //_initializeEmptySpots();
        }
    }
}