using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Implement;
using Entities;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Service {
    public class HabilidadService : IDaoBase<Habilidad> {

        HabilidadImplementacion habilidadI;

        public HabilidadService() {
            habilidadI = new HabilidadImplementacion();
        }

        public void Add(Habilidad habilidad) {
            habilidadI.Add( habilidad );
        }

        public void Delete(int habilidadId) {
            habilidadI.Delete( habilidadId );
        }

        public void Update(Habilidad habilidad) {
            habilidadI.Update( habilidad );
        }

        public Habilidad getById(int habilidadId) {
            return habilidadI.getById( habilidadId );
        }

        public Habilidad getByName(string name) {
            return habilidadI.getByName( name );
        }

        public List<Habilidad> getAll() {
            return habilidadI.getAll();
        }

        public int getCount() {
            return habilidadI.getCount();
        }
    }
}