using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public const float ScaleReducer = 2f;

    [SerializeField, Min(0)] public int _minCopyCount = 2;
    [SerializeField, Min(0)] public int _maxCopyCount = 7;

    private void OnValidate()
    {
        if (_minCopyCount >= _maxCopyCount)
            _maxCopyCount = _minCopyCount + 1;
    }

    public List<Rigidbody> GetNewItemsList(Transform targetTransform)
    {
        List<Rigidbody> list = new();
        Vector3 scale = targetTransform.localScale / ScaleReducer;

        for (int i = 0; i < Random.Range(_minCopyCount, _maxCopyCount); i++)
        {
            Vector3 subPosition = targetTransform.position + Random.onUnitSphere * scale.x / 2;
            Transform newItem = Instantiate(targetTransform, subPosition, targetTransform.rotation);
            newItem.transform.localScale = scale;

            if (newItem.TryGetComponent(out Rigidbody rb))
                list.Add(rb);
        }

        return list;
    }
}
