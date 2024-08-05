package com.example.translatorandroid.Adapter;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;
import androidx.viewpager2.adapter.FragmentStateAdapter;

import com.example.translatorandroid.Fragment.FavoriteFragment;
import com.example.translatorandroid.Fragment.HistoryFragment;

public class SavedViewpageAdapter extends FragmentStateAdapter {
    public SavedViewpageAdapter(@NonNull FragmentActivity fragmentActivity) {
        super(fragmentActivity);
    }

    @NonNull
    @Override
    public Fragment createFragment(int position) {
        switch (position){
            case 0:
                return new HistoryFragment();
            case 1:
                return new FavoriteFragment();
            default:
                return new HistoryFragment();
        }
    }

    @Override
    public int getItemCount() {
        return 2;
    }
}
