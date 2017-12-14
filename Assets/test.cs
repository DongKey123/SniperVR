using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		particle.GetComponent<ParticleChildRotate>().Rotate( Quaternion.LookRotation( Vector3.left ) );
		particle.SetActive( true );
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	[SerializeField]
	GameObject particle;
}
