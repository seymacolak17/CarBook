using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
	public class CarPricingRepository : ICarPricingRepository
	{
		private readonly CarBookContext _context;

		public CarPricingRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<CarPricing> GetCarPricingWithCars()
		{
			var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingID == 2).ToList();
			return values;
		}

		public List<CarPricing> GetCarPricingWithTimePeriod()
		{
			throw new NotImplementedException();
		}

		public List<CarPricingViewModel> GetCarPricingWithTimePeriod1()
		{
			List<CarPricingViewModel> values = new List<CarPricingViewModel>();
			using (var command = _context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = "select * from(select Model,CoverImageUrl,Brands.Name as BrandsName,PricingID,Amount from CarPricings Inner Join Cars on Cars.CarID=CarPricings.CarID Inner Join Brands on Brands.BrandID=cars.BrandID) as SourceTable Pivot (Sum(Amount) for PricingID In ([2],[3],[4],[5])) as PivotTable";
				command.CommandType = System.Data.CommandType.Text;
				_context.Database.OpenConnection();
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
						{
							Model = reader["Model"].ToString(),
							CoverImageUrl = reader["CoverImageUrl"].ToString(),
							BrandName = reader["BrandsName"].ToString(),
							Amounts = new List<decimal>
							{
								reader["2"] != DBNull.Value ? Convert.ToDecimal(reader["2"]) : 0,
								reader["3"] != DBNull.Value ? Convert.ToDecimal(reader["3"]) : 0,
								reader["4"] != DBNull.Value ? Convert.ToDecimal(reader["4"]) : 0,
								reader["5"] != DBNull.Value ? Convert.ToDecimal(reader["5"]) : 0
							}

						};
						values.Add(carPricingViewModel);
					}
				}
				_context.Database.CloseConnection();
				return values;
			}
		}
	}
}

/*
 
            var values = from x in _context.CarPricings
                         group x by x.PricingID into g
                         select new
                         {
                             CarId = g.Key,
                             HourlylyPrice = g.Where(y => y.CarPricingID == 2).Sum(z => z.Amount),
                             DailyPrice = g.Where(y => y.CarPricingID == 3).Sum(z => z.Amount),
                             WeeklyPrice = g.Where(y => y.CarPricingID == 4).Sum(z => z.Amount),
                             MonthlyPrice = g.Where(y => y.CarPricingID == 5).Sum(z => z.Amount),
                         };
            return values;
 
 */

//List<CarPricing> values = new List<CarPricing>();
//         using (var command = _context.Database.GetDbConnection().CreateCommand())
//         {
//             command.CommandText = "select * from(select Model,PricingID,Amount from CarPricings Inner Join Cars on Cars.CarID=CarPricings.CarID Inner Join Brands on Brands.BrandID=cars.BrandID) as SourceTable Pivot (Sum(Amount) for PricingID In ([2],[3],[4],[5])) as PivotTable";
//             command.CommandType = System.Data.CommandType.Text;
//             _context.Database.OpenConnection();
//             using (var reader = command.ExecuteReader())
//             {
//                 while (reader.Read())
//                 {
//                     CarPricing carPricing = new CarPricing();
//                     Enumerable.Range(0, values.Count).ToList().ForEach(x =>
//                     {
//                         if (DBNull.Value.Equals(reader[x]))
//                         {
//                             carPricing
//                         }
//                         else
//                         {
//                             carPricing.Amount
//                         }

//                     });
//                     values.Add(carPricing);
//                 }
//             }
//             _context.Database.CloseConnection();
//             return values;
//}