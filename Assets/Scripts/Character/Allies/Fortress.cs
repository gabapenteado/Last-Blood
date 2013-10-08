using UnityEngine;
using System.Collections;

public class Fortress : Character {
	
	public tk2dTextMesh text;
	static public Fortress instance;
	
	void Awake()
	{
		instance = this;
		text.renderer.enabled = false;
		health = 10;
		
	}
	
	public override void Kill()
	{
		LoseGame();
	}
	
	public void LoseGame()
	{
		Debug.Log("Perdeu o jogo");
		text.renderer.enabled = true;
		Time.timeScale = 0;
	}
	
	
}
