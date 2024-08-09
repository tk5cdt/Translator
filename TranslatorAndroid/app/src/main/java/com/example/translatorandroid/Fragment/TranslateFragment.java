package com.example.translatorandroid.Fragment;

import static android.app.Activity.RESULT_OK;

import android.content.ActivityNotFoundException;
import android.content.Intent;
import android.os.Build;
import android.os.Bundle;

import androidx.activity.result.ActivityResultLauncher;
import androidx.activity.result.contract.ActivityResultContracts;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import android.os.Handler;
import android.os.Looper;
import android.speech.RecognizerIntent;
import android.speech.tts.TextToSpeech;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Toast;

import com.example.translatorandroid.Activity.MainActivity;
import com.example.translatorandroid.Model.Account;
import com.example.translatorandroid.Model.History;
import com.example.translatorandroid.Model.HistoryRequest;
import com.example.translatorandroid.Model.Language;
import com.example.translatorandroid.Model.Translate;
import com.example.translatorandroid.Model.TranslateResponse;
import com.example.translatorandroid.R;
import com.example.translatorandroid.Service.LanguageAPI;
import com.example.translatorandroid.Service.ServicesAPI;
import com.example.translatorandroid.Service.TranslateAPI;
import com.example.translatorandroid.databinding.FragmentTranslateBinding;
import com.google.errorprone.annotations.Var;

import java.time.LocalDateTime;
import java.time.ZoneOffset;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.Objects;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class TranslateFragment extends Fragment {

    FragmentTranslateBinding binding;
    Handler handler = new Handler(Looper.getMainLooper());
    Runnable translateRunnable;
    TextToSpeech textToSpeech;
    String lang;
    String langDetected;
    private static final int RESULT_SPEECH = 1;

    private final ActivityResultLauncher<Intent> speechRecognizerLauncher = registerForActivityResult(
            new ActivityResultContracts.StartActivityForResult(),
            result -> {
                if (result.getResultCode() == RESULT_OK && result.getData() != null) {
                    ArrayList<String> text = result.getData().getStringArrayListExtra(RecognizerIntent.EXTRA_RESULTS);
                    if (text != null && !text.isEmpty()) {
                        binding.edtOriginalWord.setText(text.get(0));
                    }
                }
            }
    );
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
                if(s != null && !s.toString().trim().isEmpty()){
                    translateRunnable = new Runnable() {
                        @Override
                        public void run() {
                            translate(s.toString());
                        }
                    };
                    handler.postDelayed(translateRunnable, 2000);
                }
                else{
                    binding.tvTranslatedWord.setText("");
                }
            }
        });

        binding.spOriginalLang.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                if(!binding.edtOriginalWord.getText().toString().trim().isEmpty()){
                    translate(binding.edtOriginalWord.getText().toString());
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        binding.spTranslatedLang.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                if(!binding.edtOriginalWord.getText().toString().trim().isEmpty()){
                    translate(binding.edtOriginalWord.getText().toString());
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });


        textToSpeech = new TextToSpeech(getContext(), new TextToSpeech.OnInitListener() {
            @Override
            public void onInit(int status) {
                if(status!=TextToSpeech.ERROR){

                }
            }
        });

        binding.ibtnOriginalWord.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!binding.edtOriginalWord.getText().toString().isEmpty()) {
                    Locale locale = getLocaleFromLanguageCode(lang);
                    if (locale != null) {
                        textToSpeech.setLanguage(locale);
                        textToSpeech.speak(binding.edtOriginalWord.getText().toString(), TextToSpeech.QUEUE_FLUSH, null, null);
                    }
                }
            }
        });

        binding.ibtnTranslatedWord.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!binding.tvTranslatedWord.getText().toString().isEmpty()) {
                    Locale locale = getLocaleFromLanguageCode(((Language) binding.spTranslatedLang.getSelectedItem()).code);
                    if (locale != null) {
                        textToSpeech.setLanguage(locale);
                        textToSpeech.speak(binding.tvTranslatedWord.getText().toString(), TextToSpeech.QUEUE_FLUSH, null, null);
                    }
                }
            }
        });

        binding.ibtnSpeak.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(RecognizerIntent.ACTION_RECOGNIZE_SPEECH);
                intent.putExtra(RecognizerIntent.EXTRA_LANGUAGE_MODEL, RecognizerIntent.LANGUAGE_MODEL_FREE_FORM);
                intent.putExtra(RecognizerIntent.EXTRA_LANGUAGE, "en-US");
                try {
                    speechRecognizerLauncher.launch(intent);
                } catch (Exception e) {
                    Toast.makeText(getContext(), "Your device doesn't support Speech to Text", Toast.LENGTH_SHORT).show();
                    e.printStackTrace();
                }
            }
        });

        return view;
    }

    private Locale getLocaleFromLanguageCode(String languageCode) {
        Map<String, Locale> localeMap = new HashMap<>();
        localeMap.put("en", Locale.ENGLISH);
        localeMap.put("fr", Locale.FRENCH);
        localeMap.put("de", Locale.GERMAN);
        localeMap.put("it", Locale.ITALIAN);
        localeMap.put("zh",Locale.CHINESE);
        localeMap.put("ja", Locale.JAPANESE);
        localeMap.put("ko", Locale.KOREAN);
        localeMap.put("es", new Locale("es", "ES"));

        return localeMap.getOrDefault(languageCode, Locale.ENGLISH); // Default to English if not found
    }

    private void loadSpFromLanguage(){
        LanguageAPI.languageAPI.getLanguages().enqueue(new Callback<List<Language>>() {
            @Override
            public void onResponse(Call<List<Language>> call, Response<List<Language>> response) {
                if(response.isSuccessful() && response.body() != null){
                    List<Language> languages = new ArrayList<>();

                    Language detectLanguage = new Language();
                    detectLanguage.code ="auto";
                    detectLanguage.name="Detect language";
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

    private void loadAlternative(List<String> alternatives){
        binding.tvAlternatives.setText("");
        if(alternatives != null){
            StringBuilder alternativesText = new StringBuilder();
            int count = 0;

            for (String item : alternatives) {
                alternativesText.append(++count).append(". ").append(item).append("\n");
            }

            binding.tvAlternatives.setText(alternativesText.toString().trim());
        }
        else {
            binding.tvAlternatives.setText("");
        }
    }

    private void translate(String q){
        Translate content = new Translate();
        content.setQ(q);
        content.setSource(((Language) binding.spOriginalLang.getSelectedItem()).code);
        content.setTarget(((Language) binding.spTranslatedLang.getSelectedItem()).code);
        content.setFormat("text");
        content.setAlternatives(3);

        TranslateAPI.translateAPI.sendTranslateContent(content).enqueue(new Callback<TranslateResponse>() {
            @Override
            public void onResponse(Call<TranslateResponse> call, Response<TranslateResponse> response) {
                if (response.isSuccessful() && response.body() != null) {
                    String translatedText = response.body().getTranslatedText();
                    binding.tvTranslatedWord.setText(translatedText);

                    if(binding.spOriginalLang.getSelectedItemPosition() == 0){
                        lang = response.body().detectedLanguage.getLanguage();
                        List<Language> languages = new ArrayList<>();
                        ArrayAdapter<Language> adapter = (ArrayAdapter<Language>) binding.spOriginalLang.getAdapter();

                        for (int i = 0; i < adapter.getCount(); i++) {
                            languages.add(adapter.getItem(i));
                        }

                        for (Language language : languages) {
                            if (language.code.equals(lang)) {
                                langDetected = language.name;
                                binding.txtDetectedLanguage.setText("Detected Language: " + langDetected);
                                binding.txtConfidence.setText("Confidence: " + response.body().detectedLanguage.getConfidence() + "%");

                                Account account = ((MainActivity) requireActivity()).account;
                                if (account != null) {
                                    HistoryRequest historyRequest = new HistoryRequest();
                                    historyRequest.originalword = q;
                                    if (binding.spOriginalLang.getSelectedItemPosition() == 0) {
                                        //String dl = binding.txtDetectedLanguage.getText().toString();
                                       // String ld =dl.replace("Detected Language: ","");
                                        historyRequest.fromlanguage = langDetected;
                                    } else {
                                        historyRequest.fromlanguage = ((Language) binding.spOriginalLang.getSelectedItem()).name;
                                    }
                                    historyRequest.isfavorite = false;
                                    historyRequest.tolanguage = ((Language) binding.spTranslatedLang.getSelectedItem()).name;
                                    historyRequest.translatedword = binding.tvTranslatedWord.getText().toString();
                                    historyRequest.uid = ((MainActivity) requireActivity()).account.getUID();
                                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                                        historyRequest.timesave = Date.from(LocalDateTime.now().toInstant(ZoneOffset.UTC));
                                    }
                                    ServicesAPI.servicesAPI.saveHistory(historyRequest).enqueue(new Callback<History>() {
                                        @Override
                                        public void onResponse(Call<History> call, Response<History> response) {

                                        }

                                        @Override
                                        public void onFailure(Call<History> call, Throwable throwable) {

                                        }
                                    });
                                }
                                break;
                            }
                        }
                    }
                    loadAlternative(response.body().getAlternatives());

                }
                else {
                    binding.tvTranslatedWord.setText("");
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