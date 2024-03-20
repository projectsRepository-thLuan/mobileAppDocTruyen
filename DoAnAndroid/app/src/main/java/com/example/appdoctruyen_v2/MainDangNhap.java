package com.example.appdoctruyen_v2;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.example.appdoctruyen_v2.Interface.TruyenAPI;
import com.example.appdoctruyen_v2.database.databasedoctruyen;
import com.example.appdoctruyen_v2.model.TaiKhoan;

import java.io.IOException;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MainDangNhap extends AppCompatActivity {


    EditText edtTaiKhoan, edtMatKhau;
    Button btnDangNhap, btnDangKy;

    databasedoctruyen databaseDocTruyen;
    TruyenAPI truyenAPI;
    TaiKhoan taikhoan;
    boolean loginSuccess = false;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_dang_nhap);
        AnhXa();

        databaseDocTruyen = new databasedoctruyen(this);

        truyenAPI = TruyenAPI.truyenAPI;


        btnDangKy.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MainDangNhap.this,MainDangKy.class);
                startActivity(intent);
            }
        });

        btnDangNhap.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String tentaikhoan = edtTaiKhoan.getText().toString();
                String matkhau = edtMatKhau.getText().toString();
                taikhoan = new TaiKhoan(tentaikhoan, matkhau);
                truyenAPI.login(taikhoan).enqueue(new Callback<TaiKhoan>() {
                    @Override
                    public void onResponse(Call<TaiKhoan> call, Response<TaiKhoan> response) {
                        if(response.isSuccessful()){
                            taikhoan = response.body();
                            Intent intent = new Intent(MainDangNhap.this,MainActivity.class);
                            intent.putExtra("phanq",taikhoan.getmPhanQuyen());
                            intent.putExtra("idd",taikhoan.getmId());
                            intent.putExtra("email",taikhoan.getmEmail());
                            intent.putExtra("tentaikhoan",taikhoan.getmTenTaiKhoan());
                            startActivity(intent);
                            loginSuccess = true;
                            Toast.makeText(MainDangNhap.this, "Đăng nhập thành công", Toast.LENGTH_SHORT).show();
                        } else {
                            try {
                                System.out.println("abc ded :"+response.errorBody().string());
                                Toast.makeText(MainDangNhap.this, "Login failed: " +  response.errorBody().string(), Toast.LENGTH_SHORT).show();

                            }catch (IOException e){
                                Toast.makeText(MainDangNhap.this, "Network error: " + e.getMessage(), Toast.LENGTH_SHORT).show();
                            }
                        }
                    }

                    @Override
                    public void onFailure(Call<TaiKhoan> call, Throwable t) {
                        Toast.makeText(MainDangNhap.this, "Network error: " + t.getMessage(), Toast.LENGTH_SHORT).show();
                    }

                });

            }
        });
    }

    private void AnhXa() {
        edtTaiKhoan = findViewById(R.id.edtUsername);
        edtMatKhau = findViewById(R.id.edtPasswod);
        btnDangNhap = findViewById(R.id.btnDangNhap);
        btnDangKy = findViewById(R.id.btnDangKy);
    }
}