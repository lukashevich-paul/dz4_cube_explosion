using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _rotationSpeed = 100f;
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        _inputReader.Move += OnMove;
        _inputReader.Rotate += OnRotate;
    }

    private void OnDisable()
    {
        _inputReader.Move -= OnMove;
        _inputReader.Rotate -= OnRotate;
    }

    private void OnMove(float distance)
    {
        transform.Translate(_speed * Time.deltaTime * distance * Vector3.forward);
    }

    private void OnRotate(float distance)
    {
        transform.Rotate(_rotationSpeed * Time.deltaTime * distance * Vector3.up);
    }
}
