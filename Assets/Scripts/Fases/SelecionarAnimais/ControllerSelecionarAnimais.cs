using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

/*Classe auxiliar*/

public class ReprodutorSom
{
    public string PATHPASTA_AUDIOS {get;set;}

    private GameObject gameObject_atrelado;
    private AudioSource audioSource;

    private const float STD_VOLUME = 1.0f;
    public ReprodutorSom(string __path_audios,GameObject __gameObject)
    {
        this.PATHPASTA_AUDIOS = __path_audios;
        this.gameObject_atrelado = __gameObject;
    }

    public void reproduzirArquivo(string filename)
    {
        audioSource = gameObject_atrelado.GetComponent<AudioSource>();
        if (audioSource != null)
        {
            this.reprodutorAudioLog("O gameobject atrelado possui audiosource");
            audioSource.clip = Resources.Load<AudioClip>(filename);
            if(audioSource.clip != null)
            {
                audioSource.Play();
            }
            else
            {
                this.reprodutorAudioError("O arquivo de �udio n�o foi encontrado");
            }
            
        }
        else
        {
           this.reprodutorAudioError("O gameobject atrelado n�o possui audio source");
           this.reprodutorAudioWarning("A API ir� adicionar um audio source automaticamente.");
           addAudioSource();
        
        }
    }

    private void reprodutorAudioError(string desc)
    {
        Debug.LogError("ReproduzirAudio ERRO:" + desc );
    }
    private void reprodutorAudioLog(string desc)
    {
        Debug.Log("ReproduzirAudio:" + desc );
    }
    private void reprodutorAudioWarning(string desc)
    {
        Debug.LogWarning("ReproduzirAudioWarning:" + desc);
    }

    private void addAudioSource()
    {
        audioSource = gameObject_atrelado.AddComponent<AudioSource>();
    }

    private void set_stdConfigAudioSource()
    {
        audioSource.volume = STD_VOLUME;
        audioSource.playOnAwake = false;
    }
   
};
public class ControllerItensClicados
{
    public int itens_clicados { get; set; }
    private int LIMITE_CLICAR;
    public ControllerItensClicados(int lIMITE_CLICAR)
    {
        this.itens_clicados = 0;
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

    public void verItensClicados()
    {
        Debug.Log(this.itens_clicados);
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
        text.text = (this.LIMITE_CLICAR - this.itens_clicados).ToString();
    }
}

/*Script Principal*/
public class ControllerSelecionarAnimais :
    MonoBehaviour
{
    /*Vari�veis auxiliares*/
    private static GameObject gameobject_ext;

    /*Constantes auxiliares*/

    /* Vari�veis inspector*/
    [SerializeField] private Text GetHud;
    [SerializeField] private List<GameObject> obj;
    [SerializeField] private static Text hud_text;


    /*Objetos auxili�res*/

    private static ControllerItensClicados itensClicados;
    private SortearAnimal sortearAnimalInstanciar = new SortearAnimal();
    private ConfigurarFase ctrlFase = new ConfigurarFase(5,"selecionar_animais");
    private SpritePath path_sprites = new SpritePath("All/sprites_beadapt/Animais",null,"Selecionar Animais");
    private ReprodutorSom reproduzirSom;

    void Start()
    {
        gameobject_ext = this.gameObject;
        hud_text = GetHud;

        reproduzirSom = new ReprodutorSom("sdds",gameobject_ext);
        reproduzirSom.reproduzirArquivo("teu cu");

        sortearAnimalInstanciar.sortearAnimal();
        //path_sprites.spriteLog();
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
        Debug.Log("CONTROLLER:OBJ Instanciados ->" + obj.Count);
    }

    /*
        API para outras classes.
     */

    public static void external_adicionarClicado()
    {
        itensClicados.acrescentarItensClicados();
        itensClicados.verItensClicados();
        itensClicados.updateHud(hud_text);
    }
    public static void external_removerClicado()
    {
        itensClicados.removerItensClicados();
        itensClicados.verItensClicados();
        itensClicados.updateHud(hud_text);
    }

}