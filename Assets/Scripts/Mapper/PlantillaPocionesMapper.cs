using System;
using System.Collections.Generic;
using Entities;
using System.Data;

namespace Assets.Scripts.Mapper {
    class PlantillaPocionesMapper {
        public PlantillaPocionesMapper() { }
        /*
         * plantillaPocionesId
         * item1
         * item2
         * item3
         * item4
         */
        public PlantillaPociones assignValuesFrom(IDataReader reader) {
            PlantillaPociones plantillaPociones = new PlantillaPociones();
            plantillaPociones.PlantillaPocionesId = (int)reader["plantillaPocionesID"];
            plantillaPociones.ItemId_1 = (int) reader["itemID_1"];
            plantillaPociones.ItemId_2 = (int) reader["itemID_2"];
            plantillaPociones.ItemId_3 = (int) reader["itemID_3"];
            plantillaPociones.ItemId_4 = (int) reader["itemID_4"];

            return plantillaPociones;
        }

        public List<PlantillaPociones> getListPlantillaPocionesFrom(IDataReader reader) {
            List<PlantillaPociones> listPlantillaPociones = new List<PlantillaPociones>();
            while (reader.Read()) {
                listPlantillaPociones.Add( assignValuesFrom( reader ) );
            }
            return listPlantillaPociones;
        }
    }
}
