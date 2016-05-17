﻿using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	//enemies array list
	private ArrayList enemies;

	private int maxEnemies = 5;
	public GameObject prefab;

	//scripts 
	public DayNightController dayNightScript;

	// Use this for initialization
	void Start () {
		enemies = new ArrayList ();
		dayNightScript = GetComponent<DayNightController> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (enemies.Count < maxEnemies) {
			Instantiate(prefab);
			enemies.Add (prefab);
		}

	}
}
