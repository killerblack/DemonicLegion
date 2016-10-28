using System;
using System.Collections.Generic;
using Entities;
using System.Data;

namespace Assets.Scripts.Mapper {
    class InvocacionMapper {

        public InvocacionMapper() { }
        /*
         * invocacionId
         * nombre
         * descripcion
         * listaAtributos
         * listaHabilidades
         * nivel
         * 
        */
        public Invocacion assignValuesFrom(IDataReader reader) {
            Invocacion invocacion = new Invocacion();
            invocacion.InvocacionId = (int)reader["invocacionID"];
            invocacion.Nombre = (string) reader["nombre"];
            invocacion.Descripcion = (string) reader["descripcion"];
            invocacion.ListaAtributos = (List<Atributo>) reader["atributoID"];
            invocacion.ListaHabilidades = (List<Habilidad>) reader["habilidadID"];
            invocacion.Nivel = (int) reader["nivel"];

            return invocacion;
        }

        public List<Invocacion> getListInvocacionesFrom(IDataReader reader) {
            List<Invocacion> listInvocaciones = new List<Invocacion>();
            while (reader.Read()) {
                listInvocaciones.Add( assignValuesFrom( reader ) );
            }
            return listInvocaciones;
        }
    }
}
