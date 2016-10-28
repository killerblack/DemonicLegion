namespace Entities {
    public class PlantillaArmadura {
        /*
         * plantillaArmaduraId
         * armadura
         * item1
         * item2
         * item3
         */

        private int plantillaArmaduraId;
        private int armaduraId;
        private int itemId_1;
        private int itemId_2;
        private int itemId_3;

        public int PlantillaArmaduraId {
            get { return plantillaArmaduraId; }
            set { plantillaArmaduraId = value; }
        }

        public int ArmaduraId {
            get { return armaduraId; }
            set { armaduraId = value; }
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