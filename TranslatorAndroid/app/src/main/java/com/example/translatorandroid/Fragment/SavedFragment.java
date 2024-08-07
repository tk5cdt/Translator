package com.example.translatorandroid.Fragment;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.translatorandroid.Adapter.SavedViewpageAdapter;
import com.example.translatorandroid.R;
import com.example.translatorandroid.databinding.FragmentSavedBinding;
import com.google.android.material.tabs.TabLayoutMediator;

public class SavedFragment extends Fragment {
    FragmentSavedBinding binding;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_saved, container, false);
        binding = FragmentSavedBinding.bind(view);
        return view;
    }

    @Override
    public void onResume() {
        super.onResume();
        SavedViewpageAdapter savedViewpageAdapter = new SavedViewpageAdapter(getChildFragmentManager(), getLifecycle());
        binding.vpSaved.setAdapter(savedViewpageAdapter);
        new TabLayoutMediator(binding.tabs, binding.vpSaved, (tab, position) -> {
            switch (position){
                case 0:
                    tab.setText("History");
                    break;
                case 1:
                    tab.setText("Favorite");
                    break;
            }
        }).attach();
    }
}