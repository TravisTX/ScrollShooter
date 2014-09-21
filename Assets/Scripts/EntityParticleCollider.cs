using UnityEngine;
using System.Collections;

// Particles can't trigger OnParticleCollision on a 2d collider.  So the entity has this 3d collider, which just pushes the event up the stack
public class EntityParticleCollider : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        this.gameObject.GetComponentInParent<EntityBase>().OnParticleCollision(other);
    }

}
