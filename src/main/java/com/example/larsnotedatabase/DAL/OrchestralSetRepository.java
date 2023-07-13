package com.example.larsnotedatabase.DAL;

import com.example.larsnotedatabase.Models.Country;
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

	public boolean create(OrchestralSet set) {
		if (session.getAttribute("userID") != null) {
			int userID = (int) session.getAttribute("userID");

			//Check fields
			//if (newUser.valid()) {
			//System.out.println("Fields valid for " + newUser.getEmail());
			try {
				String sql = "INSERT INTO orchestral_sets (name, creator_id, description, country_id, created_date, updated_date)" +
						"VALUES (?, ?, ?, ?, ?, CURRENT_TIMESTAMP)";
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
/*

	public boolean forgot(String email) {
		try {
			User queried = getUser(email);
			if (queried != null) {
				System.out.print("Sent mail");
				return true;
			}
		} catch (EmptyResultDataAccessException e) {
			// Handle case when no user is found or password doesn't match
			return false;
		} catch (Exception e) {
			logger.error("Error in forgot: " + e);
		}
		return false;
	}


	public boolean checkSession() {
		return session.getAttribute("userID") != null;
	}

	public boolean checkPrivileges() {
		return session.getAttribute("admin") != null;
	}

	public void logout() {
		session.removeAttribute("userID");
	}*/

}
