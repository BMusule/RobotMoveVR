using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arm3_Controller : MonoBehaviour
{
    public Slider arm3Slider;

    // slider value for upper arm that goes from -1 to 1.
    public float upperArm3SliderValue = 0.0f;

    // These slots are where you will plug in the appropriate arm parts into the inspector.
    public Transform upperArm3;

    // Allow us to have numbers to adjust in the inspector the speed of each part's rotation.
    public float upperArm3TurnRate = 1.0f;

    private float upperArm3ZRot = 0f;
    public float upperArm3ZRotMin = -110;
    public float upperArm3ZRotMax = 10;

    void Start()
    {
        /* Set default values to that we can bring our UI sliders into negative values */
        arm3Slider.minValue = -1;
        arm3Slider.maxValue = 1;
    }
    void CheckInput()
    {
        upperArm3SliderValue = arm3Slider.value;
    }
    void ProcessMovement()
    {
        //rotating our upper arm of the robot here around the Z axis and multiplying
        //the rotation by the slider's value and the turn rate for the upper arm.
        upperArm3ZRot += upperArm3SliderValue * upperArm3TurnRate;
        upperArm3ZRot = Mathf.Clamp(upperArm3ZRot, upperArm3ZRotMin, upperArm3ZRotMax);
        upperArm3.localEulerAngles = new Vector3(upperArm3.localEulerAngles.x, upperArm3.localEulerAngles.y, upperArm3ZRot);
    }

    public void ResetSliders()
    {
        //resets the sliders back to 0 when you lift up on the mouse click down (snapping effect)
        upperArm3SliderValue = 0.0f;
        arm3Slider.value = 0.0f;
    }

    void Update()
    {
        CheckInput();
        ProcessMovement();
    }
}
