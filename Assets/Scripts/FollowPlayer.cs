using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    private Vector3 playerOffset = new Vector3(0, 3.75f, -16);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update is called after per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + playerOffset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;

        transform.LookAt(player);
    }
}
