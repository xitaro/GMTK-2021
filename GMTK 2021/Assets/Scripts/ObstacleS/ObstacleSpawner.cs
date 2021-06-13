using System.Collections;
using UnityEngine;

[System.Serializable]
public class ObstacleSpawner : MonoBehaviour
{
	[System.Serializable]
	public class Wave
	{
		public GameObject[] obstacles;
		public int numberOfObstacles;
		private float timeBetweenSpawns;
		public float minTime;
		public float maxTime;	
		
		public float CalculateTimeBetweenSpawns()
        {
			timeBetweenSpawns = Random.Range(minTime, maxTime);
			return timeBetweenSpawns;
        }
	}

	public Wave[] waves;
	public Transform[] obstacleSpawnPoints;
	public float timeBetweenWaves;

	private void Start()
	{
		StartCoroutine(SpawnLevel());
	}

	IEnumerator SpawnLevel()
	{
		for (int i = 0; i < waves.Length; i++)
		{
			for (int h = 0; h < waves[i].numberOfObstacles; h++)
			{
				Transform spawnPoint = obstacleSpawnPoints[Random.Range(0, obstacleSpawnPoints.Length)];
				GameObject obstacle = waves[i].obstacles[Random.Range(0, waves[i].obstacles.Length)];
				Instantiate(obstacle, spawnPoint);
				yield return new WaitForSeconds(waves[i].CalculateTimeBetweenSpawns());
			}
			if (i == waves.Length - 1)
			{
				i--;
			}
			yield return new WaitForSeconds(timeBetweenWaves);
		}
		print("Game Finished");
	}
}

