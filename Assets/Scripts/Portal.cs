using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Portal : MonoBehaviour
 {
	public Material[] materials;
	public Transform device;
	bool wasInFront;
	bool inOtherWorld;
	bool hasCollided;
    public Portal(Transform t)
    {

    }

    void Start ()
	{
        Camera cam = FindObjectOfType<Camera>();

        device = cam.transform;

	}

	void SetMaterials(bool fullRender){
		var stencilTest = fullRender ? CompareFunction.NotEqual : CompareFunction.Equal;
		foreach (var mat in materials){
			mat.SetInt("_StencilTest", (int)stencilTest);
		}
	}

	bool GetIsInFront(){
		Vector3 worldPos = device.position;
		Vector3 pos = transform.InverseTransformPoint(worldPos);
		return pos.z >= 0 ? true: false;
	}
    
	void OnTriggerEnter(Collider other){
		if(other.transform != device)
			return;
		wasInFront = GetIsInFront();
		hasCollided = true;
	}

	void OnTriggerExit(Collider other){
		if(other.transform != device)
			return;
			hasCollided = false;
	}

	void WhileCameraColliding(){
		if(!hasCollided)
			return;
		bool isInFront = GetIsInFront();
		if((isInFront && !wasInFront) || (wasInFront && !isInFront)) {
		 	inOtherWorld = !inOtherWorld;
		 	SetMaterials(inOtherWorld);
		}
		wasInFront = isInFront;
		}

	void OnDestroy(){
        Debug.Log("XYZ ");
    }

	void Update () {
		WhileCameraColliding();
	}
}
