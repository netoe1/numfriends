using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ControllerItensClicados
{
    public int itens_clicados { get; set; }
    private int LIMITE_CLICAR;


    private void Start()
    {
        itens_clicados = 0;
    }
    public ControllerItensClicados(int lIMITE_CLICAR)
    {
        this.itens_clicados = itens_clicados;
        LIMITE_CLICAR = lIMITE_CLICAR;
    }

    public void removerItensClicados()
    {
        if(itens_clicados - 1 >= 0)
        {
            itens_clicados--;
        }
    }

    public void acrescentarItensClicados()
    {
        if (itens_clicados + 1 <= LIMITE_CLICAR)
        {
            itens_clicados++;
        }
    }

    public void resetarTudo()
    {
        itens_clicados = 0;
    }

    public void setLimiteClicar(int limiteClicar)
    {
        if(limiteClicar < 0)
        {
            limiteClicar = 1;
            return;
        }

        this.LIMITE_CLICAR = limiteClicar;
     
    }

    public void updateHud(Text text)
    {
        text.text = this.itens_clicados.ToString();
    }
}
public class ControllerSelecionarAnimais :
    MonoBehaviour
{    
    [SerializeField] private Text GetHud;
    [SerializeField] private List<GameObject> obj;
    [SerializeField] private static Text hud_text;


    private static ControllerItensClicados itensClicados;
    private SortearAnimal sortearAnimalInstanciar = new SortearAnimal();
    private ConfigurarFase ctrlFase = new ConfigurarFase(5,"selecionar_animais");
    private SpritePath path_sprites = new SpritePath("All/sprites_beadapt/Animais",null,"Selecionar Animais");

    void Start()
    {
        hud_text = GetHud;
        sortearAnimalInstanciar.sortearAnimal();
        path_sprites.spriteLog();
        this.hudConfig();
        itensClicados.updateHud(hud_text);

        for(int i = 0; i < obj.Count; i++)
        {
            path_sprites.loadIntoGameObject(obj[i],sortearAnimalInstanciar.ultimoAnimalSorteado());
        }
        path_sprites.spriteLog();
        controllerLog();
        
    }

    void hudConfig()
    {
        hud_text = GetHud;
        itensClicados = new ControllerItensClicados(obj.Count);
    }


    void controllerLog()
    {
        Debug.Log("CONTROLLER:Fase Atual ->" + ctrlFase.fase_atual);
        Debug.Log("CONTROLLER:OBJ Instanciados ->" + ctrlFase.LIMITE_FASE);
    }

    /*
        API para outras classes.
     */

    public static void external_adicionarClicado()
    {
        itensClicados.acrescentarItensClicados();
        itensClicados.updateHud(hud_text);
    }

    public static void external_removerClicado()
    {
        itensClicados.removerItensClicados();
        itensClicados.updateHud(hud_text);
    }

}
