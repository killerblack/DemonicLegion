using System;
using System.Collections.Generic;
using Entities;
using System.Data;

namespace Assets.Scripts.Mapper {
    class EnemigoMapper {

        public EnemigoMapper() { }
        /*
         * enemigoId
         * Nombre
         * Nivel
         * Experiencia que da
         * listaAtributos
         * Raza
         * listaClases, puede ser null
         * listaObjetos que da
         * gold. Oro que arroja al ser eliminado
         * listaArmas que da debe ser a traves de lista de objetos
         * listaArmaduras que da debe ser a traves de lista de objetos
         * 
         */
        public Enemigo assignValuesFrom(IDataReader reader) {
            Enemigo enemigo = new Enemigo();
            enemigo.EnemigoId = (int) reader["enemigoID"];
            enemigo.Nombre = (string) reader["nombre"];
            enemigo.Nivel = (int) reader["nivel"];
            enemigo.Experiencia = (int) reader["experiencia"];
            enemigo.ListaAtributos = (List<Atributo>) reader["atributoID"];
            enemigo.Raza = (Raza) reader["razaID"];
            enemigo.ListaClases = (List<Clase>) reader["claseID"];
            enemigo.ListaObjetos = (List<Item>) reader["itemID"];
            enemigo.Gold = (int) reader["gold"];

            return enemigo;
        }

        public List<Enemigo> getListEnemigosFrom(IDataReader reader) {
            List<Enemigo> listEnemigo = new List<Enemigo>();
            while (reader.Read()) {
                listEnemigo.Add( assignValuesFrom( reader ) );
            }
            return listEnemigo;
        }
    }
}
