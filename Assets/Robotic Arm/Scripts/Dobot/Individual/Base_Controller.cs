using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base_Controller : MonoBehaviour
{
    public Slider baseSlider;

    // slider value for base platform that goes from -1 to 1.
    public float baseSliderValue = 0.0f;


    // These slots are where you will plug in the appropriate arm parts into the inspector.
    public Transform robotBase;

    // Allow us to have numbers to adjust in the inspector the speed of each part's rotation.
    public float baseTurnRate = 1.0f;

    private float baseZRot = 0.0f;
    public float baseZRotMin = -90.0f;
    public float baseZRotMax = 90.0f;

    void Start()
    {
        /* Set default values to that we can bring our UI sliders into negative values */
        baseSlider.minValue = -1;
        baseSlider.maxValue = 1;
    }
    void CheckInput()
    {
        baseSliderValue = baseSlider.value;
    }
    void ProcessMovement()
    {
        //rotating our base of the robot here around the Y axis and multiplying
        //the rotation by the slider's value and the turn rate for the base.
        baseZRot += baseSliderValue * baseTurnRate;
        baseZRot = Mathf.Clamp(baseZRot, baseZRotMin, baseZRotMax);
        robotBase.localEulerAngles = new Vector3(robotBase.localEulerAngles.x, robotBase.localEulerAngles.y,baseZRot);

    }

    public void ResetSliders()
    {
        //resets the sliders back to 0 when you lift up on the mouse click down (snapping effect)
        baseSliderValue = 0.0f;
        baseSlider.value = 0.0f;
    }

    void Update()
    {
        CheckInput();
        ProcessMovement();
    }
}
