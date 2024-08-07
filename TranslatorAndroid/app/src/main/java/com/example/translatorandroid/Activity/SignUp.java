package com.example.translatorandroid.Activity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Patterns;
import android.view.View;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.example.translatorandroid.Model.Account;
import com.example.translatorandroid.Model.ClassSignUp;
import com.example.translatorandroid.R;

import com.example.translatorandroid.Service.ServicesAPI;
import com.example.translatorandroid.databinding.ActivitySignUpBinding;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class SignUp extends AppCompatActivity {

    ActivitySignUpBinding binding;
    public Account account;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);

        binding = ActivitySignUpBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        binding.btnRegister.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(isValidEmail(binding.email.getText().toString()) && isValidPassword(binding.password.getText().toString()) && binding.username.getText().toString().length() > 0) {
                    CreateNewAccount(binding.username.getText().toString(), binding.email.getText().toString(), binding.password.getText().toString(), binding.confirmPassword.getText().toString());
                }
            }
        });

    }
    private boolean isValidEmail(String email) {
        // Kiểm tra định dạng cơ bản và số lượng ký tự
        if(email == null && email.length() <= 0 && Patterns.EMAIL_ADDRESS.matcher(email).matches())
        {
            binding.email.setError("Invalid email");
        }
        return true;
    }
    private String PASSWORD_PATTERN =
            "^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=])(?=\\S+$).{8,}$";

    private Pattern pattern = Pattern.compile(PASSWORD_PATTERN);

    public boolean isValidPassword(String password) {
        Matcher matcher = pattern.matcher(password);
        if(matcher.matches() == false)
        {
            binding.password.setError("Invalid password");
        }
        return matcher.matches();
    }


    private void CreateNewAccount(String username, String email, String password, String confirmPassword)
    {
        ClassSignUp classSignUp = new ClassSignUp(username, email, password, confirmPassword);
        ServicesAPI.servicesAPI.signup(classSignUp).enqueue(new Callback<Account>() {
            @Override
            public void onResponse(Call<Account> call, Response<Account> response) {
                if (response.body() != null) {
                    account = response.body();
                    Toast.makeText(SignUp.this, "Create account successful", Toast.LENGTH_SHORT).show();
                    Intent intent = new Intent(SignUp.this, Login.class);
                    startActivity(intent);
                } else {
                    account = new Account();
                    Toast.makeText(SignUp.this, "Create account failed", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<Account> call, Throwable throwable) {

            }
        });
    }
}