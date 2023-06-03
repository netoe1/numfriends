using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*  Este arquivo .cs � respons�vel por manter os metadados da fase,
 * despoluindo visualmente, ao programador, no script controlador, encontrado nesse mesmo diret�rio. 
 */


public class Meta_ManterAnimais
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
    private static string[] animais_permitidos = {
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
    [SerializeField] static GameObject[] posicoes_permitidas;

    /*      Esta bool � respons�vel por permitir animais iguais ou diferentes,
     *  que poder�o ser instanciados. � uma maneira de controlar, via script,
     *  o que pode poupar tempo na fase de testagem do app.
     *  PS: Por padr�o, essa op��o fica desativada.
    */
    private static bool animais_iguais = false;

    /* Inicializa��o da vari�vel que controla a quantidade dos animais instanciados. */
    private static int nro_instanciar = 0;

    /* Inicializa��o da vari�vel que controle o limite da quantidade. */
    private const int nro_lmt_instanciar = 5;




    /*Getters e Setters:*/


    //  GETS:
    public static string get_tagPos() 
    {
        return tag_inst_pos;
    }

    public static string[] get_animaisPermitidos()
    {
        return animais_permitidos;
    }
}
