using UnityEngine;

public class CartMove : MonoBehaviour
{
    [SerializeField] Transform target, player;
    [SerializeField] float lerpDuration;
    float timeElapsed;

    private void Start()
    {
        player.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.parent == null) GetComponent<CartMove>().enabled = false;
        if (timeElapsed < lerpDuration && transform.position != target.position)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
        }
        if (timeElapsed >= 5f) player.parent = null;
    }
}
