package com.example.translatorandroid.Adapter;

import android.annotation.SuppressLint;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.translatorandroid.Fragment.FavoriteFragment;
import com.example.translatorandroid.Model.Favorite;
import com.example.translatorandroid.Model.FavoriteRequest;
import com.example.translatorandroid.Model.History;
import com.example.translatorandroid.Model.HistoryRequest;
import com.example.translatorandroid.R;
import com.example.translatorandroid.Service.ServicesAPI;
import com.example.translatorandroid.databinding.ItemHistoryBinding;

import java.time.LocalDateTime;
import java.util.Date;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class HistoryAdapter extends RecyclerView.Adapter<HistoryAdapter.HistoryViewHolder> {
    List<History> historyList;
    int uid;
    public HistoryAdapter(List<History> historyList, int uid) {
        this.historyList = historyList;
        this.uid = uid;
    }
    @NonNull
    @Override
    public HistoryViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_history, parent, false);
        return new HistoryViewHolder(ItemHistoryBinding.bind(view));
    }

    @Override
    public void onBindViewHolder(@NonNull HistoryViewHolder holder, int position) {
        History history = historyList.get(position);
        ItemHistoryBinding binding = ItemHistoryBinding.bind(holder.itemView);
        String lang = history.FROMLANGUAGE + " -> " + history.TOLANGUAGE;
        binding.tvLang.setText(lang);
        binding.tvSourceLang.setText(history.ORIGINALWORD);
        binding.tvTargetLang.setText(history.TRANSLATEDWORD);
        if(history.ISFAVORITE) {
            binding.btnFavorite.setImageResource(R.drawable.baseline_bookmark_24);
        } else {
            binding.btnFavorite.setImageResource(R.drawable.baseline_bookmark_border_24);
        }
        binding.btnFavorite.setOnClickListener(new View.OnClickListener() {
            @SuppressLint("NewApi")
            @Override
            public void onClick(View v) {
                if (history.ISFAVORITE)
                {
                    binding.btnFavorite.setImageResource(R.drawable.baseline_bookmark_border_24);
                    history.ISFAVORITE = false;
                    FavoriteRequest favorite = new FavoriteRequest();
                    favorite.originalword = history.ORIGINALWORD;
                    favorite.translatedword = history.TRANSLATEDWORD;
                    favorite.fromlanguage = history.FROMLANGUAGE;
                    favorite.tolanguage = history.TOLANGUAGE;
                    favorite.timesave = Date.from(LocalDateTime.now().toInstant(java.time.ZoneOffset.UTC));
                    favorite.wordidhis = history.WORDID;
                    favorite.uid = uid;
                    HistoryRequest historyRequest = new HistoryRequest();
                    historyRequest.wordid = history.WORDID;
                    historyRequest.uid = 4;
                    historyRequest.isfavorite = false;
                    ServicesAPI.servicesAPI.updateHistory(historyRequest).enqueue(new Callback<History>() {
                        @Override
                        public void onResponse(Call<History> call, Response<History> response) {
                            notifyDataSetChanged();
                        }

                        @Override
                        public void onFailure(Call<History> call, Throwable throwable) {

                        }
                    });
                    ServicesAPI.servicesAPI.deleteFavoriteHistory(favorite).enqueue(new Callback<Favorite>() {
                        @SuppressLint("NotifyDataSetChanged")
                        @Override
                        public void onResponse(Call<Favorite> call, Response<Favorite> response) {
                            if(FavoriteFragment.adapter != null)
                            {
                                FavoriteFragment.adapter.notifyDataSetChanged();
                                notifyDataSetChanged();
                            }
                        }

                        @Override
                        public void onFailure(Call<Favorite> call, Throwable throwable) {

                        }
                    });
                }
                else
                {
                    binding.btnFavorite.setImageResource(R.drawable.baseline_bookmark_24);
                    history.ISFAVORITE = true;
                    FavoriteRequest favorite = new FavoriteRequest();
                    favorite.originalword = history.ORIGINALWORD;
                    favorite.translatedword = history.TRANSLATEDWORD;
                    favorite.fromlanguage = history.FROMLANGUAGE;
                    favorite.tolanguage = history.TOLANGUAGE;
                    favorite.timesave = Date.from(LocalDateTime.now().toInstant(java.time.ZoneOffset.UTC));
                    favorite.wordidhis = history.WORDID;
                    favorite.uid = 4;
                    ServicesAPI.servicesAPI.saveFavorite(favorite).enqueue(new Callback<Favorite>() {
                        @SuppressLint("NotifyDataSetChanged")
                        @Override
                        public void onResponse(Call<Favorite> call, Response<Favorite> response) {
                            Log.e("Success", "Success");
                            notifyDataSetChanged();
                        }

                        @Override
                        public void onFailure(Call<Favorite> call, Throwable throwable) {
                            Log.e("Error", throwable.toString());
                        }
                    });
                }
            }
        });
        binding.btnDelete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                HistoryRequest historyRequest = new HistoryRequest();
                historyRequest.wordid = history.WORDID;
                historyRequest.uid = 4;
                historyList.remove(history);
                notifyDataSetChanged();
                ServicesAPI.servicesAPI.deleteHistory(historyRequest).enqueue(new Callback<History>() {
                    @SuppressLint("NotifyDataSetChanged")
                    @Override
                    public void onResponse(Call<History> call, Response<History> response) {

                    }

                    @Override
                    public void onFailure(Call<History> call, Throwable throwable) {

                    }
                });
            }
        });
    }

    @Override
    public int getItemCount() {
        return historyList.size();
    }

    class HistoryViewHolder extends RecyclerView.ViewHolder {
        public TextView tvLang, tvSourceLang, tvTargetLang;
        public ImageButton btnFavorite, btnDelete;
        public HistoryViewHolder(@NonNull ItemHistoryBinding itemView) {
            super(itemView.getRoot());
            tvLang = itemView.tvLang;
            tvSourceLang = itemView.tvSourceLang;
            tvTargetLang = itemView.tvTargetLang;
            btnFavorite = itemView.btnFavorite;
            btnDelete = itemView.btnDelete;
        }
    }
}
