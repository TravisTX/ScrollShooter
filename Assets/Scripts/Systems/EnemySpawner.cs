using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance
    {
        get
        {
            return _instance;
        }
    }
    private static EnemySpawner _instance;


    private float _nextSpawnTime;
    private float _spawnFrequency = 1f;
    private Object _bunnyPrefab;

    void Awake()
    {
        _instance = this;
        _bunnyPrefab = Resources.Load("Prefabs/Bunny_Prefab");
    }

    void Update()
    {
        if (Time.time > _nextSpawnTime)
        {
            var go = (GameObject)UnityEngine.Object.Instantiate(_bunnyPrefab, new Vector3(-2, 5.5f, 0), new Quaternion(0, 0, 0, 0));
            _nextSpawnTime = Time.time + _spawnFrequency;
        }
    }
}
