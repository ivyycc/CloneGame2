using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("checkpoint hit");
            //check if died to respwan at checkpoint : collision.transform.position = this.transform.position; //respawn player at checkpoint
        }
    }

    public void UpdatePos()
    {
        //If player dies/falls into void...
        //...check for old Pos and override that old Pos with checkPointPos
        //currentPos = newPos
    }
}
