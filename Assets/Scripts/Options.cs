using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    // config params
    [SerializeField] public static bool mouse = true; // making this static and public means I can use it throughout in every scene

    public void Mouse()
    {
        mouse = true;
    }

    public void Controller()
    {
        mouse = false;
    }
}
