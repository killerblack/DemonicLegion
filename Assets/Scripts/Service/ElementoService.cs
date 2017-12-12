using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Implement;
using Entities;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Service {
    public class ElementoService : IDaoBase<Elemento> {

        ElementoImplementacion elementoI;

        public ElementoService() {
            elementoI = new ElementoImplementacion();
        }

        public void Add(Elemento elemento) {
            elementoI.Add( elemento );
        }

        public void Delete(int elementoId) {
            elementoI.Delete( elementoId );
        }

        public void Update(Elemento elemento) {
            elementoI.Update( elemento );
        }

        public Elemento getById(int elementoId) {
            return elementoI.getById( elementoId );
        }

        public Elemento getByName(string name) {
            return elementoI.getByName( name );
        }

        public List<Elemento> getAll() {
            return elementoI.getAll();
        }

        public int getCount() {
            return elementoI.getCount();
        }
    }
}