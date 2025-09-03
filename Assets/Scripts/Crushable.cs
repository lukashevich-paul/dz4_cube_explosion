using UnityEngine;

public class Crushable : MonoBehaviour
{
    public const float RandomMinChanse = 0f;
    public const float RandomMaxChanse = 1f;
    public const float ChanceReducer = 2f;

    private Rigidbody _rigidbody;

    [field: SerializeField, Range(RandomMinChanse, RandomMaxChanse)] public float ChanceOfFragmentation { get; private set; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (_rigidbody == null)
        {
            _rigidbody = gameObject.AddComponent<Rigidbody>();
        }
    }

    private void Update() {
        if (transform.position.y < -500) {
            Destroy(gameObject);
        }
    }

    public void ReduceChance()
    {
        ChanceOfFragmentation /= ChanceReducer;
    }

    public bool IsFragmentation()
    {
        return ChanceOfFragmentation >= Random.Range(RandomMinChanse, RandomMaxChanse);
    }
}
