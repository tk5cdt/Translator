package com.example.translatorandroid.Service;

import com.example.translatorandroid.Model.Favorite;
import com.example.translatorandroid.Model.History;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import java.util.List;

import retrofit2.Call;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import retrofit2.http.GET;
import retrofit2.http.Query;

public interface ServicesAPI {
    Gson gson = new GsonBuilder()
            .setDateFormat("yyyy-MM-dd' 'HH:mm:ss")
            .create();

    ServicesAPI servicesAPI = new Retrofit.Builder()
            .baseUrl("http://192.168.1.4:3000/api/")
            .addConverterFactory(GsonConverterFactory.create(gson))
            .build()
            .create(ServicesAPI.class);
    @GET("gethistory")
    Call<List<History>> getHistory(@Query("uid") int uid);

    @GET("getfavorite")
    Call<List<Favorite>> getFavorite(@Query("uid") int uid);
}
