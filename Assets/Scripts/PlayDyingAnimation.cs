using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDyingAnimation : MonoBehaviour {

	public void justDie() {
	    Destroy (gameObject);
	}

    public void DieandRespawn() {
        GoogleARCore.HelloAR.HelloARController.PortalOpen = false;
	    Destroy (gameObject);
	}

}
