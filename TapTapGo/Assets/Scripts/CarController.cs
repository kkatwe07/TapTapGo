using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private bool _movingLeft = true;
    private bool _firstTap = true;

    private void Update()
    {
        if (GameManager.Instance.gameStarted)
        {
            Move();
            CheckInput();
        }

        if(transform.position.y <= -2f)
        {
            GameManager.Instance.GameOver();
        }
    }

    private void Move()
    {
        var transform1 = transform;
        transform1.position += transform1.forward * (speed * Time.deltaTime);
    }

    private void CheckInput()
    {
        if (_firstTap)
        {
            _firstTap = false;
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        if (_movingLeft) 
        {
            _movingLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            _movingLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
