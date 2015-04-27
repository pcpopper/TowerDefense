using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridLines : MonoBehaviour {

	public static GridLines S;
	
	public GameObject linePrefab;

	private LineRenderer lineRend;
	private GameObject gridHolder;

	void Awake () {
		S = this;
	}

	public void createGrid(Vector2 dimensions) {
		float xSize = dimensions.x - 1;
		float ySize = dimensions.y - 1;

		gridHolder = GameObject.Find ("HorizontalLines");

		for (int x = -1; x <= xSize; x++) {
			Vector3 Pos = new Vector3 (0, 0, 0);
			Vector3 linePos = new Vector3(-.5f, .5f, .5f);

			GameObject newLine = Instantiate(linePrefab, Pos, Quaternion.identity) as GameObject;
			newLine.name = "Horizontal_Line_" + x;
			newLine.transform.parent = gridHolder.transform;

			lineRend = newLine.GetComponent<LineRenderer>();

			linePos.z += x;
			lineRend.SetPosition(0, linePos);
			linePos.x = ySize + .5f;
			lineRend.SetPosition(1, linePos);
		}

		gridHolder = GameObject.Find ("VerticalLines");
		for (int y = -1; y <= ySize; y++) {
			Vector3 Pos = new Vector3 (0, 0, 0);
			Vector3 linePos = new Vector3(.5f, .5f, -.5f);
			
			GameObject newLine = Instantiate(linePrefab, Pos, Quaternion.identity) as GameObject;
			newLine.name = "Verticle_Line_" + y;
			newLine.transform.parent = gridHolder.transform;
			
			lineRend = newLine.GetComponent<LineRenderer>();
			
			linePos.x += y;
			lineRend.SetPosition(0, linePos);
			linePos.z = xSize + .5f;
			lineRend.SetPosition(1, linePos);
		}
	}
}