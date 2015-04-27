using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileDrop : MonoBehaviour {

	public static TileDrop S;

	public GameObject highlitePrefab;
	public bool HighlightAtPointer;
	public GameObject[,] objectsList;

	private GameObject highlitedSquare;
	public int xSize;
	public int ySize;
	public int[] xAxis;
	public int[] yAxis;

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

	public void setupEnviroment (Vector2 mapSize) {
		xAxis = new int[(int)mapSize.y];
		yAxis = new int[(int)mapSize.x];
		xSize = (int)mapSize.x - 6;
		ySize = (int)mapSize.y - 6;
		objectsList = new GameObject[(int) mapSize.y, (int) mapSize.x];

		GameObject parent = GameObject.Find ("Walls");
		GameObject leftDoor = new GameObject();
		leftDoor.name = "leftDoorHolder";
		leftDoor.transform.parent = parent.transform;
		GameObject rightDoor = new GameObject();
		rightDoor.name = "rightDoorHolder";
		rightDoor.transform.parent = parent.transform;

		objectsList[(int)Walls.S.leftDoor.x,(int)Walls.S.leftDoor.z] = leftDoor;
		objectsList[(int)Walls.S.rightDoor.x,(int)Walls.S.rightDoor.z] = rightDoor;
	}

	public bool getPosition (out RaycastHit hitInfo) {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast(ray, out hitInfo);

		return true;
	}

	public bool checkPosition (Vector3 position) {
		Vector2 startPos = new Vector2 (-.5f, -.5f);
		Vector2 endPos = Map.S.mapSize;
		endPos.x -= .5f;
		endPos.y -= .5f;

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

	public void setPosition (Vector3 position, GameObject item) {
		int x = Mathf.RoundToInt (position.x);
		int y = Mathf.RoundToInt (position.z);
		objectsList [x, y] = item;

		xAxis [x] += 1;
		yAxis [y] += 1;
	}

	public bool checkForObject (Vector3 position) {
		if (objectsList [Mathf.RoundToInt (position.x), Mathf.RoundToInt (position.z)]) {
			return true;
		} else {
			return false;
		}
	}

	public bool willBlockPath (Vector3 position) {
		if (xAxis [Mathf.RoundToInt (position.x)] == xSize || yAxis [Mathf.RoundToInt (position.z)] == ySize) {
			return true;
		} else {
			return false;
		}
	}

	public bool willBlockDoor (Vector3 position) {
		//TODO: Impliment this
		return false;
	}

	private void destroyHighlight () {
		if (highlitedSquare) {
			Destroy (highlitedSquare);
		}
	}
}
