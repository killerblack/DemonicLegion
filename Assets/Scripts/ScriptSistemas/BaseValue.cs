using UnityEngine;
using System.Collections;

public class BaseValue : MonoBehaviour {
	
	class Energy{
		private readonly float value;

		public static readonly Energy L5 = new Energy(10.4f);
		public static readonly Energy L4 = new Energy(4.4f);
		public static readonly Energy L3 = new Energy(3.3f);
		public static readonly Energy L2 = new Energy(2.73f);
		public static readonly Energy L1 = new Energy(2.4f);

		public static readonly Energy M5 = new Energy(2.14f);
		public static readonly Energy M4 = new Energy(1.96f);
		public static readonly Energy M3 = new Energy(1.8f);
		public static readonly Energy M2 = new Energy(1.7f);
		public static readonly Energy M1 = new Energy(1.62f);

		public static readonly Energy X5 = new Energy(1.52f);
		public static readonly Energy X4 = new Energy(1.45f);
		public static readonly Energy X3 = new Energy(1.4f);
		public static readonly Energy X2 = new Energy(1.34f);
		public static readonly Energy X1 = new Energy(1.3f);

		public static readonly Energy MX5 = new Energy(1.25f);
		public static readonly Energy MX4 = new Energy(1.2f);
		public static readonly Energy MX3 = new Energy(1.174f);
		public static readonly Energy MX2 = new Energy(1.14f);
		public static readonly Energy MX1 = new Energy(1.11f);

		public static readonly Energy XX5 = new Energy(1.08f);
		public static readonly Energy XX4 = new Energy(1.06f);
		public static readonly Energy XX3 = new Energy(1.03f);
		public static readonly Energy XX2 = new Energy(1.009f);
		public static readonly Energy XX1 = new Energy(0.983f);

		//return de Enums
		public static IEnumerable Values{
			get{
				yield return L5;
				yield return L4;
				yield return L3;
				yield return L2;
				yield return L1;

				yield return M5;
				yield return M4;
				yield return M3;
				yield return M2;
				yield return M1;

				yield return X5;
				yield return X4;
				yield return X3;
				yield return X2;
				yield return X1;

				yield return MX5;
				yield return MX4;
				yield return MX3;
				yield return MX2;
				yield return MX1;

				yield return XX5;
				yield return XX4;
				yield return XX3;
				yield return XX2;
				yield return XX1;
			}
		}

		//Constructor
		Energy(float value){
			this.value = value;
		}

		public float Value {get{return value;}}
		public override string ToString (){
			return string.Format ("[Energy: Value={0}]", Value);
		}
	}

	class PV{

		private readonly float value;

		public static readonly PV L5 = new PV(3.98f);
		public static readonly PV L4 = new PV(3.96f);
		public static readonly PV L3 = new PV(3.9f);
		public static readonly PV L2 = new PV(3.85f);
		public static readonly PV L1 = new PV(3.7f);

		public static readonly PV M5 = new PV(3.6f);
		public static readonly PV M4 = new PV(3.4f);
		public static readonly PV M3 = new PV(3.2f);
		public static readonly PV M2 = new PV(2.98f);
		public static readonly PV M1 = new PV(2.75f);

		public static readonly PV X5 = new PV(2.5f);
		public static readonly PV X4 = new PV(2.31f);
		public static readonly PV X3 = new PV(2.1f);
		public static readonly PV X2 = new PV(1.92f);
		public static readonly PV X1 = new PV(1.732f);

		public static readonly PV MX5 = new PV(1.57f);
		public static readonly PV MX4 = new PV(1.43f);
		public static readonly PV MX3 = new PV(1.3f);
		public static readonly PV MX2 = new PV(1.21f);
		public static readonly PV MX1 = new PV(1.08f);

		public static readonly PV XX5 = new PV(0.98f);
		public static readonly PV XX4 = new PV(0.89f);
		public static readonly PV XX3 = new PV(0.81f);
		public static readonly PV XX2 = new PV(0.755f);
		public static readonly PV XX1 = new PV(0.692f);

		//return de Enums
		public static IEnumerable Values{
			get{
				yield return L5;
				yield return L4;
				yield return L3;
				yield return L2;
				yield return L1;

				yield return M5;
				yield return M4;
				yield return M3;
				yield return M2;
				yield return M1;

				yield return X5;
				yield return X4;
				yield return X3;
				yield return X2;
				yield return X1;

				yield return MX5;
				yield return MX4;
				yield return MX3;
				yield return MX2;
				yield return MX1;

				yield return XX5;
				yield return XX4;
				yield return XX3;
				yield return XX2;
				yield return XX1;
			}
		}

		//Constructor
		PV(float value){
			this.value = value;
		}

		public float Value {get{return value;}}
		public override string ToString (){
			return string.Format ("[PV: Value={0}]", Value);
		}
	}

	class Status{

		private readonly float value;

		public static readonly Status L5 = new Status(9.2f);
		public static readonly Status L4 = new Status(7.2f);
		public static readonly Status L3 = new Status(6f);
		public static readonly Status L2 = new Status(5f);
		public static readonly Status L1 = new Status(4.5f);

		public static readonly Status M5 = new Status(4f);
		public static readonly Status M4 = new Status(3.6f);
		public static readonly Status M3 = new Status(3.41f);
		public static readonly Status M2 = new Status(3.24f);
		public static readonly Status M1 = new Status(3f);

		public static readonly Status X5 = new Status(2.87f);
		public static readonly Status X4 = new Status(2.7f);
		public static readonly Status X3 = new Status(2.61f);
		public static readonly Status X2 = new Status(2.51f);
		public static readonly Status X1 = new Status(2.45f);

		public static readonly Status MX5 = new Status(2.35f);
		public static readonly Status MX4 = new Status(2.29f);
		public static readonly Status MX3 = new Status(2.21f);
		public static readonly Status MX2 = new Status(2.15f);
		public static readonly Status MX1 = new Status(2.08f);

		public static readonly Status XX5 = new Status(2.01f);
		public static readonly Status XX4 = new Status(1.98f);
		public static readonly Status XX3 = new Status(1.95f);
		public static readonly Status XX2 = new Status(1.89f);
		public static readonly Status XX1 = new Status(1.85f);

		//return de Enums
		public static IEnumerable Values{
			get{
				yield return L5;
				yield return L4;
				yield return L3;
				yield return L2;
				yield return L1;

				yield return M5;
				yield return M4;
				yield return M3;
				yield return M2;
				yield return M1;

				yield return X5;
				yield return X4;
				yield return X3;
				yield return X2;
				yield return X1;

				yield return MX5;
				yield return MX4;
				yield return MX3;
				yield return MX2;
				yield return MX1;

				yield return XX5;
				yield return XX4;
				yield return XX3;
				yield return XX2;
				yield return XX1;
			}
		}

		//Constructor
		Status(float value){
			this.value = value;
		}

		public float Value {get{return value;}}
		public override string ToString (){
			return string.Format ("[Status: Value={0}]", Value);
		}
	}
}
