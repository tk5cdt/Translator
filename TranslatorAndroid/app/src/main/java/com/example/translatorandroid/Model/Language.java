package com.example.translatorandroid.Model;

import java.util.List;

public class Language {
    public String code;
    public String name;
    public List<String> targets;

    @Override
    public String toString() {
        return name;
    }
}
