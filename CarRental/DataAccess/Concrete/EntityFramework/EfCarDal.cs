using Core;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentaCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDtos()
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var result = from p in context.Cars
                             join c in context.Colors
                             on p.Id equals c.ColorId
                             join d in context.Brands
                             on p.Id equals d.BrandId
                             select new CarDetailDto
                             {
                                 ColorName = c.ColorName,
                                 CarName = p.Description,
                                 BrandName = d.BrandName,
                                 DailyPrice = p.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
