using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothValue;
    private Vector3 _distance;

    private void Start()
    {
        _distance = target.position - transform.position;
    }

    private void Update()
    {
        if (target.position.y >= 0)
        {
            Follow();
        }        
    }

    private void Follow()
    {
        var currentPos = transform.position;
        var targetPos = target.position - _distance;
        
        transform.position = Vector3.Lerp(currentPos, targetPos, smoothValue * Time.deltaTime);
    }
}
