package com.example.larsnotedatabase.Models;

import jakarta.persistence.*;

import java.sql.Date;


@Entity
@Table(name = "contributors")
public class Contributors {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;

	@Column(name = "first_name", length = 50) // 	@Column(name = "first_name", nullable = false, length = 50)
	private String firstName;

	@Column(name = "last_name", length = 50) //	@Column(name = "last_name", nullable = false, length = 50)
	private String lastName;

	@Column(name = "old_name", length = 255)
	private String old_name;
	@ManyToOne
	@JoinColumn(name = "country_id")
	private Country country;

	@Column(name = "birth_date")
	private Date birthDate;


	// Constructors

	public Contributors(int id, String firstName, String lastName, String old_name, Country country, Date birthDate) {
		this.id = id;
		this.firstName = firstName;
		this.lastName = lastName;
		this.old_name = old_name;
		this.country = country;
		this.birthDate = birthDate;
	}

	public Contributors() {
	}

	// Getters and Setters
	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getFirstName() {
		return firstName;
	}

	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}

	public String getLastName() {
		return lastName;
	}

	public void setLastName(String lastName) {
		this.lastName = lastName;
	}

	public String getOld_name() {
		return old_name;
	}

	public void setOld_name(String old_name) {
		this.old_name = old_name;
	}

	public Country getCountry() {
		return country;
	}

	public void setCountry(Country country) {
		this.country = country;
	}

	public Date getBirthDate() {
		return birthDate;
	}

	public void setBirthDate(Date birthDate) {
		this.birthDate = birthDate;
	}
}
