using UnityEngine;
using System.Collections;

[System.Serializable]
public class TowerOptions {
	public float damage;
	public GameObject[] towerPieces;
}

public class TowerSuperClass : MonoBehaviour {

	public TowerOptions options;
}
