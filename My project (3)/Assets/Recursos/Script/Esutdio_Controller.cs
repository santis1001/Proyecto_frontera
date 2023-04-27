using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Esutdio_Controller : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Vista;
    public GameObject ar,it;
    public GameObject[] obj;
    public GameObject[] images;
    public TMP_Text titulo;
    public int index = 0;
    void Start()
    {
        for(int i =0;i<obj.Length;i++)
        {
            obj[i].SetActive(false);
            images[i].SetActive(false);
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
        ar.SetActive(true);
        it.SetActive(true);
        Menu.SetActive(false);
        images[index].SetActive(true);

        titulo.text = images[index].name;
    }
    public void atrasVista(){
        Vista.SetActive(false);
        Menu.SetActive(true);

        ar.SetActive(false);
        it.SetActive(false);

        for(int i =0;i<obj.Length;i++)
        {
            obj[i].SetActive(false);
            images[i].SetActive(false);
        }
    }
    public void atrasMenu(){
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }
}
