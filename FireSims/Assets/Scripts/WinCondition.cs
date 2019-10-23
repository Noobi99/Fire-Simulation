using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class responsible for checking whether or not a Person has reached the win platform
public class WinCondition : MonoBehaviour
{
    public delegate void EnterAction();
    public event EnterAction OnEnter;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Person"))
        {
            GameObject child = other.transform.GetChild(0).gameObject;
            var spriteRenderer = child.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.green;

            // Used for UI to update amount of savedPeople
            if (OnEnter != null)
            {
                OnEnter();
            }
        }
    }
}
