using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainRenderer : MonoBehaviour
{
    LineRenderer line;
    public Transform entrypoint;
    public Transform exitpoint;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        
    }

    
    void Update()
    {
        line.SetPosition(0, entrypoint.position);
        line.SetPosition(1, exitpoint.position);
    }
}
