using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Move_UR_Controller : MonoBehaviour
{

    public Slider baseSlider;
    public Slider armSlider;
    public Slider arm2Slider;
    public Slider arm3Slider; 
    public Slider arm4Slider;
    public Slider arm5Slider;

    // slider value for base platform that goes from -1 to 1.
    public float baseSliderValue = 0.0f;
    // slider value for upper arm that goes from -1 to 1.
    public float upperArmSliderValue = 0.0f;

    // slider value for upper arm2 that goes from -1 to 1.
    public float upperArm2SliderValue = 0.0f;

    // slider value for upper arm3that goes from -1 to 1.
    public float upperArm3SliderValue = 0.0f;
    public float upperArm4SliderValue = 0.0f;
    public float upperArm5SliderValue = 0.0f;

    // These slots are where you will plug in the appropriate arm parts into the inspector.
    public Transform robotBase;
    public Transform upperArm;
    public Transform upperArm2;
    public Transform upperArm3;
    public Transform upperArm4;
    public Transform upperArm5;

    // Allow us to have numbers to adjust in the inspector the speed of each part's rotation.
    public float baseTurnRate = 1.0f;

    private float baseZRot = 0.0f;
    public float baseZRotMin = -90.0f;
    public float baseZRotMax = 90.0f;

    //Arm 1
    public float upperArmTurnRate = 1.0f;

    private float upperArmYRot = 0f;
    public float upperArmYRotMin = -160.0f;
    public float upperArmYRotMax = -60.0f;

    //Arm2
    public float upperArm2TurnRate = 1.0f;

    private float upperArm2YRot = 0f;
    public float upperArm2YRotMin = -20;
    public float upperArm2YRotMax = 80;

    //Arm3
    public float upperArm3TurnRate = 1.0f;

    private float upperArm3YRot = 0f;
   // public float upperArm3YRotMin = -110;
    //public float upperArm3YRotMax = 10;

    //Arm4
    public float upperArm4TurnRate = 1.0f;

    private float upperArm4ZRot = 0f;
   // public float upperArm4XRotMin = -110;
   // public float upperArm4XRotMax = 10;

    //Arm5
    public float upperArm5TurnRate = 1.0f;

    private float upperArm5ZRot = 0f;
   // public float upperArm5ZRotMin = -110;
  //  public float upperArm5ZRotMax = 10;

    void Start()
    {
        /* Set default values to that we can bring our UI sliders into negative values */
        baseSlider.minValue = -1;
        baseSlider.maxValue = 1;

        armSlider.minValue = -1;
        armSlider.maxValue = 1;

        arm2Slider.minValue = -1;
        arm2Slider.maxValue = 1;

        arm3Slider.minValue = -1;
        arm3Slider.maxValue = 1;

        arm4Slider.minValue = -1;
        arm4Slider.maxValue = 1;

        arm5Slider.minValue = -1;
        arm5Slider.maxValue = 1;
    }
    void CheckInput()
    {
        baseSliderValue = baseSlider.value;
        upperArmSliderValue = armSlider.value;
        upperArm2SliderValue = arm2Slider.value;
        upperArm3SliderValue = arm3Slider.value;
        upperArm4SliderValue = arm4Slider.value;
        upperArm5SliderValue = arm5Slider.value;
    }
    void ProcessMovement()
    {
        //rotating our base of the robot here around the Z axis and multiplying
        //the rotation by the slider's value and the turn rate for the base.
        baseZRot += baseSliderValue * baseTurnRate;
        baseZRot = Mathf.Clamp(baseZRot, baseZRotMin, baseZRotMax);
        robotBase.localEulerAngles = new Vector3(robotBase.localEulerAngles.x, robotBase.localEulerAngles.y, baseZRot);

        //rotating our upper arm1 of the robot here around the Z axis and multiplying
        //the rotation by the slider's value and the turn rate for the upper arm.
        upperArmYRot += upperArmSliderValue * upperArmTurnRate;
        upperArmYRot = Mathf.Clamp(upperArmYRot, upperArmYRotMin, upperArmYRotMax);
        upperArm.localEulerAngles = new Vector3(upperArm.localEulerAngles.x, upperArmYRot, upperArm.localEulerAngles.z);

        //rotating our upper arm of the robot here around the Z axis and multiplying
        //the rotation by the slider's value and the turn rate for the upper arm.
        upperArm2YRot += upperArm2SliderValue * upperArm2TurnRate;
        upperArm2YRot = Mathf.Clamp(upperArm2YRot, upperArm2YRotMin, upperArm2YRotMax);
        upperArm2.localEulerAngles = new Vector3(upperArm2.localEulerAngles.x, upperArm2YRot, upperArm2.localEulerAngles.z);

        //rotating our upper arm of the robot here around the Z axis and multiplying
        //the rotation by the slider's value and the turn rate for the upper arm.
        upperArm3YRot += upperArm3SliderValue * upperArm3TurnRate;
        upperArm3.localEulerAngles = new Vector3(upperArm3.localEulerAngles.x, upperArm3YRot, upperArm3.localEulerAngles.z);

        upperArm4ZRot += upperArm4SliderValue * upperArm4TurnRate;
        upperArm4.localEulerAngles = new Vector3(upperArm4.localEulerAngles.x, upperArm4.localEulerAngles.y, upperArm4ZRot);

        upperArm5ZRot += upperArm5SliderValue * upperArm5TurnRate;
        upperArm5.localEulerAngles = new Vector3(upperArm5.localEulerAngles.x, upperArm5.localEulerAngles.y, upperArm5ZRot);

    }

    public void ResetSliders()
    {
        //resets the sliders back to 0 when you lift up on the mouse click down (snapping effect)
        baseSliderValue = 0.0f;
        baseSlider.value = 0.0f;
        upperArmSliderValue = 0.0f;
        armSlider.value = 0.0f;
        upperArm2SliderValue = 0.0f;
        arm2Slider.value = 0.0f;
        upperArm3SliderValue = 0.0f;
        arm3Slider.value = 0.0f;
        upperArm4SliderValue = 0.0f;
        arm4Slider.value = 0.0f;
        upperArm5SliderValue = 0.0f;
        arm5Slider.value = 0.0f;
    }

    void Update()
    {
        CheckInput();
        ProcessMovement();
    }
}
