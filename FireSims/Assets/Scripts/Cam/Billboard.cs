using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Is this class neccesary. There's a billboard component? :D tjek maybe
public class Billboard : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.forward = Camera.main.transform.forward;
    }
}
