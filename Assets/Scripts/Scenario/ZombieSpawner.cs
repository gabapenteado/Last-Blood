using UnityEngine;
using System.Collections;

public class ZombieSpawner : Spawner
{	
	public GameObject[] possibleEnemies;
	private float currentGoldValue;
	private float goldSpeed;
	private float goldSpeedAcc;
	private float waveNumber;
	private float enemyMaxNumber;
	private float enemyCurrentNumber;
	private int numberOfZombies;
	private EnemyType enemyType;
	
	void Awake ()
	{
		goldSpeed = 1.5f;
		goldSpeedAcc = 0.2f;
		originalSpawnTime = 5f;
		currentSpawnTime = originalSpawnTime;
		enemyMaxNumber = 3f;
	}

	override protected void ChooseEnemy ()
	{
		while (currentGoldValue > 1) { //do this while I still have gold to spend
			int i = Random.Range (0, (int)EnemyType.nZombieTypeCount); // get a random number from 0 to the amount of enemies on my enum
//				if(i == 0)
//				{
//					enemyType = EnemyType.ZombieG;
//					currentGoldValue--;
//				}
//				if(i == 1)
//				{
//					enemyType = EnemyType.ZombieR;
//					currentGoldValue -= 2f;
//				}
//				SpawnWave(enemyType);
				
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
		Instantiate (possibleEnemies [n], new Vector3 (Random.Range (-2f, 2f), Random.Range (-5f, 5f), 0), Quaternion.identity);
	}
	void OnGUI ()
	{
		GUI.TextArea(new Rect(30,15, 45, 30),waveNumber.ToString());
		GUI.TextArea(new Rect(30,55, 45, 30),currentGoldValue.ToString());
		GUI.TextArea(new Rect(30,95, 45, 30),numberOfZombies.ToString());
	}
}
