using System;
using System.Collections.Generic;
using Entities;
using System.Data;

namespace Assets.Scripts.Mapper {
    class HabilidadMapper {

        public HabilidadMapper() { }
        /*
         * habilidadId
         * Nombre
         * Descripción
         * Tipo
         * Icono
         * tipoElementium. Elementium por clase
         * Potencia de Sanación. Se aplica a la formula de curacion
         * Modulador. Se aplica a la formula de curacion
         * Alcance (1 o varios enemigos)
         * listaEstadosAlterados. Estado alterado que puede producir la habilidad
         * listaElementos (fuego, agua, etc.)
         * Costo de Energia
         * Costo de PV
         * Función extra (según la clase, morfo, hunter e invocador las raras) Y por cada habilidad settear que atributos modifica
         */
        public Habilidad assignValuesFrom(IDataReader reader) {
            Habilidad habilidad = new Habilidad();
            habilidad.HabilidadId = (int)reader["habilidadID"];
            habilidad.Nombre = (string) reader["nombre"];
            habilidad.Descripcion = (string) reader["descripcion"];
            habilidad.Tipo = (string) reader["tipo"];
            habilidad.Icono = (byte[]) reader["icono"];
            habilidad.TipoElementium = (string) reader["elementium"];
            habilidad.PotenciaSanacion = (int) reader["potenciaSanacion"];
            habilidad.Modulador = (int) reader["modulador"];
            habilidad.Alcance = (int) reader["alcance"];
            habilidad.ListaEstadosAlterados = (List<EstadoAlterado>) reader["estadoAlteradoID"];
            habilidad.ListaElementos = (List<Elemento>) reader["elementoID"];
            habilidad.CostoEnergia = (int) reader["costoEnergia"];
            habilidad.CostoPV = (int) reader["costoPV"];

            return habilidad;
        }
        
        public List<Habilidad> getListHabilidadesFrom(IDataReader reader) {
            List<Habilidad> listHabilidades = new List<Habilidad>();
            while (reader.Read()) {
                listHabilidades.Add( assignValuesFrom( reader ) );
            }
            return listHabilidades;
        }
    }
}
