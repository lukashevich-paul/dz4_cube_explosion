using System;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const int LeftMouseButtonNumber = 0;
    private const string Walls = "Walls";

    [SerializeField] private float _checkDistance;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private RaycastHit _hit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButtonNumber))
        {
            int layerToIgnore = LayerMask.GetMask(Walls);
            int maskToUse = ~layerToIgnore;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out _hit, _checkDistance, maskToUse);

            if (_hit.collider == null)
                return;

            GameObject target = _hit.collider.gameObject;

            if (!target.TryGetComponent<Crushable>(out Crushable crushable))
                return;

            if (crushable.IsFragmentation())
            {
                crushable.ReduceChance();

                Transform targetTransform = target.transform;
                List<Rigidbody> Parts = _spawner.GetNewItemsList(targetTransform);

                _exploder.UseForceForParts(Parts, targetTransform.position, targetTransform.localScale.x / 2);
            }

            Destroy(target);
        }
    }
}
