using System.Collections.Generic;

namespace Entities {
    public class Enemigo : IEntity {

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

        private int enemigoId;
        private string nombre;
        private int nivel;
        private int experiencia;
        private List<Atributo> listaAtributos;
        private Raza raza;
        private List<Clase> listaClases;
        private List<Item> listaObjetos;
        private int gold;

        public int EnemigoId {
            get { return enemigoId; }
            set { enemigoId = value; }
        }

        public string Nombre {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Nivel {
            get { return nivel; }
            set { nivel = value; }
        }

        public int Experiencia {
            get { return experiencia; }
            set { experiencia = value; }
        }

        public List<Atributo> ListaAtributos {
            get { return listaAtributos; }
            set { listaAtributos = value; }
        }

        public Raza Raza {
            get { return raza; }
            set { raza = value; }
        }

        public List<Clase> ListaClases {
            get { return listaClases; }
            set { listaClases = value; }
        }

        public List<Item> ListaObjetos {
            get { return listaObjetos; }
            set { listaObjetos = value; }
        }

        public int Gold {
            get { return gold; }
            set { gold = value; }
        }
    }
}