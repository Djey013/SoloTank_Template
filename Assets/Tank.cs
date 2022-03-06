using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : BaseController
{
    public float speedMoves = 0;
    public float speedRotation = 0;
    
    public Rigidbody rb;
    public float bulletVelocity = 0;

   
    void Update()
    {
        float direction = Input.GetAxis("Vertical") * speedMoves;            //controle du tank
        transform.Translate(0f,0f,direction*Time.deltaTime,Space.Self);
        
        float rotation = Input.GetAxis("Horizontal") * speedRotation;
        transform.Rotate(0, rotation, 0);
        
        GetMouseDirection();            //deplace la tourelle avec les mouvements de la souris
        
        if (Input.GetMouseButtonDown(0))     //tir bullet avec LMB
        {
            Fire();
        }
        
    }
    
    
    public void Fire()
    {
        GameObject newBullet = Instantiate<GameObject>(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().AddForce(headTransform.forward * bulletVelocity);
        
    }

    
    private void GetMouseDirection()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //point d'écran de la caméra principale (vers position du curseur souris)
        
        if (Physics.Raycast(ray, out hit)) //hit recupere tout ce que le raycast touche
        {
            Vector3 direction = new Vector3(hit.point.x, headTransform.position.y, hit.point.z);
            headTransform.LookAt(direction);
            
            headTransform.LookAt(new Vector3(hit.point.x, headTransform.position.y, hit.point.z));
          
        }
        
    }
    
    
    
    
}



/*

1. destruction des turret
2. message de destrcution
3. interface 
4. autolock //avec lookat


*/