package com.example.larsnotedatabase.DAL;

import com.example.larsnotedatabase.Models.User;
import jakarta.servlet.http.HttpSession;
import org.mindrot.jbcrypt.BCrypt;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Repository;


@Repository
public class UserRepository {
	@Autowired
	JdbcTemplate db;
	Logger logger = LoggerFactory.getLogger(UserRepository.class);
	@Autowired
	private HttpSession session;

	public boolean login(User user) {
		try {
			User queried = db.queryForObject("SELECT * FROM Users WHERE email = ?", BeanPropertyRowMapper.newInstance(User.class), user.getEmail());
			if ((queried != null) && BCrypt.checkpw(user.getPassword(), queried.getPassword())) {
				session.setAttribute("Innlogget", queried.getId());
				System.out.println("logged in" + queried.getEmail());
				return true;
			}
		} catch (Exception e) {
			logger.error("Feil i login : " + e);
		}
		return false;
	}

	public boolean create(User newUser) {
		if (session.getAttribute("Innlogget") == null) {
			if (newUser.valid()) {
				System.out.println("Valid");
				try {
					return db.update("INSERT INTO Users (email, password) VALUES (?, ?)", newUser.getEmail(), newUser.getHashedPwd()) > 0;
				} catch (Exception e) {
					logger.error("Feil i registrer : " + e);
				}
			}
			System.out.println("Not valid");
		}
		return false;
	}

	public boolean checkSession() {
		return session.getAttribute("Innlogget") != null;
	}

	public boolean checkPrivileges() {
		return session.getAttribute("admin") != null;
	}

	public void logout() {
		session.removeAttribute("Innlogget");
	}

}
