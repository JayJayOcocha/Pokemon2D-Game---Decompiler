using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unity로 돌아가서 Project window에서 우클릭 할 시,
// Create > Pokemon > Create new Pokemon
// 이런 식으로 새로운 포켓몬을 만들 수 있음
[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create new pokemon")]

// ScriptableObject는 데이터를 저장할 수 있는 클래스로
// MonoBehaviour와 비슷하지만, 게임 옵젝이 붙어 있지 않다.
// Scene이 아닌 자산으로 존재하며, 장면과 독립적으로 존재가능

// 주 목적은 게임의 설정이나 데이터를 쉽게 관리하고 재사용하기 위함
public class PokemonBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    // battle에서 사용될듯 밑에는
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    // 포켓몬은 타입 최대 2개
    [SerializeField] PokemonType type1;
    [SerializeField] PokemonType type2;

    // Base Stats for Pokemon
    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;

    // two ways to expose a private varialbe outside the class
    // public string GetName()
    // {
    //     return name;
    // }

    //Properties
    public string Name{
        get { return name; }
    }
    public string Description{
        get { return description; }
    }
    public Sprite FrontSprite{
        get { return frontSprite; }
    }
    public Sprite BackSprite{
        get { return backSprite; }
    }
    public PokemonType Type1{
        get { return type1; }
    }
    public PokemonType Type2{
        get { return type2; }
    }
    public int MaxHp{
        get { return maxHp; }
    }
    public int Attack{
        get { return attack; }
    }
    public int Defense{
        get { return defense; }
    }
    public int SpAttack{
        get { return spAttack; }
    }
    public int SpDefense{
        get { return spDefense; }
    }
    public int Speed{
        get { return speed; }
    }
    
    

}

public enum PokemonType
{
    None,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon
}