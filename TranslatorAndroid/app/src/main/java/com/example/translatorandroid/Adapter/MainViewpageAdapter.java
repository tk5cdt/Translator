package com.example.translatorandroid.Adapter;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;
import androidx.fragment.app.FragmentManager;
import androidx.lifecycle.Lifecycle;
import androidx.viewpager2.adapter.FragmentStateAdapter;

import com.example.translatorandroid.Fragment.SavedFragment;
import com.example.translatorandroid.Fragment.TranslateFragment;

public class MainViewpageAdapter extends FragmentStateAdapter {
    public MainViewpageAdapter(@NonNull FragmentActivity fragmentActivity) {
        super(fragmentActivity);
    }

    public MainViewpageAdapter(@NonNull Fragment fragment) {
        super(fragment);
    }

    public MainViewpageAdapter(@NonNull FragmentManager fragmentManager, @NonNull Lifecycle lifecycle) {
        super(fragmentManager, lifecycle);
    }

    @NonNull
    @Override
    public Fragment createFragment(int position) {
        switch (position){
            case 0:
                return new TranslateFragment();
            case 1:
                return new SavedFragment();
            default:
                return new TranslateFragment();
        }
    }

    /**
     * Returns the total number of items in the data set held by the adapter.
     *
     * @return The total number of items in this adapter.
     */
    @Override
    public int getItemCount() {
        return 2;
    }
}
