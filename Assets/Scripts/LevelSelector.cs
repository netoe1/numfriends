using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelector : MonoBehaviour
{

    [SerializeField] private string nome_level;
    
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene(nome_level);
        });
    }
    
}
