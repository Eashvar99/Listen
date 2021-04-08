using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemRotator : MonoBehaviour
{
    public int interpolationFramesCount = 45; // Number of frames to completely interpolate between the 2 positions
    int elapsedFrames = 0;
    Quaternion endRotation; 
    // Start is called before the first frame update
    void Start()
    {
         float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

         endRotation = Quaternion.Euler(this.transform.localRotation.x, this.transform.localRotation.y + 360.0f, this.transform.localRotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion.Lerp(this.transform.localRotation, endRotation, elapsedFrames);
        elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);
    }
}
