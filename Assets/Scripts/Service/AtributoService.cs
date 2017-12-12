using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Implement;
using Entities;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Service {
    public class AtributoService : IDaoBase<Atributo> {

        AtributoImplementacion atributoI;

        public AtributoService() {
            atributoI = new AtributoImplementacion();
        }

        public void Add(Atributo atributo) {
            atributoI.Add( atributo );
        }

        public void Delete(int atributoId) {
            atributoI.Delete( atributoId );
        }

        public void Update(Atributo atributo) {
            atributoI.Update( atributo );
        }

        public Atributo getById(int atributoId) {
            return atributoI.getById( atributoId );
        }

        public Atributo getByName(string name) {
            return atributoI.getByName( name );
        }

        public List<Atributo> getAll() {
            return atributoI.getAll();
        }

        public int getCount() {
            return atributoI.getCount();
        }
    }
}