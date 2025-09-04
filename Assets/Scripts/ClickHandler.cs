using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private void OnEnable()
    {
        _raycaster.OnItemHit += MainProcess;
    }

    private void OnDisable()
    {
        _raycaster.OnItemHit -= MainProcess;
    }

    private void MainProcess(Crushable crushable)
    {
        if (crushable.IsFragmentation())
        {
            crushable.ReduceChance();

            List<Rigidbody> parts = _spawner.GetNewItemsList(crushable);

            _exploder.UseForceForParts(parts, crushable.transform.position, crushable.transform.localScale.x);
        }
    }
}
