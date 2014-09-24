using UnityEngine;
using System.Collections;

public class ScrollSpawner : MonoBehaviour
{
    public static ScrollSpawner Instance
    {
        get
        {
            return _instance;
        }
    }
    private static ScrollSpawner _instance;

    private bool IsActive = true;
    private float _speed = 2.0f;

    void Start()
    {

    }

    void Update()
    {
        if (!IsActive)
            return;

        this.transform.position = new Vector3(transform.position.x, transform.position.y - _speed * Time.deltaTime, transform.position.z);

    }
}
