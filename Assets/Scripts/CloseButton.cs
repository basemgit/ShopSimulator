using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public void Close()
    {
        transform.parent.gameObject.SetActive(false);

    }
}
