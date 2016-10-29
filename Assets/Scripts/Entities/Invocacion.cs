using System.Collections.Generic;

namespace Entities {
    public class Invocacion : IEntity {
        /*
         * invocacionId
         * nombre
         * descripcion
         * animacion
         * listaAtributos
         * listaHabilidades
         * nivel
         * 
        */

        private int invocacionId;
        private string nombre;
        private string descripcion;
        private List<Atributo> listaAtributos;
        private List<Habilidad> listaHabilidades;
        private int nivel;

        public int InvocacionId {
            get { return invocacionId; }
            set { invocacionId = value; }
        }

        public string Nombre {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Descripcion {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public List<Atributo> ListaAtributos {
            get { return listaAtributos; }
            set { listaAtributos = value; }
        }

        public List<Habilidad> ListaHabilidades {
            get { return listaHabilidades; }
            set { listaHabilidades = value; }
        }

        public int Nivel {
            get { return nivel; }
            set { nivel = value; }
        }
    }
}