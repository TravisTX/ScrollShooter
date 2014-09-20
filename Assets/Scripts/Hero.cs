using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour
{
    private float _speed = 5.0f;

    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {
        if (InputManager.Instance.Touching())
        {
            Vector2 touchPosition = InputManager.Instance.GetTouch();
            Vector3 touchWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 0));

            var currentDestination = new Vector3(touchWorldPoint.x, touchWorldPoint.y, transform.position.z);
            Debug.DrawLine(transform.position, currentDestination, Color.white);
            transform.position = Vector3.Lerp(transform.position, currentDestination, _speed * Time.deltaTime);
            //transform.forward = currentDestination - transform.position;
            //transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }
}
