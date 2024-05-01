using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    
    // 아래 처럼 코드를 작성하면 
    // C#이 자동적으로 private variable에 접근 허용
    public MoveBase Base {get; set;}
    public int PP {get; set;}
    
    // PokemonMove 클래스 참조
    public Move(MoveBase pBase)
    {
        Base = pBase;
        PP = pBase.PP;
    }


}
