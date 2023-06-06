using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfigurarFase : MonoBehaviour
{
    protected string NOME_CENA { get; set; }
    protected int LIMITE_FASE { get; set; }
    protected int fase_atual { get; set; }
    public ConfigurarFase(int __limite_fase,string nome_cena)
    {
        this.LIMITE_FASE = __limite_fase;
        this.NOME_CENA= nome_cena;
    }

    private void Start()
    {
        fase_atual = 0;
    }

    protected void passarFase()
    {
        if(this.fase_atual + 1 != LIMITE_FASE)
        {
            SceneManager.LoadScene(this.NOME_CENA);
        }
        else if(this.fase_atual == LIMITE_FASE)
        {
            Debug.LogError("Não é possivel avançar de fase!");
        }
    }

    protected bool acrescentarFase()
    {
       if(this.fase_atual + 1 <= this.LIMITE_FASE)
       {
            this.fase_atual++;
            return true;
       }
        return false;
        
    }

    protected bool voltarFase()
    {
        if (this.fase_atual - 1 > 0)
        {
            this.fase_atual--;
            return true;
        }
        return false;
    }


}
