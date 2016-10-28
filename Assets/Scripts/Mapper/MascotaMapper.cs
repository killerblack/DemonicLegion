using System;
using System.Collections.Generic;
using Entities;
using System.Data;

namespace Assets.Scripts.Mapper {
    class MascotaMapper {

        public MascotaMapper() { }
        /*
         * mascotaId
         * nombre
         * descripcion
         * apodo
         * listaClases. Las clases que pueden usar la mascota
         * listaAtributos. Lista de atributos de la mascota
         * 
         */
        public Mascota assignValuesFrom(IDataReader reader) {
            Mascota mascota = new Mascota();
            mascota.MascotaId = (int) reader["mascotaID"];
            mascota.Nombre = (string) reader["nombre"];
            mascota.Descripcion = (string) reader["descripcion"];
            mascota.Apodo = (string) reader["apodo"];
            mascota.ListaClases = (List<Clase>) reader["claseID"];
            mascota.ListaAtributos = (List<Atributo>) reader["atributoID"];

            return mascota;
        }

        public List<Mascota> getListMascotasFrom(IDataReader reader) {
            List<Mascota> listMascotas = new List<Mascota>();
            while (reader.Read()) {
                listMascotas.Add( assignValuesFrom( reader ) );
            }
            return listMascotas;
        }
    }
}
