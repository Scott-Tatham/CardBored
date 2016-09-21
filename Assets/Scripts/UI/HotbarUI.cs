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
        pos.x = blocks[_index].transform.position.x - 5;
        selectBox.transform.position = new Vector3(pos.x, selectBox.transform.position.y, selectBox.transform.position.z);
    }
}