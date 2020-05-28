using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAdDisplayObject : MonoBehaviour
{

    public string myGameIdAndroid = "3620727";
    public string myGameIdIos = "3620726";
    public string myVideoPlacement = "rewardedVideo";
    public bool adStarted;
    public bool adCompleted;
    public bool testMode = true;

    ShowOptions options = new ShowOptions();

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_IOS
        Advertisement.Initialize(myGameIdIOS, testMode);
#else
        Advertisement.Initialize(myGameIdAndroid, testMode);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        if (Advertisement.isInitialized && Advertisement.IsReady(myVideoPlacement) && !adStarted)
        {
            options.resultCallback = AdDisplayResultCallback;
            Advertisement.Show(myVideoPlacement, options);
            adStarted = true;
        }
    }
    private void AdDisplayResultCallback(ShowResult obj)
    {
        adCompleted = obj == ShowResult.Finished;
    }
}
