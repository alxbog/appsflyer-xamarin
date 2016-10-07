mkdir sharpie_output
cd sharpie_output

sharpie pod init iphoneos AppsFlyer-SDK
sharpie bind -o Binding -sdk iphoneos -n AppsFlyer Pods/AppsFlyer-SDK/AppsFlyerTracker.h

cd ..
cp sharpie_output/Binding/ApiDefinitions.cs ApiDefinition.cs
cp sharpie_output/Binding/StructsAndEnums.cs Structs.cs

rm -rf libAppsFlyerLib.a
cp -r sharpie_output/Pods/AppsFlyer-SDK/libAppsFlyerLib.a .

rm -rf sharpie_output