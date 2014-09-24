using UnityEngine;
using System.Collections;
using System.Linq;

public class Hero : EntityBase
{
    public static Hero Instance
    {
        get
        {
            return _instance;
        }
    }
    private static Hero _instance;

    private float _speed = 5.0f;
    private int _weaponId = 0;

    void Awake()
    {
        _instance = this;
        this.Health = 1;
        _weaponId = 0;
        UpgradeWeapon();
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

    public override void Die()
    {
        GameManager.Instance.ChangeState(GameManager.GameStates.RecapScreen);
    }

    public void UpgradeWeapon()
    {
        _weaponId++;
        transform.FindChild("Weapon1").GetComponentInChildren<ParticleSystem>().Stop();
        transform.FindChild("Weapon2").GetComponentInChildren<ParticleSystem>().Stop();

        Transform weaponTransform = null;

        if (_weaponId == 1)
        {
            weaponTransform = transform.FindChild("Weapon1");
        }
        if (_weaponId == 2)
        {
            weaponTransform = transform.FindChild("Weapon2");
        }



        foreach (var pe in weaponTransform.GetComponentsInChildren<ParticleSystem>())
        {
            pe.Play();
        }
    }
}
