using UnityEngine;

public class ShopKeeper1Trigger : MonoBehaviour
{
    [SerializeField]
    GameObject InventoryView;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InventoryView.SetActive(true);

        }
    }
}
