namespace Entities {
    public class PlantillaArma : IEntity {
        /*
         * plantillaArmaId
         * arma
         * item1
         * item2
         * item3
         */

        private int plantillaArmaId;
        private int armaId;
        private int itemId_1;
        private int itemId_2;
        private int itemId_3;

        public int PlantillaArmaId {
            get { return plantillaArmaId; }
            set { plantillaArmaId = value; }
        }

        public int ArmaId {
            get { return armaId; }
            set { armaId = value; }
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

    }
}