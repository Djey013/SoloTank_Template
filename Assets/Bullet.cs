using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BaseController
{
    
     
    //public Rigidbody rb;
    public GameObject bulletApparition;
    public GameObject bulletPosition;

    //public float bulletVelocity;

    
    public void Fire()
    {
        
        Instantiate<GameObject>(bulletApparition, bulletPosition.transform);
        //rb.AddForce(0,0,bulletVelocity);
        
    }
    
    
}


/* TENTATIVE : interagir avec les bullet instanciées
 
 public void Fire()
 {
   bulletPosition = new Vector3();
   GameObject newBullet = Instantiate(bulletApparition, new Vector3(bulletPosition), Quaternion.identity);
   rb.AddForce(0,0,bulletVelocity);
 }

*/