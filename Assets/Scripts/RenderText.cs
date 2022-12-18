using UnityEngine;

public class RenderText : MonoBehaviour
{
    GameObject child;

    private void Start()
    {
        child = transform.GetChild(0).gameObject;
        child.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) child.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) child.SetActive(false);
    }
}
