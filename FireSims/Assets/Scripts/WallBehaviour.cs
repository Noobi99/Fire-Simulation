using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Is this class even used? meh
public class WallBehaviour : MonoBehaviour
{
    public bool isLookedAt;
    private MeshRenderer _mesh;
    
    // Start is called before the first frame update
    void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _mesh.gameObject.SetActive(true);
    }
}
