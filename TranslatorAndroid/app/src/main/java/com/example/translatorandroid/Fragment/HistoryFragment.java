package com.example.translatorandroid.Fragment;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.translatorandroid.R;
import com.example.translatorandroid.databinding.FragmentHistoryBinding;

public class HistoryFragment extends Fragment {
    FragmentHistoryBinding binding;
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

    }
}