using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 1000f;

    public void UseForceForParts(List<Crushable> parts, Vector3 position, float radius)
    {
        foreach (Crushable item in parts)
        {
            if (item.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(_explosionForce, position, radius);
        }
    }
}
