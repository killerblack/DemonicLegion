using System;
using System.Collections.Generic;
using Entities;
using System.Data;

namespace Assets.Scripts.Mapper {
    class EstadoAlteradoMapper {

        public EstadoAlteradoMapper() { }
        /*
         * estadoAlteradoId
         * nombre
         * descripción
         * icono
         * Costo de Energia
         * listaAtributos que afecta (propiedades o de impacto)
         * 
         */
        public EstadoAlterado assignValuesFrom(IDataReader reader) {
            EstadoAlterado estadoAlterado = new EstadoAlterado();
            estadoAlterado.EstadoAlteradoId = (int) reader["estadoAlteradoID"];
            estadoAlterado.Nombre = (string) reader["nombre"];
            estadoAlterado.Descripcion = (string) reader["descripcion"];
            estadoAlterado.Icono = (byte[]) reader["icono"];
            estadoAlterado.CostoEnergia = (int) reader["costoEnergia"];
            estadoAlterado.ListaAtributos = (List<Atributo>) reader["atributoID"];

            return estadoAlterado;
        }

        public List<EstadoAlterado> getListEstadosAlteradosFrom(IDataReader reader) {
            List<EstadoAlterado> listEstadosAlterados = new List<EstadoAlterado>();
            while (reader.Read()) {
                listEstadosAlterados.Add( assignValuesFrom( reader ) );
            }
            return listEstadosAlterados;
        }
    }
}
