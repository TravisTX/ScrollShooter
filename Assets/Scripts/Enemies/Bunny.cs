using UnityEngine;
using System.Collections;

public class Bunny : EnemyBase
{
    private Vector3 _currentDestination;
    private bool _currentDestinationLeft = true;
    private float _speed = 2.0f;

    void Awake()
    {
        this.Health = 2;
    }

    void Start()
    {
        _currentDestination = transform.position;
    }

    void Update()
    {
        Debug.DrawLine(transform.position, _currentDestination, Color.white);

        Vector3 directionOfTravel = _currentDestination - transform.position;
        //now normalize the direction, since we only want the direction information
        directionOfTravel.Normalize();
        //scale the movement on each axis by the directionOfTravel vector components

        this.transform.Translate(
            (directionOfTravel.x * _speed * Time.deltaTime),
            (directionOfTravel.y * _speed * Time.deltaTime),
            (directionOfTravel.z * _speed * Time.deltaTime),
            Space.World);


        //transform.position = Vector3.Lerp(transform.position, _currentDestination, _speed * Time.deltaTime);
        if ((_currentDestination - transform.position).magnitude < 0.1f)
        {
            // we have arrived
            GetNextDestination();
        }
    }

    private void GetNextDestination()
    {
        _currentDestinationLeft = !_currentDestinationLeft;
        _currentDestination = new Vector3(_currentDestinationLeft ? -2.0f : 2.0f, _currentDestination.y - 1.0f, _currentDestination.z); 
    }

    public override void Die()
    {
        base.Die();
        Destroy(this.gameObject);
    }    

}
