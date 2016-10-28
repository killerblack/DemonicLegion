using System;
using System.Collections.Generic;
using Entities;
using System.Data;

namespace Assets.Scripts.Mapper {
    class PlantillaArmaduraMapper {

        public PlantillaArmaduraMapper() { }
        /*
         * plantillaArmaduraId
         * armadura
         * item1
         * item2
         * item3
         */
        public PlantillaArmadura assignValuesFrom(IDataReader reader) {
            PlantillaArmadura plantillaArmadura = new PlantillaArmadura();
            plantillaArmadura.PlantillaArmaduraId = (int)reader["plantillaArmadurasID"];
            plantillaArmadura.ArmaduraId = (int)reader["armaduraID"];
            plantillaArmadura.ItemId_1 = (int)reader["itemID_1"];
            plantillaArmadura.ItemId_2 = (int)reader["itemID_2"];
            plantillaArmadura.ItemId_3 = (int)reader["itemID_3"];

            return plantillaArmadura;
        }

        public List<PlantillaArmadura> getListPlantillaArmadurasFrom(IDataReader reader) {
            List<PlantillaArmadura> listPlantillaArmaduras = new List<PlantillaArmadura>();
            while (reader.Read()) {
                listPlantillaArmaduras.Add( assignValuesFrom( reader ) );
            }
            return listPlantillaArmaduras;
        }
    }
}
