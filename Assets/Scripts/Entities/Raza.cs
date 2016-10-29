using System.Collections.Generic;

namespace Entities {
    public class Raza : IEntity {
        /*
         * Se inician propiedades en cada diferente raza
         * Se configura su invocación racial
         * razaId
         * nombre
         * descripcion
         * listaAtributos
         * listaInvocacionesRaciales
         * 
        */

        private int razaId;
        private string nombre;
        private string descripcion;
        private List<Atributo> listaAtributos;
        private List<Invocacion> listaInvocacionesRaciales;

        public int RazaId {
            get { return razaId; }
            set { razaId = value; }
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

        public List<Invocacion> ListaInvocacionesRaciales {
            get { return listaInvocacionesRaciales; }
            set { listaInvocacionesRaciales = value; }
        }

    }
}