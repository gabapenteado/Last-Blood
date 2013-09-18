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
	private EnemyType enemyType;
	
	void Awake()
	{
		goldSpeed = 1.5f;
		goldSpeedAcc = 0.2f;
		originalSpawnTime = 5f;
		currentSpawnTime = originalSpawnTime;
		enemyMaxNumber = 3f;
	}
	override protected void ChooseEnemy ()
	{
		if(randomSpawner)
		{
			while(currentGoldValue > 1) //do this while I still have gold to spend
			{
				int i = Random.Range(0,(int)EnemyType.nZombieTypeCount); // get a random number from 0 to the amount of enemies on my enum
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
				foreach(GameObject prefab in possibleEnemies) //check to see which enemy was selected
				{					
					if(i == index)
					{
						SpawnWave(index);   //spawn selected enemy
						currentGoldValue -= 1 + index;   //decrease its value from my gold stash
					}
					index++;
				}
			}
			currentSpawnTime = originalSpawnTime;   //resets timer
			waveNumber++;
		}
		else if(biggerFirst)
		{
			
		}
		else if(smallerFirst)
		{
			
		}
	}
	override protected void UpdateGold ()
	{
		currentGoldValue += (goldSpeed + goldSpeedAcc * waveNumber) * Time.deltaTime;  //Gold gain curve
	}
	override protected void SpawnWave (int n)
	{
		//Instantiate(possibleEnemies[(int)pSpawnType], new Vector3(0, Random.Range(-5,5), 0), Quaternion.identity);	
		Instantiate(possibleEnemies[n], new Vector3(0, Random.Range(-5,5), 0), Quaternion.identity);
	}
}
