package com.example.translatorandroid.Model;

public class DetectedLanguage {
    public double confidence;
    public String language;

    public double getConfidence() {
        return confidence;
    }

    public void setConfidence(double confidence) {
        this.confidence = confidence;
    }

    public String getLanguage() {
        return language;
    }

    public void setLanguage(String language) {
        this.language = language;
    }

    public DetectedLanguage() {
    }
}
