using System.Collections;
using UnityEngine;

[System.Serializable]
public class ItemSpawner : MonoBehaviour
{
	[System.Serializable]
	public class Wave
	{
		public GameObject[] items;
		public int numberOfItems;
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
	public Transform[] itemSpawnPoints;
	public float timeBetweenWaves;

	private void Start()
	{
		StartCoroutine(SpawnLevel());
	}

	IEnumerator SpawnLevel()
	{
		for (int i = 0; i < waves.Length; i++)
		{
			for (int h = 0; h < waves[i].numberOfItems; h++)
			{
				Transform spawnPoint = itemSpawnPoints[Random.Range(0, itemSpawnPoints.Length)];
				GameObject item = waves[i].items[Random.Range(0, waves[i].items.Length)];
				Instantiate(item, spawnPoint);
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

