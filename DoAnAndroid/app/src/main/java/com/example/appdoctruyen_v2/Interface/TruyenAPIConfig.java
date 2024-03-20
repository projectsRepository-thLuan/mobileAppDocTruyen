package com.example.appdoctruyen_v2.Interface;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import java.io.IOException;

import okhttp3.Interceptor;
import okhttp3.OkHttpClient;
import okhttp3.Request;

public class TruyenAPIConfig {
    public static final String BASE_URL = "https://54d6-123-21-124-36.ngrok-free.app";
    public static final Gson GSON = new GsonBuilder().create();
    public static final OkHttpClient OK_HTTP_CLIENT = new OkHttpClient.Builder()
            .addInterceptor(new Interceptor() {
                @Override
                public okhttp3.Response intercept(Chain chain) throws IOException {
                    Request original = chain.request();
                    Request request = original.newBuilder()
                            .header("Content-Type", "application/json")
                            .method(original.method(), original.body())
                            .build();
                    return chain.proceed(request);
                }
            })
            .build();
}
