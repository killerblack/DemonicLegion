using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Implement;
using Entities;
using Assets.Scripts.DataBase;

/**
 * Son los metodos que se deben llamar para invocar datos de Arma de la BD. 
 */
namespace Assets.Scripts.Service {
    public class ArmaService : IDaoBase<Arma> {

        ArmaImplementacion armaI;

        public ArmaService() {
            armaI = new ArmaImplementacion();
        }

        public void Add(Arma arma) {
            armaI.Add( arma );
        }

        public void Delete(int armaId) {
            armaI.Delete(armaId);
        }

        public void Update(Arma arma) {
            armaI.Update( arma );
        }

        public Arma getById(int armaId) {
            return armaI.getById(armaId);
        }

        public Arma getByName(string name) {
            return armaI.getByName(name);
        }

        public List<Arma> getAll() {
            return armaI.getAll();
        }

        public int getCount() {
            return armaI.getCount();
        }
        
    }
}
