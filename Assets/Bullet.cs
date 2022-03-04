using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : BaseController
{
    public GameObject messageDestruction;

    
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
            StartCoroutine(MessageDestruction());
        }
    }

    IEnumerator MessageDestruction()
    {
        messageDestruction.SetActive(true);
        yield return new WaitForSeconds(2);
        messageDestruction.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if()
    }
}


