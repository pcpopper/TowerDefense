using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileDrop : MonoBehaviour {

	public static TileDrop S;

	public GameObject highlitePrefab;
	public bool HighlightAtPointer;

	private GameObject highlitedSquare;

	void Awake () {
		S = this;
	}

	void Update () {
		if (HighlightAtPointer) {

			RaycastHit hit;
			getPosition(out hit);

			if (checkPosition(hit.point)) {
				updateHighlight(hit);
			} else {
				destroyHighlight();
			}
		}
	}

	public bool getPosition (out RaycastHit hitInfo) {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast(ray, out hitInfo);

		return true;
	}

	public bool checkPosition (Vector3 position) {
		Vector2 startPos = new Vector2 (-.5f, -.5f);
		Vector2 endPos = new Vector2 (8.5f, 15.5f);

		if (
			position.x >= startPos.y && 
			position.x <= endPos.y &&
			position.z >= startPos.x &&
			position.z <= endPos.x
		) {
			return true;
		} else {
			return false;
		}
	}

	private void updateHighlight (RaycastHit hit) {
		Vector3 newPos = new Vector3 (
			Mathf.RoundToInt (hit.point.x),
			.1f,
			Mathf.RoundToInt (hit.point.z)
		);

		if (highlitedSquare) {
			highlitedSquare.transform.position = newPos;
		} else {
			highlitedSquare = Instantiate (highlitePrefab, newPos, Quaternion.identity) as GameObject;
		}
	}

	public bool checkForObject (RaycastHit hit) {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] hits = Physics.RaycastAll(ray);

		int i = 0;
		while (i < hits.Length) {
			if (hits[i].collider.tag == "Path" || hits[i].collider.tag == "Tower") {
				return true;
			}
			i++;
		}

		return false;
	}

	private void destroyHighlight () {
		if (highlitedSquare) {
			Destroy (highlitedSquare);
		}
	}
}
