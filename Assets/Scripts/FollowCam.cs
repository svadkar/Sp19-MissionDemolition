﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
    static public FollowCam S; //a FollowCam Singleton

    //field set in the Unity Inspector pane
    public float easing = 0.05f;
    public Vector2 minXY;
    public bool _____________________________;

    //field set dynamically
    public GameObject poi; //The point of interest
    public float camZ; //The desired Z pos of the camera

    void Awake()
    {
        S = this;
        camZ = this.transform.position.z;
    }

    // Use this for initialization
    void Start ()
    {
       
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Get the position of the poi
        Vector3 destination;

        if (poi == null)
        {
            destination = Vector3.zero;
        } else
        {
            //Get the position of the poi
            destination = poi.transform.position;

            //If poi is a Projectile, check to see if it's at rest
            if (poi.tag == "Projectile")
            {
                //If it is sleeping (that is, not moving)
                if (poi.rigidbody.IsSleeping())
                {
                    //return to default view
                    poi = null;
                    //in the next update
                    return;
                }
            }
        }

        //Limit the X & Y to minimum values
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);

        //Interpolate from the current Camera position toward destination
        destination = Vector3.Lerp(transform.position, destination, easing);

        //Retain a destination.z of camZ
        destination.z = camZ;

        //Set the camera to the destination
        transform.position = destination;

        //Set the orthographicSize of the Camera to keep Ground in view
        this.GetComponent<Camera>().orthographicSize = destination.y + 10;
    }
}
