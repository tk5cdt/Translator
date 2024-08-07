package com.example.translatorandroid.Service;

import com.example.translatorandroid.Model.Account;
import com.example.translatorandroid.Model.ClassSignUp;
import com.example.translatorandroid.Model.Favorite;
import com.example.translatorandroid.Model.FavoriteRequest;
import com.example.translatorandroid.Model.History;
import com.example.translatorandroid.Model.ClassLogin;
import com.example.translatorandroid.Model.HistoryRequest;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import java.util.List;

import retrofit2.Call;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Query;

public interface ServicesAPI {
    Gson gson = new GsonBuilder()
            .setDateFormat("yyyy-MM-dd' 'HH:mm:ss")
            .create();

    ServicesAPI servicesAPI = new Retrofit.Builder()
            .baseUrl("http://192.168.1.111:3000/api/")
            .addConverterFactory(GsonConverterFactory.create(gson))
            .build()
            .create(ServicesAPI.class);
    @GET("gethistory")
    Call<List<History>> getHistory(@Query("uid") int uid);

    @GET("getfavorite")
    Call<List<Favorite>> getFavorite(@Query("uid") int uid);

    @GET("getaccount")
    Call<List<Account>> getAccount();

    @POST("login")
    Call<Account> login(@Body ClassLogin classLogin);

    @POST("newaccount")
    Call<Account> signup(@Body ClassSignUp classSignUp);

    @POST("logout")
    Call<Account> logout();

    @POST("savehistory")
    Call<History> saveHistory(@Body HistoryRequest history);

    @POST("savefavorite")
    Call<Favorite> saveFavorite(@Body FavoriteRequest favorite);

    @POST("deletehistory")
    Call<History> deleteHistory(@Body HistoryRequest historyRequest);

    @POST("deletefavorite")
    Call<Favorite> deleteFavorite(@Body FavoriteRequest favoriteRequest);

    @POST("deletefavoritehistory")
    Call<Favorite> deleteFavoriteHistory(@Body FavoriteRequest favoriteRequest);

    @POST("updateHistory")
    Call<History> updateHistory(@Body HistoryRequest historyRequest);
}
