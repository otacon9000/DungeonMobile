using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    string _gameId = "4271931";
    string _myPlacementId = "Rewarded_Android";
    bool _areAdsAvailable;



    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, true);

        _areAdsAvailable = Advertisement.IsReady(_myPlacementId);
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == _myPlacementId)
        {
            _areAdsAvailable = true;
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:
                //add gems 
                GameManager.Instance.UpdatePlayerGemsFromAds(100);
                UIManager.Instance.adsButton.gameObject.SetActive(false);
                Debug.Log("Give me my money");
                break;
            case ShowResult.Skipped:
                Debug.Log("No video, no gems, don't skip");
                break;
            case ShowResult.Failed:
                Debug.Log(" video as failed, try again");
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }
    public void OnUnityAdsDidError(string message)
    {

    }




    public void ShowRewardedAd()
    {

        if (Advertisement.IsReady(_myPlacementId))
        {

            Advertisement.Show(_myPlacementId);
            _areAdsAvailable = false;
        }

    }
}
