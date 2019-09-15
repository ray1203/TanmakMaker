using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class AdMobBanner : MonoBehaviour
{
    private readonly string unitId = "ca-app-pub-3105023249067875/8010561230";
    private readonly string test_unitId = "ca-app-pub-3940256099942544/6300978111";

    private readonly string test_deviceId = "8DE850D9410E5F9B";
    //ce10171a79c96e2304
    private BannerView banner;
    public AdPosition position;
    public bool activeBanner = false;
    private void Start() {
            InitAd();
    }
    private void InitAd() {
        //string id = Debug.isDebugBuild ? test_unitId : unitId;

        string id = unitId;
        //string id = test_unitId;
        MobileAds.Initialize(id);
        banner = new BannerView(id, AdSize.Banner, position);

        //AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice(test_deviceId).Build();
        AdRequest request = new AdRequest.Builder().Build();
        banner.LoadAd(request);
        
        ToggleAd(activeBanner);
        //banner.Show();
    }
    public void ToggleAd(bool active) {
        if (active) {
            banner.Show();
        } else {
            banner.Hide();
        }
    }
    void OnDestroy() {
        banner.Destroy();
    }
}
