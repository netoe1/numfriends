using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortearAnimal
{
    private List<string> animaisSorteados = new List<string>();
    private string ultimoSorteado;
    private string[] animais = { "Abelha", "Galinha", "Galo", "Leao_marinho", "Pinguim", "Pinto", "Polvo" };

    public string sortearAnimal()
    {
        System.Random rnd = new System.Random();
        string aux = "undefined";
        do
        {
            aux = animais[rnd.Next(0, animais.Length - 1)].ToLower();
        }
        while (animaisSorteados.Count < animais.Length && animaisSorteados.Contains(aux));

        if (animaisSorteados.Count == animais.Length)
        {
            animaisSorteados.Clear();
        }
        ultimoSorteado = aux;
        animaisSorteados.Add(aux);
        Debug.Log(aux);
        return aux;
    }

    public string ultimoAnimalSorteado()
    {
        return this.ultimoSorteado;
    }
}