-- ----------------------------------------------------------------------------
-- MySQL Workbench
-- Source Schemata: UniversityDB
-- Created: Thu Aug 21 16:18:48 2014
-- ----------------------------------------------------------------------------

SET FOREIGN_KEY_CHECKS = 0;;

-- ----------------------------------------------------------------------------
-- Schema UniversityDB
-- ----------------------------------------------------------------------------
DROP SCHEMA IF EXISTS `UniversityDB` ;
CREATE SCHEMA IF NOT EXISTS `UniversityDB` ;

-- ----------------------------------------------------------------------------
-- Table UniversityDB.Titles
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Titles` (
  `TitleID` VARCHAR(64) UNIQUE NOT NULL,
  `TitleName` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`TitleID`));

-- ----------------------------------------------------------------------------
-- Table UniversityDB.ProfessorsTitles
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`ProfessorsTitles` (
  `ProfessorID` INT NOT NULL,
  `TitleID` VARCHAR(64) UNIQUE NOT NULL,
  PRIMARY KEY (`ProfessorID`, `TitleID`),
  CONSTRAINT `FK_ProfessorsTitles_Titles`
    FOREIGN KEY (`TitleID`)
    REFERENCES `UniversityDB`.`Titles` (`TitleID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_ProfessorsTitles_Professors`
    FOREIGN KEY (`ProfessorID`)
    REFERENCES `UniversityDB`.`Professors` (`ProfessorID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table UniversityDB.Professors
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Professors` (
  `ProfessorID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NULL,
  `DepartmentID` INT NULL,
  PRIMARY KEY (`ProfessorID`),
  CONSTRAINT `FK_Professors_Departments`
    FOREIGN KEY (`DepartmentID`)
    REFERENCES `UniversityDB`.`Departments` (`DepartmentID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table UniversityDB.Courses
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Courses` (
  `CourseID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  `DepertmentID` INT NULL,
  PRIMARY KEY (`CourseID`),
  CONSTRAINT `FK_Courses_Departments`
    FOREIGN KEY (`DepertmentID`)
    REFERENCES `UniversityDB`.`Departments` (`DepartmentID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table UniversityDB.ProfessorsCourses
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`ProfessorsCourses` (
  `ProfessorID` INT NOT NULL,
  `CourseID` INT NOT NULL,
  PRIMARY KEY (`ProfessorID`, `CourseID`),
  CONSTRAINT `FK_ProfessorsCourses_Courses`
    FOREIGN KEY (`CourseID`)
    REFERENCES `UniversityDB`.`Courses` (`CourseID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_ProfessorsCourses_Professors`
    FOREIGN KEY (`ProfessorID`)
    REFERENCES `UniversityDB`.`Professors` (`ProfessorID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table UniversityDB.Students
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Students` (
  `StudentID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  `FacNumber` CHAR(10) NULL,
  PRIMARY KEY (`StudentID`));

-- ----------------------------------------------------------------------------
-- Table UniversityDB.StudentsCourses
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`StudentsCourses` (
  `StudentID` INT NOT NULL,
  `CourseID` INT NOT NULL,
  PRIMARY KEY (`StudentID`, `CourseID`),
  CONSTRAINT `FK_StudentsCourses_Courses`
    FOREIGN KEY (`CourseID`)
    REFERENCES `UniversityDB`.`Courses` (`CourseID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_StudentsCourses_Students`
    FOREIGN KEY (`StudentID`)
    REFERENCES `UniversityDB`.`Students` (`StudentID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table UniversityDB.Faculties
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Faculties` (
  `CacultyID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`CacultyID`));

-- ----------------------------------------------------------------------------
-- Table UniversityDB.Departments
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Departments` (
  `DepartmentID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  `FacultyID` INT NOT NULL,
  PRIMARY KEY (`DepartmentID`),
  CONSTRAINT `FK_Departments_Faculties`
    FOREIGN KEY (`FacultyID`)
    REFERENCES `UniversityDB`.`Faculties` (`CacultyID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
SET FOREIGN_KEY_CHECKS = 1;;
