using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaceBlock : MonoBehaviour
{
    [SerializeField]
    private GameObject currentBlock;
    private List<GameObject> allBounds = new List<GameObject>();
    private Ray ray;
    private RaycastHit hit;

    void Start()
    {
        allBounds.AddRange(GameObject.FindGameObjectsWithTag("BuildZone"));
    }

    void Update()
    {
        PlacePoint();
    }

    void PlacePoint()
    {
        if (currentBlock != null && Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 placePos = new Vector3(hit.transform.position.x, hit.transform.position.y + 1, hit.transform.position.z);

                foreach (GameObject go in allBounds)
                {
                    if (go.GetComponent<BoundingBox>().GetBuildZone().Contains(hit.point))
                    {
                        GameObject block = Instantiate(currentBlock, placePos, Quaternion.identity) as GameObject;
                    }
                }
            }
        }
    }
}