using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
     *  
     *  PS: Esses nomes s�o usados para carregar os arquivos!
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
    [SerializeField] private GameObject[] get_prefabs_cena;
    [SerializeField] private static GameObject[] prefabs_cena_static;

    /*      Esta bool � respons�vel por permitir animais iguais ou diferentes,
     *  que poder�o ser instanciados. � uma maneira de controlar, via script,
     *  o que pode poupar tempo na fase de testagem do app.
     *  PS: Por padr�o, essa op��o fica desativada.
    */
    //  private static bool animais_iguais = false;


    /*  Inicializa��o das vari�veis de controle:    */

    private static int nro_instanciar = 0;  //  Qtde. de animais que v�o ser instanciados.
    private const int LMT_INSTANCIAR = 5;   //  Limite dos animais poss�veis.
    private const int LMT_ETAPA = 5;        //  Limite da etapa por fase;
    private static int etapa_atual = 1;     //  Etapa Atual;
    private static int itens_clicados = 0;  //  Itens que foram clicados pelo usu�rio.

    /*  Vari�veis auxiliares:   */
    private System.Random rnd;              //  System.Random para sortear n�meros.
    private string animal_sorteado;         //  Animal sorteado por etapa.
    private List<string> animais_sorteados = new List<string>(); //  Animais j� sorteados.


    /*  Path's para o carregamento de arquivos / sprites etc. */
    
    private const string DEF_PATH_ANIMAL = "All/sprites_beadapt";

    void Start()
    {

        rnd = new System.Random();              //  Inicializando o rand para gerar n�meros aleat�rios.
        prefabs_cena_static = get_prefabs_cena; //  Setando dados recolhidos do Unity Inspector.

        /*  Esse loop "do while" � respons�vel por verificar , se na etapa anterior, os animais foram instanciados! */
        do
        {
            animal_sorteado = animais_permitidos[rnd.Next(0, animais_permitidos.Length - 1)];
        }
        while (animais_sorteados.Contains(animal_sorteado));
        animais_sorteados.Add(animal_sorteado);

        /*  O peda�o de c�digo abaixo ir� setar as configura��es iniciais dos prefabs */
        Debug.Log("MetaManterAnimais:Setando prefabs.");
        Debug.Log("MetaManterAnimais PATH:" + DEF_PATH_ANIMAL + "/" + animal_sorteado);

        for(int i = 0; i < prefabs_cena_static.Length; i++)
        {
            prefabs_cena_static[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(DEF_PATH_ANIMAL + "/" + animal_sorteado.ToLower());
        }
    }

    //  Gets:
    public static string get_tagPos()
    {
        return tag_inst_pos;
    }

    public GameObject[] get_posicoesPermitidas()
    {
        return prefabs_cena_static;
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

    





