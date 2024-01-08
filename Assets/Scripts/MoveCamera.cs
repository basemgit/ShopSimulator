using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    Transform camPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = camPosition.position;
    }
}
