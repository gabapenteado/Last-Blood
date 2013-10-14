using UnityEngine;
using System.Collections;

public class TapToStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUI.color = new Color(0,0,0,0);
		if (GUI.Button(new Rect(0, 0, Screen.width, Screen.height), ""))
		{    
			Application.LoadLevel("teste");	
		}
	}
}
