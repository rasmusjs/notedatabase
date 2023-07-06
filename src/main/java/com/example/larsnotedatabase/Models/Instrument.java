package com.example.larsnotedatabase.Models;

import jakarta.persistence.*;

@Entity
public class Instrument {
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Id
    private long id;
    @Column(name = "name", nullable = false)

    private String name;
    @Column(name = "description")

    private String description;

    // Constructors
    public Instrument() {
        // Default constructor
    }

    public Instrument(int id, String name, String description) {
        this.id = id;
        this.name = name;
        this.description = description;
    }


}
