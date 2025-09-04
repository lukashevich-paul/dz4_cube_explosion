using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private const string Walls = "Walls";

    [SerializeField] private float _checkDistance;
    [SerializeField] private InputReader _inputReader;

    public event Action<Crushable> OnItemHit;

    private void OnEnable()
    {
        _inputReader.OnMouseDown += GetObject;
    }

    private void OnDisable()
    {
        _inputReader.OnMouseDown -= GetObject;
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
