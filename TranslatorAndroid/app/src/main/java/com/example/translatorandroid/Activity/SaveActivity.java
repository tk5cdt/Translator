package com.example.translatorandroid.Activity;

import android.os.Bundle;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.example.translatorandroid.Adapter.HistoryViewpageAdapter;
import com.example.translatorandroid.R;
import com.example.translatorandroid.databinding.ActivitySaveBinding;
import com.google.android.material.tabs.TabLayout;
import com.google.android.material.tabs.TabLayoutMediator;

import java.util.Objects;

public class SaveActivity extends AppCompatActivity {
    ActivitySaveBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        binding = ActivitySaveBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());
        setSupportActionBar(binding.tbSave);
        Objects.requireNonNull(getSupportActionBar()).setTitle("Saved");
        binding.vpSave.setAdapter(new HistoryViewpageAdapter(this));
        new TabLayoutMediator(binding.tabs, binding.vpSave, (tab, position) -> {
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