using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// PersonsUI shows amount of people in the scene and how many saved people
public class PersonsUI : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private int _savedPeople = 0;
    private int _amountPeople = 0;

    public WinCondition winCondition;
    public int Test;
    private int Test2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] persons = GameObject.FindGameObjectsWithTag("Person");
        _text = GetComponent<TextMeshProUGUI>();
        _amountPeople = persons.Length;
        _text.text = "Saved people: " + _savedPeople + "/" + _amountPeople;
        
        winCondition.OnEnter += NewPersonCameIn;
    }

    // Updates the text on the TextMeshPro object
    public void NewPersonCameIn()
    {
        _savedPeople++;
        _text.text = "Saved people: " + _savedPeople + "/" + _amountPeople;

    }
}
