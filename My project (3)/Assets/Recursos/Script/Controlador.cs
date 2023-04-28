using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Controlador : MonoBehaviour
{

    public GameObject[] cubes;
    public GameObject[] images;

    float maxX = 4.5f;
    float minX = -4.5f;

    float maxY = 4.5f;
    float minY = -4.5f;

    int img = 0;
  void ShuffleList(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            int temp = list[randomIndex];
            list[randomIndex] = list[i];
            list[i] = temp;
        }
    }

  void Start()
    
    {

        List<int> numbers = new List<int>();
        for (int i = 0; i < 15; i++)
        {
            numbers.Add(i);
        }
        ShuffleList(numbers);
        Debug.Log(string.Join(", ", numbers));

        

        float grid = 2.25f;
        float adj = 4.5f;
        int indx = 0;
        for(int yval =1;yval<5;yval++)
        {
            for(int xval =1;xval<5;xval++){

                if(xval == 4 && yval==4){

                }else{

                float xvalue =((float)xval*grid)-adj;
                float yvalue = ((float)yval*grid)-adj;

                cubes[numbers[indx]].transform.localPosition = new Vector3(xvalue, cubes[numbers[indx]].transform.localPosition.y, yvalue);
                indx++;
                }

            }
        }

        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
        }

        img = Random.Range(0, images.Length);
        images[img].SetActive(true);
    }

  /*  void Start()
    
    {

        for (int i = 0; i < cubes.Length; i++)
        {
            //bool iscolliding = true;
            
            float newdist_ref;

            float xvalue;
            float yvalue;

            bool exitdo = true;

            do
            { 
                xvalue = Random.Range(minX, maxX);
                yvalue = Random.Range(minY, maxY);

                int Error_finder = 0;

                for (int e=0; e<i;e++)
                {                   
                    newdist_ref = Vector2.Distance(new Vector2(xvalue,yvalue), new Vector2(cubes[e].transform.localPosition.x, cubes[e].transform.localPosition.z));


                    if (newdist_ref < 1.25)
                    {
                        //Debug.Log(newdist_ref);
                        Error_finder++;
                    }                   

                }
                if (Error_finder==0)
                {
                    exitdo = false;
                }
               // Debug.Log("todo bien?");

            } while (exitdo);
                
            cubes[i].transform.localPosition = new Vector3(xvalue, cubes[i].transform.localPosition.y, yvalue);

        }
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
        }

        img = Random.Range(0, images.Length);
        images[img].SetActive(true);

    }
*/
    GameObject SelectedCube = null;
    int Intentos = 0;
    int Aciertos = 0;
    float Porcentaje = 0;

    public TMP_Text val_intentos, val_aciertos, val_porcentaje;

    public void selectedCube(GameObject go)
    {
        SelectedCube = go;
        Intentos++;
        val_intentos.text = "Intentos: " + Intentos;
    }

    public void correctclick(GameObject correctIMG)
    {
        if (images[img].name == correctIMG.name && SelectedCube != null)
        {
            Aciertos++;


            val_aciertos.text = "Aciertos: " + Aciertos;


            //Debug.Log(correctIMG.name+": "+xvalue + " , " + yvalue);

            correctIMG.SetActive(false);
            int aux = img;
            do
            {
                img = Random.Range(0, images.Length);
            }
            while (aux == img);

            images[img].SetActive(true);
        }
        else
        {
            //Debug.Log("No fue correcto");
        }

        Porcentaje = ((float)Aciertos / (float)Intentos * 100f);
        float roundedPorcentaje = Mathf.RoundToInt(Porcentaje*10f)/10f;
        //Debug.Log(Aciertos + "/" +Intentos+"*100="+Porcentaje);
        val_porcentaje.text = "Porcentaje: " + roundedPorcentaje + "%";

    }
    
    public void atrasMenu(){
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }
}

