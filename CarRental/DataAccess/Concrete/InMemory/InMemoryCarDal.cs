using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _carDal;
        public InMemoryCarDal()
        {
            _carDal = new List<Car> { new Car { Id = 1, BrandId = 1, ColorId = 2, ModelYear = "1998", DailyPrice = 120, Description = "CCZ" } };
            _carDal = new List<Car> { new Car { Id = 2, BrandId = 2, ColorId = 3, ModelYear = "2001", DailyPrice = 150, Description = "BBA" } };
            _carDal = new List<Car> { new Car { Id = 3, BrandId = 2, ColorId = 4, ModelYear = "2005", DailyPrice = 180, Description = "ZZX" } };
            _carDal = new List<Car> { new Car { Id = 4, BrandId = 4, ColorId = 4, ModelYear = "2011", DailyPrice = 220, Description = "RX" } };
          //SimuleEttik
        }
        public void Add(Car car)
        {
            _carDal.Add(car);       //Ekledik
        }

        public void Delete(Car car)
        {
            Car carToDelete = _carDal.SingleOrDefault(c => c.Id == car.Id);
            _carDal.Remove(carToDelete);   //LİNQ İle Silme İşlemi
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _carDal;  //Hepsini Döndürdük
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllBrand(int BrandId)
        {
            return _carDal.Where(c => c.BrandId == BrandId).ToList();
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _carDal.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
