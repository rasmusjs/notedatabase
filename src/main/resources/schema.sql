CREATE TABLE users
(
    id                INT PRIMARY KEY AUTO_INCREMENT,
    -- Unique identifier for each user
    first_name        VARCHAR(50)                         NOT NULL,
    -- User's first name
    last_name         VARCHAR(50)                         NOT NULL,
    -- User's last name
    email             VARCHAR(100) UNIQUE                 NOT NULL,
    -- User's email address
    password          VARCHAR(100)                        NOT NULL,
    -- User's password
    access_level      ENUM ('Admin', 'Moderator', 'User') NOT NULL,
    -- User's access level
    registration_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- Date and time of user registration
);

CREATE TABLE countries
(
    id   INT PRIMARY KEY,
    -- Unique identifier for each country
    name VARCHAR(100) NOT NULL -- Name of the country
);

CREATE TABLE role
(
    id   INT PRIMARY KEY,
    -- Unique identifier for each role
    name VARCHAR(100) NOT NULL -- Name of the role
);

CREATE TABLE orchestral_sets
(
    id           INT PRIMARY KEY AUTO_INCREMENT,
    -- Unique identifier for each orchestral set
    name         VARCHAR(100) NOT NULL,
    -- Name of the orchestral set
    creator_id   INT          NOT NULL,
    -- Foreign key referencing the user who created the set
    description  TEXT,
    -- Additional description or details about the orchestral set
    country_id   INT,
    -- Foreign key referencing the country associated with the orchestral set
    created_date DATE         NOT NULL,
    -- Date when the orchestral set was created
    updated_date DATE,
    -- Date when the orchestral set was last updated
    FOREIGN KEY (creator_id) REFERENCES users (id),    -- Foreign key constraint referencing the user table
    FOREIGN KEY (country_id) REFERENCES countries (id) -- Foreign key constraint referencing the countries table
);


CREATE TABLE instruments
(
    id          INT PRIMARY KEY AUTO_INCREMENT,
    -- Unique identifier for each instrument
    name        VARCHAR(100) NOT NULL,
    -- Instrument name
    description TEXT
    -- Additional description or details about the instrument
);
CREATE TABLE orchestral_set_instruments
(
    orchestral_set_id INT NOT NULL,
    -- Foreign key referencing the orchestral set
    instrument_id     INT NOT NULL,
    -- Foreign key referencing the instrument
    PRIMARY KEY (orchestral_set_id, instrument_id),
    FOREIGN KEY (orchestral_set_id) REFERENCES orchestral_sets (id),
    FOREIGN KEY (instrument_id) REFERENCES instruments (id)
);

CREATE TABLE contributors
(
    id         INT PRIMARY KEY AUTO_INCREMENT,
    -- Unique identifier for each contributor
    first_name VARCHAR(50) NOT NULL,
    -- Contributor's first name
    last_name  VARCHAR(50) NOT NULL,
    -- Contributor's last name
    country_id INT         NOT NULL,
    -- Foreign key referencing the country of birth
    birth_date DATE        NOT NULL,
    -- Contributor's birth date
    FOREIGN KEY (country_id) REFERENCES countries (id) -- Foreign key constraint referencing the countries table
);

CREATE TABLE orchestral_set_contributors
(
    orchestral_set_id INT NOT NULL,
    -- Foreign key referencing the orchestral set
    role_id           INT NOT NULL,
    -- Foreign key referencing the role
    contributor_id    INT NOT NULL,
    -- Foreign key referencing the contributor
    PRIMARY KEY (orchestral_set_id, role_id, contributor_id),
    FOREIGN KEY (orchestral_set_id) REFERENCES orchestral_sets (id),
    FOREIGN KEY (role_id) REFERENCES role (id),
    FOREIGN KEY (contributor_id) REFERENCES contributors (id)
);

CREATE TABLE files
(
    id                INT PRIMARY KEY AUTO_INCREMENT,
    -- Unique identifier for each file/link
    orchestral_set_id INT  NOT NULL,
    -- Foreign key referencing the orchestral set associated with the file/link
    file_path         VARCHAR(255),
    -- Path to the file
    upload_date       DATE NOT NULL,
    -- Date when the file was uploaded
    real_name         VARCHAR(255),
    -- Real name of the file
    FOREIGN KEY (orchestral_set_id) REFERENCES orchestral_sets (id) -- Foreign key constraint referencing the orchestral_sets table
);