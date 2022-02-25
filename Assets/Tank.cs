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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 direction = new Vector3(hit.point.x, headTransform.position.y, hit.point.z);
            headTransform.LookAt(direction);
            
            headTransform.LookAt(new Vector3(hit.point.x, headTransform.position.y, hit.point.z));
            
        }
        
        
    }
    
    
    
}



/*

-----------------------------------------------------------------------------------------------
test pour raycast - origine : doc unity
----------------------------------------------------------------------------------------------

// Apply a force to a rigidbody in the Scene at the point
    // where it is clicked.

    // The force with which the target is "poked" when hit.
    float pokeForce;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForceAtPosition(ray.direction * pokeForce, hit.point);
                }
            }
        }
    }


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