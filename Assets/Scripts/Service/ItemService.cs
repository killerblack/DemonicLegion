using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Implement;
using Entities;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Service {
    public class ItemService : IDaoBase<Item> {

        ItemImplementacion itemI;

        public ItemService() {
            itemI = new ItemImplementacion();
        }

        public void Add(Item item) {
            itemI.Add( item );
        }

        public void Delete(int itemId) {
            itemI.Delete( itemId );
        }

        public void Update(Item item) {
            itemI.Update( item );
        }

        public Item getById(int itemId) {
            return itemI.getById( itemId );
        }

        public Item getByName(string name) {
            return itemI.getByName( name );
        }

        public List<Item> getAll() {
            return itemI.getAll();
        }

        public int getCount() {
            return itemI.getCount();
        }
    }
}