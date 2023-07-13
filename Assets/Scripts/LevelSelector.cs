using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private Scene scene_to_redirect;
    private void Start()
    {
        if (!GetComponent<Button>())
        {
            this.gameObject.AddComponent<Button>();
        }

        gameObject.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene(scene_to_redirect.name.ToString());
        });
    }
    
}
