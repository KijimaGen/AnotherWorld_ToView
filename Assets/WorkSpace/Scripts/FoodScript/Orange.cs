/**
 * @file Orange.cs
 * @brief �_���ς��I�����W
 * @author Sum1r3
 * @date 2025/6/17
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : Foods {
    public override void Initialize() {
        
    }

    public override void MargeSmoothie() {
        Cop.instance.AddAcid();
    }
}
