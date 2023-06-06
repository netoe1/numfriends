using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/*      Este arquivo .cs � respons�vel por manter os metadados da fase,
 *  despoluindo visualmente, ao programador, no script controlador,
 *  encontrado nesse mesmo diret�rio. 
 */


public class Meta_ManterAnimais : MonoBehaviour
{
    /* 
    *      Esta const string � respons�vel por mostrar o padr�o da tag,
    *  que ser� usado para reconhecer o gameobject das posi��es permitidas.
   */
    private const string tag_inst_pos = "perm_pos";


    /*      Este vetor cont�m as strings permitidas dos animais,
     *  que mais tarde ir�o nos ajudar em rela��o ao carregamento das sprites,
     *  de modo autom�tico e organizado.
     */
    private static string[] animais_permitidos =
                                                            {
                                            "Abelha"        ,
                                            "Galinha"       ,
                                            "Galo"          ,
                                            "Pinto"         ,
                                            "Urso"          ,
                                            "Leao_marinho"  };


    /*      Essa lista � respons�vel por definir as posi��es permitidas,
     *  que ser�o as posi��es respons�veis de manter os animais responsivos,
     *  na hora de instanci�-los na UI.
     *  PS: � importante que eles estejam definidos na cena, voc� deve apenas arrast�-los ao script no unity inspector.
     */
    [SerializeField] private GameObject[] get_posicoes_permitidas;
    [SerializeField] private GameObject[] posicoes_permitidas_static;

    /*      Esta bool � respons�vel por permitir animais iguais ou diferentes,
     *  que poder�o ser instanciados. � uma maneira de controlar, via script,
     *  o que pode poupar tempo na fase de testagem do app.
     *  PS: Por padr�o, essa op��o fica desativada.
    */
    //  private static bool animais_iguais = false;


    /*  Inicializa��o das vari�veis de controle:    */

    private static int nro_instanciar = 0;   // Qtde. de animais que v�o ser instanciados.
    private const int LMT_INSTANCIAR = 5;   //  Limite dos animais poss�veis.
    private static int itens_clicados = 0;  // Itens que foram clicados pelo usu�rio.

    


    void Start()
    {
        posicoes_permitidas_static = get_posicoes_permitidas;
    }

    //  Gets:
    public static string get_tagPos()
    {
        return tag_inst_pos;
    }

    public GameObject[] get_posicoesPermitidas()
    {
        return posicoes_permitidas_static;
    }

    public static string[] get_animaisPermitidos()
    {
        return animais_permitidos;
    }

    public static int get_nroInstaciados()
    {
        return nro_instanciar;
    }


    //  Sets:

    public static void set_resetarTudo()
    {
        nro_instanciar = 0;
    }

    public static bool set_nroInstanciar(int valor) 
    {
        if(valor <= nro_instanciar || valor > 0)
        {
            nro_instanciar = valor;
            return true;
        }

        return false;
    }

    public static bool adicionar_clicados()
    {
        if(itens_clicados + 1 <= LMT_INSTANCIAR)
        {
            itens_clicados++;
            return true;
        }

        return false;
    }

    public static bool remover_clicados()
    {
        if(itens_clicados - 1 >= 0)
        {
            itens_clicados--;
            return true;
        }
        return false;
    }

   
}

    





