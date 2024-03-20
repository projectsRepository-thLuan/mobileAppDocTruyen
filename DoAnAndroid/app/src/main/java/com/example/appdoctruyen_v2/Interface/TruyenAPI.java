package com.example.appdoctruyen_v2.Interface;

import com.example.appdoctruyen_v2.model.TaiKhoan;
import com.example.appdoctruyen_v2.model.Truyen;

import java.util.List;

import retrofit2.Call;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;

public interface TruyenAPI {
    Retrofit retrofit = new Retrofit.Builder()
            .baseUrl(TruyenAPIConfig.BASE_URL)
            .addConverterFactory(GsonConverterFactory.create(TruyenAPIConfig.GSON))
            .client(TruyenAPIConfig.OK_HTTP_CLIENT)
            .build();
    TruyenAPI truyenAPI = retrofit.create(TruyenAPI.class);
    @GET("/api/truyen/")
    Call<List<Truyen>> getTruyenList();

    @POST("/api/Auth/Login")
    Call<TaiKhoan> login(@Body TaiKhoan taiKhoan);
}