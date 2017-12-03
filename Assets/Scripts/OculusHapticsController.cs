using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VibrationForce
{
    Light,
    Medium,
    Hard,
}

public enum OVRTouch
{
    Left,
    Right
}

public class OculusHapticsController : MonoBehaviour {

   

    [SerializeField]
    OVRInput.Controller controllerMask;

    public int cnt = 100;

    private OVRHapticsClip clipLight;
    private OVRHapticsClip clipMedium;
    private OVRHapticsClip clipHard;

    private void Start()
    {
        InitializeOVRHaptics();
    }

    private void InitializeOVRHaptics()
    {
        clipLight = new OVRHapticsClip(cnt);
        clipMedium = new OVRHapticsClip(cnt);
        clipHard = new OVRHapticsClip(cnt);
        for (int i = 0; i < cnt; i++)
        {
            clipLight.Samples[i] = i % 2 == 0 ? (byte)0 : (byte)75;
            clipMedium.Samples[i] = i % 2 == 0 ? (byte)0 : (byte)150;
            clipHard.Samples[i] = i % 2 == 0 ? (byte)0 : (byte)255;
        }

        clipLight = new OVRHapticsClip(clipLight.Samples, clipLight.Samples.Length);
        clipMedium = new OVRHapticsClip(clipMedium.Samples, clipMedium.Samples.Length);
        clipHard = new OVRHapticsClip(clipHard.Samples, clipHard.Samples.Length);
    }

    public void Vibrate(VibrationForce vibrationForce, OVRTouch touchType)
    {
        var channel = OVRHaptics.RightChannel;
        switch (touchType)
        {
            case OVRTouch.Left:
                {
                    channel = OVRHaptics.LeftChannel;
                }
                break;
            case OVRTouch.Right:
                {
                    channel = OVRHaptics.RightChannel;
                }
                break;
        }

        switch (vibrationForce)
        {
            case VibrationForce.Light:
                channel.Preempt(clipLight);
                break;
            case VibrationForce.Medium:
                channel.Preempt(clipMedium);
                break;
            case VibrationForce.Hard:
                channel.Preempt(clipHard);
                break;
        }
    }
}
