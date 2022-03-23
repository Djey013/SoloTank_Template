using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerBox : MonoBehaviour
{
    public GameObject popUpMessage;
    public string messageLog;

    private void OnTriggerEnter(Collider other)         //affiche un message pop up quand un objet touche le collider d'une TriggerBox
    {

        if (other.CompareTag("Bullet"))
        {
            popUpMessage.SetActive(true);

            popUpMessage.GetComponent<Text>().text = messageLog;
            
            StartCoroutine(MessageFade());
            
        }
        
    }

    IEnumerator MessageFade()
    {
        yield return new WaitForSeconds(1);
        popUpMessage.gameObject.SetActive(false);
        
    }


}
