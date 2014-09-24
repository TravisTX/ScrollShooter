using UnityEngine;
using System.Collections;

public class LootBase : MonoBehaviour
{
    [HideInInspector]
    public bool IsActive = false;
    private float _speed = 1f;


    void Update()
    {
        if (!IsActive)
            return;

        this.transform.position = new Vector3(transform.position.x, transform.position.y - _speed * Time.deltaTime, transform.position.z);
    }

    public virtual void Activate()
    {
        transform.parent = null;
        IsActive = true;
    }

}
