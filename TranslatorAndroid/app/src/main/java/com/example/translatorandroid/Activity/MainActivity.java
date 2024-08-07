package com.example.translatorandroid.Activity;

import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.annotation.NonNull;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import androidx.viewpager2.widget.ViewPager2;

import com.example.translatorandroid.Adapter.MainViewpageAdapter;
import com.example.translatorandroid.Model.Account;
import com.example.translatorandroid.R;
import com.example.translatorandroid.Service.ServicesAPI;
import com.example.translatorandroid.databinding.ActivityMainBinding;
import com.google.android.material.navigation.NavigationBarView;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MainActivity extends AppCompatActivity {

    ActivityMainBinding binding;
    MainViewpageAdapter adapter = new MainViewpageAdapter(this);

    public Account account;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        binding = ActivityMainBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        setSupportActionBar(binding.tbMain);

        binding.vpMain.setAdapter(adapter);
        binding.vpMain.setUserInputEnabled(false);
        binding.navBotMain.setOnItemSelectedListener(new NavigationBarView.OnItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                if (item.getItemId() == R.id.miTranslate) {
                    binding.vpMain.setCurrentItem(0);
                    return true;
                } else {
                    if (account != null) {
                        binding.vpMain.setCurrentItem(1);
                    } else {
                        AlertDialog Dialog = new AlertDialog.Builder(MainActivity.this)
                                .setTitle("Login required")
                                .setMessage("You need to login to access this feature")
                                .setNegativeButton("OK", new DialogInterface.OnClickListener() {
                                    @Override
                                    public void onClick(DialogInterface dialog, int which) {
                                        Intent intent = new Intent(MainActivity.this, Login.class);
                                        startActivity(intent);
                                    }
                                }).setPositiveButton("Cancel", new DialogInterface.OnClickListener() {
                                    @Override
                                    public void onClick(DialogInterface DialogInterface, int i) {
                                        //make  NavigationBarView.OnItemSelectedListener() return false
                                        binding.navBotMain.setSelectedItemId(R.id.miTranslate);
                                    }
                                }).create();
                        Dialog.show();
                    }
                    return true;
                }
            }
        });

        binding.vpMain.registerOnPageChangeCallback(new ViewPager2.OnPageChangeCallback() {
            @Override
            public void onPageSelected(int position) {
                super.onPageSelected(position);
                if (position == 0) {
                    binding.navBotMain.setSelectedItemId(R.id.miTranslate);
                } else if (position == 1) {
                    binding.navBotMain.setSelectedItemId(R.id.miSaved);
                }
            }
        });


        Bundle bundle = getIntent().getExtras();
        if(bundle != null)
        {
            account = (Account) bundle.get("account");
            if(account != null)
            {
                Toast.makeText(MainActivity.this, "Hello " + account.getUSERNAME(), Toast.LENGTH_SHORT).show();
            }
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater menuInflater = getMenuInflater();
        menuInflater.inflate(R.menu.menu_toolbar, menu);

        MenuItem loginStatusItem = menu.findItem(R.id.login);
        MenuItem logoutItem = menu.findItem(R.id.logout);

        Intent intent = getIntent();
        boolean isLoggedIn = intent.getBooleanExtra("isLoggedIn", false);

        if (isLoggedIn) {
            loginStatusItem.setVisible(false); // Ẩn mục Login
            logoutItem.setVisible(true); // Hiển thị mục Logout
            // hien thi icon
            logoutItem.setIcon(R.drawable.iclogout);
        } else {
            loginStatusItem.setVisible(true); // Hiển thị mục Login
            loginStatusItem.setIcon(R.drawable.ic_account);
            logoutItem.setVisible(false); // Ẩn mục Logout
        }
        loginStatusItem.setIcon(R.drawable.ic_account);
        return true;
    }


    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {

        if(item.getItemId() == R.id.login)
        {
            if (!item.isVisible()) {
                return false; // Nếu mục Login không hiển thị, không xử lý sự kiện
            }
            Intent intent = new Intent(this, Login.class);
            startActivity(intent);
        }
        if(item.getItemId() == R.id.logout)
        {
            if (!item.isVisible()) {
                return false;

            }
            performLogout();
            boolean isLoggedIn = getIntent().getBooleanExtra("isLoggedIn", false);
            Intent intent = new Intent(this, MainActivity.class);
            intent.putExtra("isLoggedIn", isLoggedIn);
            startActivity(intent);

        }

        return super.onOptionsItemSelected(item);
    }


    private void performLogout()
    {
        ServicesAPI.servicesAPI.logout().enqueue(new Callback<Account>() {
            @Override
            public void onResponse(Call<Account> call, Response<Account> response) {
                if (response.isSuccessful() && response.body() != null) {
                    Account account = response.body();
                    account.setUID(0); // Đặt UID về 0

                    // Cập nhật giao diện người dùng
                    Toast.makeText(MainActivity.this, "Logout successful", Toast.LENGTH_SHORT).show();

                } else {
                    Toast.makeText(MainActivity.this, "Logout failed", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<Account> call, Throwable throwable) {
                Toast.makeText(MainActivity.this, "Logout failed", Toast.LENGTH_SHORT).show();
            }
        });
    }
}