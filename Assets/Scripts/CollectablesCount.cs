using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectablesCount : MonoBehaviour
{
    public TMP_Text collectableText;
    public static int score;

    private void Start()
    {
        score = 0;
    }
    void Update()
    {
        collectableText.text = score.ToString();
    }
}
