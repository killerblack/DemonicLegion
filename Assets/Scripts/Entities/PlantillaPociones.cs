namespace Entities {
    public class PlantillaPociones : IEntity {
        /*
         * plantillaPocionesId
         * item1
         * item2
         * item3
         * item4
         */

        private int plantillaPocionesId;
        private int itemId_1;
        private int itemId_2;
        private int itemId_3;
        private int itemId_4;

        public int PlantillaPocionesId {
            get { return plantillaPocionesId; }
            set { plantillaPocionesId = value; }
        }

        public int ItemId_1 {
            get { return itemId_1; }
            set { itemId_1 = value; }
        }

        public int ItemId_2 {
            get { return itemId_2; }
            set { itemId_2 = value; }
        }

        public int ItemId_3 {
            get { return itemId_3; }
            set { itemId_3 = value; }
        }

        public int ItemId_4 {
            get { return itemId_4; }
            set { itemId_4 = value; }
        }

    }
}