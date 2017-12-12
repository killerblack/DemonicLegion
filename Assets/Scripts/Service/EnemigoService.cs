using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Implement;
using Entities;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Service {
    public class EnemigoService : IDaoBase<Enemigo> {

        EnemigoImplementacion enemigoI;

        public EnemigoService() {
            enemigoI = new EnemigoImplementacion();
        }

        public void Add(Enemigo enemigo) {
            enemigoI.Add( enemigo );
        }

        public void Delete(int enemigoId) {
            enemigoI.Delete( enemigoId );
        }

        public void Update(Enemigo enemigo) {
            enemigoI.Update( enemigo );
        }

        public Enemigo getById(int enemigoId) {
            return enemigoI.getById( enemigoId );
        }

        public Enemigo getByName(string name) {
            return enemigoI.getByName( name );
        }

        public List<Enemigo> getAll() {
            return enemigoI.getAll();
        }

        public int getCount() {
            return enemigoI.getCount();
        }
    }
}