using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEditor.SceneManagement;
using UnityEditor.Tilemaps;
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
                this.reprodutorAudioError("O arquivo de áudio não foi encontrado");
            }
            
        }
        else
        {
            this.reprodutorAudioError("O gameobject atrelado não possui audio source");
            this.reprodutorAudioWarning("A API irá adicionar um audio source automaticamente.");
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
    private static bool passarDeFase;
    public int itens_clicados { get; set; }
    public int itens_limite_fase { get;set; }
    private int LIMITE_CLICAR { get; set; }
    public ControllerItensClicados(int itens_limite_fase,int LIMITE_CLICAR)
    {
        passarDeFase = false;
        this.itens_clicados = 0;
        this.itens_limite_fase = itens_limite_fase;
        this.LIMITE_CLICAR = LIMITE_CLICAR;
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
        text.text = (this.itens_limite_fase - this.itens_clicados).ToString();
    }

    public static void setPassarDeFase()
    {
       passarDeFase = true;
    }

    public static bool getPassarDeFase()
    {
        return passarDeFase;
    }
   
}
/*Script Principal*/
public class ControllerSelecionarAnimais :
    MonoBehaviour
{
    /*Variáveis auxiliares*/
    private static GameObject gameobject_ext;

    /*Constantes auxiliares*/

    /* Variáveis inspector*/
    [SerializeField] private Text GetHud;
    [SerializeField] private List<GameObject> obj;
    [SerializeField] private static Text hud_text;
    [SerializeField] private GameObject popup;
    [SerializeField] private Button botao_sair;
    [SerializeField] private Button botao_menu;


    /*Objetos auxiliáres*/

    private static ControllerItensClicados itensClicados;
    private SortearAnimal sortearAnimalInstanciar = new SortearAnimal();
    private ConfigurarFase ctrlFase = new ConfigurarFase(5,"selecionar_animais");
    private SpritePath path_sprites = new SpritePath("All/sprites_beadapt/Animais",null,"Selecionar Animais");
    //private ReprodutorSom reproduzirSom;

    void Start()
    {
        
        gameobject_ext = this.gameObject;
        hud_text = GetHud;

       // reproduzirSom = new ReprodutorSom("sdds",gameobject_ext);
       // reproduzirSom.reproduzirArquivo("testezao");

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
    
    /* Métodos para componentes externos .*/

    void hudConfig()
    {
        hud_text = GetHud;
        itensClicados = new ControllerItensClicados(sortearNroDeItensParaClicar(),obj.Count);
    }

    void controllerLog()
    {
        Debug.Log("CONTROLLER:Fase Atual ->" + ctrlFase.fase_atual);
        Debug.Log("CONTROLLER:OBJ Instanciados ->" + obj.Count);
    }

    int sortearNroDeItensParaClicar()
    {
        int retorno;
        System.Random rnd = new System.Random();
        retorno = rnd.Next(obj.Count / 2, obj.Count - 2);
        return retorno;
    }
}