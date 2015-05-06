using UnityEngine;
using System.Collections;

[System.Serializable]
public class EnemyOptions {
	public float speed;
}

public class EnemySuperClass : MonoBehaviour {

	public EnemyOptions options;
}
