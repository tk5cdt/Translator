package com.example.translatorandroid.ShareReferences;

import android.content.Context;
import android.content.SharedPreferences;

public class SharedReference {
    private static final String MY_SHARED_REFERENCES = "Translator";
    private Context context;
    public SharedReference(Context context)
    {
        this.context = context;
    }

    public void putString(String key, String value)
    {
        SharedPreferences sharedPreferences = context.getSharedPreferences(MY_SHARED_REFERENCES, Context.MODE_PRIVATE);
        SharedPreferences.Editor editor = sharedPreferences.edit();
        editor.putString(key, value);
        editor.apply();
    }

    public String getString(String key)
    {
        SharedPreferences sharedPreferences = context.getSharedPreferences(MY_SHARED_REFERENCES, Context.MODE_PRIVATE);
        return sharedPreferences.getString(key, "");
    }
}
