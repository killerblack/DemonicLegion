using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Implement;
using Entities;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Service {
    public class EstadoAlteradoService : IDaoBase<EstadoAlterado> {

        EstadoAlteradoImplementacion estadoAlteradoI;

        public EstadoAlteradoService() {
            estadoAlteradoI = new EstadoAlteradoImplementacion();
        }

        public void Add(EstadoAlterado estadoAlterado) {
            estadoAlteradoI.Add( estadoAlterado );
        }

        public void Delete(int estadoAlteradoId) {
            estadoAlteradoI.Delete( estadoAlteradoId );
        }

        public void Update(EstadoAlterado estadoAlterado) {
            estadoAlteradoI.Update( estadoAlterado );
        }

        public EstadoAlterado getById(int estadoAlteradoId) {
            return estadoAlteradoI.getById( estadoAlteradoId );
        }

        public EstadoAlterado getByName(string name) {
            return estadoAlteradoI.getByName( name );
        }

        public List<EstadoAlterado> getAll() {
            return estadoAlteradoI.getAll();
        }

        public int getCount() {
            return estadoAlteradoI.getCount();
        }
    }
}