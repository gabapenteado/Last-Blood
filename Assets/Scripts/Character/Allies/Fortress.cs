using UnityEngine;
using System.Collections;

public class Fortress : Character {
	
	public tk2dSprite sprite;
	static public Fortress instance;
	
	void Awake()
	{
		instance = this;
		sprite.renderer.enabled = false;
		health = 10;
		
	}
	
	public override void Kill()
	{
		LoseGame();
	}
	
	public void LoseGame()
	{
		Debug.Log("Perdeu o jogo");
		sprite.renderer.enabled = true;
		Time.timeScale = 0;
		StartCoroutine(ChangeScene());
	}
	
	
	IEnumerator ChangeScene()
	{
		Time.timeScale = 1;
		yield return new WaitForSeconds(3f);
		//yield return new WaitForSeconds(.9f);
		Application.LoadLevel("startScene");		
		yield break;
	}
}
