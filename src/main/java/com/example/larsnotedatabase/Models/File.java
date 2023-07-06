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

    // Constructors, Getters and Setters
    // ...

    // Other fields, constructors, getters, setters, and methods omitted for brevity
}
