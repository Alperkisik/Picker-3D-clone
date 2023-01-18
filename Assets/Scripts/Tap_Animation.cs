using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap_Animation : MonoBehaviour
{
    [SerializeField] float animation_speed;
    Vector3 scaleVector;
    float scale_value;
    bool goBig = true;
    void Start()
    {
        scale_value = 1f;
        scaleVector.z = 1f;
    }
    void Update()
    {
        //if (doAnimate) Animate();
    }

    private void Animate()
    {
        if (goBig) scale_value += 0.1f * animation_speed;
        else scale_value += -0.1f * animation_speed;

        scaleVector.x = scale_value;
        scaleVector.y = scale_value;

        transform.localScale = scaleVector;

        if (scale_value > 1.5f) goBig = false;
        else if (scale_value < -1.5f) goBig = true;
    }
}
