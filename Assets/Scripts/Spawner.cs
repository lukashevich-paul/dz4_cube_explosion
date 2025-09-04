using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public const float ScaleReducer = 2f;

    [SerializeField, Min(0)] public int _minCopyCount = 2;
    [SerializeField, Min(0)] public int _maxCopyCount = 7;
    [SerializeField] private Raycaster _raycaster;

    private void OnEnable()
    {
        _raycaster.OnItemHit += DestroyOblect;
    }

    private void OnDisable()
    {
        _raycaster.OnItemHit -= DestroyOblect;
    }

    private void OnValidate()
    {
        if (_minCopyCount >= _maxCopyCount)
            _maxCopyCount = _minCopyCount + 1;
    }

    public List<Rigidbody> GetNewItemsList(Crushable crushable)
    {
        List<Rigidbody> list = new();
        Transform targetTransform = crushable.transform;
        Vector3 scale = targetTransform.localScale / ScaleReducer;

        for (int i = 0; i < Random.Range(_minCopyCount, _maxCopyCount); i++)
        {
            Vector3 subPosition = targetTransform.position + Random.onUnitSphere * scale.x;
            Crushable newItem = Instantiate(crushable, subPosition, targetTransform.rotation);
            newItem.transform.localScale = scale;

            if (newItem.TryGetComponent(out Rigidbody rigidbody))
                list.Add(rigidbody);
        }

        return list;
    }

    public void DestroyOblect(Crushable crushable)
    {
        Destroy(crushable.gameObject);
    }
}
