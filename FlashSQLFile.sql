DROP TABLE Flashcards;
GO

CREATE TABLE Flashcards
(
    Id UNIQUEIDENTIFIER default newid(),
    Question VARCHAR(255) NOT NULL,
    Answer VARCHAR(255) NOT NULL,
    PRIMARY KEY(Id)
);
GO

INSERT INTO Flashcards(Question, Answer)
VALUES
('What is my name?', 'Mason');
GO

SELECT * FROM Flashcards