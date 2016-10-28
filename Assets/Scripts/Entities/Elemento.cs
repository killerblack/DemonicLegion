namespace Entities {
    public class Elemento {
        /*
         * elementId
         * nombre
         * descripcion
         * icono
         * porcentaje de daño
         * porcentaje de resistencia
         * 
         */

        private int elementId;
        private string nombre;
        private string descripcion;
        private byte[] icono;
        private float porcentajeDamage;
        private float porcentajeResistencia;

        public int ElementId {
            get { return elementId; }
            set { elementId = value; }
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

        public float PorcentajeDamage {
            get { return porcentajeDamage; }
            set { porcentajeDamage = value; }
        }

        public float PorcentajeResistencia {
            get { return porcentajeResistencia; }
            set { porcentajeResistencia = value; }
        }

    }
}