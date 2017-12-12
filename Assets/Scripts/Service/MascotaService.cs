using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Implement;
using Entities;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Service {
    public class MascotaService : IDaoBase<Mascota> {

        MascotaImplementacion mascotaI;

        public MascotaService() {
            mascotaI = new MascotaImplementacion();
        }

        public void Add(Mascota mascota) {
            mascotaI.Add( mascota );
        }

        public void Delete(int mascotaId) {
            mascotaI.Delete( mascotaId );
        }

        public void Update(Mascota mascota) {
            mascotaI.Update( mascota );
        }

        public Mascota getById(int mascotaId) {
            return mascotaI.getById( mascotaId );
        }

        public Mascota getByName(string name) {
            return mascotaI.getByName( name );
        }

        public List<Mascota> getAll() {
            return mascotaI.getAll();
        }

        public int getCount() {
            return mascotaI.getCount();
        }
    }
}