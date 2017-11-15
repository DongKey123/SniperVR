using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSoundManager : MonoBehaviour
{
	[SerializeField]
	Paradox.SceneMovement _sceneMove;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine( "LoadSoundManagerFrefab" );
		
	}

	IEnumerator LoadSoundManagerFrefab()
	{
		yield return new WaitForSeconds( 0.5f );
		_sceneMove.LoadScene();
	}

}
