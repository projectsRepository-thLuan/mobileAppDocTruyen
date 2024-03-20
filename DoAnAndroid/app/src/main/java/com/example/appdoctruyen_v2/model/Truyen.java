package com.example.appdoctruyen_v2.model;

import com.google.gson.annotations.SerializedName;

public class Truyen {
    @SerializedName("id")
    private int ID;
    @SerializedName("tentruyen")
    private String TenTruyen;
    @SerializedName("noidung")
    private String NoiDung;
    @SerializedName("anh")
    private String Anh;
    @SerializedName("idTk")
    private int ID_TK;
    @SerializedName("Voice")
    private String Voice;

    public String getVoice() {
        return Voice;
    }

    public void setVoice(String voice) {
        Voice = voice;
    }

    public Truyen(String tenTruyen, String noiDung, String anh, int ID_TK) {
        TenTruyen = tenTruyen;
        NoiDung = noiDung;
        Anh = anh;
        this.ID_TK = ID_TK;
    }

    public Truyen(int ID, String tenTruyen, String noiDung, String anh, int ID_TK) {
        this.ID = ID;
        TenTruyen = tenTruyen;
        NoiDung = noiDung;
        Anh = anh;
        this.ID_TK = ID_TK;
    }

    public int getID() {
        return ID;
    }

    public void setID(int ID) {
        this.ID = ID;
    }

    public String getTenTruyen() {
        return TenTruyen;
    }

    public void setTenTruyen(String tenTruyen) {
        TenTruyen = tenTruyen;
    }

    public String getNoiDung() {
        return NoiDung;
    }

    public void setNoiDung(String noiDung) {
        NoiDung = noiDung;
    }

    public String getAnh() {
        return Anh;
    }

    public void setAnh(String anh) {
        Anh = anh;
    }

    public int getID_TK() {
        return ID_TK;
    }

    public void setID_TK(int ID_TK) {
        this.ID_TK = ID_TK;
    }
}
