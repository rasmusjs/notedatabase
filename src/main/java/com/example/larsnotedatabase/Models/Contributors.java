package com.example.larsnotedatabase.Models;

import jakarta.persistence.*;

import java.sql.Date;


@Entity
@Table(name = "contributors")
public class Contributors {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    @Column(name = "first_name", nullable = false)
    private String firstName;

    @Column(name = "last_name", nullable = false)
    private String lastName;

    @ManyToOne
    @JoinColumn(name = "country_id", nullable = false)
    private Country country;

    @Column(name = "birth_date", nullable = false)
    private Date birthDate;

    // Constructors, Getters and Setters
    // ...

    // Other fields, constructors, getters, setters, and methods omitted for brevity
}
