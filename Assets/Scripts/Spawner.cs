using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	public float currentSpawnTime;
	public float originalSpawnTime;	
	
	// Use this for initialization
	void Awake ()
	{
			
	}
	void Start () 
	{
		//This is a Base Class
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentSpawnTime -= Time.deltaTime;
		if(currentSpawnTime <= 0)
		{
			ChooseEnemy();			
		}
		UpdateGold();		
	}
	virtual protected void ChooseEnemy(){}
	virtual protected void UpdateGold(){}
	virtual protected void SpawnWave (int index){}
}
