package com.example.translatorandroid.Activity;

import android.os.Bundle;
import android.view.MenuItem;

import androidx.activity.EdgeToEdge;
import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import androidx.viewpager2.widget.ViewPager2;

import com.example.translatorandroid.Adapter.MainViewpageAdapter;
import com.example.translatorandroid.R;
import com.example.translatorandroid.databinding.ActivityMainBinding;
import com.google.android.material.navigation.NavigationBarView;

public class MainActivity extends AppCompatActivity {

    ActivityMainBinding binding;
    MainViewpageAdapter adapter = new MainViewpageAdapter(this);
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        binding = ActivityMainBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        binding.vpMain.setAdapter(adapter);
        binding.vpMain.setUserInputEnabled(false);
        binding.navBotMain.setOnItemSelectedListener(new NavigationBarView.OnItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                if (item.getItemId() == R.id.miTranslate) {
                    binding.vpMain.setCurrentItem(0);
                    return true;
                } else {
                    binding.vpMain.setCurrentItem(1);
                    return true;
                }
            }
        });

        binding.vpMain.registerOnPageChangeCallback(new ViewPager2.OnPageChangeCallback() {
            @Override
            public void onPageSelected(int position) {
                super.onPageSelected(position);
                if (position == 0) {
                    binding.navBotMain.setSelectedItemId(R.id.miTranslate);
                } else if (position == 1) {
                    binding.navBotMain.setSelectedItemId(R.id.miSaved);
                }
            }
        });
    }
}