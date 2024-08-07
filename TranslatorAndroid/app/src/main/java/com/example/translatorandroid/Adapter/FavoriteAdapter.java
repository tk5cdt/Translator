package com.example.translatorandroid.Adapter;

import android.annotation.SuppressLint;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageButton;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.translatorandroid.Model.Favorite;
import com.example.translatorandroid.Model.FavoriteRequest;
import com.example.translatorandroid.Model.History;
import com.example.translatorandroid.Model.HistoryRequest;
import com.example.translatorandroid.R;
import com.example.translatorandroid.Service.ServicesAPI;
import com.example.translatorandroid.databinding.ItemHistoryBinding;

import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class FavoriteAdapter extends RecyclerView.Adapter<FavoriteAdapter.FavoriteViewHolder> {
    List<Favorite> favoriteList;
    int uid;
    public FavoriteAdapter(List<Favorite> favoriteList, int uid) {
        this.favoriteList = favoriteList;
        this.uid = uid;
    }
    @NonNull
    @Override
    public FavoriteViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_history, parent, false);
        return new FavoriteViewHolder(ItemHistoryBinding.bind(view));
    }

    @Override
    public void onBindViewHolder(@NonNull FavoriteViewHolder holder, @SuppressLint("RecyclerView") int position) {
        Favorite favorite = favoriteList.get(position);
        ItemHistoryBinding binding = ItemHistoryBinding.bind(holder.itemView);
        String lang = favorite.FROMLANGUAGE + " -> " + favorite.TOLANGUAGE;
        binding.tvLang.setText(lang);
        binding.tvSourceLang.setText(favorite.ORIGINALWORD);
        binding.tvTargetLang.setText(favorite.TRANSLATEDWORD);
        binding.btnDelete.setVisibility(View.VISIBLE);
        binding.btnFavorite.setVisibility(View.GONE);
        binding.btnDelete.setOnClickListener(new View.OnClickListener() {
            @SuppressLint("NotifyDataSetChanged")
            @Override
            public void onClick(View v) {
                FavoriteRequest favoriteRequest = new FavoriteRequest();
                favoriteRequest.wordid = favorite.WORDID;
                favoriteRequest.uid = uid;
                if(favorite.WORDIDHIS != 0) {
                    HistoryRequest n = new HistoryRequest();
                    n.wordid = favorite.WORDIDHIS;
                    n.uid = uid;
                    n.isfavorite = false;
                    ServicesAPI.servicesAPI.updateHistory(n).enqueue(new Callback<History>() {
                        @Override
                        public void onResponse(Call<History> call, Response<History> response) {

                        }

                        @Override
                        public void onFailure(Call<History> call, Throwable throwable) {

                        }
                    });
                }
                notifyDataSetChanged();
                ServicesAPI.servicesAPI.deleteFavorite(favoriteRequest).enqueue(new retrofit2.Callback<Favorite>() {
                    @Override
                    public void onResponse(retrofit2.Call<Favorite> call, retrofit2.Response<Favorite> response) {


                    }

                    @Override
                    public void onFailure(retrofit2.Call<Favorite> call, Throwable t) {

                    }
                });
                favoriteList.remove(position);
                notifyDataSetChanged();
            }
        });
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
