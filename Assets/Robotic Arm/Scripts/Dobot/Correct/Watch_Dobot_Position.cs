using UnityEngine;
using TMPro;

public class Watch_Dobot_Position: MonoBehaviour
{
    public GameObject[] robotObject;
    public TextMeshProUGUI[] rotationText;



    void Start()
    {

    }

    void Update()
    {
        // Obtenemos la rotación en el eje Z
        float baseRotation = robotObject[0].transform.localEulerAngles.z;
        rotationText[0].text = baseRotation.ToString("F0");
        float arm1Rotation = robotObject[1].transform.localEulerAngles.z;
        rotationText[1].text = arm1Rotation.ToString("F0");
        float arm2Rotation = robotObject[2].transform.localEulerAngles.z;
        rotationText[2].text = arm2Rotation.ToString("F0");
        float arm3Rotation = robotObject[3].transform.localEulerAngles.z;
        rotationText[3].text = arm3Rotation.ToString("F0");
    }


}