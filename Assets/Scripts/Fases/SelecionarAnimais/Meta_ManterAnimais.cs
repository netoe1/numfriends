using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*  Este arquivo .cs é responsável por manter os metadados da fase,
 * despoluindo visualmente, ao programador, no script controlador, encontrado nesse mesmo diretório. 
 */


public class Meta_ManterAnimais
{
    /* 
    *      Esta const string é responsável por mostrar o padrão da tag,
    *  que será usado para reconhecer o gameobject das posições permitidas.
   */
    private const string tag_inst_pos = "perm_pos";


    /*      Este vetor contém as strings permitidas dos animais,
     *  que mais tarde irão nos ajudar em relação ao carregamento das sprites,
     *  de modo automático e organizado.
     */
    private static string[] animais_permitidos = {
                                            "Abelha"        ,
                                            "Galinha"       ,
                                            "Galo"          ,
                                            "Pinto"         ,
                                            "Urso"          ,
                                            "Leao_marinho"  };


    /*      Essa lista é responsável por definir as posições permitidas,
     *  que serão as posições responsáveis de manter os animais responsivos,
     *  na hora de instanciá-los na UI.
     *  PS: É importante que eles estejam definidos na cena, você deve apenas arrastá-los ao script no unity inspector.
     */
    [SerializeField] static GameObject[] posicoes_permitidas;

    /*      Esta bool é responsável por permitir animais iguais ou diferentes,
     *  que poderão ser instanciados. É uma maneira de controlar, via script,
     *  o que pode poupar tempo na fase de testagem do app.
     *  PS: Por padrão, essa opção fica desativada.
    */
    private static bool animais_iguais = false;

    /* Inicialização da variável que controla a quantidade dos animais instanciados. */
    private static int nro_instanciar = 0;

    /* Inicialização da variável que controle o limite da quantidade. */
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
