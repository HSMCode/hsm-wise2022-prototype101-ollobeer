using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(3);
    }

    // Update is called once per frame
    void Update()
    {
        //Load Scenes
        if(Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("Start");
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene(1);
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            SceneManager.LoadScene(2);
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene(3);
        }

        if(Input.GetKeyDown(KeyCode.P)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
