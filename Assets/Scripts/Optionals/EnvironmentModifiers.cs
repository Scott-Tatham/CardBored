using UnityEngine;
using System.Collections;

public class EnvironmentModifiers : MonoBehaviour
{
    private float gravity;

    public float GetGravity() { return gravity; }

    public void SetGravity(float _gravity) { gravity = _gravity; }

    void Awake()
    {
        SetGravity(-15.0f);
    }
}