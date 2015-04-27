using UnityEngine;
using System.Collections;

public class RoutingPath : MonoBehaviour {

	public static RoutingPath S;

	public GameObject routeNumberPrefab;
	public bool check = false;

	private Vector3 destination;
	private int[,] routeNumbers;
	private int x, y;

	void Awake () {
		S = this;
	}

	void Update () {
		if (check) {
			check = false;
			Vector3[,] bestRoute = getBestRoute (Walls.S.leftDoor);
			Debug.Log(bestRoute);
		}
	}

	public void setupEnv () {
		//destination = Walls.S.rightDoor;
		routeNumbers = new int[(int) Map.S.mapSize.y, (int) Map.S.mapSize.x];
		Vector3[,] bestRoute = getBestRoute (Walls.S.leftDoor);
		Debug.Log(bestRoute);
	}

	public Vector3[,] getBestRoute (Vector3 position) {
		x = (int)position.z;
		y = (int)position.x;
		routeNumbers [x, y] = 1;

		checkForward (position, 1);

		displayRoute ();

		return new Vector3[0,0];
	}

	private void checkForward (Vector3 pos, int number) {
		if (routeNumbers [(int)pos.x + 1, (int)pos.y] < 1) {
			routeNumbers [(int)pos.x + 1, (int)pos.y] = ++number;
		}
	}

	private void displayRoute () {
		int[,] route = routeNumbers;
		for (int x = 0; x < Map.S.mapSize.y; x++) {
			for (int y = 0; y < Map.S.mapSize.x; y++) {
				Vector3 pos = new Vector3 (x, 1, y); 
				GameObject newNumber = Instantiate (routeNumberPrefab, pos, Quaternion.identity) as GameObject;
				newNumber.transform.Rotate(90,0,0);
				TextMesh text = newNumber.GetComponent<TextMesh>();
				text.text = route[x,y].ToString();
			}
		}
	}
}
