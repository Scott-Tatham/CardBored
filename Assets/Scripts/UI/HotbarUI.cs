using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HotbarUI : MonoBehaviour
{
    [SerializeField]
    Image[] blocks;
    [SerializeField]
    Image selectBox;
    Vector3 pos;

    void Start()
    {
        pos = selectBox.transform.position;
    }

    public void SetBox(int _index)
    {
        switch (_index)
        {
            case 0:
                pos.x = blocks[0].transform.position.x - 5; // Dunno why 5. Perhaps (selectBox.transform.position.x / 2) - (blocks[0].transform.position.x / 2)?
                selectBox.transform.position = new Vector3(pos.x, selectBox.transform.position.y, selectBox.transform.position.z);
                break;

            case 1:
                pos.x = blocks[1].transform.position.x - 5;
                selectBox.transform.position = new Vector3(pos.x, selectBox.transform.position.y, selectBox.transform.position.z);
                break;

            case 2:
                pos.x = blocks[2].transform.position.x - 5;
                selectBox.transform.position = new Vector3(pos.x, selectBox.transform.position.y, selectBox.transform.position.z);
                break;

            case 3:
                pos.x = blocks[3].transform.position.x - 5;
                selectBox.transform.position = new Vector3(pos.x, selectBox.transform.position.y, selectBox.transform.position.z);
                break;

            case 4:
                pos.x = blocks[4].transform.position.x - 5;
                selectBox.transform.position = new Vector3(pos.x, selectBox.transform.position.y, selectBox.transform.position.z);
                break;

            case 5:
                pos.x = blocks[5].transform.position.x - 5;
                selectBox.transform.position = new Vector3(pos.x, selectBox.transform.position.y, selectBox.transform.position.z);
                break;

            case 6:
                pos.x = blocks[6].transform.position.x - 5;
                selectBox.transform.position = new Vector3(pos.x, selectBox.transform.position.y, selectBox.transform.position.z);
                break;

            case 7:
                pos.x = blocks[7].transform.position.x - 5;
                selectBox.transform.position = new Vector3(pos.x, selectBox.transform.position.y, selectBox.transform.position.z);
                break;

            case 8:
                pos.x = blocks[8].transform.position.x - 5;
                selectBox.transform.position = new Vector3(pos.x, selectBox.transform.position.y, selectBox.transform.position.z);
                break;
        }
    }
}