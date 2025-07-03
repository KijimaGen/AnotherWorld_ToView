/**
 * @file Apple.cs
 * @brief í èÌçUåÇ
 * @author Sum1r3
 * @date 2025/6/17
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Foods{
    public override void Initialize() {
        this.transform.rotation = Quaternion.Euler(-90, -90, 0);
    }

    public override void MargeSmoothie() {
        Cop.instance.AddSweet();
    }

    
}
