using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : BaseController
{
    public Bullet _bullet;
    public float speed = 0;
    public float speedRotation = 0;
  

    void Update()
    {
        
        float direction = Input.GetAxis("Vertical") * speed;            //controle du tank
        transform.Translate(0f,0f,direction*Time.deltaTime,Space.Self);
        
        float rotation = Input.GetAxis("Horizontal") * speedRotation;
        transform.Rotate(0, rotation, 0);

        if (Input.GetAxis("Mouse X") > 0)            //
        {
            Debug.Log("Mous rotating in X axis");
        }


        if (Input.GetMouseButtonDown(0))            //tir bullet avec LMB
        {
            _bullet.Fire();
            Debug.Log("Fire !");
        }
       
        
    }
    

    private void GetMouseDirection() 
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("screen point");
        }
    }
    
    
}



/*

void Update()
    {
        RaycastHit Hit;
        Debug.DrawRay(transform.position, -Vector3.forward * laserSize, Color.red);

        if (Physics.Raycast(transform.position, -Vector3.forward, out Hit, laserSize))
        {
            Debug.Log("Alert !!!!!!!!!!");
        }

    }


-----------------------------------------------------------------------------------------------
if (Input.GetMouseButtonDown(1))
            Debug.Log("Pressed secondary button.");

        if (Input.GetMouseButtonDown(2))
            Debug.Log("Pressed middle click.");



*/