using System;
using System.Collections.Generic;
using Entities;
using System.Data;

namespace Assets.Scripts.Mapper {
    class PersonajeMapper {

        public PersonajeMapper() { }
        /*
         * personajeId
         * Nombre
         * Peso
         * listaAtributos
         * listaClases
         * raza
         * listaItems
         * 
         */
        public Personaje assignValuesFrom(IDataReader reader) {
            Personaje personaje = new Personaje();
            personaje.PersonajeId = (int) reader["personajeID"];
            personaje.Nombre = (string) reader["nombre"];
            personaje.Peso = (int)reader["descripcion"];
            personaje.ListaAtributos = (List<Atributo>)reader["atributoID"];
            personaje.ListaClases = (List<Clase>) reader["claseID"];
            personaje.Raza = (Raza) reader["razaID"];
            personaje.ListaItems = (List<Item>) reader["itemID"];

            return personaje;
        }

        public List<Personaje> getListPersonajesFrom(IDataReader reader) {
            List<Personaje> listPersonajes = new List<Personaje>();
            while (reader.Read()) {
                listPersonajes.Add( assignValuesFrom( reader ) );
            }
            return listPersonajes;
        }
    }
}
