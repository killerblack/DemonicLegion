using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicioGUI : MonoBehaviour {

	public GUISkin GeneralGUI;

	void OnGUI () {

		int width = 320;
		int height = 280;

		GUI.skin = GeneralGUI;

		GUI.BeginGroup( new Rect( Screen.width / 2 - width / 2, Screen.height / 2 - height / 2, width, height ) );
			GUI.Box(new Rect(0, 0, width, height), "Demonic Legion");

			if(GUI.Button(new Rect(20, 100, 280, 40), "Juego Nuevo")) {
				SceneManager.LoadScene(1);
			}

			if(GUI.Button(new Rect(20, 150, 280, 40), "Continuar")) {
				SceneManager.LoadScene(2);
			}

			if(GUI.Button(new Rect(20, 200, 280, 40), "Terminar")) {
				SceneManager.LoadScene(3);
			}
		GUI.EndGroup ();
	}
}
