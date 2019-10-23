using System;
using System.Collections;
using System.Collections.Generic;
using Person;
using TMPro;
using UnityEngine;

/*
 * This class is still a little buggy. You can't select the same person twice in a row.
 * Furthermore, a click first deselects unit and then selects after, *deselect should probably be possible
 *
 *
 * 
 */
public class PersonHighligther : MonoBehaviour
{
    private GameObject _currentTarget;
    private GameObject _lastTarget;

    // Window to show information
    public GameObject personInformationPanel;
    public TextMeshProUGUI personInformationTextName;
    public TextMeshProUGUI personInformationTextAge;
    public TextMeshProUGUI personInformationTextType;

    private Vector3 newVector;

    // For storing the origianl color before a selection
    private Color _originalColor;
    private bool _isOver;
    private MeshRenderer _mesh;
    private PersonInformationSO _personInfo;

    // For exposing private members to tests
    public void Construct(Color originalColor, bool isOver, MeshRenderer mesh)
    {
        _originalColor = originalColor;
        _isOver = isOver;
        _mesh = mesh;
    }
    
    // Update is called once per frame asd
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider != null && hit.collider.CompareTag("Person"))
                {
                    if (_isOver)
                    {
                        // Showing last mesh
                        _mesh.material.color = _originalColor;

                        _isOver = false;
                    }
                    else if (hit.collider.gameObject.CompareTag("Person") && hit.collider.gameObject != _lastTarget)
                    { 
                        _currentTarget = hit.collider.gameObject;

                        // changes the color of the selected object
                        _mesh = _currentTarget.GetComponent<MeshRenderer>();
                        _originalColor = _mesh.material.color;
                        _mesh.material.color = new Color(0, 0, 255);

                        _isOver = true;

                        // Setting the GUI information
                        try
                        {
                            _personInfo = hit.collider.GetComponent<PersonVariables>().PersonInformation;

                            personInformationTextName.text = "Name: " + _personInfo.name;
                            personInformationTextAge.text = "Age: " + _personInfo.Age;
                            personInformationTextType.text = "Type: " + _personInfo.personType;

                        }
                        catch (ArgumentNullException e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }

                        _lastTarget = _currentTarget;
                    }
                }
            }
        }    
    }
}