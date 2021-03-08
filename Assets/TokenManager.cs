using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenManager : MonoBehaviour
{
    List<Token> allTokens;
    List<int> ActivatedIndex;
    bool isAllTokenGathered;

    void Awake()
    {
        allTokens = new List<Token>();
        ActivatedIndex = new List<int>();
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
        isAllTokenGathered = (ActivatedIndex.Count >= allTokens.Count);

        for (int i = 0; i < token.NeighborIndexes.Length; i++)
        {
            TokenNeighbour tokenNeighbour = token.NeighborIndexes[i];

            if (isNeighbourTokenActive(tokenNeighbour.NeighbourIndex))
               DrawLine(tokenNeighbour.NeighbourConnectLine);
        }

        if (isAllTokenGathered)
            OnAllTokensActivated?.Invoke();
    }

    bool isNeighbourTokenActive(int NeighbourIndex)
    {
        return (ActivatedIndex.IndexOf(NeighbourIndex) > -1);
    }

    void DrawLine(GameObject connectLineToDraw)
    {
        connectLineToDraw.SetActive(true);
        //TODO: ADD SFX, PARTICLE OR ETC TO JUICY DRAWING LINE
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
}
