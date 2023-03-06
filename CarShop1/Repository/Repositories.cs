using Carshop.Models;

namespace CarShop1.Repository
{
    public class Repositories
    {

        private int _NextID;
        private List<Car> cars;

        public Repositories() 
        {
            _NextID = 1;
            cars = new List<Car>()
            {
                new Car{ Id = 1, Model = "Bmw", Price =150000, LicensPlat = "CA23335" },
                new Car{ Id = 2, Model = "Mercedes",Price = 155000, LicensPlat = "AA50551"},
                new Car{ Id = 3, Model = "Audi", Price = 175000, LicensPlat = "HA02067"},
                new Car{ Id = 4, Model = "Cadilac", Price = 195000, LicensPlat = "LI27092"},
                new Car{ Id = 5, Model = "VW", Price =150000, LicensPlat = "CA23335" },
                new Car{ Id = 6, Model = "Toyota",Price = 125000, LicensPlat = "AA50998"},
                new Car{ Id = 7, Model = "Jaguar", Price = 275000, LicensPlat = "SA22067"},
                new Car{ Id = 8, Model = "Honda", Price = 135000, LicensPlat = "AR54101"}


            };
        }

        public List<Car> GetAlle(int?amount,string? model, int? minprice, int? maxprice)
        {
            List<Car> result = new List<Car>(cars);
            if(model != null)
            {
                result=result.FindAll(r=>r.Model.Contains(model, StringComparison.InvariantCultureIgnoreCase));
            }

            if (minprice != null)
            {
                result = result.FindAll(r => r.Price >= minprice);
            }
            if (maxprice != null)
            {
                result = result.FindAll(r => r.Price <= maxprice);
            }
            if(amount != null)
            {
                int pasedamount= (int) amount;
                result=result.Take(pasedamount).ToList();
            }

            return result;
        }

        public Car? GetCarByID(int id)
        {
            return cars.Find(c => c.Id == id);
        }

        public Car Add(Car newcar)
        {  
            newcar.Validate();
            newcar.Id = _NextID++;
            cars.Add(newcar);
            return newcar;
        }

        public Car Update(int id, Car updates)
        {
            Car? foundCar = GetCarByID(id);
            if (foundCar == null)
            {
                return null;
            }
            foundCar.Model = updates.Model;
            foundCar.Price = updates.Price;
            foundCar.LicensPlat = updates.LicensPlat;
            return foundCar;

        }


        public Car? Delete(int id)
        {
            Car? foundCar = GetCarByID(id);

            if (foundCar == null)
            {
                return null;
            }
            cars.Remove(foundCar);
            return foundCar;


        }

    }
}
