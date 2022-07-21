using ProductManagementSystem.Data;
using ProductManagementSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementSystem.Console.Operations
{
    public class ProductLocationOperations
    {

        public static void CreateLocation(ProductManagementContext db)
        {
            System.Console.WriteLine("Creating Location");
            var locationData = GetLocationData();  //this links to the GetProductData method below

            ProductLocation newLocation = new ProductLocation()  //creates a new intance of Product
            {
                Location = locationData.location,
                LocationType = locationData.locationType
            };

            db.Add(newLocation);  //add row to "product" to DB
            db.SaveChanges();   //saves changes to DB
        }

        private static void WriteProductLocation(ProductLocation location)  //this is the location details
        {
            System.Console.WriteLine($"Product Location: {location.Id}");
            System.Console.WriteLine($"Product Location: {location.Location}");
            System.Console.WriteLine($"Product Location Type: {location.LocationType}");
        }

        private static (string location, string locationType) GetLocationData()
        {
            string locationInput = "";  
            while (locationInput == "") // update in the future to validate that the return string starts with one letter and has 6 digits following it
            {
                System.Console.WriteLine("Enter location as Aisle/Bay/Level/Location e.g: A010101");
                locationInput = System.Console.ReadLine();
            }

            List<string> loctypeconsole = new List<string>();
            loctypeconsole.Add("Select from the below location types by typing the number associated with the location type");
            loctypeconsole.Add("1 = PickFace");
            loctypeconsole.Add("2 = Bulk");
            loctypeconsole.Add("3 = Quarantine");
            loctypeconsole.Add("4 = CrossDock");
            foreach(string loctype in loctypeconsole)
            {
                System.Console.WriteLine(loctype);
            }

            string locationType = System.Console.ReadLine();  // lock this at some point so you can only return 1,2,3,4
            if (locationType == "1")
            {
                locationType = "PickFace";
            }
            if (locationType == "2")
            {
                locationType = "Bulk";
            }
            if (locationType == "3")
            {
                locationType = "Quarantine";
            }
            if (locationType == "4")
            {
                locationType = "CrossDock";
            }

            System.Console.WriteLine($"New Location {locationInput} type {locationType}");

            return (locationInput, locationType);
        }

        public static void ListLocation(ProductManagementContext db)
        {
            foreach(ProductLocation i in db.ProductLocation)
            {
                WriteProductLocation(i);
            }
        }



        public static void DeleteLocation(ProductManagementContext db)
        {

            System.Console.WriteLine("Deleting Location");

            System.Console.Write("What is the location Id you would like to delete: ");
            int id = int.Parse(System.Console.ReadLine());

            ProductLocation? locationP = db.ProductLocation.FirstOrDefault(x => x.Id == id);

            if (locationP == null)
            {
                System.Console.WriteLine($"Product with Id {id} not found!");
            }
            else
            {
                System.Console.WriteLine("You are deleting the following location:");
                System.Console.WriteLine("update this");

                db.Remove(locationP);
                db.SaveChanges();
            }

        }


    }
}
