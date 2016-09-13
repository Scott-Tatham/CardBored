using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RadialMenu : MonoBehaviour
{
    [SerializeField]
    Image Rad;
    Ray ray;
    RaycastHit hit;

    void Update()
    {
        Menu();
    }
    
    void Menu()
    {
        if (Input.GetKey(KeyCode.Tab) && Input.GetMouseButton(1))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            if (Vector3.Distance(hit.point, transform.position) < 4.0f)
            {
                if (hit.transform.GetComponent<BaseBlock>() != null)
                {
                    Rad.gameObject.SetActive(true);
                }
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            Rad.gameObject.SetActive(false);
        }
    }
}
