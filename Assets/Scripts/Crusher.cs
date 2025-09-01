using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    public const int MinCubeCount = 2;
    public const int MaxCubeCount = 7;
    public const float RandomMinChanse = 0f;
    public const float RandomMaxChanse = 1f;
    public const float ScaleReducer = 2f;

    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] float _explosionForce = 1000f;

    private void Start()
    {
        Renderer objectRenderer = GetComponent<Renderer>();
        objectRenderer.material.color = Random.ColorHSV();
    }

    private void OnMouseDown()
    {
        Vector3 position = transform.position;
        Vector3 scale = transform.localScale / ScaleReducer;
        Quaternion rotation = transform.rotation;
        float chanse = transform.localScale.x;

        List<Rigidbody> Cubes = new List<Rigidbody>();

        if (chanse >= Random.Range(RandomMinChanse, RandomMaxChanse))
        {
            for (var i = 0; i <= Random.Range(MinCubeCount, MaxCubeCount); i++)
            {
                Vector3 subPosition = position - Random.onUnitSphere * scale.x;

                GameObject newCube = CreateCube(subPosition, scale, rotation);
                Cubes.Add(newCube.GetComponent<Rigidbody>());
            }

            foreach (Rigidbody item in Cubes)
            {
                item.AddExplosionForce(_explosionForce, position, scale.x);
            }
        }

        Destroy(gameObject);
    }

    private GameObject CreateCube(Vector3 position, Vector3 scale, Quaternion rotation)
    {
        GameObject newCube = Instantiate(_cubePrefab, position, rotation);
        newCube.transform.localScale = scale;
        newCube.GetComponent<Crusher>().SetCubePrefab(_cubePrefab);

        return newCube;
    }

    public void SetCubePrefab(GameObject prefab)
    {
        _cubePrefab = prefab;
    }
}
