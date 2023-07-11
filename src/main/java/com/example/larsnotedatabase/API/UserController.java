package com.example.larsnotedatabase.API;

import com.example.larsnotedatabase.DAL.UserRepository;
import com.example.larsnotedatabase.Models.User;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/user")
public class UserController {

	final UserRepository userRepository;

	public UserController(UserRepository userRepository) {
		this.userRepository = userRepository;
	}

	@PostMapping("/create")
	public boolean createUser(@RequestBody User user) {
		System.out.println(user.getEmail() + user.getPassword());
		return true;
	}

}
