using System;
using Unity.VisualScripting;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private const string Walls = "Walls";

    [SerializeField] private float _checkDistance;
    [SerializeField] private InputReader _inputReader;

    public event Action<Crushable> ItemHit;

    private void OnEnable()
    {
        _inputReader.SendRay += OnSendRay;
    }

    private void OnDisable()
    {
        _inputReader.SendRay -= OnSendRay;
    }

    private void OnSendRay(Vector3 mousePosition)
    {
        int layerToIgnore = LayerMask.GetMask(Walls);
        int maskToUse = ~layerToIgnore;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _checkDistance, maskToUse))
        {
            if (hit.collider != null && hit.collider.TryGetComponent(out Crushable crushable) == true)
                ItemHit?.Invoke(crushable);
        }
    }
}
