using System;
using System.Collections.Generic;
using Entities;
using System.Data;

namespace Assets.Scripts.Mapper {
    class ElementoMapper {

        public ElementoMapper() { }
        /*
         * elementId
         * nombre
         * descripcion
         * icono
         * porcentaje de daño
         * porcentaje de resistencia
         * 
         */
        public Elemento assignValuesFrom(IDataReader reader) {
            Elemento elemento = new Elemento();
            elemento.ElementId = (int) reader["elementoID"];
            elemento.Nombre = (string) reader["nombre"];
            elemento.Icono = (byte[]) reader["icono"];
            elemento.PorcentajeDamage = (int) reader["porcentajeDamage"];
            elemento.PorcentajeResistencia = (int) reader["porcentajeResistencia"];
            elemento.Descripcion = (string) reader["descripcion"];
            return elemento;
        }

        public List<Elemento> getListElementosFrom(IDataReader reader) {
            List<Elemento> listElementos = new List<Elemento>();
            while (reader.Read()) {
                listElementos.Add( assignValuesFrom( reader ) );
            }
            return listElementos;
        }
    }
}
