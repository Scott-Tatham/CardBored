using UnityEngine;
using System.Collections;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    private GameObject fpCamera;
    private float xMouse;
    private float yMouse;
    private float xEul;
    private float yEul;
    private float zEul;
    private Options opt;
    private Transform player;
    private Quaternion playerQ;
    private Quaternion fpCameraQ;

    void Start()
    {
        opt = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Options>();

        player = GetComponent<Transform>();

        playerQ = player.transform.localRotation;
        fpCameraQ = fpCamera.transform.localRotation;

        MouseLock();
    }

    void Update()
    {
        lookRotation();
        SetMouseLock();
    }

    public void lookRotation()
    {
        xMouse = Input.GetAxis("Mouse X") * opt.GetXSens();
        yMouse = Input.GetAxis("Mouse Y") * opt.GetYSens();

        playerQ = playerQ * Quaternion.Euler(0, xMouse, 0);
        fpCameraQ = fpCameraQ * Quaternion.Euler(-yMouse, 0, 0);

        xEul = fpCameraQ.eulerAngles.x;
        yEul = fpCameraQ.eulerAngles.y;
        zEul = fpCameraQ.eulerAngles.z;

        if (xEul < 180.0f)
        {
            xEul = Mathf.Clamp(xEul, 0, 60);
        }

        else if (xEul > 180.0f)
        {
            xEul = Mathf.Clamp(xEul, 300, 360);
        }

        fpCameraQ.eulerAngles = new Vector3(xEul, yEul, zEul);

        player.localRotation = playerQ;
        fpCamera.transform.localRotation = fpCameraQ;
    }

    public void MouseLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SetMouseLock()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            MouseLock();
        }
    }
}