using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InitShaders : MonoBehaviour {

		public Material[] materials;
		bool inOtherWorld;
		bool hasCollided;

		void Start () {
			SetMaterials(false);
		}

		void SetMaterials(bool fullRender){
			var stencilTest = fullRender ? CompareFunction.NotEqual : CompareFunction.Equal;
			foreach (var mat in materials){
				mat.SetInt("_StencilTest", (int)stencilTest);
			}
		}

		void Update () {
		}
}
