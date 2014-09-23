using UnityEngine;
using System.Collections;

public class EnemySquad : MonoBehaviour
{
    public void Activate()
    {
        // loop through child enemies, and call Activate
        var enemies = GetComponentsInChildren<EnemyBase>();
        foreach (var enemy in enemies)
        {
            enemy.Activate();
        }
    }
}
