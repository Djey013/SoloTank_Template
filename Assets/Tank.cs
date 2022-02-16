using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : BaseController
{
    
    public float speed = 0;
    public float speedRotation = 0;
    
    void Update()
    {
        
        float direction = Input.GetAxis("Vertical") * speed;
        transform.Translate(0f,0f,direction*Time.deltaTime,Space.Self);
        
        float rotation = Input.GetAxis("Horizontal") * speedRotation;
        transform.Rotate(0, rotation, 0);


    }
    private void GetMouseDirection() //
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            
        }
    }
    
    
}
