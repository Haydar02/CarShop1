using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarShop1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carshop.Models;

namespace CarShop1.Repository.Tests
{
    [TestClass()]
    public class RepositoriesTests
    {
        [TestMethod()]
        public void GetAlleTest()
        {
            Repositories repository = new Repositories();
            List<Car> cars = repository.GetAlle(5,"",1,100000000);
            Assert.IsNotNull(cars);
            Assert.IsTrue(cars.Count() >= 1);

        }
        [TestMethod()]
        public void GetCarByIDTest()
        {
            Repositories repository = new Repositories();
            Car? car = repository.GetCarByID(1);
            Assert.IsNotNull(car);
            Assert.AreEqual(car.Id, 1);
            Assert.AreEqual(car.Model, "Bmw");
            Assert.AreNotEqual(car.Price, 15000);
            Assert.AreNotEqual(car.LicensPlat, "popop1");


        }
        [TestMethod()]
        public void AddTest()
        {
            Car newcar = new Car { Id = 15, Model = "Skoda", Price =155 , LicensPlat = "CA23335" };
            Repositories repository = new Repositories();
            Car car = repository.Add(newcar);

           Assert.AreEqual(car.Id, 1);
           Assert.AreNotEqual(car.Model,"Audi");
            Assert.AreEqual(car.Price, 155);
            Assert.IsNotNull(car.LicensPlat);


        }
        [TestMethod()]

        public void DeleteTest()
        {
            Car newcar = new Car { Id = 1, Model = "Bmw", Price = 150000, LicensPlat = "CA23335" };

            Repositories repository = new Repositories();
            Car? car = repository.Delete(15);
            Assert.IsFalse(car != null);
        }
        [TestMethod()]
        public void UpdateTest()
        {
            Car newcar = new Car { Id = 15, Model = "Bmw", Price = 150000, LicensPlat = "CA23335" };
            Repositories repository = new Repositories();
            Car car = repository.Update(1, newcar);

            Assert.AreEqual (car.Id, 1);

        }
    }


}
