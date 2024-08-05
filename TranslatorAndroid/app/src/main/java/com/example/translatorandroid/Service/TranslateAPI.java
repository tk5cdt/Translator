package com.example.translatorandroid.Service;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import java.util.List;

import retrofit2.Call;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;

public interface TranslateAPI {
    Gson gson = new GsonBuilder()
            .setDateFormat("yyyy-MM-dd' 'HH:mm:ss")
            .create();

    TranslateAPI translateAPI = new Retrofit.Builder()
            .baseUrl("http://192.168.1.4:5000/")
            .addConverterFactory(GsonConverterFactory.create(gson))
            .build()
            .create(TranslateAPI.class);
}
