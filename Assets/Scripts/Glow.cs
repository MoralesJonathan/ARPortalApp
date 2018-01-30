using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update(){
transform.GetComponent<Light>().intensity = Mathf.Abs(Mathf.Sin(Time.time*2))/2;
}
}
