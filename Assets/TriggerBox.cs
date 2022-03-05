using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerBox : MonoBehaviour
{
    public Text messageInfo;


    private void Start()
    {
        messageInfo.gameObject.SetActive(false);

    }


    private void OnTriggerEnter(Collider other)             //affiche un message pop up quand un objet touche le collider d'une TriggerBox
    {

        messageInfo.text = other.gameObject.name + " detruite.";

        /*
        if(other.gameObject.CompareTag("TriggerBox"))
        {
            messageInfo.gameObject.SetActive(true);
            messageInfo.text = "Tourelle 1 détruite";

            StartCoroutine(MessageFade());
        }

        if(other.gameObject.CompareTag("TriggerBox1"))
        {
            messageInfo.gameObject.SetActive(true);
            messageInfo.text = "Tourelle 2 détruite";

            StartCoroutine(MessageFade());
        }

        if (other.gameObject.CompareTag("TriggerBox2"))
        {
            messageInfo.gameObject.SetActive(true);
            messageInfo.text = "Tourelle 2 détruite";

            StartCoroutine(MessageFade());
        }

        if (other.gameObject.CompareTag("TriggerBox3"))
        {
            messageInfo.gameObject.SetActive(true);
            messageInfo.text = "Tourelle 2 détruite";

            StartCoroutine(MessageFade());
        }
        */
    }


    IEnumerator MessageFade()
    {
        yield return new WaitForSeconds(2);
        messageInfo.gameObject.SetActive(false);

    }


}
