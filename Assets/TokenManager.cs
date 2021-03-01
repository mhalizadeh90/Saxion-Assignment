using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenManager : MonoBehaviour
{
    [SerializeField] Vector2Variable tokensCenterPosition;
    List<Token> allTokens;
    List<int> ActivatedIndex;
    bool isAllTokenGathered;

    void Awake()
    {
        allTokens = new List<Token>();
        ActivatedIndex = new List<int>();
        tokensCenterPosition.value = Vector2.zero;
    }

    void OnEnable()
    {
        Token.OnTokenStart += registerToken;
        Token.OnTokenActivated += ActivateToken;
    }

    void registerToken(Token token)
    {
        allTokens.Add(token);
    }

    void ActivateToken(Token token)
    {
        ActivatedIndex.Add(token.TokenIndex);

        isAllTokenGathered = (allTokens.Count == ActivatedIndex.Count);

        if (isAllTokenGathered)
            OnAllTokensActivated?.Invoke();

        for (int i = 0; i < token.NeighborIndexes.Length; i++)
        {
            if(ActivatedIndex.IndexOf(token.NeighborIndexes[i]) > -1)
            {
               StartCoroutine(DrawLine(token.transform.position, GetPositionBasedOnIndex(token.NeighborIndexes[i])));
            }
        }

    }


    IEnumerator DrawLine(Vector2 StartPoint, Vector2 EndPoint)
    {
        print("StartPoint: " + StartPoint);
        print("EndPoint: " + EndPoint);
       
        yield return null;
        // After All Lines Drawn
        if(isAllTokenGathered)
            OnAllLineDrawn?.Invoke();

    }

    Vector2 GetPositionBasedOnIndex(int Index)
    {
        Vector2 result = Vector2.zero;

        for (int i = 0; i < allTokens.Count; i++)
        {
            if(allTokens[i].TokenIndex == Index)
            {
                result = allTokens[i].transform.position;
                break;
            }
        }
        return result;
    }

    void OnDisable()
    {
        Token.OnTokenStart -= registerToken;
    }


    public static Action OnAllTokensActivated;
    public static Action OnAllLineDrawn;
}
