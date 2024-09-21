using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmp;
    private float time;

    private void Update()
    {
        time += Time.deltaTime;
        string temp = time.ToString();
        if (temp.IndexOf(".") + 3 < temp.Length)
            temp = temp[..(temp.IndexOf(".") + 3)];
        tmp.text = temp;
    }
}
