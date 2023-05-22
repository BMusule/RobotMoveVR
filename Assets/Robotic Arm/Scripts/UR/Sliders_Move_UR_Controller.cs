using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders_Move_UR_Controller : MonoBehaviour
{
    public Slider[] sliders;
    public Transform[] parts;
    public float[] turnRates;
    public Vector2[] limits;

    private float[] rotations;

    void Start()
    {
        //Inicializa el array de rotaciones.
        rotations = new float[parts.Length];

        //Inicializa los valores mínimos y máximos de los sliders.
        foreach (Slider slider in sliders)
        {
            slider.minValue = -1;
            slider.maxValue = 1;
        }
    }

    void Update()
    {
        //Procesa los movimientos de las partes del robot.
        for (int i = 0; i < parts.Length; i++)
        {
            float sliderValue = sliders[i].value;
            float turnRate = turnRates[i];
            Vector2 limit = limits[i];

            rotations[i] += sliderValue * turnRate;
            rotations[i] = Mathf.Clamp(rotations[i], limit.x, limit.y);

            parts[i].localEulerAngles = GetRotation(i);
        }
    }

    //Devuelve un vector con la rotación actual de la parte del robot.
    private Vector3 GetRotation(int index)
    {
        switch (index)
        {
            case 0:
                return new Vector3(parts[index].localEulerAngles.x, parts[index].localEulerAngles.y, rotations[index]);
            case 1:
                return new Vector3(parts[index].localEulerAngles.x, rotations[index], parts[index].localEulerAngles.z);
            case 2:
                return new Vector3(parts[index].localEulerAngles.x, rotations[index], parts[index].localEulerAngles.z);
            case 3:
                return new Vector3(parts[index].localEulerAngles.x, rotations[index], parts[index].localEulerAngles.z);
            case 4:
                return new Vector3(parts[index].localEulerAngles.x, parts[index].localEulerAngles.y, rotations[index]);
            case 5:
                return new Vector3(parts[index].localEulerAngles.x, parts[index].localEulerAngles.y, rotations[index]);
            default:
                return Vector3.zero;
        }
    }
    public void ResetSliders()
    {
        foreach (Slider slider in sliders)
        {
            slider.value = 0;
        }
    }
}
