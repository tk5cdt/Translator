package com.example.translatorandroid.Adapter;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageButton;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.translatorandroid.Model.Favorite;
import com.example.translatorandroid.R;
import com.example.translatorandroid.databinding.ItemHistoryBinding;

import java.util.List;

public class FavoriteAdapter extends RecyclerView.Adapter<FavoriteAdapter.FavoriteViewHolder> {
    List<Favorite> favoriteList;
    public FavoriteAdapter(List<Favorite> favoriteList) {
        this.favoriteList = favoriteList;
    }
    @NonNull
    @Override
    public FavoriteViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_history, parent, false);
        return new FavoriteViewHolder(ItemHistoryBinding.bind(view));
    }

    @Override
    public void onBindViewHolder(@NonNull FavoriteViewHolder holder, int position) {
        Favorite favorite = favoriteList.get(position);
        ItemHistoryBinding binding = ItemHistoryBinding.bind(holder.itemView);
        String lang = favorite.FROMLANGUAGE + " -> " + favorite.TOLANGUAGE;
        binding.tvLang.setText(lang);
        binding.tvSourceLang.setText(favorite.ORIGINALWORD);
        binding.tvTargetLang.setText(favorite.TRANSLATEDWORD);
        binding.btnDelete.setVisibility(View.VISIBLE);
        binding.btnFavorite.setVisibility(View.GONE);
    }

    @Override
    public int getItemCount() {
        return favoriteList.size();
    }

    class FavoriteViewHolder extends RecyclerView.ViewHolder {
        public TextView tvLang, tvSourceLang, tvTargetLang;
        public ImageButton btnFavorite, btnDelete;
        public FavoriteViewHolder(@NonNull ItemHistoryBinding itemView) {
            super(itemView.getRoot());
            tvLang = itemView.tvLang;
            tvSourceLang = itemView.tvSourceLang;
            tvTargetLang = itemView.tvTargetLang;
            btnFavorite = itemView.btnFavorite;
            btnDelete = itemView.btnDelete;
        }
    }
}
