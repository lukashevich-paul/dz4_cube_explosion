using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Crushable : MonoBehaviour
{
    public const float RandomMinChanse = 0f;
    public const float RandomMaxChanse = 1f;
    public const float ChanceReducer = 2f;

    [field: SerializeField, Range(RandomMinChanse, RandomMaxChanse)] public float ChanceOfFragmentation { get; private set; }

    public void ReduceChance()
    {
        ChanceOfFragmentation /= ChanceReducer;
    }

    public bool IsFragmentation()
    {
        return ChanceOfFragmentation >= Random.Range(RandomMinChanse, RandomMaxChanse);
    }
}
