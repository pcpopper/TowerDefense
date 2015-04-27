using UnityEngine;
using System.Collections;

public class Walls : MonoBehaviour {

	public static Walls S;

	public GameObject wallprefab;

	//[HideInInspector]
	//public Vector3 backDoor;
	//[HideInInspector]
	//public Vector3 frontDoor;
	[HideInInspector]
	public Vector3 rightDoor;
	[HideInInspector]
	public Vector3 leftDoor;

	private Vector3 wallSize = new Vector3(.37f, .75f, .5f);
	private GameObject parent;

	void Awake () {
		S = this;
	}

	void Start () {

	}
	
	void Update () {
	}

	public void buildWalls () {
		buildBackWall ();
		buildFrontWall ();
		buildRightWall ();
		buildLeftWall ();
	}

	private void buildBackWall () {
		parent = GameObject.Find ("BackWall");
		
		Vector2 mapSize = Map.S.mapSize;
		Vector3 startPos = new Vector3 (0, -1, mapSize.x - .3f);
		
		//float doorPos = Mathf.RoundToInt(Random.Range (4, mapSize.y - 4));
		//backDoor = startPos;
		//backDoor.x = doorPos;
		
		for (int x = 0; x < mapSize.y; x++) {
			//if (x != doorPos) {
				Vector3 pos = startPos;
				pos.x += x;
				
				GameObject newWall = Instantiate(wallprefab, pos, Quaternion.identity) as GameObject;
				newWall.transform.localScale = wallSize;
				newWall.name = "backWall" + x;
				newWall.transform.parent = parent.transform;
			//}
		}
	}

	private void buildFrontWall () {
		parent = GameObject.Find ("FrontWall");
		
		Vector2 mapSize = Map.S.mapSize;
		Vector3 startPos = new Vector3 (0, -.87f, -1.5f);

		//float doorPos = Mathf.RoundToInt(Random.Range (4, mapSize.y - 4));
		//frontDoor = startPos;
		//frontDoor.x = doorPos;
		
		for (int x = -1; x <= mapSize.y; x++) {
			//if (x != doorPos) {
			Vector3 pos = startPos;
			pos.x += x;
			
			GameObject newWall = Instantiate(wallprefab, pos, Quaternion.identity) as GameObject;
			newWall.transform.localScale = wallSize;
			newWall.transform.Rotate (30, 0, 0);
			newWall.name = "frontWall" + x;
			newWall.transform.parent = parent.transform;
			//}
		}
	}

	private void buildRightWall () {
		parent = GameObject.Find ("RightWall");
		
		Vector2 mapSize = Map.S.mapSize;
		Vector3 startPos = new Vector3 (mapSize.y - .3f, -1, 0);
		
		//float doorPos = Mathf.RoundToInt(Random.Range (2, mapSize.x - 2));
		float doorPos = Mathf.RoundToInt (mapSize.x / 2);
		rightDoor = startPos;
		rightDoor.z = doorPos;
		
		for (int y = 0; y < mapSize.x; y++) {
			if (y != doorPos) {
				Vector3 pos = startPos;
				pos.z += y;
				
				GameObject newWall = Instantiate(wallprefab, pos, Quaternion.identity) as GameObject;
				newWall.transform.localScale = wallSize;
				newWall.transform.Rotate (0, 90, 0);
				newWall.name = "rightWall" + y;
				newWall.transform.parent = parent.transform;
			}
		}
	}
	
	private void buildLeftWall () {
		parent = GameObject.Find ("LeftWall");
		
		Vector2 mapSize = Map.S.mapSize;
		Vector3 startPos = new Vector3 (-.7f, -1, 0);
		
		//float doorPos = Mathf.RoundToInt(Random.Range (2, mapSize.x - 2));
		float doorPos = Mathf.RoundToInt (mapSize.x / 2);
		leftDoor = startPos;
		leftDoor.z = doorPos;
		
		for (int y = 0; y < mapSize.x; y++) {
			if (y != doorPos) {
				Vector3 pos = startPos;
				pos.z += y;
				
				GameObject newWall = Instantiate(wallprefab, pos, Quaternion.identity) as GameObject;
				newWall.transform.localScale = wallSize;
				newWall.transform.Rotate (0, 90, 0);
				newWall.name = "leftWall" + y;
				newWall.transform.parent = parent.transform;
			}
		}
	}
}
