using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetodosBtn : MonoBehaviour
{
    // Start is called before the first frame update
      
   public void SairDoJogo()
   {
        Application.Quit();
   }
    
   public async void IntroElli()
   {
        if(gameObject.GetComponent<AudioSource>() ==null)
        gameObject.AddComponent<AudioSource>();

        gameObject.GetComponent<AudioSource>().loop = false;
        gameObject.GetComponent<AudioSource>().playOnAwake= false;
        gameObject.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/Prototipo/BemVindoPrototipo");
        await Task.Delay(1000);
        gameObject.GetComponent<AudioSource>().Play();
        await Task.Delay(60000);
    }

    public async void FimDeJogo()
    {
        if (gameObject.GetComponent<AudioSource>() == null)
            gameObject.AddComponent<AudioSource>();

        gameObject.GetComponent<AudioSource>().loop = false;
        gameObject.GetComponent<AudioSource>().playOnAwake = false;
        gameObject.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/Prototipo/fimDeJogo");

        await Task.Delay(1000);
        gameObject.GetComponent<AudioSource>().Play();
        await Task.Delay(3000);
    }

    public void comecarJogo()
    {
        SceneManager.LoadScene("fase01_linear");
    }

    public void terminarJogo()
    {
        SceneManager.LoadScene("fimJogo");
    }

}
