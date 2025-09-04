using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private void OnEnable()
    {
        _raycaster.ItemHit += OnItemHit;
    }

    private void OnDisable()
    {
        _raycaster.ItemHit -= OnItemHit;
    }

    private void OnItemHit(Crushable crushable)
    {
        if (crushable.CanFragmentate)
        {
            List<Crushable> parts = _spawner.GetNewItemsList(crushable);

            _exploder.UseForceForParts(parts, crushable.transform.position, crushable.transform.localScale.x);
        }
        else
        {
            _exploder.Exploide(targetTransform);
        }

		_spawner.DestroyOblect(crushable);
    }
}
