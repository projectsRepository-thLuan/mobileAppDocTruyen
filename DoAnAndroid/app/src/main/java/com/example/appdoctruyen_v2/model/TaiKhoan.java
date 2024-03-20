package com.example.appdoctruyen_v2.model;

import com.google.gson.annotations.SerializedName;

public class TaiKhoan {
    @SerializedName("id")
    private int mId;
    @SerializedName("tentaikhoan")
    private String mTenTaiKhoan;
    @SerializedName("matkhau")
    private String mMatKhau;
    @SerializedName("email")
    private String mEmail;
    @SerializedName("phanquyen")
    private int mPhanQuyen;

    public TaiKhoan(String mTenTaiKhoan, String mMatKhau, String mEmail, int mPhanQuyen) {
        this.mTenTaiKhoan = mTenTaiKhoan;
        this.mMatKhau = mMatKhau;
        this.mEmail = mEmail;
        this.mPhanQuyen = mPhanQuyen;
    }
    public TaiKhoan(){
        this.mPhanQuyen =0;
    }
    public TaiKhoan(String mTenTaiKhoan, String mMatKhau) {
        this.mTenTaiKhoan = mTenTaiKhoan;
        this.mMatKhau = mMatKhau;
    }

    public int getmId() {
        return mId;
    }

    public void setmId(int mId) {
        this.mId = mId;
    }

    public String getmTenTaiKhoan() {
        return mTenTaiKhoan;
    }

    public void setmTenTaiKhoan(String mTenTaiKhoan) {
        this.mTenTaiKhoan = mTenTaiKhoan;
    }

    public String getmMatKhau() {
        return mMatKhau;
    }

    public void setmMatKhau(String mMatKhau) {
        this.mMatKhau = mMatKhau;
    }

    public String getmEmail() {
        return mEmail;
    }

    public void setmEmail(String mEmail) {
        this.mEmail = mEmail;
    }

    public int getmPhanQuyen() {
        return mPhanQuyen;
    }

    public void setmPhanQuyen(int mPhanQuyen) {
        this.mPhanQuyen = mPhanQuyen;
    }
}
