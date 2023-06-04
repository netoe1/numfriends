using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
 * Este script � respos�vel por configurar os itens clic�veis das fases, 
 *  podendo ser utilizado de forma gen�rica, de prefer�ncia, usar o prefab item_clicavel,
 *  para evitar bugs!
 */

public class ConfigurarItensClicaveis : MonoBehaviour
{
    private Outline item_outline;


    private void Start()
    {
        item_outline = this.GetComponent<Outline>();
        item_outline.effectColor = Color.black;

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
