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
                            //if (go.GetComponent<BoundingBox>().CheckBlock(placePos))
                            {
                                GameObject block = Instantiate(currentBlock, placePos, Quaternion.identity) as GameObject;
                                
                                block.GetComponent<BaseBlock>().SetBZSpace(Mathf.RoundToInt(placePos.x - go.GetComponent<BoundingBox>().GetZeroPoint().x), Mathf.RoundToInt(placePos.y - go.GetComponent<BoundingBox>().GetZeroPoint().y), Mathf.RoundToInt(placePos.z - go.GetComponent<BoundingBox>().GetZeroPoint().z));
                                //Debug.Log(block.GetComponent<BaseBlock>().GetBZSpace().GetBZSpace());
                                go.GetComponent<BoundingBox>().AddBlock(block.GetComponent<BaseBlock>());
                                block.GetComponent<BaseBlock>().SetSide(hit.normal);

                                //Debug.Log(block.GetComponent<BaseBlock>().GetBZSpace().GetBZSpace());

                                if (block.tag != "StaticBlock" && hit.transform.tag != "Base")
                                {
                                    block.GetComponent<BaseBlock>().SetBlockParent(hit.transform);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}