using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int ButtonNumber = 0;

    public event Action<Vector3> OnMouseDown;

    private void Update()
    {
        if (Input.GetMouseButtonDown(ButtonNumber))
        {
            OnMouseDown?.Invoke(Input.mousePosition);
        }
    }
}
