package com.example.translatorandroid.ShareReferences;

import android.content.Context;

import com.example.translatorandroid.Model.Account;
import com.google.gson.Gson;

public class DataManager {

    private static final String PREF_OBJECT_ACCOUNT = "Translator";
    private static DataManager instance;
    private SharedReference sharedReference;

    public static void init(Context context)
    {
        instance = new DataManager();
        instance.sharedReference = new SharedReference(context);
    }

    public static DataManager getInstance()
    {
        if(instance == null)
        {
            instance = new DataManager();
        }
        return instance;
    }
    public static void SetAccount(Account account)
    {
        Gson gson = new Gson();
        String json = gson.toJson(account);
        DataManager.getInstance().sharedReference.putString(PREF_OBJECT_ACCOUNT, json);
    }

    public static Account GetAccount()
    {
        Gson gson = new Gson();
        String json = DataManager.getInstance().sharedReference.getString(PREF_OBJECT_ACCOUNT);
        return gson.fromJson(json, Account.class);
    }

}
