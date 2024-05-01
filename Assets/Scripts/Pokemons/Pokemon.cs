using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    // PokemonBase 클래스 참조
    PokemonBase base;
    int level;

    public Pokemon(Pokemon pBase, int pLevel)
    {
        _base = pBase;
        level = pLevel;
    }

    // Pokemon game이 사용하는 몬스터들의 레벨 별 스탯
    public int Attack{
        get { return Mathf.FloorToInt((_base.Attack * level)/100f)+5; }
    }
    public int Defense{
        get { return Mathf.FloorToInt((_base.Defense * level)/100f)+5; }
    }
    public int SpAttack{
        get { return Mathf.FloorToInt((_base.SpAttack * level)/100f)+5; }
    }
    public int SpDefense{
        get { return Mathf.FloorToInt((_base.SpDefense * level)/100f)+5; }
    }
    public int Speed{
        get { return Mathf.FloorToInt((_base.Speed * level)/100f)+5; }
    }
    public int MaxHp{
        get { return Mathf.FloorToInt((_base.MaxHp * level)/100f)+10; }
    }
}
