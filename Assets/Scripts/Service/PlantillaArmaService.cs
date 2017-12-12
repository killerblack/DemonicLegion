using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Implement;
using Entities;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Service {
    public class PlantillaArmaService : IDaoBase<PlantillaArma> {

        PlantillaArmaImplementacion plantillaArmaI;

        public PlantillaArmaService() {
            plantillaArmaI = new PlantillaArmaImplementacion();
        }

        public void Add(PlantillaArma plantillaArma) {
            plantillaArmaI.Add( plantillaArma );
        }

        public void Delete(int plantillaArmaId) {
            plantillaArmaI.Delete( plantillaArmaId );
        }

        public void Update(PlantillaArma plantillaArma) {
            plantillaArmaI.Update( plantillaArma );
        }

        public PlantillaArma getById(int plantillaArmaId) {
            return plantillaArmaI.getById( plantillaArmaId );
        }

        public PlantillaArma getByName(string name) {
            return plantillaArmaI.getByName( name );
        }

        public List<PlantillaArma> getAll() {
            return plantillaArmaI.getAll();
        }

        public int getCount() {
            return plantillaArmaI.getCount();
        }
    }
}