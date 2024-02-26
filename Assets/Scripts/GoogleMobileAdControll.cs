using UnityEngine;
using System.Collections;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class GoogleMobileAdControll : MonoBehaviour {
    private BannerView bannerView;
    private InterstitialAd interstitial;
    public static bool showbanner;
    private string bannerID = "ca-app-pub-4128501448856864/4738594839";
    private string fullID = "ca-app-pub-4128501448856864/6215328035"; 
    private static GoogleMobileAdControll admobControll = null;
    public static GoogleMobileAdControll AdmobControll{get{ if (admobControll == null) admobControll = new GoogleMobileAdControll(); return admobControll;} }  
    
	// Use this for initialization   
 //   void Awake()
 //   {
 //       if (admobControll)
 //       {
 //           DestroyImmediate(this.gameObject);
 //           return;
 //       }
 //       admobControll = this;
 //       DontDestroyOnLoad(this.gameObject);
	//	RequestBanner();
	//}	
	
    #region BannerAD
    private void RequestBanner()
    {
        if (bannerView != null) 
        {
            bannerView.Destroy();
        }        
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(bannerID, AdSize.SmartBanner, AdPosition.Bottom);
        // Register for ad events.
        bannerView.AdLoaded += HandleAdLoaded;
        bannerView.AdFailedToLoad += HandleAdFailedToLoad;
        bannerView.AdOpened += HandleAdOpened;
        bannerView.AdClosing += HandleAdClosing;
        bannerView.AdClosed += HandleAdClosed;
        bannerView.AdLeftApplication += HandleAdLeftApplication;        
       // bannerView.LoadAd(createAdRequest());
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }

    public void ShowBanner()
    {        
        bannerView.Show();
    }
    public void HideBanner()
    {
        bannerView.Hide();
    }
    public void desBanner()
    {
        bannerView.Destroy();
    }
    #endregion

    #region InterstitialAD

    private void RequestInterstitial()
    {
        // Create an interstitial.
        if (interstitial != null)
        {
            interstitial.Destroy();
        }
        interstitial = new InterstitialAd(fullID);
        // Register for ad events.
        interstitial.AdLoaded += HandleInterstitialLoaded;
        interstitial.AdFailedToLoad += HandleInterstitialFailedToLoad;
        interstitial.AdOpened += HandleInterstitialOpened;
        interstitial.AdClosing += HandleInterstitialClosing;
        interstitial.AdClosed += HandleInterstitialClosed;
        interstitial.AdLeftApplication += HandleInterstitialLeftApplication;      
        // Load an interstitial ad.
        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);        
    }
    public void ShowInterstitial()
    {       
        RequestInterstitial();
    }
    public void LoadInterstitial()
    {
        RequestInterstitial();
    }
    
    #endregion

    #region Banner callback handlers

    public void HandleAdLoaded(object sender, EventArgs args)
    {        
        print("HandleAdLoaded event received.");
    }

    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleFailedToReceiveAd event received with message: " + args.Message);
    }

    public void HandleAdOpened(object sender, EventArgs args)
    {
        print("HandleAdOpened event received");
    }

    void HandleAdClosing(object sender, EventArgs args)
    {
        print("HandleAdClosing event received");
    }

    public void HandleAdClosed(object sender, EventArgs args)
    {
        bannerView.Destroy();
        print("HandleAdClosed event received");
    }

    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
        print("HandleAdLeftApplication event received");
    }

    #endregion

    #region Interstitial callback handlers

    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
       interstitial.Show();
        print("HandleInterstitialLoaded event received.");
    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
    }

    public void HandleInterstitialOpened(object sender, EventArgs args)
    {
        print("HandleInterstitialOpened event received");
    }

    void HandleInterstitialClosing(object sender, EventArgs args)
    {
        print("HandleInterstitialClosing event received");
    }

    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
        interstitial.Destroy();
        print("HandleInterstitialClosed event received");
    }

    public void HandleInterstitialLeftApplication(object sender, EventArgs args)
    {
        print("HandleInterstitialLeftApplication event received");
    }

    #endregion
}
