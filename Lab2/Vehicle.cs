using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarparkDemo
{
    public class Vehicle
    {
        // start with a private field with no accessors
        private string _licenseNumber = "0000000";
        // if find that we need to read the value, add a get method on a public Property
        // readonly property: no set method
        public string LicenseNumber { get { return _licenseNumber; } }
        private void UpdateLicenseNumber(string licenseNumber)
        {
            // add all validations
            // add whatever syntax or notes that make clear that this method should only be invoked under specific circumstances
            if (licenseNumber.Length < 3 || licenseNumber.Length > 7 ||
                !licenseNumber.All(c => Char.IsLetterOrDigit(c)))
            {
                throw new Exception("License number must be between 3 and 7 alphanumeric characters long.");
            }
            else
            {
                _licenseNumber = licenseNumber;
            }
        }

        private HashSet<ParkingSpot> _parkingSpots = new HashSet<ParkingSpot>();
        public Vehicle(string licenseNumber)
        {
            UpdateLicenseNumber(licenseNumber);
        }
    }
}