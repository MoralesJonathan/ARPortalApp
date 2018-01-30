using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InterDimensionalTransport : MonoBehaviour {

	public Material[] materials;

	void Start () {
		foreach (var mat in materials){
			mat.SetInt("_StencilTest", (int)CompareFunction.Equal);
		}
	}

	void OnTriggerStay(Collider other){
		if (other.name != "Main Camera")
			return;
		if (transform.position.z > other.transform.position.z){ //not inside portal
			foreach(var mat in materials){
				mat.SetInt("_StencilTest",(int)CompareFunction.Equal);
			}
		} else { //inside portal
			foreach(var mat in materials){
				mat.SetInt("_StencilTest",(int)CompareFunction.NotEqual);
			}
		}

	}
	void OnDestroy(){
		foreach(var mat in materials){
			mat.SetInt("_StencilTest",(int)CompareFunction.NotEqual);
		}
	}

	void Update () {

	}
}
