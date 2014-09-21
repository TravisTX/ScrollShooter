using UnityEngine;
using System.Collections;

public class ParticleCollider : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        this.gameObject.GetComponentInParent<Enemy>().OnParticleCollision(other);
    }

}
