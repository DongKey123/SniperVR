using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : HitObject {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
