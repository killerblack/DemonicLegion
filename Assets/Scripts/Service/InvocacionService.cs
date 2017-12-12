using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Implement;
using Entities;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Service {
    public class InvocacionService : IDaoBase<Invocacion> {

        InvocacionImplementacion invocacionI;

        public InvocacionService() {
            invocacionI = new InvocacionImplementacion();
        }

        public void Add(Invocacion invocacion) {
            invocacionI.Add( invocacion );
        }

        public void Delete(int invocacionId) {
            invocacionI.Delete( invocacionId );
        }

        public void Update(Invocacion invocacion) {
            invocacionI.Update( invocacion );
        }

        public Invocacion getById(int invocacionId) {
            return invocacionI.getById( invocacionId );
        }

        public Invocacion getByName(string name) {
            return invocacionI.getByName( name );
        }

        public List<Invocacion> getAll() {
            return invocacionI.getAll();
        }

        public int getCount() {
            return invocacionI.getCount();
        }
    }
}