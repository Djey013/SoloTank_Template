using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : BaseController
{
    public Tank _Tank;
    public Transform tankTransform;
    public float detectionDistance;
    private bool insTankDetected;
    public float TimeBeforeFire = 2f;
    private float timer;
    public float lazerSize;
    public bool canShoot = true;
    public float bulletSpeed = 1000f;
    
    private void Update()
    {
        if (tankTransform != null)  //tant que le tank est vivant
        {
            isTankDetected();
        } 
    }

    public void isTankDetected()
    {
        RaycastHit hit;

        Vector3 direction = Vector3.Normalize(tankTransform.position - headTransform.position); // delta entre le tank et la tourelle

        if (Physics.Raycast(headTransform.position, direction, out hit, detectionDistance))
        {
            gameObject.transform.LookAt(new Vector3(tankTransform.position.x, 0, tankTransform.position.z)); //la tourelle regarde le tank
            
            
            if (hit.collider.gameObject.GetComponentInParent<Tank>() != null)
            {
                Debug.DrawRay(headTransform.position, direction * lazerSize, Color.red);
                Debug.Log("Y'a quelque chose !!!");

                if (canShoot == true) //si je peut tirer
                {
                    StartCoroutine(FireTurret());
                    canShoot = false;
                }
            }
        }
    }

    IEnumerator FireTurret()
    {
        GameObject newBullet = Instantiate<GameObject>(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity); //instantie la balle a la sortie du canon
        newBullet.GetComponent<Rigidbody>().AddForce(headTransform.forward * bulletSpeed); //ajoute un force a la balle

        yield return new WaitForSeconds(2); //attend 2 sec entre chaque tir

        canShoot = true; // je peut re-tirer
    }

    
}
