using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlatform : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(End_PlatformTime());
        }
    }

    IEnumerator End_PlatformTime()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
}
