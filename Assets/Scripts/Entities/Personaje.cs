using System.Collections.Generic;

namespace Entities {
    public class Personaje {
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

        private int personajeId;
        private string nombre;
        private float peso;
        private List<Atributo> listaAtributos;
        private List<Clase> listaClases;
        private Raza raza;
        private List<Item> listaItems;

        public int PersonajeId {
            get { return personajeId; }
            set { personajeId = value; }
        }

        public string Nombre {
            get { return nombre; }
            set { nombre = value; }
        }

        public float Peso {
            get { return peso; }
            set { peso = value; }
        }

        public List<Atributo> ListaAtributos {
            get { return listaAtributos; }
            set { listaAtributos = value; }
        }

        public List<Clase> ListaClases {
            get { return listaClases; }
            set { listaClases = value; }
        }

        public Raza Raza {
            get { return raza; }
            set { raza = value; }
        }

        public List<Item> ListaItems {
            get { return listaItems; }
            set { listaItems = value; }
        }

    }
}