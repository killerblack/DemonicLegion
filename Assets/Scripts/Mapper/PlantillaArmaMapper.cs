using System;
using System.Collections.Generic;
using Entities;
using System.Data;

namespace Assets.Scripts.Mapper {
    class PlantillaArmaMapper {
        public PlantillaArmaMapper() { }
        /*
         * plantillaArmaId
         * arma
         * item1
         * item2
         * item3
         */
        public PlantillaArma assignValuesFrom(IDataReader reader) {
            PlantillaArma plantillaArma = new PlantillaArma();
            plantillaArma.PlantillaArmaId = (int) reader["plantillaArmasID"];
            plantillaArma.ArmaId = (int) reader["armaID"];
            plantillaArma.ItemId_1 = (int) reader["itemID_1"];
            plantillaArma.ItemId_2 = (int) reader["itemID_2"];
            plantillaArma.ItemId_3 = (int) reader["itemID_3"];

            return plantillaArma;
        }

        public List<PlantillaArma> getListPlantillaArmasFrom(IDataReader reader) {
            List<PlantillaArma> listPlantillaArmas = new List<PlantillaArma>();
            while (reader.Read()) {
                listPlantillaArmas.Add( assignValuesFrom( reader ) );
            }
            return listPlantillaArmas;
        }
    }
}
