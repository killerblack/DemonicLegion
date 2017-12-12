using System.Collections.Generic;

namespace Entities {
    public class Arma : IEntity {
        /*
	     * 	armaId
	     *	nombre
	     *	descripción
	     *	icono
	     *	tipo. El tipo de arma puede ser hacha, espada, etc.
	     *	precio. Cuanto cuesta el arma en tienda
         *	bonoSanacion. Cantidad de sanacion que agrega el arma a la formula de sanacion.
	     *	peso. El peso del arma afecta a la fuerza de cada ataque.
	     *	nivel. El nivel del arma con un rango de 1-20
	     *	listaAtributos. Lista de Atributos que afecta el arma como fuerza, inteligencia, etc.
	     *	listaElementos. Elemento que posee como fuego, agua, etc.
	     *	listaEstadosAlterados. Lista de estados alterados que posee el arma como maldicion, o petra, etc.
	     *	listaClases. Lista de clases que la puede equipar.
	     *	listaRazas. Lista de razas que la puede equipar.
	     *	listaItems. Lista de objetos que pueden ser equipado para mejora.
	    */

        private int armaId;
        private string nombre;
        private string descripcion;
        private byte[] icono;
        private int tipo;
        private int precio;
        private int bonoSanacion;
        private int peso;
        private int nivel;
        private List<Atributo> listaAtributos;
        private List<Elemento> listaElementos;
        private List<EstadoAlterado> listaEstadosAlterados;
        private List<Clase> listaClases;
        private List<Raza> listaRazas;
        private List<Item> listaItems;

        public int ArmaId{
            get { return armaId; }
            set { armaId = value; }
        }

        public string Nombre{
            get { return nombre; }
            set { nombre = value; }
        }

        public string Descripcion{
            get { return descripcion; }
            set { descripcion = value; }
        }

        public byte[] Icono{
            get { return icono; }
            set { icono = value; }
        }

        public int Tipo{
            get { return tipo; }
            set { tipo = value; }
        }

        public int Precio{
            get { return precio; }
            set { precio = value; }
        }

        public List<Atributo> ListaAtributos{
            get { return listaAtributos; }
            set { listaAtributos = value; }
        }

        public List<Elemento> ListaElementos{
            get { return listaElementos; }
            set { listaElementos = value; }
        }

        public List<EstadoAlterado> ListaEstadosAlterados{
            get { return listaEstadosAlterados; }
            set { listaEstadosAlterados = value; }
        }

        public List<Clase> ListaClases{
            get { return listaClases; }
            set { listaClases = value; }
        }

        public List<Raza> ListaRazas{
            get { return listaRazas; }
            set { listaRazas = value; }
        }

        public int BonoSanacion{
            get { return bonoSanacion; }
            set { bonoSanacion = value; }
        }

        public List<Item> ListaItems{
            get { return listaItems; }
            set { listaItems = value; }
        }

        public int Peso{
            get { return peso; }
            set { peso = value; }
        }

        public int Nivel{
            get { return nivel; }
            set { nivel = value; }
        }
    }
}