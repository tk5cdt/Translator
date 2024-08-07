package com.example.translatorandroid;

import android.app.Application;

import com.example.translatorandroid.ShareReferences.DataManager;

public class MyApplication extends Application {
    @Override
    public void onCreate() {
        super.onCreate();

        DataManager.init(getApplicationContext());
    }
}
