using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] float _explosionForce = 20f;
    [SerializeField, Min(0)] float _basicExplosionRadius = 2f;
    [SerializeField] GameObject _effect;
    [SerializeField, Min(0)] float _effectLifeTime = 0.5f;

    public void UseForceForParts(List<Crushable> parts, Vector3 position, float radius)
    {
        foreach (Crushable item in parts)
        {
            if (item.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(_explosionForce, position, radius);
        }
    }

    public void Exploide(Transform transform)
    {
        Vector3 position = transform.position;
        Vector3 scale = transform.localScale;

        float IncreasingFactor = 1 / scale.x;
        float radius = _basicExplosionRadius * IncreasingFactor;

        Collider[] parts = Physics.OverlapSphere(position, radius);

        foreach (var item in parts)
        {
            if (item.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(_explosionForce * IncreasingFactor, position, radius);
        }

        _effect.transform.localScale = Vector3.one * radius;

        GameObject effect = Instantiate(_effect, position, transform.rotation);
        Destroy(effect, _effectLifeTime);
    }
}
