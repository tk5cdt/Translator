package com.example.translatorandroid.Fragment;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.os.Handler;
import android.os.Looper;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;

import com.example.translatorandroid.Model.Language;
import com.example.translatorandroid.Model.Translate;
import com.example.translatorandroid.Model.TranslateResponse;
import com.example.translatorandroid.R;
import com.example.translatorandroid.Service.LanguageAPI;
import com.example.translatorandroid.Service.TranslateAPI;
import com.example.translatorandroid.databinding.FragmentTranslateBinding;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class TranslateFragment extends Fragment {

    FragmentTranslateBinding binding;
    Handler handler = new Handler(Looper.getMainLooper());
    Runnable translateRunnable;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_translate, container, false);
        binding = FragmentTranslateBinding.bind(view);
        loadSpFromLanguage();
        loadSpToLanguage();

        binding.edtOriginalWord.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                if (translateRunnable != null) {
                    handler.removeCallbacks(translateRunnable);
                }
            }

            @Override
            public void afterTextChanged(Editable s) {
                translateRunnable = new Runnable() {
                    @Override
                    public void run() {
                        translate(s.toString());
                    }
                };
                handler.postDelayed(translateRunnable, 1000);
            }
        });


        return view;
    }

    private void loadSpFromLanguage(){
        LanguageAPI.languageAPI.getLanguages().enqueue(new Callback<List<Language>>() {
            @Override
            public void onResponse(Call<List<Language>> call, Response<List<Language>> response) {
                if(response.isSuccessful() && response.body() != null){
                    List<Language> languages = new ArrayList<>();

                    Language detectLanguage = new Language();
                    detectLanguage.code ="auto";
                    detectLanguage.name="Detect lanuage";
                    languages.add(detectLanguage);

                    for (Language language : response.body()){
                        if(!language.code.equals("vi")){
                            languages.add(language);
                        }
                    }

                    ArrayAdapter<Language> adapter = new ArrayAdapter<>(getContext(), android.R.layout.simple_spinner_dropdown_item, languages);
                    binding.spOriginalLang.setAdapter(adapter);
                }
            }

            @Override
            public void onFailure(Call<List<Language>> call, Throwable throwable) {

            }
        });
    }

    private void loadSpToLanguage(){
        LanguageAPI.languageAPI.getLanguages().enqueue(new Callback<List<Language>>() {
            @Override
            public void onResponse(Call<List<Language>> call, Response<List<Language>> response) {
                if(response.isSuccessful() && response.body() != null){
                    List<Language> languages = new ArrayList<>();
                    for (Language language : response.body()){
                        if(!language.code.equals("vi")){
                            languages.add(language);
                        }
                    }

                    ArrayAdapter<Language> adapter = new ArrayAdapter<>(getContext(), android.R.layout.simple_spinner_dropdown_item, languages);
                    binding.spTranslatedLang.setAdapter(adapter);
                }
            }

            @Override
            public void onFailure(Call<List<Language>> call, Throwable throwable) {

            }
        });
    }

    private  void translate(String q){
        Translate content = new Translate();
        content.setQ(q);
        content.setSource(((Language) binding.spOriginalLang.getSelectedItem()).code);
        content.setTarget(((Language) binding.spTranslatedLang.getSelectedItem()).code);
        content.setFormat("text");
        content.setAlternatives(2);

        TranslateAPI.translateAPI.sendTranslateContent(content).enqueue(new Callback<TranslateResponse>() {
            @Override
            public void onResponse(Call<TranslateResponse> call, Response<TranslateResponse> response) {
                if (response.isSuccessful() && response.body() != null) {
                    String translatedText = response.body().getTranslatedText();
                    binding.tvTranslatedWord.setText(translatedText);

                }
//                Log.e("error", response.body().getTranslatedText());
            }

            @Override
            public void onFailure(Call<TranslateResponse> call, Throwable throwable) {
                Log.e("error:", throwable.toString());
            }
        });
    }
}