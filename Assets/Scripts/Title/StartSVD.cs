using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSVD : VRInteraction
{
	// Use this for initialization
	void Start () {
		handCount = 0;
		activeSceneChange = false;
	}
	
	public override void InteractionForHand( OVRInput.Controller _inputController )
	{
		if ( activeSceneChange )
			return;

		activeSceneChange = true;
		SceneManager.LoadScene( _nextScene );
	}

	public override void ControllerIn( OVRInput.Controller _inputController )
	{
		if ( handCount <= 0 )
			_showUI.SetActive( true );
		handCount++;
	}

	public override void ContollerOut( OVRInput.Controller _outputController )
	{
		handCount--;
		if ( handCount <= 0 )
			_showUI.SetActive( false );
	}

	bool activeSceneChange;
	int handCount;

	public GameObject _showUI;
	public AudioClip _hitSound;

	public string _nextScene;
}
