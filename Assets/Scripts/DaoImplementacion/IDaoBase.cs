using System.Collections.Generic;
using Entities;

public interface IDaoBase<T> where T : IEntity{
	void Add(T entity);
	void Delete(int id);
	void Update(T entity);
	T getById(int id);
	T getByName(string name);
	List<T> getAll();
	int getCount();
}

