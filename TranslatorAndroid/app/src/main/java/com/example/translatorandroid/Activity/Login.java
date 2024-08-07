package com.example.translatorandroid.Activity;

import android.content.Intent;
import android.os.Bundle;
import android.service.autofill.FieldClassification;
import android.text.InputType;
import android.text.method.HideReturnsTransformationMethod;
import android.text.method.PasswordTransformationMethod;
import android.util.Log;
import android.util.Patterns;
import android.view.MotionEvent;
import android.view.View;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.example.translatorandroid.Model.Account;
import com.example.translatorandroid.Model.ClassLogin;
import com.example.translatorandroid.R;
import com.example.translatorandroid.Service.ServicesAPI;
import com.example.translatorandroid.databinding.ActivityLoginBinding;
import com.google.android.material.textfield.TextInputEditText;

import org.mindrot.jbcrypt.BCrypt;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import kotlin.text.Regex;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class Login extends AppCompatActivity {

    ActivityLoginBinding binding;
    Account account;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        binding = ActivityLoginBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());


        binding.btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String email = binding.email.getText().toString();
                String password = binding.password.getText().toString();
                isValidEmail(email);
                if (isValidPassword(password)) {
                        login(email, password);
                }
            }
        });

        binding.needNewAccount.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Login.this, SignUp.class);
                startActivity(intent);

            }
        });


    }

        private boolean isValidEmail(String email) {
            // Kiểm tra định dạng cơ bản và số lượng ký tự
            if (email == null && email.length() <= 0 && Patterns.EMAIL_ADDRESS.matcher(email).matches()) {
                binding.email.setError("Invalid email");
                return false;
            }
            return true;
        }
    private String PASSWORD_PATTERN = "^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=])(?=\\S+$).{8,}$";

    private Pattern pattern = Pattern.compile(PASSWORD_PATTERN);

    public boolean isValidPassword(String password) {
        Matcher matcher = pattern.matcher(password);
        if (!matcher.matches()) {
            binding.password.setError("Invalid password");
            return false;
        }
        return true;
    }

    private void login(String email, String pass) {
        ClassLogin classLogin = new ClassLogin(email, pass);

        ServicesAPI.servicesAPI.login(classLogin).enqueue(new Callback<Account>() {
            @Override
            public void onResponse(Call<Account> call, Response<Account> response) {
                if (response.body() != null) {
                    account = response.body();
                    Toast.makeText(Login.this, "Login successful", Toast.LENGTH_SHORT).show();

                    // Chuyển sang MainActivity và gửi trạng thái đăng nhập
                    Intent intent = new Intent(Login.this, MainActivity.class);
                    intent.putExtra("isLoggedIn", true);
                    intent.putExtra("account", account);
                    startActivity(intent);
                    finish();
                } else {
                    account = new Account();
                    Toast.makeText(Login.this, "Login failed", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<Account> call, Throwable throwable) {
                Log.e("API Call", "Failed: " + throwable.getMessage());
                Toast.makeText(Login.this, "Call API fail", Toast.LENGTH_SHORT).show();
            }
        });
    }

}