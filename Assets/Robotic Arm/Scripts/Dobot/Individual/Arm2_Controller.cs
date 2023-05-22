using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arm2_Controller : MonoBehaviour
{
    public Slider arm2Slider;

    // slider value for upper arm that goes from -1 to 1.
    public float upperArm2SliderValue = 0.0f;

    // These slots are where you will plug in the appropriate arm parts into the inspector.
    public Transform upperArm2;

    // Allow us to have numbers to adjust in the inspector the speed of each part's rotation.
    public float upperArm2TurnRate = 1.0f;

    private float upperArm2ZRot = 0f;
    public float upperArm2ZRotMin = -20;
    public float upperArm2ZRotMax = 80;

    void Start()
    {
        /* Set default values to that we can bring our UI sliders into negative values */
        arm2Slider.minValue = -1;
        arm2Slider.maxValue = 1;
    }
    void CheckInput()
    {
        upperArm2SliderValue = arm2Slider.value;
    }
    void ProcessMovement()
    {
        //rotating our upper arm of the robot here around the Z axis and multiplying
        //the rotation by the slider's value and the turn rate for the upper arm.
        upperArm2ZRot += upperArm2SliderValue * upperArm2TurnRate;
        upperArm2ZRot = Mathf.Clamp(upperArm2ZRot, upperArm2ZRotMin, upperArm2ZRotMax);
        upperArm2.localEulerAngles = new Vector3(upperArm2.localEulerAngles.x, upperArm2.localEulerAngles.y, upperArm2ZRot);
    }

    public void ResetSliders()
    {
        //resets the sliders back to 0 when you lift up on the mouse click down (snapping effect)
        upperArm2SliderValue = 0.0f;
        arm2Slider.value = 0.0f;
    }

    void Update()
    {
        CheckInput();
        ProcessMovement();
    }
}
