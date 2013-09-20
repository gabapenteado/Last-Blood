using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	private int totalStageTime;
	private bool isSurvival;
	private float currentStageTime;
	private Enemy[] activeEnemies;
	public Character[] activeAllies;
	
	private static GameController _instance;
	
	public static bool initiated()
	{
		return (_instance != null);
	}
	
	public static GameController instance()
	{
		
		if(_instance == null)
		{
			_instance = new GameController();
			_instance.Init();
			Debug.Log(_instance);
		}
		return _instance;
	}
	
	private void Init()
	{
			
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
