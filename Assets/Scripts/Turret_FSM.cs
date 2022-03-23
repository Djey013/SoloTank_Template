using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum TurretState                                         //enum placé au dessus de la classe pour qu'il soit visible partout
{
    None,
    Detecting,
    Shooting
}

public class Turret_FSM : BaseController
{
    
    public Tank _Tank;
    public Transform tankTransform;
    public float detectionDistance;
    private bool insTankDetected;
    public float TimeBeforeFire = 2f;
    private float timer;
    public float lazerSize;
    public bool canShoot = true;
    public float bulletSpeed = 0f;
    
    
    public TurretState state = TurretState.None;                //variable stockant l'état actuel
    public TurretState nextState = TurretState.None;            //Variable utilisée pour un changement d'état

    public bool isTankDetected = false;

    private void Start()
    {
        state = TurretState.Detecting;
    }

    private void Update()
    {
        if (CheckingForTransition())
        {
            ChangeForNewState();
        }
        
        StateBehaviour();
    }

    private bool CheckingForTransition()                //recherche dans une liste d'event pouvant déclencher une Action
    {
        switch (state)
        {
            case TurretState.None:
                break;
            
            case TurretState.Detecting:
                if (isTankDetected)
                {
                    nextState = TurretState.Shooting;
                    return true;
                }
                break;
            
            case TurretState.Shooting:
                if (!isTankDetected)
                {
                    nextState = TurretState.Detecting;
                    return true;
                }
                break;
        }
        
        return false;
    }

    private void ChangeForNewState()            // Liste d'Actions déclenchées en cas de transition
    {
        switch (nextState)                      //si on est dans l'etat "nextState", alors  ChangeForNewState() va faire plusieurs vérifications (plusieurs IF déguisés en case/break)
                                                // et vérifier s'il peut executer telle ou telle action
        {
            case TurretState.None:
                break;
            
            case TurretState.Detecting:
                break;
            
            case TurretState.Shooting:
                break;
        }

        state = nextState;
    }

    private void StateBehaviour()               //comportement pour chaque etat
    {
        switch (state)
        {
            case TurretState.None:
                break;
            
            case TurretState.Detecting:
                Detecte();
                break;
            
            case TurretState.Shooting:
                Detecte();
                Tournelatete();
                if (canShoot)
                {
                    canShoot = false;
                    StartCoroutine(Fire());

                }

                break;
        }

    }

    public void Detecte()
    {
        RaycastHit hit;
        Vector3 direction = Vector3.Normalize(tankTransform.position - headTransform.position); // delta entre le tank et la tourelle (pour implementer une direction au raycast)

        if (Physics.Raycast(headTransform.position, direction, out hit, detectionDistance))
        {
            if (hit.collider.gameObject.GetComponentInParent<Tank>() != null) // fait apparaitre le lazer s'il detecte le collider du tank sur une certaine distance
            {
                Debug.DrawRay(headTransform.position, direction * lazerSize, Color.red);
                Debug.Log("[TOURELLE] : Y'a quelque chose !!!");
                isTankDetected = true;
            }
            else
            {
                isTankDetected = false;
            }

        }
        else
        {
            isTankDetected = false;
        }

    }

    public void Tournelatete()
    {
        gameObject.transform.LookAt(new Vector3(tankTransform.position.x, 0, tankTransform.position.z)); //la tourelle regarde le tank
        
    }

    IEnumerator Fire()
    {
        GameObject newBullet = Instantiate<GameObject>(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity); //instantie la balle a la sortie du canon
        newBullet.GetComponent<Rigidbody>().AddForce(headTransform.forward * bulletSpeed); //ajoute un force a la balle

        yield return new WaitForSeconds(2); //attend 2 sec entre chaque tir

        canShoot = true; // je peut re-tirer
    }
}
