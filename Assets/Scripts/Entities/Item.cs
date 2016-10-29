using System.Collections.Generic;

namespace Entities {
    public class Item : IEntity {

        /*
         * itemId
         * nombre
         * tipo
         * descripción
         * icono
         * precio
         * peso
         * cantidad. Numero de objetos disponibles
         * consumible. que se termina si se usa depende la cantidad que haya del objeto
         * alcance. Un jugador, varios enemigos, etc.
         * usableEn. donde es usable
         * pocentajeExito. porcentaje de éxito al ser usado
         * nivel. Comparable con el nivel del personaje
         * listaItemsCompatibles. Compatibles para combinaciones
         * listaAtributos. Atributos que afecta al ser usado o equipado
         * listaArmas. Arma(s) aplicable(s)
         * listaArmaduras. Armadura(s) aplicables(s)
         * listaElementos. posibles elementos ligados al objeto
         * 
        */

        private int itemId;
        private string nombre;
        private string tipo;
        private string descripcion;
        private byte[] icono;
        private float precio;
        private float peso;
        private int cantidad;
        private int consumible;
        private string alcance;
        private string usableEn;
        private float porcentajeExito;
        private int nivel;
        private List<Item> listaItemsCompatibles;
        private List<Atributo> listaAtributos;
        private List<Arma> listaArmas;
        private List<Armadura> listaArmaduras;
        private List<Elemento> listaElementos;

        public int ItemId {
            get { return itemId; }
            set { itemId = value; }
        }

        public string Nombre {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Descripcion {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Tipo {
            get { return tipo; }
            set { tipo = value; }
        }

        public byte[] Icono {
            get { return icono; }
            set { icono = value; }
        }

        public float Precio {
            get { return precio; }
            set { precio = value; }
        }

        public float Peso {
            get { return peso; }
            set { peso = value; }
        }

        public int Cantidad {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public int Consumible {
            get { return consumible; }
            set { consumible = value; }
        }

        public string Usable {
            get { return usableEn; }
            set { usableEn = value; }
        }

        public float PorcentajeExito {
            get { return porcentajeExito; }
            set { porcentajeExito = value; }
        }

        public int Nivel {
            get { return nivel; }
            set { nivel = value; }
        }

        public List<Item> ListaItemsCompatibles {
            get { return listaItemsCompatibles; }
            set { listaItemsCompatibles = value; }
        }

        public List<Atributo> ListaAtributos {
            get { return listaAtributos; }
            set { listaAtributos = value; }
        }

        public List<Arma> ListaArmas {
            get { return listaArmas; }
            set { listaArmas = value; }
        }

        public List<Armadura> ListaArmaduras {
            get { return listaArmaduras; }
            set { listaArmaduras = value; }
        }

        public List<Elemento> ListaElementos {
            get { return listaElementos; }
            set { listaElementos = value; }
        }

        public string Alcance {
            get { return alcance; }
            set { alcance = value; }
        }
    }
}