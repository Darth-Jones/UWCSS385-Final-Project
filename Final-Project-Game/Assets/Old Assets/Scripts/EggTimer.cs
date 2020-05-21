using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggTimer : MonoBehaviour
{
    public float eggExperation = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Destroies the egg after one second
        Destroy(gameObject, eggExperation);
    }

    void update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Wall"))
        {
            //Destroies the egg on collision with walls
            Destroy(gameObject);
        }
        else if ( collision.gameObject.name.Contains("Walk") || 
                    collision.gameObject.name.Contains("nemy") ) 
        {
            Destroy(gameObject);
            Health eHealth = collision.gameObject.GetComponent<Health>();
            eHealth.updateHealth();
        }

        
    }
}
