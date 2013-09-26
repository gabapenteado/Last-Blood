using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {
	
	public static GameGUI instance;
	
	public DamageFeedback damageFeedback;
	
	void Awake()
	{
		instance = this;
	}
	
	void Start () 
	{
		Input.multiTouchEnabled = false;
	}
}
