
CREATE TABLE
    IF NOT EXISTS Projet (
        Id INTEGER PRIMARY KEY AUTOINCREMENT ,
        Nom VARCHAR(255) NOT NULL,
        Nom_Client VARCHAR(255) NOT NULL,
        Created_at DATE NOT NULL
    );

/* Create Listes table if not exist can have 0*n Taches */
CREATE TABLE
    IF NOT EXISTS Liste (
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        Nom VARCHAR(255) NOT NULL,
        Created_at DATE NOT NULL,
        ProjetId INTEGER NOT NULL,
        FOREIGN KEY (ProjetId) REFERENCES Projet (Id) ON DELETE CASCADE
    );