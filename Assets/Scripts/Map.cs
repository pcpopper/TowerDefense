using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour {

	public static Map S;

	public Vector2 mapSize;
	public GameObject[] groundTiles;

	private GameObject tileHolder;

	void Awake () {
		S = this;
	}

	// Use this for initialization
	void Start () {
		tileHolder = GameObject.Find ("Ground Tiles");
		for (int i = 0; i < mapSize.y; i++) {
			for (int j = 0; j < mapSize.x; j++) {
				int rand = Random.Range (1, 20);
				Vector3 Pos = new Vector3 (i, 0, j);
				GameObject tile = Instantiate(groundTiles[(rand % 2)], Pos, Quaternion.identity) as GameObject;
				tile.transform.parent = tileHolder.transform;
			}
		}

		GridLines.S.createGrid (mapSize);
		Walls.S.buildWalls ();
		//RoutingPath.S.setupEnv ();
		TileDrop.S.setupEnviroment (mapSize);
	}
}
