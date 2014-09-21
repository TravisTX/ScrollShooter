using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private int Health = 10;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnParticleCollision(GameObject other)
    {
        Debug.Log("Partical collision");
        StartCoroutine(FlashSprites(GetComponentsInChildren<SpriteRenderer>(), 1, .1f, false));
        if (Health-- <= 0)
        {
            Destroy(this.gameObject);
        }
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
                    // for changing the alpha
                    sprites[i].renderer.material.color = Color.white;
                }
            }

            // delay specified amount
            yield return new WaitForSeconds(delay);
        }
    }
 

}
