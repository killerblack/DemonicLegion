using System.Collections.Generic;

namespace Entities {
    public class Habilidad {

        /*
         * habilidadId
         * Nombre
         * Descripción
         * Tipo
         * Icono
         * tipoElementium. Elementium por clase
         * Potencia de Sanación. Se aplica a la formula de curacion
         * Modulador. Se aplica a la formula de curacion
         * Alcance (1 o varios enemigos)
         * listaEstadosAlterados. Estado alterado que puede producir la habilidad
         * listaElementos (fuego, agua, etc.)
         * Costo de Energia
         * Costo de PV
         * Función extra (según la clase, morfo, hunter e invocador las raras) Y por cada habilidad settear que atributos modifica
         */

        private int habilidadId;
        private string nombre;
        private string descripcion;
        private string tipo;
        private byte[] icono;
        private string tipoElementium;
        private float potenciaSanacion;
        private float modulador;
        private int alcance;
        private List<EstadoAlterado> listaEstadosAlterados;
        private List<Elemento> listaElementos;
        private int costoEnergia;
        private int costoPV;

        public int HabilidadId {
            get { return habilidadId; }
            set { habilidadId = value; }
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

        public string Tipo {
            get { return tipo; }
            set { tipo = value; }
        }

        public string TipoElementium {
            get { return tipoElementium; }
            set { tipoElementium = value; }
        }

        public List<EstadoAlterado> ListaEstadosAlterados {
            get { return listaEstadosAlterados; }
            set { listaEstadosAlterados = value; }
        }

        public List<Elemento> ListaElementos {
            get { return listaElementos; }
            set { listaElementos = value; }
        }

        public int CostoPV {
            get { return costoPV; }
            set { costoPV = value; }
        }

        public int CostoEnergia {
            get { return costoEnergia; }
            set { costoEnergia = value; }
        }

        public float PotenciaSanacion {
            get { return potenciaSanacion; }
            set { potenciaSanacion = value; }
        }

        public float Modulador {
            get { return modulador; }
            set { modulador = value; }
        }

        public int Alcance {
            get { return alcance; }
            set { alcance = value; }
        }

    }
}