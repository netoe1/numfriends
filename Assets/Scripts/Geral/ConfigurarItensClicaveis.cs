using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using Unity.VisualScripting;

/*
 * Este script é resposável por configurar os itens clicáveis das fases, 
 *  podendo ser utilizado de forma genérica, de preferência, usar o prefab item_clicavel,
 *  para evitar bugs!
 */

public class ConfigurarItensClicaveis : MonoBehaviour
{
    private float amount_of_scale = 1.5f;
    private float default_scale = 1f;


    private Outline item_outline;
    private static bool item_clicado;
    private void Start()
    {
        item_outline = this.GetComponent<Outline>();
        item_outline.effectColor = Color.black;
        item_clicado = false;
    }

    private void gui_item_click()
    {
        this.gameObject.GetComponent<RectTransform>().localScale = new Vector3(amount_of_scale, amount_of_scale, amount_of_scale);
    }

    private void gui_item_unclick()
    {
        this.gameObject.GetComponent<RectTransform>().localScale = new Vector3(default_scale,default_scale,default_scale);
    }
    private void OnMouseEnter()
    {
        Debug.LogWarning("Mouse enter!");
        this.config_outline(true);
        //this.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnMouseExit()
    {
        Debug.LogWarning("Mouse out!");
        this.config_outline(false);
        //this.gameObject.GetComponent<Renderer>().material.color = Color.black;
    }

    private void OnMouseDown()
    {
        Debug.LogWarning("OnMouseClick!");
        item_clicado = !item_clicado;

        if (item_clicado)
        {
            gui_item_click();
            Meta_ManterAnimais.adicionar_clicados();
        }
        else
        {
            gui_item_unclick();
            Meta_ManterAnimais.remover_clicados();   
        }
    }
    
    private void config_outline(bool enter) 
    {
        if (enter)
        {
            item_outline.effectDistance = new Vector2(5f,5f);
            return;
        }

        item_outline.effectDistance = new Vector2(2.5f, 2.5f);
    }
}
