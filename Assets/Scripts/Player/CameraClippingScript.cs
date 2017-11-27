﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClippingScript : MonoBehaviour
{

	public Transform StartPoint;
	public Transform EndPoint;
	public GameObject playerPos;
	public GameObject cameraObj;
	public Vector3 originalPos;
	public float lerpC = 0f;
	public bool go = false;

    private void Start()
    {
		cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
		playerPos = GameObject.FindGameObjectWithTag("Player");
		StartPoint = cameraObj.transform;
		EndPoint = playerPos.transform;
		originalPos = cameraObj.transform.localPosition;
	}

    private void FixedUpdate()
    {
		RaycastHit hit;

		if(Physics.SphereCast(cameraObj.transform.position, 4.5f, transform.forward, out hit, 1)) {
			print("hit");
			go = true;
			
		} else if(!Physics.SphereCast(cameraObj.transform.position, 1, transform.forward, out hit, 1)) {
			go = false;
			if(cameraObj.transform.position != originalPos && go == false) {
				cameraObj.transform.localPosition = originalPos;
			}
		}
		if(go == true) {
			cameraObj.transform.position += transform.forward * 0.11f;
		}
	}

}
    


