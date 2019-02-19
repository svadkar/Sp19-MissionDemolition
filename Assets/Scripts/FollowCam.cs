using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
    static public FollowCam S; //a FollowCam Singleton

    //field set in the Unity Inspector pane
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
        if (poi == null) return; //Return if there is no poi

        //Get the position of the poi
        Vector3 destination = poi.transform.position;
        
        //Retain a destination.z of camZ
        destination.z = camZ;

        //Set the camera to the destination
        transform.position = destination;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
