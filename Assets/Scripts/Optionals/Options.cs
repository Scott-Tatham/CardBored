using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Options : MonoBehaviour
{
    private float xSens;
    private float ySens;

    public float GetXSens() { return xSens; }
    public float GetYSens() { return ySens; }

    void Awake()
    {
            xSens = 2.0f;
            ySens = 2.0f;
    }
}