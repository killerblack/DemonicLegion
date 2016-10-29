using System.Collections.Generic;

namespace Entities {
    public class Armadura : IEntity {
        /**
         * 	id
         *	nombre
         *	descripción
         *	icono
         *	tipo
         *	precio
         *	peso. El peso del arma afecta a la fuerza de cada ataque.
         *	nivel. El nivel del arma con un rango de 1-20
         *	listaElementos. lista de elementos que tiene la armadura
         *	listaEstadosAlterados. Lista de estados alterados que posee el arma como maldicion, o petra, etc.
         *	listaAtributos. Lista de atributos que afecta como fuerza, inteligencia, etc.
         *	
         *	listaClases. Lista de clases que la puede equipar.
         *	listaRazas. Lista de razas que la puede equipar.
         *	listaItems. Lista de objetos que pueden ser equipado para mejora.
         *
         **/

        private int armaduraId;
        private string nombre;
        private string descripcion;
        private byte[] icono;
        private int tipo;
        private int precio;
        private int peso;
        private int nivel;
        private List<Elemento> listaElementos;
        private List<EstadoAlterado> listaEstadosAlterados;
        private List<Atributo> listaAtributos;

        private List<Clase> listaClases;
        private List<Raza> listaRazas;
        private List<Item> listaItems;


        public int ArmaduraId {
            get { return armaduraId; }
            set { armaduraId = value; }
        }

        public string Nombre {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Descripcion {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public byte[] Icono {
            get { return icono; }
            set { icono = value; }
        }

        public int Tipo {
            get { return tipo; }
            set { tipo = value; }
        }

        public int Precio {
            get { return precio; }
            set { precio = value; }
        }

        public int Peso {
            get { return peso; }
            set { peso = value; }
        }

        public int Nivel {
            get { return nivel; }
            set { nivel = value; }

        }

        public List<Elemento> ListaElementos {
            get { return listaElementos; }
            set { listaElementos = value; }
        }

        public List<EstadoAlterado> ListaEstadosAlterados {
            get { return listaEstadosAlterados; }
            set { listaEstadosAlterados = value; }
        }

        public List<Atributo> ListaAtributos {
            get { return listaAtributos; }
            set { listaAtributos = value; }
        }

        public List<Clase> ListaClases {
            get { return listaClases; }
            set { listaClases = value; }
        }

        public List<Raza> ListaRazas {
            get { return listaRazas; }
            set { listaRazas = value; }
        }

        public List<Item> ListaItems {
            get { return listaItems; }
            set { listaItems = value; }
        }

    }
}