package com.example.larsnotedatabase.Models;

import jakarta.persistence.*;

import java.sql.Timestamp;

@Entity
@Table(name = "users")
public class User {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    @Column(name = "first_name", nullable = false)
    private String firstName;

    @Column(name = "last_name", nullable = false)
    private String lastName;

    @Column(name = "email", unique = true, nullable = false)
    private String email;

    @Column(name = "password", nullable = false)
    private String password;

    @Column(name = "access_level", nullable = false)
    private String accessLevel;

    @Column(name = "registration_date", nullable = false)
    private Timestamp registrationDate;

    // Constructors, Getters and Setters
    // ...

    // Other fields, constructors, getters, setters, and methods omitted for brevity
}
