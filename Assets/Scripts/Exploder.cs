using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 1000f;

    public void UseForceForParts(List<Rigidbody> parts, Vector3 position, float radius)
    {
        foreach (Rigidbody item in parts)
        {
            item.AddExplosionForce(_explosionForce, position, radius);
        }
    }
}
