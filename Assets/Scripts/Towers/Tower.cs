using UnityEngine;
using System.Collections;

public class Tower : TowerSuperClass {

	private Color alphaRed;
	private Color alphaGreen;

	public bool towerPlaced = false;
	public GameObject projectile;
	public GameObject target;
	public GameObject p;
	public float fireRate;
	public float projPos, tarPos, curPos;

	void Awake () {
		alphaRed = new Color (1, 0, 0, .5f);
		alphaGreen = new Color (0, 1, 0, .5f);
	}
	
	void Update () {
		target = getTarget();
		if(target != null){
			InvokeRepeating("fire", 1, 2);
		}
	}

	public void fire(){
		Vector3 pos = transform.position + new Vector3(-0.5f, 2.5f, 0);
		Instantiate (projectile, pos, Quaternion.identity);

		/*projPos = projectile.transform.position;
		p1 = poi.transform.position;
		
		p01 = (1-u)* p0 + u * p1;
		
		go.transform.position = p01;*/
	}

	public GameObject getTarget(){
		GameObject[] enemies;
		GameObject closest = null;
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach(GameObject enemy in enemies){
			Vector3 diff = enemy.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if(curDistance < distance){
				closest = enemy;
				distance = curDistance;
			}
		}
		return closest;
	}

	public void makeTransparent () {
		foreach (GameObject component in options.towerPieces) {
			component.renderer.material.shader = Shader.Find("Transparent/Diffuse");
		}
	}
	
	public void makeGreen () {
		foreach (GameObject component in options.towerPieces) {
			component.renderer.material.color = alphaGreen;
		}
	}
	
	public void makeRed () {
		foreach (GameObject component in options.towerPieces) {
			component.renderer.material.color = alphaRed;
		}
	}
}
