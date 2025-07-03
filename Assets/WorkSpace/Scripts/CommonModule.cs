/*
 * Date 2025年6月27日
 * programar Sum1r3
 * CommonModule.cs
 * 色々汎用性のある関数たち
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommonModule {
   
    /// <summary>
    /// enumをもらって、その中からランダムに一個かえす
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetRandomEnumValue<T>() {
        System.Array values = System.Enum.GetValues(typeof(T));
        return (T) values.GetValue(Random.Range(0, values.Length));
    }
}
