/*
 * Date 2025�N6��27��
 * programar Sum1r3
 * CommonModule.cs
 * �F�X�ėp���̂���֐�����
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommonModule {
   
    /// <summary>
    /// enum��������āA���̒����烉���_���Ɉ������
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetRandomEnumValue<T>() {
        System.Array values = System.Enum.GetValues(typeof(T));
        return (T) values.GetValue(Random.Range(0, values.Length));
    }
}
