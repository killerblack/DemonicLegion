using System.Collections.Generic;

namespace Entities {
    public class Mascota {

        /*
         * mascotaId
         * nombre
         * descripcion
         * apodo
         * listaClases. Las clases que pueden usar la mascota
         * listaAtributos. Lista de atributos de la mascota
         * 
         */

        private int mascotaId;
        private string nombre;
        private string descripcion;
        private string apodo;
        private List<Clase> listaClases;
        private List<Atributo> listaAtributos;

        public int MascotaId {
            get { return mascotaId; }
            set { mascotaId = value; }
        }

        public string Nombre {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Descripcion {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Apodo {
            get { return apodo; }
            set { apodo = value; }
        }

        public List<Clase> ListaClases {
            get { return listaClases; }
            set { listaClases = value; }
        }

        public List<Atributo> ListaAtributos {
            get { return listaAtributos; }
            set { listaAtributos = value; }
        }
    }
}