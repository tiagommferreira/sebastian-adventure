using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class PlayerSanity : MonoBehaviour {

	private int sanity;
	private int maxSanityLevel = 1000;
	private int sanityCouncern=200;
	private SanityBlur sanityBlurScript;
	private double lastAttackReceived=0f;
	private double minTimeBetweenRecoveries=5f;
	private int recoveryRate=50;

	void Start () {
		sanity = maxSanityLevel;
		sanityBlurScript = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<SanityBlur> ();
	}


	// Update is called once per frame
	void Update () {
		if (sanity < sanityCouncern) {
			sanityBlurScript.setBlur (true);
		} else {
			sanityBlurScript.setBlur (false);
		}

		if (Time.time > (minTimeBetweenRecoveries + lastAttackReceived)) {
			lastAttackReceived = Time.time;
			sanity = System.Math.Min (sanity+recoveryRate, maxSanityLevel);
		}

	}

	public void decreaseSanity(int damage) {
		sanity -= damage;
		lastAttackReceived = Time.time;
	}
}
