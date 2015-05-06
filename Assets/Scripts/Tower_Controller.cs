using UnityEngine;
using System.Collections;

[System.Serializable]
public class Towers {
	public string name;
	public GameObject towerPrefab;
}

public class Tower_Controller : MonoBehaviour {

	public static Tower_Controller S;

	public Towers[] towerPrefabs;

	private GameObject ghostTower;

	void Awake () {
		S = this;
	}

	void Update () {
		if (ghostTower) {
			RaycastHit hit;
			TileDrop.S.getPosition(out hit);

			Vector3 towerPos = new Vector3 (Mathf.RoundToInt (hit.point.x), .5f, Mathf.RoundToInt (hit.point.z));

			ghostTower.transform.position = towerPos;

			Tower script = ghostTower.GetComponent<Tower> ();
			if (checkForPlacement(hit)) {
				script.makeGreen ();
			} else {
				script.makeRed ();
			}
		}

		if (Input.GetMouseButtonDown (0) && ghostTower) {
			RaycastHit hit;
			TileDrop.S.getPosition(out hit);

			if (checkForPlacement(hit)) {
				Destroy (ghostTower);

				Vector3 towerPos = new Vector3 (Mathf.RoundToInt (hit.point.x), .5f, Mathf.RoundToInt (hit.point.z));

				GameObject newTower = Instantiate (towerPrefabs [0].towerPrefab, towerPos, Quaternion.identity) as GameObject;
				newTower.transform.parent = transform;
			} else {
				Destroy (ghostTower);
			}
		}
	}

	public bool checkForPlacement (RaycastHit hit) {
		if (
			TileDrop.S.checkPosition(hit.point) && 
			!TileDrop.S.checkForObject(hit)
		) {
			return true;
		} else {
			return false;
		}
	}
	
	public void createGhostTower () {
		if (ghostTower) {
			Destroy (ghostTower);
		}

		RaycastHit hit;
		TileDrop.S.getPosition(out hit);

		Vector3 towerPos = new Vector3 (Mathf.RoundToInt (hit.point.x), .5f, Mathf.RoundToInt (hit.point.z));

		ghostTower = Instantiate (towerPrefabs [0].towerPrefab, towerPos, Quaternion.identity) as GameObject;
		ghostTower.name = "ghostTower";
		ghostTower.transform.parent = transform;
		ghostTower.tag = "Ghost";

		Tower script = ghostTower.GetComponent<Tower> ();
		script.makeTransparent ();
	}
}
