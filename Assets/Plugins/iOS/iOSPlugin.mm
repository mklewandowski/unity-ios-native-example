#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import <CoreLocation/CoreLocation.h>
#import <NetworkExtension/NetworkExtension.h>
#import <NetworkExtension/NEHotspotNetwork.h>

extern UIViewController *UnityGetGLViewController();

@interface iOSPlugin : NSObject 

@end

@implementation iOSPlugin

static int value;
static int signalStrength;
static NSString *strSSID;

+(void)alertView:(NSString *)title addMessage:(NSString *)message
{
    UIAlertController *alert = [UIAlertController alertControllerWithTitle:title
        message:message preferredStyle:UIAlertControllerStyleAlert];

    UIAlertAction *defaultAction = [UIAlertAction actionWithTitle:@"OK" style:UIAlertActionStyleDefault
        handler:^(UIAlertAction *action){}];

    [alert addAction:defaultAction];
    [UnityGetGLViewController() presentViewController:alert animated:YES completion:nil];
}

+(void)initLocation
{
    CLLocationManager *locationManager = [[CLLocationManager alloc] init];
    [locationManager requestWhenInUseAuthorization];
}

+(void)fetchNetworkInfo
{
    strSSID = @"calling for fetchNetworkInfo";
    signalStrength = 0;

    if (@available(iOS 14.0, *)) {
        [NEHotspotNetwork fetchCurrentWithCompletionHandler:^(NEHotspotNetwork * _Nullable currentNetwork) {
            strSSID = [currentNetwork SSID];
            signalStrength = [currentNetwork signalStrength];
            NSLog(@"Value of signalStrength = %d", signalStrength);
            NSLog(@"Value of strSSID = %@", strSSID);
        }];
    } else {
        strSSID = @"wrong iOS version";
    }
    NSLog(@"Value of strSSID = %@", strSSID);
}

+(int)getSignalStrength
{
    return signalStrength;
}

+(const char *)getSSID
{
    if (strSSID == NULL)
        return NULL;

    const char* nsStringUtf8 = [strSSID UTF8String];
    //create a null terminated C string on the heap so that our string's memory isn't wiped out right after method's return
    char* cString = (char*)malloc(strlen(nsStringUtf8) + 1);
    strcpy(cString, nsStringUtf8);

    return cString;
}

+(void)incrementValue
{
    value = value + 1;
}

+(int)getValue
{
    return value;
}

@end

extern "C"
{
    void _ShowAlert(const char *title, const char *message)
    {
        [iOSPlugin alertView:[NSString stringWithUTF8String:title] addMessage:[NSString stringWithUTF8String:message]];
    }
    void _IncrementValue()
    {
        [iOSPlugin incrementValue];
    }
    int _GetValue()
    {
        int val = [iOSPlugin getValue];
        return val;
    }
    void _InitLocation()
    {
        [iOSPlugin initLocation];
    }
    void _FetchNetworkInfo()
    {
        [iOSPlugin fetchNetworkInfo];
    }
    int _GetSignalStrength()
    {
        int val = [iOSPlugin getSignalStrength];
        return val;
    }
    const char * _GetSSID()
    {
        const char * val = [iOSPlugin getSSID];
        return val;
    }
}
