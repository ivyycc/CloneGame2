using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public static Vector3 lastCheckpointPos;

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
        if (collision.CompareTag("Player"))
        {
            // Update the last checkpoint position to this checkpoint's position
            lastCheckpointPos = transform.position;
            Debug.Log("Checkpoint reached at position: " + lastCheckpointPos);
        }
    }

    public void UpdatePos()
    {
        //If player dies/falls into void...
        //...check for old Pos and override that old Pos with checkPointPos
        //currentPos = newPos
    }
}
