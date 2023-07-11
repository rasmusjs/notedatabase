package com.example.larsnotedatabase.API;

import com.example.larsnotedatabase.DAL.UserRepository;
import com.example.larsnotedatabase.Models.User;
import jakarta.servlet.http.HttpServletResponse;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

@RestController
@RequestMapping("/user")
public class UserController {

	final UserRepository userRepository;

	public UserController(UserRepository userRepository) {
		this.userRepository = userRepository;
	}

	@PostMapping("/create")
	public boolean create(@RequestBody User user, HttpServletResponse response) throws IOException {
		// Check firstname and lastname
		if (!(user.validName(user.getFirstName()) && user.validName(user.getLastName()))) {
			response.sendError(HttpStatus.BAD_REQUEST.value(), "Invalid first name or last name");
			return false;
		}
		// Check email
		if (!user.validEmail()) {
			response.sendError(HttpStatus.BAD_REQUEST.value(), "Invalid email address");
			return false;
		}
		// Check user exist
		if (userRepository.getUser(user.getEmail()) != null) {
			response.sendError(HttpStatus.CONFLICT.value(), "User exists, please login");
			return false;
		}

		// Create the user
		if (userRepository.create(user)) {
			System.out.println("Created account for: " + user.getEmail());
			return true;
		} else {
			response.sendError(HttpStatus.INTERNAL_SERVER_ERROR.value(), "Failed to create user account");
			return false;
		}
	}


	@PostMapping("/login")
	public ResponseEntity<Object> login(@RequestBody User user, HttpServletResponse response) throws IOException {
		User loggedUser = userRepository.login(user);
		if (loggedUser != null) {
			Map<String, Object> responseData = new HashMap<>();
			responseData.put("firstName", loggedUser.getFirstName());
			responseData.put("lastName", loggedUser.getLastName());
			responseData.put("email", loggedUser.getEmail());
			return ResponseEntity.ok(responseData);
		} else {
			response.sendError(HttpStatus.UNAUTHORIZED.value(), "Invalid password or username");
			return ResponseEntity.status(HttpStatus.UNAUTHORIZED).build();
		}
	}


	@PostMapping("/forgot")
	public boolean forgot(@RequestBody String email, HttpServletResponse response) throws IOException {
		if (userRepository.forgot(email)) {
			return true;
		} else {
			response.sendError(HttpStatus.INTERNAL_SERVER_ERROR.value(), "Failed to send user email");
			return false;
		}
	}

	@GetMapping("/logout")
	public void logout() {
		userRepository.logout();
	}

}
