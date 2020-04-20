using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Transform target;

    [Range (0, 1f)]
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float startingCameraHeight = 1f;

    PlayerControls pc;
    private float followY;

    private void Start()
    {
        pc = FindObjectOfType<PlayerControls>();

        pc.transform.LookAt(target);
    }
    private void FixedUpdate()
    {
        followY = pc.currentGroundLevel;

        Vector3 desiredPosition = new Vector3(target.position.x, followY + startingCameraHeight, target.position.z) + offset;
        Vector3 smoothedPosition = Vector3.Slerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

}
