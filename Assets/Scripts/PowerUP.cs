using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{
    public static float upStrength = 10f;

    public void OnTriggerEnter(Collider other) 
    {
        if(other.GetComponent<Player>())
        {
            Player.powerUpON = true;           
            Destroy(gameObject);      
            //Debug.Log("This is Player!!!");
        }
    }
}
