mkdir sharpie_output
cd sharpie_output

sharpie pod init iphoneos9.3 AppsFlyerFramework
sharpie pod bind -n AppsFlyer

cd ..
cp sharpie_output/Binding/AppsFlyer_ApiDefinitions.cs ApiDefinition.cs
cp sharpie_output/Binding/AppsFlyer_StructsAndEnums.cs Structs.cs

rm -rf AppsFlyer.framework
cp -r sharpie_output/Binding/AppsFlyer.framework .

rm -rf sharpie_output