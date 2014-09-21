using UnityEngine;
using System.Collections;

public class EntityBase : MonoBehaviour
{
    protected int Health = 1;

    // bubbled up from ParticleCollider
    public void OnParticleCollision(GameObject other)
    {
        StartCoroutine(FlashSprites(GetComponentsInChildren<SpriteRenderer>(), 1, .1f, false));
        var oldHealth = Health;
        if (--Health <= 0)
        {
            Die();
        }
        Debug.Log("Hit.  OldHealth: " + oldHealth + " NewHealth: " + Health);
    }

    public virtual void Die()
    {
        Debug.Log("EntityBase Die");
    }

    /**
     * Coroutine to create a flash effect on all sprite renderers passed in to the function.
     *
     * @param sprites   a sprite renderer array
     * @param numTimes  how many times to flash
     * @param delay     how long in between each flash
     * @param disable   if you want to disable the renderer instead of change alpha
     */
    IEnumerator FlashSprites(SpriteRenderer[] sprites, int numTimes, float delay, bool disable = false)
    {
        // number of times to loop
        for (int loop = 0; loop < numTimes; loop++)
        {
            // cycle through all sprites
            for (int i = 0; i < sprites.Length; i++)
            {
                if (disable)
                {
                    // for disabling
                    sprites[i].enabled = false;
                }
                else
                {
                    sprites[i].renderer.material.color = Color.red;
                }
            }

            // delay specified amount
            yield return new WaitForSeconds(delay);

            // cycle through all sprites
            for (int i = 0; i < sprites.Length; i++)
            {
                if (disable)
                {
                    // for disabling
                    sprites[i].enabled = true;
                }
                else
                {
                    sprites[i].renderer.material.color = Color.white;
                }
            }

            // delay specified amount
            yield return new WaitForSeconds(delay);
        }
    }
}
