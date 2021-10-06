using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update

    public string score;
    void Start()
    {
        score = "000";
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<TMPro.TextMeshProUGUI>().text = score;
         

    }
}
