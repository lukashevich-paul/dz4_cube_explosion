using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const int Number0 = 0;

    public event Action<Vector3> OnMouseDown;

    private void Update()
    {
        if (Input.GetMouseButtonDown(Number0))
        {
            OnMouseDown?.Invoke(Input.mousePosition);
        }
    }
}
