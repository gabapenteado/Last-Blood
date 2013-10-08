using UnityEngine;
using System.Collections;

public class ZombieSpawner : Spawner
{	
	public GameObject[] possibleEnemies;
	public bool debug = false;
	private float currentGoldValue;
	private float goldSpeed;
	private float goldSpeedAcc;
	private float waveNumber;	
	private float enemyCurrentNumber;
	private int numberOfZombies;
	private EnemyType enemyType;
	
	void Awake ()
	{
		goldSpeed = 0.5f;
		goldSpeedAcc = 0.1f;
		originalSpawnTime = 5f;
		currentSpawnTime = originalSpawnTime;		
	}

	override protected void ChooseEnemy ()
	{
		while (currentGoldValue > 1) //do this while I still have gold to spend >> be sure that the number is iquals to the cheapest Zombie
		{ 
			int i = Random.Range (0, (int)EnemyType.nZombieTypeCount); // get a random number from 0 to the amount of enemies on my enum				
			int index = 0;
			foreach (GameObject prefab in possibleEnemies) { //check to see which enemy was selected					
				if (i == index) 
				{
					ZombieBasic zombie = prefab.GetComponent<ZombieBasic> ();
					if(currentGoldValue >= zombie.spawnCost)
					{
						SpawnWave (index);   //spawn selected enemy
						currentGoldValue -= zombie.spawnCost;  //decrease its value from my gold stash	
						numberOfZombies++;
					}					
				}
				index++;
			}
		}
		currentSpawnTime = originalSpawnTime;   //resets timer
		waveNumber++;		
	}

	override protected void UpdateGold ()
	{
		currentGoldValue += (goldSpeed + goldSpeedAcc * waveNumber) * Time.deltaTime;  //Gold gain curve
	}

	override protected void SpawnWave (int n)
	{
		//Instantiate(possibleEnemies[(int)pSpawnType], new Vector3(0, Random.Range(-5,5), 0), Quaternion.identity);	
		Instantiate (possibleEnemies [n], new Vector3 (transform.position.x + Random.Range (-20f, 20f),transform.position.y + Random.Range (-50f, 50f), transform.position.z), Quaternion.identity);
	}
	void OnGUI ()
	{
		if(debug)
		{
			GUI.TextArea(new Rect(30,15, 45, 30),waveNumber.ToString());
			GUI.TextArea(new Rect(30,55, 45, 30),currentGoldValue.ToString());
			GUI.TextArea(new Rect(30,95, 45, 30),numberOfZombies.ToString());
		}
	}
}
