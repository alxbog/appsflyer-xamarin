using System;
using Foundation;
using ObjCRuntime;

namespace AppsFlyer
{
	// @protocol AppsFlyerTrackerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface AppsFlyerTrackerDelegate
	{
		// @optional -(void)onConversionDataReceived:(NSDictionary *)installData;
		[Export ("onConversionDataReceived:")]
		void OnConversionDataReceived (NSDictionary installData);

		// @optional -(void)onConversionDataRequestFailure:(NSError *)error;
		[Export ("onConversionDataRequestFailure:")]
		void OnConversionDataRequestFailure (NSError error);

		// @optional -(void)onAppOpenAttribution:(NSDictionary *)attributionData;
		[Export ("onAppOpenAttribution:")]
		void OnAppOpenAttribution (NSDictionary attributionData);

		// @optional -(void)onAppOpenAttributionFailure:(NSError *)error;
		[Export ("onAppOpenAttributionFailure:")]
		void OnAppOpenAttributionFailure (NSError error);
	}

	// @interface AppsFlyerTracker : NSObject
	[BaseType (typeof(NSObject))]
	interface AppsFlyerTracker
	{
		// +(AppsFlyerTracker *)sharedTracker;
		[Static]
		[Export ("sharedTracker")]
		AppsFlyerTracker SharedTracker { get; }

		// @property (nonatomic, setter = setCustomerUserID:, strong) NSString * customerUserID;
		[Export ("customerUserID", ArgumentSemantic.Strong)]
		string CustomerUserID { get; [Bind ("setCustomerUserID:")] set; }

		// @property (nonatomic, setter = setAdditionalData:, strong) NSDictionary * customData;
		[Export ("customData", ArgumentSemantic.Strong)]
		NSDictionary CustomData { get; [Bind ("setAdditionalData:")] set; }

		// @property (nonatomic, setter = setAppsFlyerDevKey:, strong) NSString * appsFlyerDevKey;
		[Export ("appsFlyerDevKey", ArgumentSemantic.Strong)]
		string AppsFlyerDevKey { get; [Bind ("setAppsFlyerDevKey:")] set; }

		// @property (nonatomic, setter = setAppleAppID:, strong) NSString * appleAppID;
		[Export ("appleAppID", ArgumentSemantic.Strong)]
		string AppleAppID { get; [Bind ("setAppleAppID:")] set; }

		// @property (nonatomic, strong) NSString * currencyCode;
		[Export ("currencyCode", ArgumentSemantic.Strong)]
		string CurrencyCode { get; set; }

		// @property BOOL disableAppleAdSupportTracking;
		[Export ("disableAppleAdSupportTracking")]
		bool DisableAppleAdSupportTracking { get; set; }

		// @property (nonatomic, setter = setIsDebug:) BOOL isDebug;
		[Export ("isDebug")]
		bool IsDebug { get; [Bind ("setIsDebug:")] set; }

		// @property (nonatomic, setter = setShouldCollectDeviceName:) BOOL shouldCollectDeviceName;
		[Export ("shouldCollectDeviceName")]
		bool ShouldCollectDeviceName { get; [Bind ("setShouldCollectDeviceName:")] set; }

		// @property BOOL deviceTrackingDisabled;
		[Export ("deviceTrackingDisabled")]
		bool DeviceTrackingDisabled { get; set; }

		// @property BOOL disableIAdTracking;
		[Export ("disableIAdTracking")]
		bool DisableIAdTracking { get; set; }

		[Wrap ("WeakDelegate")]
		AppsFlyerTrackerDelegate Delegate { get; set; }

		// @property (nonatomic, unsafe_unretained) id<AppsFlyerTrackerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, setter = setUseReceiptValidationSandbox:) BOOL useReceiptValidationSandbox;
		[Export ("useReceiptValidationSandbox")]
		bool UseReceiptValidationSandbox { get; [Bind ("setUseReceiptValidationSandbox:")] set; }

		// @property (nonatomic, setter = setUseUninstallSandbox:) BOOL useUninstallSandbox;
		[Export ("useUninstallSandbox")]
		bool UseUninstallSandbox { get; [Bind ("setUseUninstallSandbox:")] set; }

		// -(void)setUserEmails:(NSArray *)userEmails withCryptType:(EmailCryptType)type;
		[Export ("setUserEmails:withCryptType:")]
		void SetUserEmails (NSObject[] userEmails, EmailCryptType type);

		// -(void)trackAppLaunch;
		[Export ("trackAppLaunch")]
		void TrackAppLaunch ();

		// -(void)trackEvent:(NSString *)eventName withValue:(NSString *)value;
		[Export ("trackEvent:withValue:")]
		void TrackEvent (string eventName, string value);

		// -(void)trackEvent:(NSString *)eventName withValues:(NSDictionary *)values;
		[Export ("trackEvent:withValues:")]
		void TrackEvent (string eventName, NSDictionary values);

		// -(void)validateAndTrackInAppPurchase:(NSString *)productIdentifier price:(NSString *)price currency:(NSString *)currency transactionId:(NSString *)tranactionId additionalParameters:(NSDictionary *)params success:(void (^)(NSDictionary *))successBlock failure:(void (^)(NSError *, id))failedBlock __attribute__((availability(ios, introduced=7_0)));
		[Introduced(PlatformName.iOS, 7, 0)]
		[Export ("validateAndTrackInAppPurchase:price:currency:transactionId:additionalParameters:success:failure:")]
		void ValidateAndTrackInAppPurchase (string productIdentifier, string price, string currency, string tranactionId, NSDictionary @params, Action<NSDictionary> successBlock, Action<NSError, NSObject> failedBlock);

		// -(void)trackLocation:(double)longitude latitude:(double)latitude;
		[Export ("trackLocation:latitude:")]
		void TrackLocation (double longitude, double latitude);

		// -(NSString *)getAppsFlyerUID;
		[Export ("getAppsFlyerUID")]
		string AppsFlyerUID { get; }

		// -(void)loadConversionDataWithDelegate:(id<AppsFlyerTrackerDelegate>)delegate __attribute__((deprecated("")));
		[Export ("loadConversionDataWithDelegate:")]
		void LoadConversionDataWithDelegate (AppsFlyerTrackerDelegate @delegate);

		// -(void)handleOpenURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication __attribute__((deprecated("")));
		[Export ("handleOpenURL:sourceApplication:")]
		void HandleOpenURL (NSUrl url, string sourceApplication);

		// -(void)handleOpenURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication withAnnotation:(id)annotation __attribute__((deprecated("")));
		[Export ("handleOpenURL:sourceApplication:withAnnotation:")]
		void HandleOpenURL (NSUrl url, string sourceApplication, NSObject annotation);

		// -(void)handleOpenUrl:(NSURL *)url options:(NSDictionary *)options;
		[Export ("handleOpenUrl:options:")]
		void HandleOpenUrl (NSUrl url, NSDictionary options);

		// -(BOOL)continueUserActivity:(NSUserActivity *)userActivity restorationHandler:(void (^)(NSArray *))restorationHandler __attribute__((availability(ios, introduced=9_0)));
		[Introduced(PlatformName.iOS, 9, 0)]
		[Export ("continueUserActivity:restorationHandler:")]
		bool ContinueUserActivity (NSUserActivity userActivity, Action<NSArray> restorationHandler);

		// -(void)didUpdateUserActivity:(NSUserActivity *)userActivity __attribute__((availability(ios, introduced=9_0)));
		[Introduced(PlatformName.iOS, 9, 0)]
		[Export ("didUpdateUserActivity:")]
		void DidUpdateUserActivity (NSUserActivity userActivity);

		// -(void)handlePushNotification:(NSDictionary *)pushPayload;
		[Export ("handlePushNotification:")]
		void HandlePushNotification (NSDictionary pushPayload);

		// -(void)registerUninstall:(NSData *)deviceToken;
		[Export ("registerUninstall:")]
		void RegisterUninstall (NSData deviceToken);

		// -(NSString *)getSDKVersion;
		[Export ("getSDKVersion")]
		string SDKVersion { get; }
	}
}
