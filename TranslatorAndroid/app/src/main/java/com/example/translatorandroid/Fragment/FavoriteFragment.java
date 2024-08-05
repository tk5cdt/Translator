package com.example.translatorandroid.Fragment;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.translatorandroid.Adapter.FavoriteAdapter;
import com.example.translatorandroid.Model.Favorite;
import com.example.translatorandroid.Model.History;
import com.example.translatorandroid.R;
import com.example.translatorandroid.Service.ServicesAPI;
import com.example.translatorandroid.databinding.FragmentFavoriteBinding;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class FavoriteFragment extends Fragment {
    FragmentFavoriteBinding binding;
    List<Favorite> favoriteList;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_favorite, container, false);
        binding = FragmentFavoriteBinding.bind(view);
        return view;
    }

    @Override
    public void onResume() {
        super.onResume();
        ServicesAPI.servicesAPI.getFavorite(4).enqueue(new Callback<List<Favorite>>() {
            @Override
            public void onResponse(Call<List<Favorite>> call, Response<List<Favorite>> response) {
                if (response.body() == null) {
                    favoriteList = new ArrayList<>();
                } else {
                    favoriteList = response.body();
                }
                FavoriteAdapter adapter = new FavoriteAdapter(favoriteList);
                binding.rvFavorite.setAdapter(adapter);
                binding.rvFavorite.setLayoutManager(new LinearLayoutManager(getActivity(), LinearLayoutManager.VERTICAL, false));
            }

            @Override
            public void onFailure(Call<List<Favorite>> call, Throwable throwable) {

            }
        });
    }
}