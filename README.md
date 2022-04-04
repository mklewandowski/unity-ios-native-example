# unity-ios-native-example
An example project showing integration of iOS native code in Unity. This project is created using Unity version 2020.3.10f1. This project uses native iOS code to show an alert; store, modify, and retrieve a static variable from a native iOS class; and perform basic location and network actions.

## Credits
Code and scene structure is based on this tutorial:
https://www.youtube.com/watch?v=krerK59xVPI

## Building
When building and deploying in Xcode, the following steps are needed:
- in Signing and Capabilities, set the provisioning profile for All configurations
- add Access WiFi Information and Wireless Accessory Configuration for All configurations
- In Targets > UnityFramework > Build Phases > Link Binary With Libraries, add CoreLocation and NetworkExtension frameworks
- Add the following to the info.plist:
<key>NSLocationAlwaysAndWhenInUseUsageDescription</key>
<string>Gather location updates to get SSID</string>
<key>NSLocationWhenInUseUsageDescription</key>
<string>Gather location updates to get SSID</string>
