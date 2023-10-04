using UnityEngine;

public class CameraFollow3D : MonoBehaviour
{
    public Transform player;
    public float lookSpeed = 45f;
    public float moveSpeed = 1.8f;

    private Vector3 initialPosition = new Vector3(-4.4f, 41, 15);
    private Vector3 playerOffset = new Vector3(0, 2, -5);

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = initialPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update is called after per frame
    void LateUpdate()
    {
        Quaternion rotationTarget = Quaternion.LookRotation(player.position - this.transform.position);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotationTarget, lookSpeed * Time.deltaTime);

        this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position + playerOffset, moveSpeed * Time.deltaTime);

        //Vector3 desiredPosition = player.transform.position + playerOffset;
        //Vector3 smoothPosition = Vector3.Lerp(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        //this.transform.position = smoothPosition;

    }
}
