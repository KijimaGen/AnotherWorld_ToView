/*
 * Date 2025年6月25日
 * programar Sum1r3
 * EffectItem.cs
 * エフェクト効果のあるフルーツ
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConst;

public class EffectItem : Foods{
    [SerializeField]
    private Effect myEffect;
    [SerializeField]
    private Taste myTaste;

    public override void Initialize() {
       
    }

    public override void MargeSmoothie() {
        Cop.instance.ChangeEffect(myEffect);
        Cop.instance.AddTaste(myTaste);
    }

}
