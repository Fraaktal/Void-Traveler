using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMap : MonoBehaviour
{
    public PlanetInteractions Map1;
    public PlanetInteractions Map2;
    // Start is called before the first frame update
    void Start()
    {
        Map1.Show();
        Map2.Hide();
        Map1.OnFinished += () =>
        {
            Map1.Hide();
            Map2.Show();
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
