using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Esutdio_Controller : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Vista;

    public GameObject[] obj;
    public int index = 0;
    void Start()
    {
        for(int i =0;i<obj.Length;i++)
        {
            obj[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setIndex(int idx){
        index = idx;
        obj[index].SetActive(true);
        Vista.SetActive(true);
        Menu.SetActive(false);
    }
    public void atrasVista(){
        Vista.SetActive(false);
        Menu.SetActive(true);

        for(int i =0;i<obj.Length;i++)
        {
            obj[i].SetActive(false);
            Debug.Log(obj[i].name);
        }
    }
    public void atrasMenu(){
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }
}
