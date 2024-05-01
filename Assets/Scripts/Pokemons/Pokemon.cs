using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    // PokemonBase 클래스 참조
    PokemonBase _base;
    int level;

    // Move형 리스트 선언해주고
    public List<Move> Moves {get;set;}
    public int HP {get;set;}

    public Pokemon(PokemonBase pBase, int pLevel)
    {
        _base = pBase;
        level = pLevel;
        HP = _base.MaxHp;

        // Pokemon이 배울 수 있는 moves를 리스트형으로 초기화해준다.
        Moves = new List<Move>();
        // 포문 돌려서 move.Level이 포켓몬의 level과 같으면
        // Moves 리스트에 새로운 Move를 추가
        foreach (var move in _base.LearnableMove)
        {
            if(move.Level <= level){
                Moves.Add(new Move(move.MoveBase));
            }
            if(Moves.Count >= 4){
                break;
            }
        }
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
