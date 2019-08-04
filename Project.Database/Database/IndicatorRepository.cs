using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Project.BusinessLogic.Contract.Interface.Database;
using Project.BusinessLogic.Contract.Interface.Model;
using Project.Database.Model;

namespace Project.Database.Database
{
	public class IndicatorRepository: IRepository<IIndicator>
	{
		private readonly IMapper _mapper;

		public IndicatorRepository(IMapper mapper) {
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public IEnumerable<IIndicator> GetCollection() {
			using (var dbContext = new EntityDbContext()) {
				return dbContext.Indicators.ToList().Select(_mapper.Map<IIndicator>);
			}
		}

		public void Add(IIndicator indicator) {
			using (var dbContext = new EntityDbContext()) {
				IndicatorEntity newIndicator = _mapper.Map<IndicatorEntity>(indicator);
				dbContext.Indicators.Add(newIndicator);
				dbContext.SaveChanges();
			}
		}

		public void Edit(IIndicator indicator) {
			using (var dbContext = new EntityDbContext()) {
				IndicatorEntity editIndicator = dbContext.Indicators.Find(indicator.Id);
				_mapper.Map(indicator, editIndicator);
				dbContext.SaveChanges();
			}
		}

		public void Remove(IIndicator indicator) {
			using (var dbContext = new EntityDbContext()) {
				IndicatorEntity deleteIndicator = dbContext.Indicators.Find(indicator.Id);
				if (deleteIndicator == null) return;
				dbContext.Indicators.Remove(deleteIndicator);
				dbContext.SaveChanges();
			}
		}
	}
}