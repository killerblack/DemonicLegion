using System.Data;
using System.Collections.Generic;
using Entities;

namespace Assets.Scripts.Mapper {
    class ClaseMapper {
        public ClaseMapper() { }
        /*
         * claseId
         * nombre
         * descripción
         * tipoElementium. el tipo de elementium que utiliza esta clase
         * gradoExperiencia. grado de experiencia que sube el poder base (inicializar los valores HP, MP, ataque para clase)
         * listaHabilidades. Las habilidades que puede utilizar la clase
         * listaItems. Lista de objetos que puede usar cada clase (objetos tiene armas y armaduras que son las que usa la clase)
         * listaAtributos. Lista de mejoras en los atributos dependiendo la clase
         */
        public Clase assignValuesFrom(IDataReader reader) {
            Clase clase = new Clase();
            clase.ClaseId = (int) reader["claseID"];
            clase.Nombre = (string) reader["nombre"];
            clase.Descripcion = (string) reader["descripcion"];
            clase.TipoElementium = (int) reader["tipoElementium"];
            clase.GradoExperiencia = (int) reader["gradoExperiencia"];
            clase.ListaHabilidades = (List<Habilidad>) reader["habilidadID"];
            clase.ListaItems = (List<Item>) reader["itemID"];
            clase.ListaAtributos = (List<Atributo>) reader["atributoId"];

            return clase;
        }

        public List<Clase> getListClasesFrom(IDataReader reader) {
            List<Clase> listClases = new List<Clase>();
            while (reader.Read()) {
                listClases.Add( assignValuesFrom( reader ) );
            }
            return listClases;
        }
    }
}
