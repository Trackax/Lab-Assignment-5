using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionTwo : MonoBehaviour
{ 
        public string characterName;
        public string className;
        public int Level;
        public int Con;
        private int conMod;
        public bool isAveraged;
        private double subTotalHP;
        private double finalHP;
        public bool tough;
        [SerializeField] private bool isHill = false;
    public struct Dic {
        public Dictionary<string, int> hitDice;
        public Dic(Dictionary<string, int> hitdice)
        {
            this.hitDice = new Dictionary<string, int>() { { "artificer", 8 }, { "barbarian", 12 }, { "bard", 8 }, { "cleric", 8 }, { "druid", 8 }, { "fighter", 10 }, { "monk", 8 }, { "ranger", 10 }, { "rogue", 8 }, { "paladin", 10 }, { "sorcerer", 6 }, { "wizard", 6 }, { "warlock", 8 } }; ;
        }
    }

    public Dic dic;
    List<int> classes = new List<int>() { 1, 2, 3 }; //this assignment really didn't need all three container types

    private int[] ConDic = { -5, -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10 };

    void Start()
    {
        conMod = ConDic[Con];
        if (tough == true)
        {
            subTotalHP += 2;
        }
        if (isHill == true)
        {
            subTotalHP += 1;
        }
        if (isAveraged == true)
        {
            subTotalHP += (dic.hitDice[className] / 2 + 5) + conMod;
            finalHP = subTotalHP * Level;
        }
        else
        {
            subTotalHP = subTotalHP * Level;

            for (int i = 0; Level >= i; i++)
            {
                int rolledHealth = Random.Range(1, dic.hitDice[className] + 1) + conMod;
                if (rolledHealth <= 0)
                {
                    rolledHealth = 1;
                }
                subTotalHP += rolledHealth;
            }
        }
        finalHP = subTotalHP;
        Debug.Log(characterName + "'s HP at Level " + Level + " is " + finalHP);
    }


    void Update()
    {

    }
}
