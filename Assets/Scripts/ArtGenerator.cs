using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //ScreenCapture.CaptureScreenshot("Icon.png");
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetMouseButtonDown(0))
            ScreenCapture.CaptureScreenshot("Right.png");
    }
}
