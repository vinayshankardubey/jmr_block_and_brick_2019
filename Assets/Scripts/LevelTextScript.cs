using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelTextScript : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
int scene;
scene = SceneManager.GetActiveScene().buildIndex;

        transform.GetComponent<TMPro.TextMeshProUGUI>().text = $"Level {scene}";
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
