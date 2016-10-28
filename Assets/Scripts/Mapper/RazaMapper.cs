using System;
using System.Collections.Generic;
using Entities;
using System.Data;

namespace Assets.Scripts.Mapper {
    class RazaMapper {
        public RazaMapper() { }
        /*
         * Se inician propiedades en cada diferente raza
         * Se configura su invocación racial
         * razaId
         * nombre
         * descripcion
         * listaAtributos
         * listaInvocacionesRaciales
         * 
        */
        public Raza assignValuesFrom(IDataReader reader) {
            Raza raza = new Raza();
            raza.RazaId = (int) reader["razaID"];
            raza.Nombre = (string) reader["nombre"];
            raza.Descripcion = (string) reader["descripcion"];
            raza.ListaAtributos = (List<Atributo>) reader["atributoID"];
            raza.ListaInvocacionesRaciales = (List<Invocacion>) reader["invocacionID"];

            return raza;
        }

        public List<Raza> getListRazasFrom(IDataReader reader) {
            List<Raza> listRazas = new List<Raza>();
            while (reader.Read()) {
                listRazas.Add( assignValuesFrom( reader ) );
            }
            return listRazas;
        }
    }
}
