using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RadialMenu : MonoBehaviour
{
    [SerializeField]
    Image Rad;
    bool active;
    bool ready;
    bool lockOn;
    bool canExit;
    Ray ray;
    RaycastHit hit;

    void Start()
    {
        active = false;
        ready = true;
        lockOn = false;
        canExit = false;
    }

    void Update()
    {
        Menu();
    }
    
    void Menu()
    {
        if ((Input.GetKey(KeyCode.Tab) && Input.GetMouseButton(1) && ready) || lockOn)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            if (Vector3.Distance(hit.point, transform.position) < 4.0f)
            {
                if (hit.transform.GetComponent<BaseBlock>() != null)
                {
                    Rad.gameObject.SetActive(true);
                    active = true;
                    CrossHairUI.MouseUnlock();
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Tab) || Input.GetMouseButtonUp(1))
        {
            Exit();
        }

        if (!Input.GetKey(KeyCode.Tab) && !Input.GetMouseButton(1) && !ready)
        {
            ready = true;
        }
    }

    public void SetCanExit()
    {
        canExit = true;
    }

    public void Exit()
    {
        if (canExit)
        {
            Rad.gameObject.SetActive(false);
            active = false;
            ready = false;
            lockOn = false;
            canExit = false;
            CrossHairUI.MouseLock();
        }
    }
}