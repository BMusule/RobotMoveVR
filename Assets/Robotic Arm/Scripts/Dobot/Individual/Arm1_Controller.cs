using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arm1_Controller : MonoBehaviour
{
    public Slider armSlider;

    // slider value for upper arm that goes from -1 to 1.
    public float upperArmSliderValue = 0.0f;

    // These slots are where you will plug in the appropriate arm parts into the inspector.
    public Transform upperArm;

    // Allow us to have numbers to adjust in the inspector the speed of each part's rotation.
    public float upperArmTurnRate = 1.0f;

    private float upperArmZRot = -100f;
    public float upperArmZRotMin = -160.0f;
    public float upperArmZRotMax = -60.0f;

    void Start()
    {
        /* Set default values to that we can bring our UI sliders into negative values */
        armSlider.minValue = -1;
        armSlider.maxValue = 1;
    }
    void CheckInput()
    {
        upperArmSliderValue = armSlider.value;
    }
    void ProcessMovement()
    {
        //rotating our upper arm of the robot here around the Z axis and multiplying
        //the rotation by the slider's value and the turn rate for the upper arm.
        upperArmZRot += upperArmSliderValue * upperArmTurnRate;
        upperArmZRot = Mathf.Clamp(upperArmZRot, upperArmZRotMin, upperArmZRotMax);
        upperArm.localEulerAngles = new Vector3(upperArm.localEulerAngles.x, upperArm.localEulerAngles.y, upperArmZRot );
    }

    public void ResetSliders()
    {
        //resets the sliders back to 0 when you lift up on the mouse click down (snapping effect)
        upperArmSliderValue = 0.0f;
        armSlider.value = 0.0f;
    }

    void Update()
    {
        CheckInput();
        ProcessMovement();
    }
}
