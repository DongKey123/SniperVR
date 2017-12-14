using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleChildRotate : MonoBehaviour
{
	public void Rotate(Quaternion angle )
	{
		RotateChild( transform, angle );
	}

	void RotateChild(Transform child, Quaternion angle)
	{
		transform.rotation = angle;
		for ( int i = 0; i < child.childCount; i++ )
		{
			RotateChild( child.GetChild( i ), angle );
		}

	}
}
