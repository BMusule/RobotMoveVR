using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Move_Controller : MonoBehaviour
{

        public Slider baseSlider;
        public Slider armSlider;
        public Slider arm2Slider;
        public Slider arm3Slider;

        // slider value for base platform that goes from -1 to 1.
        public float baseSliderValue = 0.0f;
        // slider value for upper arm that goes from -1 to 1.
        public float upperArmSliderValue = 0.0f;

        // slider value for upper arm2 that goes from -1 to 1.
        public float upperArm2SliderValue = 0.0f;

        // slider value for upper arm3that goes from -1 to 1.
        public float upperArm3SliderValue = 0.0f;

        // These slots are where you will plug in the appropriate arm parts into the inspector.
        public Transform robotBase;
        public Transform upperArm;
        public Transform upperArm2;
        public Transform upperArm3;

        // Allow us to have numbers to adjust in the inspector the speed of each part's rotation.
        public float baseTurnRate = 1.0f;

        private float baseZRot = 0.0f;
        public float baseZRotMin = -90.0f;
        public float baseZRotMax = 90.0f;

        //Arm 1
        public float upperArmTurnRate = 1.0f;

        private float upperArmZRot = -100f;
        public float upperArmZRotMin = -160.0f;
        public float upperArmZRotMax = -60.0f;

        //Arm2
        public float upperArm2TurnRate = 1.0f;

        private float upperArm2ZRot = 0f;
        public float upperArm2ZRotMin = -20;
        public float upperArm2ZRotMax = 80;

        //Arm3
        public float upperArm3TurnRate = 1.0f;

        private float upperArm3ZRot = 0f;
        public float upperArm3ZRotMin = -110;
        public float upperArm3ZRotMax = 10;


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
    }
    void CheckInput()
    {
        baseSliderValue = baseSlider.value;
        upperArmSliderValue = armSlider.value;
        upperArm2SliderValue = arm2Slider.value;
        upperArm3SliderValue = arm3Slider.value;
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
        upperArmZRot += upperArmSliderValue * upperArmTurnRate;
        upperArmZRot = Mathf.Clamp(upperArmZRot, upperArmZRotMin, upperArmZRotMax);
        upperArm.localEulerAngles = new Vector3(upperArm.localEulerAngles.x, upperArm.localEulerAngles.y, upperArmZRot);
      
        //rotating our upper arm of the robot here around the Z axis and multiplying
        //the rotation by the slider's value and the turn rate for the upper arm.
        upperArm2ZRot += upperArm2SliderValue * upperArm2TurnRate;
        upperArm2ZRot = Mathf.Clamp(upperArm2ZRot, upperArm2ZRotMin, upperArm2ZRotMax);
        upperArm2.localEulerAngles = new Vector3(upperArm2.localEulerAngles.x, upperArm2.localEulerAngles.y, upperArm2ZRot);

        //rotating our upper arm of the robot here around the Z axis and multiplying
        //the rotation by the slider's value and the turn rate for the upper arm.
        upperArm3ZRot += upperArm3SliderValue * upperArm3TurnRate;
        upperArm3ZRot = Mathf.Clamp(upperArm3ZRot, upperArm3ZRotMin, upperArm3ZRotMax);
        upperArm3.localEulerAngles = new Vector3(upperArm3.localEulerAngles.x, upperArm3.localEulerAngles.y, upperArm3ZRot);
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
    }

    void Update()
    {
        CheckInput();
        ProcessMovement();
    }
}
