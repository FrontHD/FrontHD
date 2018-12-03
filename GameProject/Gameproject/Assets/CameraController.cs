using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public float lookSmooth = 0.09f;
    public Vector3 offsetFromTarget = new Vector3(0, 6, -8);
    public float xTilt = 10;

    CharacterController charController;
    float rotateVel = 0;

	// Use this for initialization
	void Start () {
        SetCameraTarget(target);
	}

    public void SetCameraTarget(Transform t) {
        target = t;
        if(target!=null)
        {
            if(target.GetComponent<CharacterController>())
            {
                charController = target.GetComponent<CharacterController>();
            }
            else
                Debug.Log("Camera target needs a character controller.");
        }
        else
            Debug.Log("Your camera needs a target.");
    }

    private void LateUpdate()
    {
        MoveToTarget();
        LookAtTarget();
    }

    void MoveToTarget()
    {
        Vector3 destination = charController.TargetRotation * offsetFromTarget;
        destination += target.position;
        transform.position = destination;
    }

    void LookAtTarget()
    {
        float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x , eulerYAngle, 0);
    }

    // Update is called once per frame
    void Update () {
	}
}
