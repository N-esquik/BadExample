using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speedMove;

    private int _currentWaypoints;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if(transform.position == _waypoints[_currentWaypoints].position)
        {
            _currentWaypoints = ++_currentWaypoints % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoints].position, _speedMove * Time.deltaTime);
    }
}
