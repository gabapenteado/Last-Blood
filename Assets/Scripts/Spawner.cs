using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	public float currentSpawnTime;
	public float originalSpawnTime;
	public bool randomSpawner = false;
	public bool biggerFirst = false;
	public bool smallerFirst = false;
	
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
