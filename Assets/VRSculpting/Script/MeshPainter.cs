using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sandiegoJohn.VRsculpting{
	
public class MeshPainter : MonoBehaviour {


		Camera sceneCamera;
		// Use this for initialization
		void Start () {
			sceneCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		bool HitTestUVPosition(ref Vector3 uvWorldPosition){
			RaycastHit hit; //create a raycasthit object
			Vector3 mousePos = Input.mousePosition; //gets the mouse position on the local screen space
			Vector3 cursorPos = new Vector3 (mousePos.x, mousePos.y, 0.0f); //gets the position of the cursor on the x,y coordinate
			Ray cursorRay=sceneCamera.ScreenPointToRay (cursorPos); //ray cast points to the cursor position.
			if (Physics.Raycast(cursorRay,out hit,200)){
				MeshCollider meshCollider = hit.collider as MeshCollider;
				if (meshCollider == null || meshCollider.sharedMesh == null)
					return false; 
				Vector2 pixelUV = new Vector2(hit.textureCoord.x,hit.textureCoord.y);
				uvWorldPosition.x=pixelUV.x;
				uvWorldPosition.y=pixelUV.y;
				uvWorldPosition.z=0.0f;
				return true;
			}
			else{ 
				return false;
			}
		}
	}
}
