using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : BaseController
{

    public Transform tankTransform;
    public float detectionDistance;
    private bool insTankDetected;
    public float TimeBeforeFire = 2f;
    private float timer;

    public void isTankDetected()
    {
        RaycastHit hit;
        Vector3 direction = Vector3.Normalize(tankTransform.position-headTransform.position);
        if (Physics.Raycast(headTransform.position, direction, out hit, detectionDistance))
        {
            if (hit.collider.gameObject.GetComponentInParent<Tank>()!= null)
            {
                Debug.DrawRay(headTransform.position,direction,Color.red, 1f);
                Debug.Log("Y'a quelque chose !!!");
                //Fire();
            }
        }
    }

    
    
    
}
