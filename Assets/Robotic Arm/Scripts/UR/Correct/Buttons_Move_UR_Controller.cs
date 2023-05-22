using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Buttons_Move_UR_Controller : MonoBehaviour
{
    private bool isMove = false;

    public Button[] buttonsPositive;
    public Button[] buttonsNegative;
    public Transform[] parts;
    public float[] turnRates;
    public Vector2[] limits;

    private bool[] isPressedPositive;
    private bool[] isPressedNegative;
    private float[] rotations;

    private bool[] isPressedReset;
    public Button[] resetRot;
    private float[] InitialPosition = {0f,0f,0f,0f,0f,0f};

    public TMP_InputField[] inputField;
    void Start()
    {
        //Inicializa los arrays de rotaciones e isPressed.
        rotations = new float[parts.Length];
        isPressedPositive = new bool[buttonsPositive.Length];
        isPressedNegative = new bool[buttonsNegative.Length];
        isPressedReset = new bool[resetRot.Length];
   
    }

    void Update()
    {
        //Procesa los movimientos de las partes del robot.
        for (int i = 0; i < parts.Length; i++)
        {
            float turnRate = turnRates[i];
            Vector2 limit = limits[i];

            //Comprueba si se está presionando el botón positivo.
            if (isPressedPositive[i])
            {
                rotations[i] += turnRate * Time.deltaTime;
                rotations[i] = Mathf.Clamp(rotations[i], limit.x, limit.y);

            }
            //Comprueba si se está presionando el botón negativo.
            else if (isPressedNegative[i])
            {
                rotations[i] -= turnRate * Time.deltaTime;
                rotations[i] = Mathf.Clamp(rotations[i], limit.x, limit.y);

            }

            //Asigna la rotación actual a la parte del robot.
            if (isMove == true)
            {
                parts[i].localEulerAngles = GetRotation(i);
            }

            if (isPressedReset[i])
            {
                parts[i].localEulerAngles = ResetRotation(i);
                rotations[i] = 0f; 
            }


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
    private Vector3 ResetRotation(int index)
    {
        switch (index)
        {
            case 0:
                return new Vector3(parts[index].localEulerAngles.x, parts[index].localEulerAngles.y, InitialPosition[0]);
            case 1:
                return new Vector3(parts[index].localEulerAngles.x, InitialPosition[1], parts[index].localEulerAngles.z);
            case 2:
                return new Vector3(parts[index].localEulerAngles.x, InitialPosition[2], parts[index].localEulerAngles.z);
            case 3:
                return new Vector3(parts[index].localEulerAngles.x, InitialPosition[3], parts[index].localEulerAngles.z);
            case 4:
                return new Vector3(parts[index].localEulerAngles.x, parts[index].localEulerAngles.y, InitialPosition[4]);
            case 5:
                return new Vector3(parts[index].localEulerAngles.x, parts[index].localEulerAngles.y, InitialPosition[5]);
            default:
                return Vector3.zero;
        }
    }


    //Método que se ejecuta cuando se presiona un botón positivo.
    public void OnButtonDownPositive(int index)
    {
        isPressedPositive[index] = true;
        isPressedNegative[index] = false;
        isMove = true;
    }

    //Método que se ejecuta cuando se suelta un botón positivo.
    public void OnButtonUpPositive(int index)
    {
        isPressedPositive[index] = false;
        isMove = false;
    }

    //Método que se ejecuta cuando se presiona un botón negativo.
    public void OnButtonDownNegative(int index)
    {
        isPressedNegative[index] = true;
        isPressedPositive[index] = false;
        isMove = true;
    }

    //Método que se ejecuta cuando se suelta un botón negativo.
    public void OnButtonUpNegative(int index)
    {
        isPressedNegative[index] = false;
        isMove = false;
    }


    public void OnbuttonDownResetRotation(int index)
    {
        isPressedReset[index] = true;
        isMove = false;
    }
    public void OnbuttonUpResetRotation(int index)
    {
        isPressedReset[index] = false;
    }


    public void OnValueChanged(int index)
    {

        float degrees;
        if (float.TryParse(inputField[index].text, out degrees))
        {
            if (index == 0 || index == 4 || index == 5)
            {
                parts[index].localEulerAngles = new Vector3(parts[index].localEulerAngles.x, parts[index].localEulerAngles.y, degrees);
            }
            else if (index == 1 || index == 2 || index == 3)
            {
                parts[index].localEulerAngles = new Vector3(parts[index].localEulerAngles.x, degrees, parts[index].localEulerAngles.z);
            }
            rotations[index] = degrees;
        }
    }


}
