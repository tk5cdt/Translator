package com.example.translatorandroid.Service;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public interface ServicesAPI {
    Gson gson = new GsonBuilder()
            .setDateFormat("yyyy-MM-dd' 'HH:mm:ss")
            .create();

    ServicesAPI servicesAPI = new Retrofit.Builder()
            .baseUrl("http://192.168.1.4:3000/api/")
            .addConverterFactory(GsonConverterFactory.create(gson))
            .build()
            .create(ServicesAPI.class);

}
