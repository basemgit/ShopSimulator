using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField]
    float senseX;
    [SerializeField]
    float senseY;
    float xRotation;
    float yRotation;
    [SerializeField]
    Transform playerOrientation;


    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senseX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senseY;
        yRotation += mouseX;
        xRotation -= mouseY;
        // rotation limit
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        // rotate cam
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        // rotate player
        playerOrientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
