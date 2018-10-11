using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class WheelController : MonoBehaviour {

    public Joystick pad;

    public Transform wheelL;
    public Transform wheelR;

    public float rotFactor = 2;

    public float speed = 10, rotSpeed = 2;

	// Use this for initialization
	void Start () {
       pad = GameObject.FindGameObjectWithTag("pad").GetComponent<Joystick>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        wheelL.localRotation = Quaternion.Euler(0, rotFactor * pad.transform.position.x - 90, 90);
        wheelR.localRotation = Quaternion.Euler(0, rotFactor * pad.transform.position.x - 90, 90);

        transform.position += speed * transform.forward * pad.transform.position.y;

        if(pad.transform.position.x < 100)
        {
            transform.rotation *= Quaternion.Euler(0, -rotSpeed * pad.transform.position.x, 0);
        }
        else
        {
            transform.rotation *= Quaternion.Euler(0, rotSpeed * pad.transform.position.x, 0);
        }
    }
}
