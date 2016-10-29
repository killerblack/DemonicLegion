using System.Collections.Generic;

namespace Entities {
    public class EstadoAlterado : IEntity {
        /*
         * estadoAlteradoId
         * nombre
         * descripción
         * icono
         * Costo de Energia
         * listaAtributos que afecta (propiedades o de impacto)
         * 
         */

        private int estadoAlteradoId;
        private string nombre;
        private string descripcion;
        private byte[] icono;
        private int costoEnergia;

        private List<Atributo> listaAtributos;

        public int EstadoAlteradoId {
            get { return estadoAlteradoId; }
            set { estadoAlteradoId = value; }
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

        public int CostoEnergia {
            get { return costoEnergia; }
            set { costoEnergia = value; }
        }

        public List<Atributo> ListaAtributos {
            get { return listaAtributos; }
            set { listaAtributos = value; }
        }
    }
}