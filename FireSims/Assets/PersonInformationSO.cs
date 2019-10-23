using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PersonInfo", menuName = "Person Information", order = 51)]
public class PersonInformationSO : ScriptableObject
{
    public enum PersonType
    {
        Normal,
        Fat,
        Old,
        Confused,
    }
    
    public string Name;
    public int Age;
    public PersonType personType;

    public List<string> GetAllInformation()
    {
        List<string> toReturn = new List<string>();

        toReturn.Add(Name);
        toReturn.Add(Age.ToString());
        toReturn.Add(personType.ToString());

        return toReturn;
    }
}
