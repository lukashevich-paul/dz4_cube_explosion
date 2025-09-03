using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
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

            Transform targetTransform = crushable.transform;
            List<Rigidbody> Parts = _spawner.GetNewItemsList(targetTransform);

            _exploder.UseForceForParts(Parts, targetTransform.position, targetTransform.localScale.x / 2);
        }

        Destroy(crushable.gameObject);
    }
}
