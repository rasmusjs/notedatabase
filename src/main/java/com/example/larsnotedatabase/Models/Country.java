package com.example.larsnotedatabase.Models;

import jakarta.persistence.*;

@Entity
@Table(name = "countries")
public class Country {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;

	@Column(name = "name", nullable = false, length = 100)
	private String name;


	// Constructors
	public Country(int id, String name) {
		this.id = id;
		this.name = name;
	}

	public Country() {
	}

	// Getters and Setters
	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}
}
