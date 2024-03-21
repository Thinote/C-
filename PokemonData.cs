using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

public class PokemonData : MonoBehaviour
{
    public string nom = "Carapuce";
    public int vieDeBase = 100;
    private int vieActuelle = 100;
    public int attaque = 15;
    public int defense = 25;
    private int stats = 0;
    public float poids = 21.2f;

    public enum Types {
        Eau,
        Feu,
        Plante,
        Sol,
        Roche,
        Acier,
        Glace,
        Electrik,
        Dragon
    }
    public Types TypesPokemon;
    public string[] faiblesses = {"Eau","Dragon"};
    public string[] resistances = {"Feu", "Glace"};

    // Start is called before the first frame update
    void Start()
    {
        Display();
        InitCurrentLife();
        InitStatsPoints();
        TakeDamage(20, "Feu");
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfPokemonAlive();
    }

    public void Display()
    {
        Debug.Log("Nom: " + nom);
        Debug.Log("Vie de Base: " + vieDeBase);
        Debug.Log("Vie Actuelle: " + vieActuelle);
        Debug.Log("Attaque: " + attaque);
        Debug.Log("Défense: " + defense);
        Debug.Log("Stats: " + stats);
        Debug.Log("Poids: " + poids + " kg");
        Debug.Log("Type de Pokémon: " + TypesPokemon);

        string faiblessesFormatted = string.Join(", ", faiblesses);
        Debug.Log("Faiblesses: " + faiblessesFormatted);

        string resistancesFormatted = string.Join(", ", resistances);
        Debug.Log("Résistances: " + resistancesFormatted);
    }
    public void InitCurrentLife()
    {
        vieActuelle = vieDeBase;
    }
    public void InitStatsPoints()
    {
        stats = vieDeBase + attaque + defense;
    }
    public int GetAttackDamage()
    {
        return attaque;
    }

    public void TakeDamage(int damage, string enemyType)
    {
    
        if (damage <= 0)
        {
            Debug.Log(nom + " ne subis pas de dégâts car l'attaque est trop faible!");
            return;
        }
        
        
        if (Array.Exists(faiblesses, element => element.Equals(enemyType, StringComparison.OrdinalIgnoreCase)))
        {
            damage *= 2;
            Debug.Log(nom + " est faible contre " + enemyType + ", les dégâts sont doublés!");
        }
        
        else if (Array.Exists(resistances, element => element.Equals(enemyType, StringComparison.OrdinalIgnoreCase)))
        {
            damage /= 2;
            Debug.Log(nom + " est résistant contre " + enemyType + ", les dégâts sont réduits de moitié!");
        }
        
        
        vieActuelle -= damage;
        
        
        if (vieActuelle < 0)
        {
            vieActuelle = 0;
        }
        
        
        Debug.Log(nom + " a maintenant " + vieActuelle + " point de vie restants.");
    }

    void CheckIfPokemonAlive()
    {
        if (vieActuelle > 0)
        {
            Debug.Log(nom + " est en bonne santé et prêt au combat!");
        }
        else
        {
            Debug.Log(nom + " est K.O.!");
        }
    }




}

