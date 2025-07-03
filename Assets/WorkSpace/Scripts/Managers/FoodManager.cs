/*
 * Date 2025年6月20日
 * programar Sum1r3
 * FoodManager.cs
 * 食材管理スクリプト
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour{
    //皿の上に置かれるフルーツのリスト
    [SerializeField]
    List<GameObject> fashonFruitList;
    //出てくるフルーツのリスト
    [SerializeField]
    List<GameObject> margeFruitList;

    //お皿
    [SerializeField]
    private GameObject syokuzaiLeft;
    [SerializeField]
    private GameObject syokuzaiCenter;
    [SerializeField]
    private GameObject syokuzaiRight;

    private int leftIndex;
    private int centerIndex;
    private int rightIndex;

    public static FoodManager instance;

    private void Start() {
        leftIndex = 0;
        centerIndex = 1;
        rightIndex = 2;
        instance = this;
        SetFruit();
        
    }

    private void Update() {
        //入力の受付
        if (Input.GetKeyDown(KeyCode.RightArrow))
            IncreaceIndex(1);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            IncreaceIndex(-1);

    }



    private void SetFruit() {
        syokuzaiLeft.GetComponent<Syokuzai>().ChangePutFruit(fashonFruitList[leftIndex], margeFruitList[leftIndex]);
        syokuzaiCenter.GetComponent<Syokuzai>().ChangePutFruit(fashonFruitList[centerIndex], margeFruitList[centerIndex]);
        syokuzaiRight.GetComponent<Syokuzai>().ChangePutFruit(fashonFruitList[rightIndex], margeFruitList[rightIndex]);
    }

    public void IncreaceIndex(int count) {
        //←端のインデックスを加算
        leftIndex += count;
        //加算した後の値がfashonFruitListのカウントを超えるようなら0に設定
        if(leftIndex > fashonFruitList.Count - 1)
            leftIndex = 0;
        if(leftIndex < 0)
            leftIndex = fashonFruitList.Count - 1;
        //真ん中と右端を設定
        centerIndex = leftIndex + 1;
        if(centerIndex >  fashonFruitList.Count -1) 
            centerIndex = 0;
        //真ん中
        rightIndex = leftIndex + 2;
        if(rightIndex > fashonFruitList.Count - 1) 
            rightIndex = rightIndex -fashonFruitList.Count;
        //全て終わったので置くアイテムを設定
        SetFruit();

    }
}
