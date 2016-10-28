namespace Entities {
    public class Atributo {
        /*	
         * atributoId
         * nombre
         * description
         * valor
         * 
         */

        private int atributoId;
        private string nombre;
        private string descripcion;
        private int valor;

        public int AtributoId {
            get { return atributoId; }
            set { atributoId = value; }
        }

        public string Nombre {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Descripcion {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int Valor {
            get { return valor; }
            set { valor = value; }
        }

    }
}