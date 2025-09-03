using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private const string Walls = "Walls";

    [SerializeField] private float _checkDistance;
    [SerializeField] private InputHandler _inputHandler;

    public event Action<Crushable> OnItemHit;

    private void OnEnable()
    {
        _inputHandler.OnMouseDown += GetObject;
    }

    private void OnDisable()
    {
        _inputHandler.OnMouseDown -= GetObject;
    }

    private void GetObject(Vector3 mousePosition)
    {
        int layerToIgnore = LayerMask.GetMask(Walls);
        int maskToUse = ~layerToIgnore;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        Physics.Raycast(ray, out RaycastHit hit, _checkDistance, maskToUse);

        if (hit.collider == null || hit.collider.TryGetComponent(out Crushable crushable) == false)
            return;

        OnItemHit?.Invoke(crushable);
    }
}
