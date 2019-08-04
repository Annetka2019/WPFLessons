using System.Collections.Generic;

namespace Project.BusinessLogic.Contract.Interface.Database
{
	public interface IRepository<T>
	{
		IEnumerable<T> GetCollection();

		void Add(T record);
		void Edit(T record);

		void Remove(T record);
	}
}