using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Implement;
using Entities;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Service {
    public class ClaseService : IDaoBase<Clase> {

        ClaseImplementacion claseI;

        public ClaseService() {
            claseI = new ClaseImplementacion();
        }

        public void Add(Clase clase) {
            claseI.Add( clase );
        }

        public void Delete(int claseId) {
            claseI.Delete( claseId );
        }

        public void Update(Clase clase) {
            claseI.Update( clase );
        }

        public Clase getById(int claseId) {
            return claseI.getById( claseId );
        }

        public Clase getByName(string name) {
            return claseI.getByName( name );
        }

        public List<Clase> getAll() {
            return claseI.getAll();
        }

        public int getCount() {
            return claseI.getCount();
        }
    }
}