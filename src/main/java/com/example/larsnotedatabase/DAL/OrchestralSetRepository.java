package com.example.larsnotedatabase.DAL;

import com.example.larsnotedatabase.Models.Contributors;
import com.example.larsnotedatabase.Models.Country;
import com.example.larsnotedatabase.Models.Instrument;
import com.example.larsnotedatabase.Models.OrchestralSet;
import jakarta.servlet.http.HttpSession;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Repository;

import java.util.List;


@Repository
public class OrchestralSetRepository {
	@Autowired
	JdbcTemplate db;
	Logger logger = LoggerFactory.getLogger(OrchestralSetRepository.class);
	@Autowired
	UserRepository userRepository;
	@Autowired
	private HttpSession session;

	public List<Contributors> getContributors() {
		try {
			String query = "SELECT * FROM contributors";
			List<Contributors> contributors = db.query(query, BeanPropertyRowMapper.newInstance(Contributors.class));
			if (!contributors.isEmpty()) {
				return contributors;
			}
		} catch (Exception e) {
			logger.error("Error in getContributors: " + e);
		}
		return null;
	}

	public boolean newContributor(String firstName, String lastName, int countryId, String birthDate) {
		if (userRepository.checkPrivileges()) { // Check if the user has privileges
			try {
				String sql = "INSERT INTO contributors (first_name, last_name, country_id, birth_date) VALUES (?, ?, ?, ?)";
				return db.update(sql, firstName, lastName, countryId, birthDate) > 0;
			} catch (Exception e) {
				logger.error("Error in create: " + e);
			}
		}
		return false;
	}

	public boolean removeContributor(int id) {
		if (userRepository.checkPrivileges()) { // Check if the user has privileges
			try {
				String sql = "DELETE FROM contributors WHERE id = ?";
				return db.update(sql, id) > 0;
			} catch (Exception e) {
				logger.error("Error in create: " + e);
			}
		}
		return false;
	}


	public List<Country> getCountries() {
		try {
			String query = "SELECT * FROM countries";
			List<Country> countries = db.query(query, BeanPropertyRowMapper.newInstance(Country.class));
			if (!countries.isEmpty()) {
				return countries;
			}
		} catch (Exception e) {
			logger.error("Error in getCountries: " + e);
		}
		return null;
	}

	public boolean newCountry(String name) {
		if (userRepository.checkPrivileges()) { // Check if the user has privileges
			try {
				String sql = "INSERT INTO countries (name) VALUES (?)";
				return db.update(sql, name) > 0;
			} catch (Exception e) {
				logger.error("Error in create: " + e);
			}
		}
		return false;
	}

	public boolean removeCountry(int id) {
		if (userRepository.checkPrivileges()) { // Check if the user has privileges
			try {
				String sql = "DELETE FROM countries WHERE id = ?";
				return db.update(sql, id) > 0;
			} catch (Exception e) {
				logger.error("Error in create: " + e);
			}
		}
		return false;
	}



	public List<Instrument> getInstruments() {
		try {
			String query = "SELECT * FROM instruments";
			List<Instrument> instruments = db.query(query, BeanPropertyRowMapper.newInstance(Instrument.class));
			if (!instruments.isEmpty()) {
				return instruments;
			}
		} catch (Exception e) {
			logger.error("Error in getInstruments: " + e);
		}
		return null;
	}

	public boolean newInstrument(String name) {
		if (userRepository.checkPrivileges()) { // Check if the user has privileges
			try {
				String sql = "INSERT INTO instruments (name) VALUES (?)";
				return db.update(sql, name) > 0;
			} catch (Exception e) {
				logger.error("Error in create: " + e);
			}
		}
		return false;
	}

	public boolean removeInstrument(int id) {
		if (userRepository.checkPrivileges()) { // Check if the user has privileges
			try {
				String sql = "DELETE FROM instruments WHERE id = ?";
				return db.update(sql, id) > 0;
			} catch (Exception e) {
				logger.error("Error in create: " + e);
			}
		}
		return false;
	}



	public boolean newOrchestralSet(OrchestralSet set) {
		if (session.getAttribute("userID") != null) {
			int userID = (int) session.getAttribute("userID");

			//Check fields
			//if (newUser.valid()) {
			//System.out.println("Fields valid for " + newUser.getEmail());
			try {
				String sql = "INSERT INTO orchestral_sets (name, creator_id, description, country_id, created_date, updated_date)" + "VALUES (?, ?, ?, ?, ?, CURRENT_TIMESTAMP)";
				return db.update(sql, userID, set.getDescription(), set.getCountry(), set.getCreatedDate()) > 0;
			} catch (Exception e) {
				logger.error("Error in create: " + e);
			}
			/*} else {
				System.out.println("Fields not valid");
			}*/
		}
		return false;
	}

}
