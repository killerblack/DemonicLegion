using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Implement;
using Entities;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Service {
    public class RazaService : IDaoBase<Raza> {

        RazaImplementacion razaI;

        public RazaService() {
            razaI = new RazaImplementacion();
        }

        public void Add(Raza raza) {
            razaI.Add( raza );
        }

        public void Delete(int razaId) {
            razaI.Delete( razaId );
        }

        public void Update(Raza raza) {
            razaI.Update( raza );
        }

        public Raza getById(int razaId) {
            return razaI.getById( razaId );
        }

        public Raza getByName(string name) {
            return razaI.getByName( name );
        }

        public List<Raza> getAll() {
            return razaI.getAll();
        }

        public int getCount() {
            return razaI.getCount();
        }
    }
}