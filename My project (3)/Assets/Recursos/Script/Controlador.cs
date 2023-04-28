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
    public GameObject pantallafinal, incorrecto, correcto;


    List<int> imgL;
    int img = 0;
    public List<int> ShuffleList(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            int temp = list[randomIndex];
            list[randomIndex] = list[i];
            list[i] = temp;
        }
        return list;
    }

  void Start()
    
    {
        imgL = new List<int>();
        for (int i = 0; i < 15; i++)
        {
            imgL.Add(i);
        }
        imgL = ShuffleList(imgL);
        // Debug.Log(string.Join(", ", imgL));

        List<int> numbers = new List<int>();
        for (int i = 0; i < 15; i++)
        {
            numbers.Add(i);
        }
        numbers = ShuffleList(numbers);
        //Debug.Log(string.Join(", ", numbers));

        

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

        index = 0;
        img = imgL[index];
        images[img].SetActive(true);
        index ++;

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
    int index = 0;
    public TMP_Text val_intentos, val_aciertos, val_porcentaje;

    public void selectedCube(GameObject go)
    {
        SelectedCube = go;
        Intentos++;
        val_intentos.text = "Intentos: " + Intentos;
        val_aciertos.text = "Aciertos: " + Aciertos;

    }

    public void correctclick(GameObject correctIMG)
    {

        if (images[img].name == correctIMG.name && SelectedCube != null)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 15; i++)
            {
                numbers.Add(i);
            }
            ShuffleList(numbers);
            //Debug.Log(string.Join(", ", numbers));



            float grid = 2.25f;
            float adj = 4.5f;
            int indx = 0;
            for (int yval = 1; yval < 5; yval++)
            {
                for (int xval = 1; xval < 5; xval++)
                {

                    if (xval == 4 && yval == 4)
                    {

                    }
                    else
                    {

                        float xvalue = ((float)xval * grid) - adj;
                        float yvalue = ((float)yval * grid) - adj;

                        cubes[numbers[indx]].transform.localPosition = new Vector3(xvalue, cubes[numbers[indx]].transform.localPosition.y, yvalue);
                        indx++;
                    }

                }
            }

            Aciertos++;
            showCRR();
            val_aciertos.text = "Aciertos: " + Aciertos;


            //Debug.Log(correctIMG.name+": "+xvalue + " , " + yvalue);

            correctIMG.SetActive(false);

            if (index != images.Length)
            {
                img = imgL[index];
                images[img].SetActive(true);
                index++;
            }
                        
        }
        else
        {
            //Debug.Log("No fue correcto");
            showINC();
        }

        Porcentaje = ((float)Aciertos / (float)Intentos * 100f);
        float roundedPorcentaje = Mathf.RoundToInt(Porcentaje*10f)/10f;
        //Debug.Log(Aciertos + "/" +Intentos+"*100="+Porcentaje);
        val_porcentaje.text = "Porcentaje: " + roundedPorcentaje + "%";
        fin_porcentaje.text = roundedPorcentaje +"%";

        fin_aciertos.text = Aciertos + "";
        if (index == images.Length)
        {
            Terminar();
        }
    }
    public void showCRR()
    {
        StartCoroutine(timeout(correcto));
    }
    public void showINC()
    {
        StartCoroutine(timeout(incorrecto));
    }
    IEnumerator timeout(GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(3);
        obj.SetActive(false);
    }

    public TMP_Text fin_aciertos, fin_porcentaje;
    public void Terminar()
    {
        pantallafinal.SetActive(true);

    }
    public void reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void atrasMenu(){
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }
}

