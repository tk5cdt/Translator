package com.example.translatorandroid.Fragment;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.translatorandroid.Adapter.HistoryAdapter;
import com.example.translatorandroid.Model.Account;
import com.example.translatorandroid.Model.History;
import com.example.translatorandroid.R;
import com.example.translatorandroid.Service.ServicesAPI;
import com.example.translatorandroid.databinding.FragmentHistoryBinding;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class HistoryFragment extends Fragment {
    FragmentHistoryBinding binding;
    List<History> historyList;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_history, container, false);
        binding = FragmentHistoryBinding.bind(view);
        return view;
    }

    @Override
    public void onResume() {
        super.onResume();
        ServicesAPI.servicesAPI.getHistory(4).enqueue(new Callback<List<History>>() {
            @Override
            public void onResponse(Call<List<History>> call, Response<List<History>> response) {
                if (response.body() == null) {
                    historyList = new ArrayList<>();
                } else {
                    historyList = response.body();
                }
                HistoryAdapter adapter = new HistoryAdapter(historyList);
                binding.rvHistory.setAdapter(adapter);
                binding.rvHistory.setLayoutManager(new LinearLayoutManager(getActivity(), LinearLayoutManager.VERTICAL, false));
            }

            @Override
            public void onFailure(Call<List<History>> call, Throwable t) {
                Log.e("Error", t.toString());
            }
        });


    }
}