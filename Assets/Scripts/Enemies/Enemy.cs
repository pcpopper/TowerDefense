using UnityEngine;
using System.Collections;

public class Enemy : EnemySuperClass {

	public static Enemy S;

	private Enemy_Spawn enemySpwan;
	private Vector3 newDestination;
	private Vector3[] routePath;
	private int nextPointIndex;

	void Awake () {
		S = this;
		nextPointIndex = 1;
		enemySpwan = Enemy_Spawn.S;
		routePath = enemySpwan.routePath;
	}

	void Update () {
		if (transform.position.x == routePath [nextPointIndex].x && transform.position.z == routePath [nextPointIndex].z) {
			if (transform.position == enemySpwan.destination) {
				Destroy(gameObject);
			} else {
				nextPointIndex++;
			}
		}

		float step = options.speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, routePath [nextPointIndex], step);
	}
}
