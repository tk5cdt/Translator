package com.example.translatorandroid.Service;

import com.example.translatorandroid.Model.Language;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import java.util.List;

import retrofit2.Call;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import retrofit2.http.GET;
import retrofit2.http.Query;

public interface LanguageAPI {
    Gson gson = new GsonBuilder()
            .setDateFormat("yyyy-MM-dd' 'HH:mm:ss")
            .create();

    LanguageAPI languageAPI = new Retrofit.Builder()
            .baseUrl("https://libretranslate.com/")
            .addConverterFactory(GsonConverterFactory.create(gson))
            .build()
            .create(LanguageAPI.class);

    @GET("languages")
    Call<List<Language>> getLanguages();
}
