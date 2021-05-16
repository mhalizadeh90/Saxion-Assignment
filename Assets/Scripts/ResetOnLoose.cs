using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnLoose : MonoBehaviour
{
    [SerializeField] float DelayToReset;
    [SerializeField] float CameraResetSpeed;
    [SerializeField] GameObject Player;
    [SerializeField] Transform MapParent;

    Vector3 mapDefaultRotation;
    Vector2 playerDefaultPosition;

    WaitForSeconds delayForReset;

    void Awake()
    {
        if (!Player)    Player = FindObjectOfType<GatherPhysicInfo>().gameObject;
        if (!MapParent)    MapParent = FindObjectOfType<RotatorManager>().transform;
       
        delayForReset = new WaitForSeconds(DelayToReset);

        mapDefaultRotation = MapParent.transform.rotation.eulerAngles;
        playerDefaultPosition = Player.transform.position;
    }

    void OnEnable()
    {
        SpikeCollisionEventTrigger.OnPlayerHitSpikes += ResetGame;
    }

    void ResetGame()
    {
        StartCoroutine(ResetToDefault());
    }


    IEnumerator ResetToDefault()
    {
        Player.SetActive(false);
        
        yield return delayForReset;

        #region Map Reset Rotation

        while (Vector3.Distance(mapDefaultRotation,MapParent.transform.rotation.eulerAngles) > 0.1f)
        {
            MapParent.transform.rotation = Quaternion.Euler(
                Vector3.Lerp (MapParent.transform.rotation.eulerAngles, mapDefaultRotation, Time.deltaTime * CameraResetSpeed)
                );
            yield return null;
        }

        MapParent.transform.rotation = Quaternion.Euler(mapDefaultRotation);

        #endregion

        #region Player Reset To Default Position and Enable

        Player.transform.position = playerDefaultPosition;
        Player.SetActive(true);

        #endregion
    }

    void OnDisable()
    {
        SpikeCollisionEventTrigger.OnPlayerHitSpikes -= ResetGame;
    }

}


