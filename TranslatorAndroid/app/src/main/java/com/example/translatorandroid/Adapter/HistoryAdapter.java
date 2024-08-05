package com.example.translatorandroid.Adapter;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.translatorandroid.Model.History;
import com.example.translatorandroid.R;
import com.example.translatorandroid.databinding.ItemHistoryBinding;

import java.util.List;

public class HistoryAdapter extends RecyclerView.Adapter<HistoryAdapter.HistoryViewHolder> {
    List<History> historyList;
    public HistoryAdapter(List<History> historyList) {
        this.historyList = historyList;
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
