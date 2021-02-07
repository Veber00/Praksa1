DROP TABLE cars_owned;
DROP TABLE person;

CREATE TABLE person (
	person_id INTEGER NOT NULL PRIMARY KEY,
	full_name VARCHAR(50) NOT NULL,
	age INTEGER NOT NULL
	);


CREATE TABLE cars_owned (
	cars_owned_id INTEGER NOT NULL PRIMARY KEY,
	person_id INTEGER NOT NULL FOREIGN KEY REFERENCES person(person_id),
	car_model VARCHAR (50) NOT NULL,
	car_year INTEGER NOT NULL,
	car_millage INTEGER NOT NULL
	);


INSERT INTO person (person_id, full_name, age) VALUES (1, 'Hrvoje Veber', 21);
INSERT INTO person (person_id, full_name, age) VALUES (2, 'Tom Davids', 26);
INSERT INTO person (person_id, full_name, age) VALUES (3, 'Zac Storm', 56);
INSERT INTO person (person_id, full_name, age) VALUES (4, 'Luke Space', 44);
INSERT INTO person (person_id, full_name, age) VALUES (5, 'Karen Joshua', 18);

INSERT INTO cars_owned (cars_owned_id, person_id, car_model, car_year, car_millage)
VALUES (1, 1, 'Jaguar', 2019, 13000);
INSERT INTO cars_owned (cars_owned_id, person_id, car_model, car_year, car_millage)
VALUES (2, 1, 'Audi', 2013, 239933);
INSERT INTO cars_owned (cars_owned_id, person_id, car_model, car_year, car_millage)
VALUES (3, 2, 'BMW', 2017, 54323);
INSERT INTO cars_owned (cars_owned_id, person_id, car_model, car_year, car_millage)
VALUES (4, 3, 'BMW', 2008, 234434);
INSERT INTO cars_owned (cars_owned_id, person_id, car_model, car_year, car_millage)
VALUES (5, 3, 'Volkswagen', 2019, 23332);
INSERT INTO cars_owned (cars_owned_id, person_id, car_model, car_year, car_millage)
VALUES (6, 4, 'Audi', 2013, 280345);

SELECT * FROM person;
SELECT * FROM cars_owned;

DELETE FROM cars_owned WHERE person_id = 2 AND car_model = 'BMW';

UPDATE cars_owned SET car_millage = 66666 WHERE person_id=2 and car_model='Jaguar' and cars_owned_id=2;