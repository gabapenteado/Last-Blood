using UnityEngine;
using System.Collections;

public class Fortress : Character {
	
	void Awake()
	{
		health = 1;
		
	}
	
	private void LooseGame()
	{
		Debug.Log("Perdeu o jogo");
	}
	
	
}
