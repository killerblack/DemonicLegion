using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Implement;
using Entities;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Service {
    public class PlantillaPocionesService : IDaoBase<PlantillaPociones> {

        PlantillaPocionesImplementacion plantillaPocionesI;

        public PlantillaPocionesService() {
            plantillaPocionesI = new PlantillaPocionesImplementacion();
        }

        public void Add(PlantillaPociones plantillaPociones) {
            plantillaPocionesI.Add( plantillaPociones );
        }

        public void Delete(int plantillaPocionesId) {
            plantillaPocionesI.Delete( plantillaPocionesId );
        }

        public void Update(PlantillaPociones plantillaPociones) {
            plantillaPocionesI.Update( plantillaPociones );
        }

        public PlantillaPociones getById(int plantillaPocionesId) {
            return plantillaPocionesI.getById( plantillaPocionesId );
        }

        public PlantillaPociones getByName(string name) {
            return plantillaPocionesI.getByName( name );
        }

        public List<PlantillaPociones> getAll() {
            return plantillaPocionesI.getAll();
        }

        public int getCount() {
            return plantillaPocionesI.getCount();
        }
    }
}