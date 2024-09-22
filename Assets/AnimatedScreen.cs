using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedScreen : MonoBehaviour
{
    
    public void CloseScreen()
    {
        GetComponent<Animator>().Play("CloseScreen");

        Destroy(gameObject, 1);
    }
}
