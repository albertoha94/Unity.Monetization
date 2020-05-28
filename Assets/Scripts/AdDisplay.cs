using UnityEngine;
using UnityEngine.Advertisements;

public class AdDisplay : MonoBehaviour
{

    public string myGameIdAndroid = "3620727";
    public string myGameIdIos = "3620726";
    public string myVideoPlacement = "video";
    public bool adStarted;
    public bool testMode = true;

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
            Advertisement.Show(myVideoPlacement);
            adStarted = true;
        }
    }
}
