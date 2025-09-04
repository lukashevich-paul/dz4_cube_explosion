using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Crushable : MonoBehaviour
{
    public const float RandomMinChanse = 0f;
    public const float RandomMaxChanse = 1f;

    [field: SerializeField, Range(RandomMinChanse, RandomMaxChanse)] public float ChanceOfFragmentation { get; private set; }

    public bool CanFragmentate { get; private set; }

    private void Start()
    {
        CanFragmentate = ChanceOfFragmentation >= Random.Range(RandomMinChanse, RandomMaxChanse);
    }

    public void Init(float newChance, Vector3 scale)
    {
        ChanceOfFragmentation = newChance;
        transform.localScale = scale;
    }
}
