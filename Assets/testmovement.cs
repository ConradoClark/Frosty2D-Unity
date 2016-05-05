using UnityEngine;
using System.Collections;

public class testmovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.localPosition += Vector3.right * 10;
	}
}
