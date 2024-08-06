package com.example.translatorandroid.Service;

import com.example.translatorandroid.Model.Translate;
import com.example.translatorandroid.Model.TranslateResponse;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import java.util.List;
import java.util.concurrent.TimeUnit;

import okhttp3.OkHttp;
import okhttp3.OkHttpClient;
import retrofit2.Call;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import retrofit2.http.Body;
import retrofit2.http.Field;
import retrofit2.http.FormUrlEncoded;
import retrofit2.http.GET;
import retrofit2.http.POST;

public interface TranslateAPI {
    Gson gson = new GsonBuilder()
            .setDateFormat("yyyy-MM-dd' 'HH:mm:ss")
            .create();

    OkHttpClient client = new OkHttpClient.Builder()
            .connectTimeout(2, TimeUnit.MINUTES)
            .readTimeout(2, TimeUnit.MINUTES)
            .build();

    TranslateAPI translateAPI = new Retrofit.Builder()
            .baseUrl("http://192.168.1.20:3000/api/")
            .client(client)
            .addConverterFactory(GsonConverterFactory.create(gson))
            .build()
            .create(TranslateAPI.class);

    @POST("translate")
    Call<TranslateResponse> sendTranslateContent(@Body Translate translate);
}
