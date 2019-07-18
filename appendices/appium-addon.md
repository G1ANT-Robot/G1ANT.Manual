# Appium Addon

Ever wanted to automate tasks on mobile apps? Now it’s possible with our Appium addon. Appium is a derivative of Selenium (browser automation package) and allows to communicate with mobile apps on a physical phone or emulated phone environment (virtual phone).

1. Download and install [Node.js](https://nodejs.org/en/download/).

2. Download and install [Android Studio](https://developer.android.com/studio).

3. Run Android Studio and in *Welcome to Android Studio* window click *Configure* button at the bottom. Click SDK Manager in the resulting list.

4. In *Android SDK* system settings window select an appropriate Android version: in case of a virtual phone, you can leave the latest version selected, but when you want to test Appium on a physical phone, be sure to check the Android version of your phone. Click *Apply* button to download and install this SDK. In case of any doubt, please refer to [this documentation](https://developer.android.com/studio/intro/update?utm_source=android-studio#sdk-manager).

5. Copy the path provided in the *Android SDK Location:* field of SDK Manager window:

   ![SDK Path](C:\Users\Darek\Desktop\git\G1ANT.Manual\-assets\sdk-path.png)

6. Open Windows System Properties: press **Win+Pause/Break** keyboard shortcut, click *Advanced system settings* in the left part of the displayed *System* window and on the resulting *Advanced* tab of *System Properties* window click *Environment Variables…* button.

7. In *System variables* section of *Environment Variables* window click *New…* button. The *New System Variable* dialog box will appear. Enter `ANDROID_HOME` as a variable name and paste the path copied from the SDK Manager into the *Variable value* field. Click OK to close the dialog box. Now *Environment Variables* window should contain this entry:

   ![](C:\Users\Darek\Desktop\git\G1ANT.Manual\-assets\environment-variables.png)

8. Restart your computer.

