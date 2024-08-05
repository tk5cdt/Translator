package com.example.translatorandroid.Model;

public class Translate {
    public String q ;
    public String source = "auto";
    public String target = "en";
    public String format = "text";
    public int alternatives = 2;
    public String api_key;

    public String getQ() {
        return q;
    }

    public void setQ(String q) {
        this.q = q;
    }

    public String getSource() {
        return source;
    }

    public void setSource(String source) {
        this.source = source;
    }

    public String getTarget() {
        return target;
    }

    public void setTarget(String target) {
        this.target = target;
    }

    public String getFormat() {
        return format;
    }

    public void setFormat(String format) {
        this.format = format;
    }

    public int getAlternatives() {
        return alternatives;
    }

    public void setAlternatives(int alternatives) {
        this.alternatives = alternatives;
    }

    public String getApi_key() {
        return api_key;
    }

    public void setApi_key(String api_key) {
        this.api_key = api_key;
    }

    public Translate() {
    }
}
