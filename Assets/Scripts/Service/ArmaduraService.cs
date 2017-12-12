using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Implement;
using Entities;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Service {
    public class ArmaduraService : IDaoBase<Armadura> {

        ArmaduraImplementacion armaduraI;

        public ArmaduraService(){
            armaduraI = new ArmaduraImplementacion();
        }

        public void Add(Armadura armadura) {
            armaduraI.Add( armadura );
        }

        public void Delete(int armaduraId) {
            armaduraI.Delete( armaduraId );
        }

        public void Update(Armadura armadura) {
            armaduraI.Update( armadura );
        }

        public Armadura getById(int armaduraId) {
            return armaduraI.getById( armaduraId );
        }

        public Armadura getByName(string name) {
            return armaduraI.getByName( name );
        }

        public List<Armadura> getAll() {
            return armaduraI.getAll();
        }

        public int getCount() {
            return armaduraI.getCount();
        }

    }
}