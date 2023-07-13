package com.example.larsnotedatabase.DAL;

import com.example.larsnotedatabase.Models.User;
import jakarta.servlet.http.HttpSession;
import org.mindrot.jbcrypt.BCrypt;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.dao.EmptyResultDataAccessException;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Repository;

import java.util.List;


@Repository
public class UserRepository {
	@Autowired
	JdbcTemplate db;
	Logger logger = LoggerFactory.getLogger(UserRepository.class);
	@Autowired
	private HttpSession session;

	public User login(User user) {
		try {
			User queried = getUser(user.getEmail());
			if (queried != null && BCrypt.checkpw(user.getPassword(), queried.getPassword())) {
				logout(); // Log the previous user out
				session.setAttribute("userID", queried.getId());
				queried.setPassword(null); // Don't send the password back
				session.setAttribute("accessLevel", queried.getAccessLevel());
				System.out.println("Logged in: " + queried.getEmail());
				return queried;
			}
		} catch (EmptyResultDataAccessException e) {
			// Handle case when no user is found or password doesn't match
			return null;
		} catch (Exception e) {
			logger.error("Error in login: " + e);
		}
		return null;
	}


	// Get user from email or number
	public User getUser(Object identifier) {
		try {
			String query;
			Object[] queryParams;
			if (identifier instanceof String) {
				query = "SELECT * FROM Users WHERE email = ?";
				queryParams = new Object[]{identifier};
			} else if (identifier instanceof Integer) {
				query = "SELECT * FROM Users WHERE id = ?";
				queryParams = new Object[]{identifier};
			} else {
				return null; // Invalid identifier type
			}

			List<User> users = db.query(query, BeanPropertyRowMapper.newInstance(User.class), queryParams);
			if (!users.isEmpty()) {
				return users.get(0);
			}
		} catch (EmptyResultDataAccessException e) {
			// Handle case when no user is found
			return null;
		} catch (Exception e) {
			logger.error("Error in getUser: " + e);
		}
		return null;
	}


	public boolean create(User newUser) {
		logout(); // For testing
		if (session.getAttribute("userID") == null) {
			if (newUser.valid()) {
				System.out.println("Fields valid for " + newUser.getEmail());
				try {
					String sql = "INSERT INTO users (first_name, last_name, email, password, access_level, registration_date) " +
							"VALUES (?, ?, ?, ?, 'User', CURRENT_TIMESTAMP)";
					return db.update(sql, newUser.getFirstName(), newUser.getLastName(), newUser.getEmail(), newUser.getHashedPwd()) > 0;
				} catch (Exception e) {
					logger.error("Error in create: " + e);
					System.out.println(newUser.getEmail() + newUser.getFirstName() + newUser.getLastName() + newUser.getPassword());
				}
			} else {
				System.out.println("Fields not valid");
			}
		}
		return false;
	}

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
		return session.getAttribute("userAccessLevel").equals("Admin") ||
		session.getAttribute("userAccessLevel").equals("Moderator");
	}

	public void logout() {
		session.removeAttribute("userID");
	}

}
