mkdir sharpie_output
cd sharpie_output

sharpie pod init iphoneos AppsFlyerFramework
sharpie bind -o Binding -sdk iphoneos -n AppsFlyer Pods/AppsFlyerFramework/AppsFlyerTracker.framework/Headers/AppsFlyerTracker.h -scope Pods/AppsFlyerFramework/AppsFlyerTracker.framework/Headers -c -F .

cd ..
cp sharpie_output/Binding/ApiDefinitions.cs ApiDefinition.cs
cp sharpie_output/Binding/StructsAndEnums.cs Structs.cs

rm -rf libAppsFlyerTracker.a
cp -r sharpie_output/Pods/AppsFlyerFramework/AppsFlyerTracker.framework/AppsFlyerTracker ./libAppsFlyerTracker.a

rm -rf sharpie_output