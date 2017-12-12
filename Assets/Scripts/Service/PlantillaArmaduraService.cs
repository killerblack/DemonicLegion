using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Implement;
using Entities;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Service {
    public class PlantillaArmaduraService : IDaoBase<PlantillaArmadura> {

        PlantillaArmaduraImplementacion plantillaArmaduraI;

        public PlantillaArmaduraService() {
            plantillaArmaduraI = new PlantillaArmaduraImplementacion();
        }

        public void Add(PlantillaArmadura plantillaArmadura) {
            plantillaArmaduraI.Add( plantillaArmadura );
        }

        public void Delete(int plantillaArmaduraId) {
            plantillaArmaduraI.Delete( plantillaArmaduraId );
        }

        public void Update(PlantillaArmadura plantillaArmadura) {
            plantillaArmaduraI.Update( plantillaArmadura );
        }

        public PlantillaArmadura getById(int plantillaArmaduraId) {
            return plantillaArmaduraI.getById( plantillaArmaduraId );
        }

        public PlantillaArmadura getByName(string name) {
            return plantillaArmaduraI.getByName( name );
        }

        public List<PlantillaArmadura> getAll() {
            return plantillaArmaduraI.getAll();
        }

        public int getCount() {
            return plantillaArmaduraI.getCount();
        }
    }
}