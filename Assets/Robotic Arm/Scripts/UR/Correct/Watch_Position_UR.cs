using UnityEngine;
using TMPro;

public class Watch_Position_UR : MonoBehaviour
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
        float arm1Rotation = robotObject[1].transform.localEulerAngles.y;
        rotationText[1].text = arm1Rotation.ToString("F0");
        float arm2Rotation = robotObject[2].transform.localEulerAngles.y;
        rotationText[2].text = arm2Rotation.ToString("F0");
        float arm3Rotation = robotObject[3].transform.localEulerAngles.y;
        rotationText[3].text = arm3Rotation.ToString("F0");
        float arm4Rotation = robotObject[4].transform.localEulerAngles.z;
        rotationText[4].text = arm4Rotation.ToString("F0");
        float arm5Rotation = robotObject[5].transform.localEulerAngles.z;
        rotationText[5].text = arm5Rotation.ToString("F0");

    }


}
