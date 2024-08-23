using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMenRoll : MonoBehaviour
{
    public int count = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {

            AudioManager.instance.PlayOneShot(FMODEvents.instance.snowRoll, this.transform.position);
            Debug.Log("SOUND");
        }
        if(collision.gameObject.CompareTag("Ground"))
        {
            count++;
            if(count<2)
            {
                AudioManager.instance.PlayOneShot(FMODEvents.instance.snowRoll, this.transform.position);
                Debug.Log("hit once");
            }
        }
        
    }
}
