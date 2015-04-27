using UnityEngine;
using System.Collections;

public class Menus : MonoBehaviour {

	public void placeTower () {
		Tower_Controller.S.createGhostTower ();
	}

	public void spawnEnemies () {
		Enemy_Spawn.S.spawnEnemy = true;
	}
}
