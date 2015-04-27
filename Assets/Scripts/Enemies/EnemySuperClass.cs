using UnityEngine;
using System.Collections;

[System.Serializable]
public class EnemyOptions {
	public float speed;
}

public class EnemySuperClass : MonoBehaviour {

	public EnemyOptions options;

	public bool directionBlocked (Vector3 pos, Vector3 destination, out RaycastHit hitInfo) {
		if (Physics.Linecast (pos, destination, out hitInfo)) {
			Debug.Log (pos.x + ", " + hitInfo.point.x + " = " + (hitInfo.point.x - pos.x));
			if (hitInfo.collider.tag == "Tower" && (hitInfo.point.x - pos.x) <= .6f) {
				return true;
			} else {
				return false;
			}
		} else {
			return false;
		}
	}

	public Vector3 findOpening (Vector3 towerPos) {

		return new Vector3 (0,1,0);
	}
}
