using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OculusInputManger : MonoBehaviour {

    public Action Shoot;
    public Action ZoomIn;
    public Action ZoomOut;

    public OculusHapticsController hapticsController;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        ////Test
        //if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        //{
        //    ////OVRHaptics.RightChannel.Preempt(clip);
        //    //this.GetComponent<OculusHapticsController>().Vibrate(VibrationForce.Hard,OVRTouch.Left);
        //    //this.GetComponent<OculusHapticsController>().Vibrate(VibrationForce.Hard, OVRTouch.Right);
        //}
            //Shooting
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch ) )
        {
            if(Shoot != null)
            {
                Shoot();
            }
        }
        //Zoom Change
        else if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch ) )
        {
            if(ZoomIn != null)
            {
                ZoomIn();
            }
        }
        //Zoom Change
        else if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger,OVRInput.Controller.LTouch))
        {
            if (ZoomOut != null)
            {
                ZoomOut();
            }
        }


    }
}
