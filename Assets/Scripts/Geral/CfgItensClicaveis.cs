using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

/*
 * Este script � respos�vel por configurar os itens clic�veis das fases, 
 *  podendo ser utilizado de forma gen�rica, de prefer�ncia, usar o prefab item_clicavel,
 *  para evitar bugs!
 */

public class CfgItensClicaveis :
    MonoBehaviour
{
    // Controlador de som 

    ReprodutorSom reprodutorSom;


    private Vector2 initial_size;
    private float amount_of_scale = 1.2f;
    private float default_scale = 1f;
    private Outline item_outline;
    private bool item_clicado;
    [SerializeField] private string tipoFase;
    void Start()
    {
        //Configurando controlador de som

        reprodutorSom = new ReprodutorSom("Sounds/Contagem",this.gameObject);
        Debug.Log("X:" + this.gameObject.GetComponent<RectTransform>().rect.height + "Y:" + this.gameObject.GetComponent<RectTransform>().rect.width);
        this.initial_size = new Vector2(this.gameObject.GetComponent<RectTransform>().rect.height, this.gameObject.GetComponent<RectTransform>().rect.width);
        item_outline = this.GetComponent<Outline>();
        item_outline.effectColor = UnityEngine.Color.black;
        item_clicado = false;
        this.gameObject.GetComponent<Image>().color = UnityEngine.Color.black;
        this.gameObject.GetComponent<RectTransform>().localScale = new Vector3(default_scale, default_scale, default_scale);

    }
    void config_outline(bool enter) 
    {
        if (enter)
        {
            item_outline.effectDistance = new Vector2(item_outline.effectDistance.x * amount_of_scale, item_outline.effectDistance.y * amount_of_scale);
            return;
        }
        item_outline.effectDistance = new Vector2(default_scale, default_scale) ;
    }

    
    void OnMouseDown()
    {

        if (Input.GetMouseButtonDown(0))
        {
            item_clicado = !item_clicado;
            if (item_clicado)
            {
                this.gameObject.GetComponent<Image>().color = UnityEngine.Color.white;
                this.gameObject.GetComponent<RectTransform>().localScale = new Vector3(default_scale * amount_of_scale, default_scale * amount_of_scale, default_scale * amount_of_scale);
                switch (tipoFase.ToLower())
                {
                    case "estatica":
                      //  Debug.LogWarning("Fase est�tica selecionada!");
                        GerenciaFase.adicionarClique();
                        break;
                    case "dinamica":
                        //Debug.LogWarning("Fase din�mica selecionada!");
                        ControllerSelecionarAnimais.external_adicionarClicado();
                        break;
                    default:
                        Debug.LogError("Erro no script de itensclicaveis");
                        break;
                }
                //ConfigBoxCollider2D.update_collider(this.gameObject, amount_of_scale, true);
                //Meta_ManterAnimais.adicionar_clicados();
                if(this.gameObject.GetComponent<AudioSource>() == null)
                {
                    this.gameObject.AddComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/Geral/sound_acerto");
                    this.gameObject.GetComponent<AudioSource>().playOnAwake = false;
                    this.gameObject.GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                this.gameObject.GetComponent<Image>().color = UnityEngine.Color.black;
                this.gameObject.GetComponent<RectTransform>().localScale = new Vector3(default_scale, default_scale, default_scale);

                switch (tipoFase.ToLower())
                {
                    case "estatica":
                        GerenciaFase.removerClique();
                        break;
                    case "dinamica":
                        ControllerSelecionarAnimais.external_removerClicado();
                        break;
                    default:
                        Debug.LogError("Erro no script de itensclicaveis");
                        break;
                }
                //ConfigBoxCollider2D.reset_size(this.gameObject);
                //Meta_ManterAnimais.remover_clicados();   
            }
            //status();

           /*
            if(int.Parse(ControllerSelecionarAnimais.external_getTextHud()) >= 0)
            {
                reprodutorSom.reproduzirArquivo(ControllerSelecionarAnimais.external_getTextHud());
            }
           */
            
        }
    }
    void OnMouseEnter()
    {
        this.config_outline(true);
    }

    void OnMouseExit()
    {
        this.config_outline(false);
    }

    public void status()
    {
        Debug.Log("Clicado:" + item_clicado + "\nTag:" + this.gameObject.tag);
    }
}
