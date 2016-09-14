using UnityEngine;
using System.Collections;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    GameObject fpCamera;
    [SerializeField]
    CrossHairUI cui;
    float xMouse;
    float yMouse;
    float xEul;
    float yEul;
    float zEul;
    Options opt;
    Transform player;
    Quaternion playerQ;
    Quaternion fpCameraQ;

    void Start()
    {
        opt = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Options>();
        player = GetComponent<Transform>();
        playerQ = player.transform.localRotation;
        fpCameraQ = fpCamera.transform.localRotation;
    }

    void Update()
    {
        if (!cui.GetFreeze())
        {
            LookRotation();
        }
    }

    public void LookRotation()
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
}