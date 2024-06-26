package com.example.appdoctruyen_v2;

import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.example.appdoctruyen_v2.database.databasedoctruyen;
import com.example.appdoctruyen_v2.model.TaiKhoan;


public class MainDangKy extends AppCompatActivity {
    EditText edtDKTaiKhoan,edtDKMatKhau,edtDKEmail;
    Button btnDKDangKy,btnDKDangNhap;

    databasedoctruyen databaseDocTruyen;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_dang_ky);

        AnhXa();

        databaseDocTruyen = new databasedoctruyen(this);

        btnDKDangKy.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                String taikhoan = edtDKTaiKhoan.getText().toString();
                String matkhau = edtDKMatKhau.getText().toString();
                String email = edtDKEmail.getText().toString();

                TaiKhoan taikhoan1 = new TaiKhoan();
                taikhoan1.setmTenTaiKhoan(taikhoan);
                taikhoan1.setmEmail(email);
                taikhoan1.setmMatKhau(matkhau);

                if(taikhoan.equals("") || matkhau.equals("") || email.equals("")){
                    Toast.makeText(MainDangKy.this,"Bạn chưa nhập đầy đủ thông tin",Toast.LENGTH_SHORT).show();
                    Log.e("Thông báo : ","Bạn chưa nhập đầy đủ thông tin");
                }
                //Nếu đầy đủ thông tin
                else{
                    databaseDocTruyen.AddTaiKhoan(taikhoan1);
                    Toast.makeText(MainDangKy.this,"Đăng ký thành công ",Toast.LENGTH_SHORT).show();
                    finish();
                }
            }
        });

        btnDKDangNhap.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
            }
        });

    }
    private void AnhXa() {
        edtDKEmail = findViewById(R.id.dkEmail);
        edtDKMatKhau = findViewById(R.id.dkMatKhau);
        edtDKTaiKhoan = findViewById(R.id.dkTaiKhoan);
        btnDKDangKy = findViewById(R.id.dkDangKy);
        btnDKDangNhap = findViewById(R.id.dkDangNhap);

    }
}