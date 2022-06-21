-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2022-06-21 08:25:53.019

-- tables
-- Table: Action
CREATE TABLE Action (
    IdAction int  NOT NULL,
    StartTime datetime  NOT NULL,
    EndTime datetime  NULL,
    NeedSpecialEquipment bit  NOT NULL,
    CONSTRAINT Action_pk PRIMARY KEY  (IdAction)
);

-- Table: FireTruck
CREATE TABLE FireTruck (
    IdFireTruck int  NOT NULL,
    OperationalNumber nvarchar(10)  NOT NULL,
    SpecialEquipment bit  NOT NULL,
    CONSTRAINT FireTruck_pk PRIMARY KEY  (IdFireTruck)
);

-- Table: FireTruck_Action
CREATE TABLE FireTruck_Action (
    IdFireTruckAction int  NOT NULL,
    IdFireTruck int  NOT NULL,
    IdAction int  NOT NULL,
    AssignmentDate datetime  NOT NULL,
    CONSTRAINT FireTruck_Action_pk PRIMARY KEY  (IdFireTruckAction)
);

-- Table: Firefighter
CREATE TABLE Firefighter (
    IdFirefighter int  NOT NULL,
    FirstName nvarchar(30)  NOT NULL,
    LastName nvarchar(50)  NOT NULL,
    CONSTRAINT Firefighter_pk PRIMARY KEY  (IdFirefighter)
);

-- Table: Firefighter_Action
CREATE TABLE Firefighter_Action (
    IdFirefighter int  NOT NULL,
    IdAction int  NOT NULL,
    CONSTRAINT Firefighter_Action_pk PRIMARY KEY  (IdFirefighter,IdAction)
);

-- foreign keys
-- Reference: FireTruck_Action_Action (table: FireTruck_Action)
ALTER TABLE FireTruck_Action ADD CONSTRAINT FireTruck_Action_Action
    FOREIGN KEY (IdAction)
    REFERENCES Action (IdAction);

-- Reference: FireTruck_Action_FireTruck (table: FireTruck_Action)
ALTER TABLE FireTruck_Action ADD CONSTRAINT FireTruck_Action_FireTruck
    FOREIGN KEY (IdFireTruck)
    REFERENCES FireTruck (IdFireTruck);

-- Reference: Firefighter_Action_Action (table: Firefighter_Action)
ALTER TABLE Firefighter_Action ADD CONSTRAINT Firefighter_Action_Action
    FOREIGN KEY (IdAction)
    REFERENCES Action (IdAction);

-- Reference: Firefighter_Action_Firefighter (table: Firefighter_Action)
ALTER TABLE Firefighter_Action ADD CONSTRAINT Firefighter_Action_Firefighter
    FOREIGN KEY (IdFirefighter)
    REFERENCES Firefighter (IdFirefighter);

insert into firefighter values (1, 'John', 'Doe');
insert into firefighter values (2, 'Jane', 'Doe');
insert into [action] values (1, 01/01/98, 02/01/99, 'True');
insert into firetruck values (1, '31231', 'True');
insert into firefighter_action values (1, 1);
insert into firefighter_action values (2, 1);
insert into firetruck_action values (1, 1, 1, 03/01/99);
-- End of file.

