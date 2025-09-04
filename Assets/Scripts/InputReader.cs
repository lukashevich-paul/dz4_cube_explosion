using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private readonly string Horizontal = "Horizontal";
    private readonly string Vertical = "Vertical";
    private readonly int SendRayButton = 0;

    public event Action<Vector3> SendRay;
    public event Action<float> Move;
    public event Action<float> Rotate;

    private void Update()
    {
        if (Input.GetMouseButtonDown(SendRayButton))
            SendRay?.Invoke(Input.mousePosition);
    }

    private void LateUpdate()
    {
        float verticalOffset = Input.GetAxis(Vertical);
        float horisontalOffset = Input.GetAxis(Horizontal);

        if (verticalOffset != 0)
            Move?.Invoke(verticalOffset);

        if (horisontalOffset != 0)
            Rotate?.Invoke(horisontalOffset);
    }
}
