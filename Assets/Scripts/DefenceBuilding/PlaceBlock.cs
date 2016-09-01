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
                if (Vector3.Distance(hit.point, transform.position) < 4.0f)
                {
                    Vector3 placePos;

                    if (hit.transform.tag == "Base")
                    {
                        placePos = new Vector3(hit.transform.position.x, hit.transform.position.y + 0.5f, hit.transform.position.z);
                    }

                    else
                    {
                        placePos = hit.transform.position + hit.normal;
                    }

                    foreach (GameObject go in allBounds)
                    {
                        // Get placement area transform's bounds and determine the Build Zone's location. Encapsulation?
                        if (go.GetComponent<BoxCollider>().bounds.Contains(placePos))
                        {
                            int x, y, z;
                            GameObject block = Instantiate(currentBlock, placePos, Quaternion.identity) as GameObject;

                            if ((placePos.x - 0.5f) % 2 == 1)
                            {
                                x = Mathf.RoundToInt(placePos.x - go.transform.position.x) - 1;
                            }

                            else
                            {
                                x = Mathf.RoundToInt(placePos.x - go.transform.position.x);
                            }

                            if ((placePos.y - 0.5f) % 2 == 1)
                            {
                                y = Mathf.RoundToInt(placePos.y - go.transform.position.y) - 1;
                            }

                            else
                            {
                                y = Mathf.RoundToInt(placePos.y - go.transform.position.y);
                            }

                            if ((placePos.z - 0.5f) % 2 == 1)
                            {
                                z = Mathf.RoundToInt(placePos.z - go.transform.position.z) - 1;
                            }

                            else
                            {
                                z = Mathf.RoundToInt(placePos.z - go.transform.position.z);
                            }

                            block.GetComponent<BaseBlock>().SetBZSpace(x, y, z);
                            block.GetComponent<BaseBlock>().SetBounds(go.GetComponent<BoundingBox>());
                            Debug.Log(block.GetComponent<BaseBlock>().GetBZSpace().GetBZSpace());
                            go.GetComponent<BoundingBox>().AddBlock(block.GetComponent<BaseBlock>());
                        }
                    }
                }
            }
        }
    }
}