using UnityEngine;
using System.Collections;

public class Enemy : EnemySuperClass {

	public static Enemy S;

	[HideInInspector]
	public bool on = false;
	public int count = 0;
	public int wait = 1000;

	private Vector3 newDestination;

	void Awake () {
		S = this;
		newDestination = Vector3.zero;
	}

	void Update () {
		if (on && count%wait == 0) {
			if (transform.position == Enemy_Spawn.S.destination) {
				Destroy (gameObject);
			} else {
				float step = options.speed * Time.deltaTime;
				newDestination = (newDestination != Vector3.zero) ? newDestination : Enemy_Spawn.S.destination;
				transform.position = Vector3.MoveTowards (transform.position, newDestination, step);

				RaycastHit hit;
				if (directionBlocked(transform.position, Enemy_Spawn.S.destination, out hit)) {
					newDestination = findOpening(hit.point);
				} else {}
			}
		}
		count++;
	}
}
