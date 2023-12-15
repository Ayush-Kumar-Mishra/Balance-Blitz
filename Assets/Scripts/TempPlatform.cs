using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlatform : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Temp_PlatformTime());
        }
    }

    IEnumerator Temp_PlatformTime()
    {
        yield return new WaitForSeconds(4f);
        this.gameObject.SetActive(false);
    }
}
