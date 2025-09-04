using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private readonly string Horizontal = "Horizontal";
    private readonly string Vertical = "Vertical";

    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _rotationSpeed = 100f;

    private void Update()
    {
        Vector3 direction = Input.GetAxis(Vertical) * Vector3.forward;
        Vector3 rotation = new Vector3(0f, Input.GetAxis(Horizontal), 0f);

        transform.Translate(_speed * Time.deltaTime * direction);
        transform.Rotate(_rotationSpeed * Time.deltaTime * rotation);
    }
}
