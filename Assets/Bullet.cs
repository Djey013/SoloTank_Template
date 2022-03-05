using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : BaseController
{
    
    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Debug.Log("[TOURELLE] : Tank neutralisé !");
        }
        
        if (other.gameObject.CompareTag("Turret"))
        {
            Destroy(other.gameObject);
            Debug.Log("[TANK] : Tourelle détruite !");
            
        }
    } 
    

    
}


