using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamps : MonoBehaviour
{
    public static Light direcLight;

    //public Light spotLight;

    // GroundTile gt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake() {
        direcLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if(direcLight.transform.localRotation.eulerAngles.x <170)
        // {
        //     Debug.Log(direcLight.transform.localRotation.eulerAngles.x);
        //     spotLight.enabled=false;
        // }
        // else
        // {
        //     spotLight.enabled=true;
        // }
    }
}
