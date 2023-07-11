package com.example.larsnotedatabase.Models;

import jakarta.persistence.*;

import java.sql.Timestamp;

@Entity
@Table(name = "files")
public class File {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    @ManyToOne
    @JoinColumn(name = "orchestral_set_id", nullable = false)
    private OrchestralSet orchestralSet;

    @Column(name = "file_path", length = 255)
    private String filePath;

    @Column(name = "upload_date", nullable = false)
    private Timestamp uploadDate;

    @Column(name = "real_name", length = 255)
    private String realName;

    // Constructors
    public File(int id, OrchestralSet orchestralSet, String filePath, Timestamp uploadDate, String realName) {
        this.id = id;
        this.orchestralSet = orchestralSet;
        this.filePath = filePath;
        this.uploadDate = uploadDate;
        this.realName = realName;
    }

    public File() {
    }

    // Getters and Setters
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public OrchestralSet getOrchestralSet() {
        return orchestralSet;
    }

    public void setOrchestralSet(OrchestralSet orchestralSet) {
        this.orchestralSet = orchestralSet;
    }

    public String getFilePath() {
        return filePath;
    }

    public void setFilePath(String filePath) {
        this.filePath = filePath;
    }

    public Timestamp getUploadDate() {
        return uploadDate;
    }

    public void setUploadDate(Timestamp uploadDate) {
        this.uploadDate = uploadDate;
    }

    public String getRealName() {
        return realName;
    }

    public void setRealName(String realName) {
        this.realName = realName;
    }
}
