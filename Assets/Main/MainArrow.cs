using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainArrow : MonoBehaviour
{
    int i;
    // Start is called before the first frame update
    private void Awake()
    {
        Invoke("Setresolution", 0.1f);
    }
    
    void Setresolution()
    {
        Screen.SetResolution(1080, 1920, true);
    }


    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (i != 0)
                i--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (i != 4)
                i++;
        }


        transform.position = new Vector2(-2 + i, -4);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(i);
        }
    }
}
