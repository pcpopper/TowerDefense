using UnityEngine;
using System.Collections;

[System.Serializable]
public class Enemies {
	public string name;
	public float spawnTime;
	public float spawnAmount; 
	public GameObject enemyPrefab;
	public int spawnedCount = 0;
}

public class Enemy_Spawn : MonoBehaviour {

	public static Enemy_Spawn S;

	public Enemies[] enemies;
	public bool spawnEnemy = false;
	public Vector3[] routePath;

	//[HideInInspector]
	public Vector3 destination;

	void Awake () {
		S = this;
		destination = routePath [routePath.Length - 1];
	}

	void Update () {
		if (spawnEnemy) {
			InvokeRepeating( "Spawn", enemies[0].spawnTime, enemies[0].spawnTime);
			enemies [0].spawnedCount = 0;
			spawnEnemy = false;
		}
	}

	public void Spawn () {
		if (enemies [0].spawnedCount == (enemies [0].spawnAmount - 1)) {
			CancelInvoke("Spawn");
		}

		enemies [0].spawnedCount++;

		Vector3 startPos = new Vector3 (-1, 0, 7);
		GameObject enemy = Instantiate (enemies [0].enemyPrefab, startPos, Quaternion.identity) as GameObject;
		enemy.transform.parent = transform;
	}
}
