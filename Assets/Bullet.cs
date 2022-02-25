using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BaseController
{
    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}


