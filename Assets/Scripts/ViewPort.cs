using UnityEngine;
using System.Collections;

public class ViewPort : MonoBehaviour
{
    public static ViewPort Instance
    {
        get
        {
            return _instance;
        }
    }
    private static ViewPort _instance;

    public BoxCollider2D ViewPortCollider2D;

    void Awake()
    {
        _instance = this;
        ViewPortCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemySquad>().Activate();
        }
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyBase>().Activate();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }

}
