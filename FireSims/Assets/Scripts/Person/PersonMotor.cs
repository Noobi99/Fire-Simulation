using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

public class PersonMotor : MonoBehaviour
{
    // The exit reference is where the people are heading in case of an emergency
    public BoxCollider ExitReference;
    
    // Reference to its own Agent
    public NavMeshAgent Agent;

    public bool StartAgents = false;
    
    // A vector3 for storing the random position
    private Vector3 randomPosition;
    
    void Start()
    {
        // Get a reference to the collider of the exit reference, used for randoming a position inside its collider.
        var exitReferenceCollider = GetComponent<BoxCollider>();
        
        // Set a random destination inside the exit reference collider
        randomPosition = ExtensionMethods.RandomPositionInCollider(exitReferenceCollider);
        
        // Prints out the random positions
        Debug.Log(randomPosition.ToString());
        
        // Should use randomPosition outside
        //Agent.SetDestination(ExitReference.transform.position);
        Agent.SetDestination(randomPosition);

        
    }
    
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(randomPosition, 1);
    }
}
