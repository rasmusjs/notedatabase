package com.example.larsnotedatabase.Models;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.Table;

@Entity
@Table(name = "countries")
public class Country {
	@Id
	@Column(name = "id")
	private int id;

	@Column(name = "name", nullable = false)
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
