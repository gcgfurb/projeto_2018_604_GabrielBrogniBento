using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andar : MonoBehaviour {

    public Rigidbody playerPrefab;

    bool walkForward = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //moveFoward();
    }

    void FixedUpdate()
    {
        moveFoward();
    }

    public void stopFoward()
    {
        walkForward = false;
    }

    public void startFoward()
    {
        walkForward = true;
    }

    public void moveFoward()
    {
        if (walkForward)
        {
            playerPrefab.AddForce(new Vector3(0, 0, 40), ForceMode.Acceleration);
        }
    }

    public void moveBackward()
    {

    }

    public void rotateLeft()
    {

    }

    public void rotateRight()
    {

    }
}
