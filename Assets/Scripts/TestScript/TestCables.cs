using System.Collections;
using System.Collections.Generic;
using Cables;
using UnityEngine;

public class TestCables : MonoBehaviour
{
    public CablesController Cables;
    // Start is called before the first frame update
    void Start()
    {
        Cables.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
