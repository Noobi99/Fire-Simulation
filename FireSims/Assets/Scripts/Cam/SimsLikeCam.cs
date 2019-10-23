using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimsLikeCamera : MonoBehaviour
{
    // Global variables
    [SerializeField]
    private GameObject toTurnAround; // Reference point to our turn point, so the cam is fixed.
    public int scrollSpeed; // scroll speed of the mouse
    
    // To enable and hide meshes of the walls
    private bool _isOver = false;
    private MeshRenderer _mesh = null;
    private GameObject _lastMesh = null;

    // A private variable to keep track of the cameras fixed setting
    private bool _camFixed = true;

    // UPDATE METHOD
    void Update()
    {
        CamHotkeys();
        CameraMovement();
        HideWalls();
    }
    
    
    private void CamHotkeys()
    {   
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_camFixed)
            {
                _camFixed = false;
            }
            else
            {
                _camFixed = true;
            }
        }
    }

    private void CameraMovement()
    {
        // Translating the camera
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontal, vertical, 0);
        transform.Translate(movement);

        // Rotating around fixed point
        if (_camFixed)
        {
            transform.LookAt(toTurnAround.transform);
        }
        
        // Zooming
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 scrollMovement = new Vector3(0, 0, scroll);
        transform.Translate(scrollMovement * scrollSpeed);
    }

    private void HideWalls()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 25, Color.green);
        
        if (Physics.Raycast(transform.position, transform.forward * 25, out hit))
        {
            // Do a check if we hit a wall
            if (hit.collider.CompareTag("Wall") && hit.collider != null)
            {
                // Do a check if we actually hitting a new wall
                if (_isOver)
                {
                    // Showing last mesh
                    _mesh.gameObject.SetActive(true);

                    _isOver = false;
                }
                
                // Kører kun en gang for en væg, fordi vi bruger en lastMesh
                if (hit.collider.CompareTag("Wall") && hit.collider.transform.gameObject != _lastMesh)
                {
                    _mesh = hit.collider.GetComponent<MeshRenderer>();

                    _mesh.gameObject.SetActive(false);
                    
                    _lastMesh = hit.collider.transform.gameObject;

                    _isOver = true;
                }
            }
        }
    }
}
