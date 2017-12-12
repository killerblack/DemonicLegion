using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Implement;
using Entities;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Service {
    public class PersonajeService : IDaoBase<Personaje> {

        PersonajeImplementacion personajeI;

        public PersonajeService() {
            personajeI = new PersonajeImplementacion();
        }

        public void Add(Personaje personaje) {
            personajeI.Add( personaje );
        }

        public void Delete(int personajeId) {
            personajeI.Delete( personajeId );
        }

        public void Update(Personaje personaje) {
            personajeI.Update( personaje );
        }

        public Personaje getById(int personajeId) {
            return personajeI.getById( personajeId );
        }

        public Personaje getByName(string name) {
            return personajeI.getByName( name );
        }

        public List<Personaje> getAll() {
            return personajeI.getAll();
        }

        public int getCount() {
            return personajeI.getCount();
        }
    }
}