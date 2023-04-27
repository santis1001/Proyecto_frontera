using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void gotoscene(int idx){
        SceneManager.LoadScene(idx,LoadSceneMode.Single);
    }
    public void salir()
    {
        Application.Quit();
    }
}
