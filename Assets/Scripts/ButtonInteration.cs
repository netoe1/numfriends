using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.iOS.Extensions.Common;
using UnityEngine;
using UnityEngine.UI;
public class ButtonInteration : MonoBehaviour
{  
    public Image img_children_btn;
    [SerializeField] Color color_hover;
    public void OnMouseEnter()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        if(!img_children_btn)
        {
            Debug.LogError("ButtonInteration:Você não definiu a imagem do botão nos pré-requisitos do script!");
            return;
        }
         Debug.Log("Mouse enter!");
        img_children_btn.color = Color.white;
    }

    public void OnMouseExit()
    {
 
        Debug.Log("Mouse out!");
        img_children_btn.color = color_hover;
    }

}
