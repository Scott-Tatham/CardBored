using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaceBlock : MonoBehaviour
{
    [SerializeField]
    GameObject[] blocks;
    bool tabbed;
    int index;
    List<GameObject> allBounds = new List<GameObject>();
    Ray ray;
    RaycastHit hit;
    HotbarUI hb;

    void Awake()
    {
        hb = GameObject.FindGameObjectWithTag("UIManager").GetComponent<HotbarUI>();
    }

    void Start()
    {
        tabbed = false;
        index = 0;
        allBounds.AddRange(GameObject.FindGameObjectsWithTag("BuildZone"));
    }

    void Update()
    {
        BlockSelect();
        PlacePoint();
    }

    void BlockSelect()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            index = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            index = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            index = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            index = 3;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            index = 4;
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            index = 5;
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            index = 6;
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            index = 7;
        }

        if (Input.GetAxisRaw("ScrollWheel") < 0 || Input.GetKeyDown(KeyCode.M))
        {
            if (index == blocks.Length - 1)
            {
                index = 0;
            }

            else
            {
                index++;
            }
        }

        if (Input.GetAxisRaw("ScrollWheel") > 0 || Input.GetKeyDown(KeyCode.N))
        {
            if (index == 0)
            {
                index = blocks.Length - 1;
            }

            else
            {
                index--;
            }
        }

        hb.SetBox(index);
    }

    void PlacePoint()
    {
        if (blocks[index] != null && Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            if (Vector3.Distance(hit.point, transform.position) < 4.0f)
            {
                Vector3 placePos;
                if (hit.transform.tag != "BuildZone")
                {
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
                        if (go.GetComponent<BoxCollider>().bounds.Contains(placePos))
                        {
                            int x, y, z;
                            GameObject block = Instantiate(blocks[index], placePos, Quaternion.identity) as GameObject;

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
                            go.GetComponent<BoundingBox>().AddBlock(block.GetComponent<BaseBlock>());

                            if (block.tag == "VariableBlock" && hit.transform.tag == "VariableBlock")
                            {
                                block.GetComponent<Variable>().SetParent(hit.transform);
                            }
                        }
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(1) && !tabbed)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            if (Vector3.Distance(hit.point, transform.position) < 4.0f)
            {
                if (hit.transform.GetComponent<BaseBlock>() != null)
                {
                    hit.transform.GetComponent<BaseBlock>().RemoveBlock();
                    Destroy(hit.transform.gameObject);
                }
            }
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            tabbed = true;
        }

        else
        {
            tabbed = false;
        }
    }
}