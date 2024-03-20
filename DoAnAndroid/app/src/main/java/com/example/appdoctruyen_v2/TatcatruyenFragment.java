package com.example.appdoctruyen_v2;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.DividerItemDecoration;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.appdoctruyen_v2.Interface.TruyenAPI;
import com.example.appdoctruyen_v2.Interface.TruyenAPIConfig;
import com.example.appdoctruyen_v2.adapter.adapterTruyen;
import com.example.appdoctruyen_v2.model.Truyen;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class TatcatruyenFragment extends Fragment {
    RecyclerView listView;
    List<Truyen> listTruyen;
    adapterTruyen adapterTruyen;

    public TatcatruyenFragment() {
        // Required empty public constructor
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        listView = getView().findViewById(R.id.listviewtatcatruyen);

        //ActionBar();
        initList();


    }

    private void callApiGetTruyen(){
        TruyenAPIConfig config = new TruyenAPIConfig();
        TruyenAPI.truyenAPI.getTruyenList().enqueue(new Callback<List<Truyen>>() {
            @Override
            public void onResponse(Call<List<Truyen>> call, Response<List<Truyen>> response) {
                listTruyen = response.body();
                adapterTruyen = new adapterTruyen(getContext(),listTruyen);
                listView.setAdapter(adapterTruyen);
                for(Truyen truyen: listTruyen){
                    System.out.println(config.BASE_URL + truyen.getAnh());
                }
                Toast.makeText(getContext(),"Thanh cong",Toast.LENGTH_SHORT).show();
            }

            @Override
            public void onFailure(Call<List<Truyen>> call, Throwable t) {
                Toast.makeText(getContext(),t.getMessage(),Toast.LENGTH_SHORT).show();
                System.out.println(t.getMessage());
            }
        });
    }

    public void initList(){
        listTruyen = new ArrayList<>();
        LinearLayoutManager linearLayoutManager = new LinearLayoutManager(getContext());
        listView.setLayoutManager(linearLayoutManager);
        DividerItemDecoration itemDecoration = new DividerItemDecoration(getContext(),DividerItemDecoration.VERTICAL);
        callApiGetTruyen();
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_tatcatruyen, container, false);
    }

}
