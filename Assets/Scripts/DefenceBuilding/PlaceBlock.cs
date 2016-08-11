using UnityEngine;
using System.Collections;

public class PlaceBlock : MonoBehaviour
{
    [SerializeField]
    private Bounds[] allBounds;
    private Ray ray;
    private RaycastHit hit;
    private GameObject currentBlock;

    void Update()
    {
        PlacePoint();
    }

    void PlacePoint()
    {
        if (currentBlock != null && Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            hit.point = new Vector3(Mathf.RoundToInt(hit.point.x), Mathf.RoundToInt(hit.point.x), Mathf.RoundToInt(hit.point.x));

            foreach (Bounds b in allBounds)
            {
                if (b.Contains(hit.point))
                {
                    GameObject block = Instantiate(currentBlock, hit.point, Quaternion.identity) as GameObject;
                }
            }
        }
    }
}