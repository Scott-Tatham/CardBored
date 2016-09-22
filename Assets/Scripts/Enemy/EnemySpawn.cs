using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
	public GameObject Enemy = null;

	public int hazardCount = 3;
	public float spawnWait = 0.5f;
	public float startWait = 1f;
	public float waveWait = 4f;            
	public Transform[] spawnPoints; 

	void Start ()
	{
		StartCoroutine(SpawnWaves ());
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				int spawnPointIndex = Random.Range (0, spawnPoints.Length);

				Instantiate (Enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}