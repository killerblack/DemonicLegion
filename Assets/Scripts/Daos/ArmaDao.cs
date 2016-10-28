using Entities;
using System.Collections.Generic;

interface ArmaDao{
	Arma getArmaById(int id);
	Arma getArmaByNombre(string nombre);
	List<Arma> getAllArmas();
	int getNumberOfArmas();
}
