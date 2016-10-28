using System;
using System.Collections.Generic;
using Entities;
using System.Data;

namespace Assets.Scripts.Mapper {
    class AtributoMapper {

        public AtributoMapper() { }
        /*	
         * atributoId
         * nombre
         * description
         * valor
         * 
         */
        public Atributo assignValuesFrom(IDataReader reader) {
            Atributo atributo = new Atributo();
            atributo.AtributoId = (int) reader["atributoId"];
            atributo.Nombre = (string) reader["nombre"];
            atributo.Descripcion = (string) reader["descripcion"];
            atributo.Valor = (int) reader["valor"];

            return atributo;
        }

        public List<Atributo> getListAtributosFrom(IDataReader reader) {
            List<Atributo> listAtributo = new List<Atributo>();
            while (reader.Read()) {
                listAtributo.Add( assignValuesFrom( reader ) );
            }
            return listAtributo;
        }
    }
}
