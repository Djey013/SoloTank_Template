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
    
        if (Input.GetMouseButtonDown(0))            //tir bullet avec LMB
        {
            Fire();
            Debug.Log("Fire !");
        }
       
        GetMouseDirection();            //deplace la tourelle avec les mouvements de la souris
        
    }
    
    
    public void Fire()
    {
        GameObject newBullet = Instantiate<GameObject>(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletVelocity);
    }

    
    private void GetMouseDirection()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            headTransform.transform.LookAt(hit.point);
            
        }
        
        
    }
    
    
    
}



/*

-----------------------------------------------------------------------------------------------
syntaxe Raycast
----------------------------------------------------------------------------------------------
void Update()
    {
        int laserSize = 10;
        RaycastHit Hit;
        Debug.DrawRay(transform.position, -Vector3.forward * laserSize, Color.red);

        if (Physics.Raycast(transform.position, -Vector3.forward, out Hit, laserSize))
        {
            Debug.Log("Alert !!!!!!!!!!");
        }

    }


-----------------------------------------------------------------------------------------------
input mouse button
----------------------------------------------------------------------------------------------
if (Input.GetMouseButtonDown(1))
    {
        Debug.Log("Pressed secondary button");
    }  

if (Input.GetMouseButtonDown(2))
    {
        Debug.Log("Pressed middle click.");
    }  


----------------------------------------------------------------------------------------------
Visee avec la souris
----------------------------------------------------------------------------------------------
if (Input.GetAxis("Mouse X") > 0)            //
        {
            Debug.Log("View rotating to the right");
        }

if (Input.GetAxis("Mouse X") < 0)            //
        {
            Debug.Log("View rotating to the left");
        }

if (Input.GetAxis("Mouse Y") > 0)            //
        {
            Debug.Log("View rotating to the top");
        }

if (Input.GetAxis("Mouse Y") < 0)            //
        {
            Debug.Log("View rotating to the bottom");
        }


*/