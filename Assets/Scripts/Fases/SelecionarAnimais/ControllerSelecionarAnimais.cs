using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ControllerSelecionarAnimais : MonoBehaviour
{
    [SerializeField] private List<GameObject> obj;

    private SortearAnimal sortearAnimalInstanciar = new SortearAnimal();
    private ConfigurarFase ctrlFase = new ConfigurarFase(5,"selecionar_animais");
    private SpritePath path_sprites = new SpritePath("All/sprites_beadapt/Animais",null,"Selecionar Animais");
    void Start()
    {
        sortearAnimalInstanciar.sortearAnimal();
        path_sprites.spriteLog();

        for(int i = 0; i < obj.Count; i++)
        {
            path_sprites.loadIntoGameObject(obj[i],sortearAnimalInstanciar.ultimoAnimalSorteado());
        }
        path_sprites.spriteLog();
        
    }
}
