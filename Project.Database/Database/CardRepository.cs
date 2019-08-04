using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Project.BusinessLogic.Contract.Interface.Database;
using Project.BusinessLogic.Contract.Interface.Model;
using Project.Database.Model;

namespace Project.Database.Database
{
	public class CardRepository: IRepository<ICard>
	{
		private readonly IMapper _mapper;

		public CardRepository(IMapper mapper) {
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public IEnumerable<ICard> GetCollection() {
			using (var dbContext = new EntityDbContext()) {
				return dbContext.Cards.ToList().Select(_mapper.Map<ICard>);
			}
		}

		public void Add(ICard indicator) {
			using (var dbContext = new EntityDbContext()) {
				CardEntity newCard = _mapper.Map<CardEntity>(indicator);
				dbContext.Cards.Add(newCard);
				dbContext.SaveChanges();
			}
		}

		public void Edit(ICard card) {
			using (var dbContext = new EntityDbContext()) {
				CardEntity editCard = dbContext.Cards.Find(card.Id);
				_mapper.Map(card, editCard);
				dbContext.SaveChanges();
			}
		}

		public void Remove(ICard card) {
			using (var dbContext = new EntityDbContext()) {
				CardEntity deleteCard = dbContext.Cards.Find(card.Id);
				if (deleteCard == null) return;
				dbContext.Cards.Remove(deleteCard);
				dbContext.SaveChanges();
			}
		}
	}
}