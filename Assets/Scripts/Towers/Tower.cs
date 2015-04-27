using UnityEngine;
using System.Collections;

public class Tower : TowerSuperClass {

	private Color alphaRed;
	private Color alphaGreen;

	void Awake () {
		alphaRed = new Color (1, 0, 0, .5f);
		alphaGreen = new Color (0, 1, 0, .5f);
	}
	
	void Update () {
	
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
