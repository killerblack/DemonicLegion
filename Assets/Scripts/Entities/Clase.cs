using System.Collections.Generic;

namespace Entities {
    public class Clase : IEntity {
        /*
         * claseId
         * nombre
         * descripción
         * tipoElementium. el tipo de elementium que utiliza esta clase
         * gradoExperiencia. grado de experiencia que sube el poder base (inicializar los valores HP, MP, ataque para clase)
         * listaHabilidades. Las habilidades que puede utilizar la clase
         *** listaItems. Lista de objetos que puede usar cada clase (No es muy claro que una clase use objetos en lugar de armas y armaduras)
         * listaAtributos. Lista de mejoras en los atributos dependiendo la clase
         */

        private int claseId;
        private string nombre;
        private string descripcion;
        private int tipoElementium;
        private float gradoExperiencia;
        private List<Habilidad> listaHabilidades;
        private List<Item> listaItems;

        private List<Atributo> listaAtributos;

        public int ClaseId {
            get { return claseId; }
            set { claseId = value; }
        }

        public string Nombre {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Descripcion {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int TipoElementium {
            get { return tipoElementium; }
            set { tipoElementium = value; }
        }

        public float GradoExperiencia {
            get { return gradoExperiencia; }
            set { gradoExperiencia = value; }
        }

        public List<Habilidad> ListaHabilidades {
            get { return listaHabilidades; }
            set { listaHabilidades = value; }
        }

        public List<Item> ListaItems {
            get { return listaItems; }
            set { listaItems = value; }
        }

        public List<Atributo> ListaAtributos {
            get { return listaAtributos; }
            set { listaAtributos = value; }
        }

    }
}