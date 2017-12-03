using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OculusInputManger : MonoBehaviour {

    public Action Shoot;
    public Action ZoomIn;
    public Action ZoomOut;

    private OVRHapticsClip hapticsClip;
    private float hapticsClipLength = 2f;
    private float hapticsTimeout;

	// Use this for initialization
	void Start () {
        hapticsClip = new OVRHapticsClip(2);
        OVRHaptics.RightChannel.Preempt(hapticsClip);
	}
	
	// Update is called once per frame
	void Update () {
        //Shooting
		if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch ) )
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
